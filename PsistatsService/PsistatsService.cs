using OpenHardwareMonitor.Hardware;
using System;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;

namespace Psistats.Service
{
    class PsistatsService : ServiceBase, IDisposable
    {
        private System.Timers.Timer primaryTimer;

        private Stat stat;
        private Psistats.MessageQueue.Server server;
        private Config conf;

        private int SecondaryCount = 0;

        private Computer computer;

        public PsistatsService()
        {
            this.ServiceName = "PsistatsService";

            this.EventLog.Source = this.ServiceName;
            this.EventLog.Log = "Application";

            this.CanHandlePowerEvent = false;
            this.CanHandleSessionChangeEvent = false;
            this.CanPauseAndContinue = false;
            this.CanShutdown = false;

            this.CanStop = true;
        }

        static void Main()
        {
            ServiceBase.Run(new PsistatsService());
        }

        protected string LogExcMessage(Exception exc)
        {
            string msg = exc.GetType().FullName + ": " + exc.Message;
            msg += "\r" + exc.StackTrace;
            if (exc.InnerException != null)
            {
                msg += "\r Caused by: ";
                msg += this.LogExcMessage(exc.InnerException);
            }

            return msg;
        }

        protected void LogException(Exception e) {
            this.Error(this.LogExcMessage(e));
        }

        protected void Error(string msg)
        {
            this.EventLog.WriteEntry(msg, EventLogEntryType.Error);
        }

        protected void Debug(String msg)
        {
            this.EventLog.WriteEntry(msg, EventLogEntryType.Information);
        }

        protected void DebugConfig(Config conf)
        {
            string msg = "Server URI: " + this.conf.server_url + "\r";
            msg += "\r";
            msg += "Exchange Name: " + this.conf.exchange_name + "\r";
            msg += "Exchange Type: " + this.conf.exchange_type + "\r";
            msg += "Exchange Durable: " + this.conf.exchange_durable.ToString() + "\r";
            msg += "Exchange AutoDelete: " + this.conf.exchange_autodelete.ToString() + "\r";
            msg += "\r";
            msg += "Queue Prefix: " + this.conf.queue_prefix + "\r";
            msg += "Queue Exclusive: " + this.conf.queue_exclusive.ToString() + "\r";
            msg += "Queue Durable: " + this.conf.queue_durable.ToString() + "\r";
            msg += "Queue AutoDelete: " + this.conf.queue_autodelete.ToString() + "\r";
            msg += "Queue TTL: " + this.conf.queue_ttl.ToString() + "\r";
            msg += "\r";
            msg += "App Main Timer: " + this.conf.primary_timer.ToString() + "\r";
            msg += "App Secondary Timer: " + this.conf.secondary_timer.ToString() + "\r";

            this.EventLog.WriteEntry(msg);
                
        }

        protected override void OnStart(string[] args)
        {
            this.stat = new Stat();

            try
            {

                this.conf = Config.LoadConf();

                if (this.conf.debug_enabled)
                {
                    this.DebugConfig(conf);

                    IHardware cpu = this.stat.GetCpuHardware();
                    this.Debug("CPU Detected:" + cpu.HardwareType + " - " + cpu.Name);

                    ISensor cpu_sensor = stat.GetCpuSensor();
                    this.Debug("CPU Temp Sensor Detected:" + cpu_sensor.SensorType + " - " + cpu_sensor.Name);
                }

                this.server = new Psistats.MessageQueue.Server(this.conf);
                this.server.Connect();
                this.server.Bind(this.stat.hostname);

                this.primaryTimer = new System.Timers.Timer(this.conf.primary_timer * 1000);
                this.primaryTimer.AutoReset = true;
                this.primaryTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.PrimaryWorker);
                this.primaryTimer.Start();



            }
            catch (Exception exc)
            {
                this.LogException(exc);
                Environment.Exit(1);
            }
        }

        protected override void OnStop()
        {
            this.EventLog.WriteEntry("Stopping service");

            this.primaryTimer.Stop();
            this.primaryTimer = null;

            this.server.Close();
        }

        private void Courier(Psistats.MessageQueue.Message msg)
        {
            try
            {
                if (!server.IsConnected())
                {
                    this.server.Connect();
                    this.server.Bind(this.stat.hostname);
                }

                if (this.conf.debug_enabled)
                {
                    this.Debug(Psistats.MessageQueue.Message.ToJson(msg));
                }

                this.server.Send(msg);
            }
            catch (RabbitMQ.Client.Exceptions.ConnectFailureException exc)
            {
                if (this.server.IsConnected())
                {
                    this.server.Close();
                }

                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (RabbitMQ.Client.Exceptions.AlreadyClosedException exc)
            {
                if (this.server.IsConnected())
                {
                    this.server.Close();
                }
                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (Exception exc)
            {
                if (this.server.IsConnected())
                {
                    this.server.Close();
                }
                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
        }

        private void PrimaryWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Psistats.MessageQueue.Message msg = new Psistats.MessageQueue.Message();
                msg.Hostname = this.stat.hostname;
                msg.Mem = this.stat.mem;
                msg.Cpu = this.stat.cpu;

                if (this.conf.enabled_cputemp)
                {
                    try
                    {
                        if (this.stat.cpu_temp != null)
                        {
                            msg.Cpu_temp = (double) this.stat.cpu_temp;
                        }
                    }
                    catch (ManagementException)
                    {
                        this.Error("CPU Temperature not available through WMI");
                        this.conf.enabled_cputemp = false;
                    }
                }

                this.Courier(msg);

                if (this.SecondaryCount == this.conf.secondary_timer)
                {
                    this.SecondaryWorker(sender, e);
                    this.SecondaryCount = 1;
                }
                else
                {
                    this.SecondaryCount++;
                }
            }
            catch (Exception exc)
            {
                this.LogException(exc);
            }
        }

        private void SecondaryWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            Psistats.MessageQueue.Message msg = new Psistats.MessageQueue.Message();
            msg.Hostname = stat.hostname;
            msg.Uptime = stat.uptime;
            msg.Ipaddr = stat.ipaddr;
            this.Courier(msg);
        }
    }
}
