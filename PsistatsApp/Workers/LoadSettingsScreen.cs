using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Psistats.App.Workers
{
    class LoadSettingsScreen : BasicFormWorker
    {
        SettingsScreen view;

        public LoadSettingsScreen(MainScreen2 form, SettingsScreen screen) : base(form) {
            view = screen;
        }

        public override void DoWork(object sender, DoWorkEventArgs e) {
            
            this.form.SetNotificationText("Loading configuration");

            try
            {
                Config conf = Config.LoadConf();
                view.Conf = conf;


                Debug.WriteLine("Setting up view");

                view.SetTextContent(view.serverPortNumber, conf.server_port.ToString());
                view.SetTextContent(view.serverHostname, conf.server_hostname);
                view.SetTextContent(view.serverUsername, conf.server_username);
                view.SetTextContent(view.serverPassword, conf.server_password);
                view.SetTextContent(view.serverPath, conf.server_vhost);

                view.SetTextContent(view.exchangeName, conf.exchange_name);
                view.SetComboBox(view.exchangeType, conf.exchange_type);

                bool[] exchangeSettings = new bool[2];
                exchangeSettings[0] = conf.exchange_durable;
                exchangeSettings[1] = conf.exchange_autodelete;
                view.SetCheckedListBox(view.exchangeSettings, exchangeSettings);

                view.SetTextContent(view.queueName, conf.queue_prefix);
                view.SetTextContent(view.queueMessageTTL, conf.queue_ttl.ToString());

                bool[] queueSettings = new bool[3];
                queueSettings[0] = conf.queue_exclusive;
                queueSettings[1] = conf.queue_durable;
                queueSettings[2] = conf.queue_autodelete;
                view.SetCheckedListBox(view.queueSettings, queueSettings);

                view.SetTextContent(view.appMainTimer, conf.app_timer.ToString());
                view.SetTextContent(view.appSecondaryTimer, conf.metadata_timer.ToString());
                view.ThreadShow(view);

                Debug.WriteLine("Showing view");
                this.form.SetNotificationText("Confing loaded");
            }
            catch (UnauthorizedAccessException exc)
            {
                this.form.SetNotificationText("Could not load config file - PERIMISSION DENIED");
            }
        }

        public override void Completed(object sender, RunWorkerCompletedEventArgs e) { }
    }
}
