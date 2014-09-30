using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Psistats.Service
{
    class PsistatsService : ServiceBase, IDisposable
    {
        private System.Timers.Timer serviceTimer;

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

        protected string logExcMessage(Exception e)
        {
            string msg = e.Message;
            msg += "\r" + e.StackTrace;
            if (e.InnerException != null)
            {
                msg += "\r Caused by: ";
                msg += this.logExcMessage(e.InnerException);
            }

            return msg;
        }

        protected void logException(Exception e) {

            this.EventLog.WriteEntry(this.logExcMessage(e), EventLogEntryType.Error);
        }

        protected void debug(String msg)
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

                this.serviceTimer = new System.Timers.Timer(conf.primary_timer * 1000);
                this.serviceTimer.AutoReset = true;
                this.serviceTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.DoWork);
                this.serviceTimer.Start();
            }
            catch (Exception exc)
            {
                this.logException(exc);
                Environment.Exit(1);
            }
        }

        protected override void OnStop()
        {
            this.EventLog.WriteEntry("Stopping service");

            this.serviceTimer.Stop();
            this.serviceTimer = null;

            

            this.server.Close();
        }

        private void DoWork(object sender, System.Timers.ElapsedEventArgs e)
        {

            try
            {
                if (!server.IsConnected())
                {
                    this.server.Connect();
                    this.server.Bind(this.stat.hostname);
                }

                Psistats.MessageQueue.Message msg = Psistats.MessageQueue.Message.FromStatObject(this.stat);

                this.EventLog.WriteEntry(Psistats.MessageQueue.Message.ToJson(msg));

                this.server.Send(msg);
            }
            catch (RabbitMQ.Client.Exceptions.ConnectFailureException exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }

                debug(exc.ToString());
                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (RabbitMQ.Client.Exceptions.AlreadyClosedException exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }
                debug(exc.ToString());
                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (Exception exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }
                debug("== UNHANDLED EXCEPTION!!!! ==\r\r" + exc.ToString());
                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
        }
    }
}
