using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.Threading;
using RabbitMQ.Client;
using System.Net.Sockets;
using Psistats;
using System.IO;
using System.Runtime.InteropServices;

namespace Psistats.Service
{
    partial class PsistatsService : ServiceBase, IDisposable
    {
        private System.Timers.Timer serviceTimer;

        private Logger logger;
        private Stat stat;
        private PsistatsServer server;
        private Config conf;

        private int metadata_counter = 0;

        protected override void OnStart(string[] args)
        {
            this.logger = new Logger("PsistatsService");
            this.stat = new Stat();

            try
            {
                this.conf = Config.LoadConf();

                this.logger.Debug(this.conf);

                this.server = new PsistatsServer(conf);

                double app_timer = this.conf.app_timer * 1000;

                this.serviceTimer = new System.Timers.Timer(app_timer);
                this.serviceTimer.AutoReset = true;
                this.serviceTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.DoWork);
                this.serviceTimer.Start();
            }
            catch (Exception exc)
            {
                string error_msg = "Exception!\n" +
                    exc.Message + "\n" +
                    exc.StackTrace + "\n";

                if (exc.InnerException != null)
                {
                    error_msg = error_msg + exc.InnerException.Message + "\n" + exc.InnerException.StackTrace;
                }

                this.logger.Debug(error_msg);

                Environment.Exit(1);
            }
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
        }

        protected override void OnStop()
        {
            this.server.Close();
            this.serviceTimer.Stop();
            this.serviceTimer = null;
        }
    }
}
