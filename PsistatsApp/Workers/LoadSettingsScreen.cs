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

                view.SetTextFieldContent(view.serverPortNumber, conf.server_port.ToString());
                view.SetTextFieldContent(view.serverHostname, conf.server_hostname);
                view.SetTextFieldContent(view.serverUsername, conf.server_username);
                view.SetTextFieldContent(view.serverPassword, conf.server_password);
                view.SetTextFieldContent(view.serverPath, conf.server_vhost);

                view.SetTextFieldContent(view.exchangeName, conf.exchange_name);
                view.SetComboBox(view.exchangeType, conf.exchange_type);

                bool[] exchangeSettings = new bool[2];
                exchangeSettings[0] = conf.exchange_durable;
                exchangeSettings[1] = conf.exchange_autodelete;
                view.SetCheckedListBox(view.exchangeSettings, exchangeSettings);

                view.SetTextFieldContent(view.queueName, conf.queue_prefix);
                view.SetTextFieldContent(view.queueMessageTTL, conf.queue_ttl.ToString());

                bool[] queueSettings = new bool[3];
                queueSettings[0] = conf.queue_exclusive;
                queueSettings[1] = conf.queue_durable;
                queueSettings[2] = conf.queue_autodelete;
                view.SetCheckedListBox(view.queueSettings, queueSettings);

                view.SetTextFieldContent(view.appMainTimer, conf.app_timer.ToString());
                view.SetTextFieldContent(view.appSecondaryTimer, conf.metadata_timer.ToString());
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
