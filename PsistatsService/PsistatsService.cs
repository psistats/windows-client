using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Psistats.Service
{
    class PsistatsService : ServiceBase, IDisposable
    {
        private System.Timers.Timer primaryTimer;
        private System.Timers.Timer secondaryTimer;

        private Stat stat;
        private Psistats.MessageQueue.Server server;
        private Config conf;

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

        protected string LogExcMessage(Exception e)
        {
            string msg = e.Message;
            msg += "\r" + e.StackTrace;
            if (e.InnerException != null)
            {
                msg += "\r Caused by: ";
                msg += this.LogExcMessage(e.InnerException);
            }

            return msg;
        }

        protected void LogException(Exception e) {

            this.EventLog.WriteEntry(this.LogExcMessage(e), EventLogEntryType.Error);
        }

        protected void Debug(String msg)
        {
            this.EventLog.WriteEntry(msg, EventLogEntryType.Information);
        }

        protected void DebugConfig(Config conf)
        {
            string msg = "Server Hostname: " + conf.server_hostname + "\r";
            msg += "Server Post: " + conf.server_port.ToString() + "\r";
            msg += "Server Username: " + conf.server_username + "\r";
            msg += "Server Password: " + conf.server_password + "\r";
            msg += "Server Virtualhost: " + conf.server_vhost + "\r";
            msg += "\r";
            msg += "Exchange Name: " + conf.exchange_name + "\r";
            msg += "Exchange Type: " + conf.exchange_type + "\r";
            msg += "Exchange Durable: " + conf.exchange_durable.ToString() + "\r";
            msg += "Exchange AutoDelete: " + conf.exchange_autodelete.ToString() + "\r";
            msg += "\r";
            msg += "Queue Prefix: " + conf.queue_prefix + "\r";
            msg += "Queue Exclusive: " + conf.queue_exclusive.ToString() + "\r";
            msg += "Queue Durable: " + conf.queue_durable.ToString() + "\r";
            msg += "Queue AutoDelete: " + conf.queue_autodelete.ToString() + "\r";
            msg += "Queue TTL: " + conf.queue_ttl.ToString() + "\r";
            msg += "\r";
            msg += "App Main Timer: " + conf.primary_timer.ToString() + "\r";
            msg += "App Secondary Timer: " + conf.secondary_timer.ToString() + "\r";

            this.EventLog.WriteEntry(msg);
                
        }

        protected override void OnStart(string[] args)
        {
            this.stat = new Stat();

            this.EventLog.WriteEntry(stat.hostname);

            try
            {
                this.EventLog.WriteEntry("hostname:" + this.stat.hostname);
                this.EventLog.WriteEntry("Confing location: " + Config.GetConfigFilePath());
                conf = Config.LoadConf();

                this.DebugConfig(conf);

                this.server = new Psistats.MessageQueue.Server(conf);
                this.server.Connect();
                this.server.Bind(this.stat.hostname);

                this.primaryTimer = new System.Timers.Timer(conf.primary_timer * 1000);
                this.primaryTimer.AutoReset = true;
                this.primaryTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.PrimaryWorker);
                this.primaryTimer.Start();

                this.secondaryTimer = new System.Timers.Timer(conf.secondary_timer * 1000);
                this.secondaryTimer.AutoReset = true;
                this.secondaryTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.SecondaryWorker);
                this.secondaryTimer.Start();
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
            this.secondaryTimer.Stop();

            this.primaryTimer = null;
            this.secondaryTimer = null;

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

                this.server.Send(msg);
            }
            catch (RabbitMQ.Client.Exceptions.ConnectFailureException exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }

                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (RabbitMQ.Client.Exceptions.AlreadyClosedException exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }
                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (Exception exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }
                this.LogException(exc);

                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
        }

        private void PrimaryWorker(object sender, System.Timers.ElapsedEventArgs e)
        {

            Psistats.MessageQueue.Message msg = new Psistats.MessageQueue.Message();
            msg.Hostname = stat.hostname;
            msg.Mem = stat.mem;
            msg.Cpu = stat.cpu;
            msg.Cpu_temp = stat.cpu_temp;
            this.Courier(msg);
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
