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

                this.server.Connect();
                this.server.Bind(this.stat.hostname);

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
                    server.Connect();
                }

                string json = "{ \"hostname\": \"" + stat.hostname + "\", \"cpu\": " + stat.cpu.ToString() + ", \"mem\": " + stat.mem.ToString() + " }";

                server.SendJson(json);
                logger.Debug(json);
            }
            catch (Exception exc)
            {
                logger.Debug(exc.Message);
                logger.Debug(exc.StackTrace);
                System.Threading.Thread.Sleep(10000);
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
