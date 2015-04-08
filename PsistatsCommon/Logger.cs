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
            string msg = "Exchange Name: " + conf.ExchangeName + "\r";
            msg += "Exchange Autodelete: " + conf.ExchangeAutodelete.ToString() + "\r";
            msg += "Exchange Durable: " + conf.ExchangeDurable.ToString() + "\r";
            msg += "Exchange Type: " + conf.ExchangeType + "\r";

            msg += "Queue Prefix: " + conf.QueuePrefix + "\r";
            msg += "Queue Autodelete: " + conf.QueueAutodelete + "\r";
            msg += "Queue Exclusive: " + conf.QueueExclusive + "\r";
            msg += "Queue Durable: " + conf.QueueDurable + "\r";
            msg += "Queue TTL: " + conf.QueueTTL.ToString() + "\r";

            msg += "App Timer: " + conf.PrimaryTimer.ToString() + "\r";
            msg += "Meta Timer: " + conf.SecondaryTimer.ToString() + "\r";
            msg += "Retry Timer: " + conf.RetryTimer.ToString() + "\r";

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
