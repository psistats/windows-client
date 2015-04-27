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
            string msg = "Server URI: " + this.conf.ServerUrl + "\r";
            msg += "\r";
            msg += "Exchange Name: " + this.conf.ExchangeName + "\r";
            msg += "Exchange Type: " + this.conf.ExchangeType + "\r";
            msg += "Exchange Durable: " + this.conf.ExchangeDurable.ToString() + "\r";
            msg += "Exchange AutoDelete: " + this.conf.ExchangeAutodelete.ToString() + "\r";
            msg += "\r";
            msg += "Queue Prefix: " + this.conf.QueuePrefix + "\r";
            msg += "Queue Exclusive: " + this.conf.QueueExclusive.ToString() + "\r";
            msg += "Queue Durable: " + this.conf.QueueDurable.ToString() + "\r";
            msg += "Queue AutoDelete: " + this.conf.QueueAutodelete.ToString() + "\r";
            msg += "Queue TTL: " + this.conf.QueueTTL.ToString() + "\r";
            msg += "\r";
            msg += "App Main Timer: " + this.conf.PrimaryTimer.ToString() + "\r";
            msg += "App Secondary Timer: " + this.conf.SecondaryTimer.ToString() + "\r";

            this.EventLog.WriteEntry(msg);
                
        }

        protected override void OnStart(string[] args)
        {
            this.stat = new Stat();

            try
            {

                this.conf = Config.LoadConf();

                if (this.conf.DebugEnabled)
                {
                    this.DebugConfig(this.conf);

                    IHardware cpu = this.stat.GetCpuHardware();
                    this.Debug("CPU Detected:" + cpu.HardwareType + " - " + cpu.Name);

                    ISensor cpu_sensor = this.stat.GetCpuSensor();
                    this.Debug("CPU Temp Sensor Detected:" + cpu_sensor.SensorType + " - " + cpu_sensor.Name);
                }

                this.server = new Psistats.MessageQueue.Server(this.conf);
                this.server.Connect();
                this.server.Bind(this.stat.Hostname);

                this.primaryTimer = new System.Timers.Timer(this.conf.PrimaryTimer * 1000);
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
                if (!this.server.IsConnected())
                {
                    this.server.Connect();
                    this.server.Bind(this.stat.Hostname);
                }

                if (this.conf.DebugEnabled)
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

                System.Threading.Thread.Sleep(this.conf.RetryTimer * 1000);
            }
            catch (RabbitMQ.Client.Exceptions.AlreadyClosedException exc)
            {
                if (this.server.IsConnected())
                {
                    this.server.Close();
                }
                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.RetryTimer * 1000);
            }
            catch (Exception exc)
            {
                if (this.server.IsConnected())
                {
                    this.server.Close();
                }
                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.RetryTimer * 1000);
            }
        }

        private void PrimaryWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Psistats.MessageQueue.Message msg = new Psistats.MessageQueue.Message();
                msg.Hostname = this.stat.Hostname;
                msg.Mem = this.stat.Mem;
                msg.Cpu = this.stat.Cpu;

                if (this.conf.EnableCpuTemp)
                {
                    try
                    {
                        if (this.stat.CpuTemp != null)
                        {
                            msg.CpuTemp = (double) this.stat.CpuTemp;
                        }
                    }
                    catch (ManagementException)
                    {
                        this.Error("CPU Temperature not available through WMI");
                        this.conf.EnableCpuTemp = false;
                    }
                }

                this.Courier(msg);

                if (this.SecondaryCount == this.conf.SecondaryTimer)
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
            msg.Hostname = this.stat.Hostname;
            msg.Uptime = this.stat.Uptime;
            msg.Ipaddr = this.stat.Ipaddr;
            this.Courier(msg);
        }
    }
}
