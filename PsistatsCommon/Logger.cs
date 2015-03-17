using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Psistats
{
    public class Logger
    {
        private string name;

        private EventLog elog;

        public Logger(string name)
        {
            this.name = name;
        }

        public void Init()
        {
            elog = new EventLog();

            if (!EventLog.SourceExists(name))
            {
                EventLog.CreateEventSource(name, "Application");
            }

            elog.Source = name;
            this.elog.EnableRaisingEvents = true;
        }

        public void Debug(Config conf)
        {
            string msg = "Exchange Name: " + conf.exchange_name + "\r";
            msg += "Exchange Autodelete: " + conf.exchange_autodelete.ToString() + "\r";
            msg += "Exchange Durable: " + conf.exchange_durable.ToString() + "\r";
            msg += "Exchange Type: " + conf.exchange_type + "\r";

            msg += "Queue Prefix: " + conf.queue_prefix + "\r";
            msg += "Queue Autodelete: " + conf.queue_autodelete + "\r";
            msg += "Queue Exclusive: " + conf.queue_exclusive + "\r";
            msg += "Queue Durable: " + conf.queue_durable + "\r";
            msg += "Queue TTL: " + conf.queue_ttl.ToString() + "\r";

            msg += "App Timer: " + conf.primary_timer.ToString() + "\r";
            msg += "Meta Timer: " + conf.secondary_timer.ToString() + "\r";
            msg += "Retry Timer: " + conf.retry_timer.ToString() + "\r";

            Debug(msg);
        }

        public void Debug(string msg)
        {
            if (this.elog == null)
            {
                this.Init();
            }
            this.elog.WriteEntry(msg);
        }
    }
}
