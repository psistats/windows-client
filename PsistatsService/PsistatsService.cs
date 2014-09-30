using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Psistats.Service
{
    class PsistatsService : ServiceBase, IDisposable
    {
        private System.Timers.Timer serviceTimer;

        private Logger logger;
        private Stat stat;
        private Psistats.MessageQueue.Server server;
        private Config conf;

        private int metadata_counter = 0;

        public PsistatsService()
        {
            this.ServiceName = "Psistats Service";

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

        protected override void OnStart(string[] args)
        {
            this.EventLog.WriteEntry("Starting Psistats Service");

            this.stat = new Stat();

            try
            {
                //this.conf = Config.LoadConf();

                //this.logger.Debug(this.conf);

                //this.server = new Psistats.MessageQueue.Server(conf);

                //double app_timer = this.conf.app_timer * 1000;

                this.serviceTimer = new System.Timers.Timer(1000);
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
            this.server.Close();
            this.serviceTimer.Stop();
            this.serviceTimer = null;
        }

        private void DoWork(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.debug("Doing work");
            /*
            try
            {
                if (!server.IsConnected())
                {
                    this.server.Connect();
                    this.server.Bind(this.stat.hostname);
                }

                string json;

                var json_data = new Dictionary<string, object>();

                if (this.metadata_counter == this.conf.metadata_timer)
                {
                    var ipaddr = new List<string>();
                    ipaddr.Add(stat.ipaddr);

                    json_data.Add("hostname", stat.hostname);
                    json_data.Add("ipaddr", ipaddr.ToArray());
                    json_data.Add("cpu", stat.cpu);
                    json_data.Add("mem", stat.mem);
                    json_data.Add("uptime", stat.uptime);

                    if (conf.app_cputemp)
                    {
                        json_data.Add("cpu_temp", stat.cpu_temp);
                    }

                    this.metadata_counter = 0;
                }
                else
                {
                    json_data.Add("hostname", stat.hostname);
                    json_data.Add("cpu", stat.cpu);
                    json_data.Add("mem", stat.mem);
                    this.metadata_counter += 1;
                }

                var json_values = new List<string>();

                foreach (string key in json_data.Keys)
                {

                    if (json_data[key].GetType().Name == "String")
                    {
                        json_values.Add("\"" + key + "\": \"" + json_data[key] + "\"");
                    }
                    else if (json_data[key].GetType().Name == "String[]")
                    {
                        String[] values = (String[])json_data[key];
                        json_values.Add("\"" + key + "\": [\"" + string.Join(",", values) + "\"]");
                    }
                    else if (json_data[key].GetType().Name == "Integer")
                    {
                        json_values.Add("\"" + key + "\": " + json_data[key].ToString());
                    }
                    else if (json_data[key].GetType().Name == "Double")
                    {
                        json_values.Add("\"" + key + "\": " + json_data[key].ToString());
                    }
                }

                json = "{" + string.Join(",", json_values.ToArray()) + "}";

                server.SendJson(json);
            }
            catch (RabbitMQ.Client.Exceptions.ConnectFailureException exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }

                logger.Debug(exc.ToString());
                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (RabbitMQ.Client.Exceptions.AlreadyClosedException exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }
                logger.Debug(exc.ToString());
                System.Threading.Thread.Sleep(this.conf.retry_timer * 1000);
            }
            catch (Exception exc)
            {
                if (server.IsConnected())
                {
                    server.Close();
                }
                logger.Debug("== UNHANDLED EXCEPTION!!!! ==\r\r" + exc.ToString());
                System.Threading.Thread.Sleep(30000);
            }
             * */
        }


    }
}
