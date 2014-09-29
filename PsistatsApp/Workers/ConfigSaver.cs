using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Psistats.App.Workers
{
    class ConfigSaver : BasicFormWorker
    {
        private SettingsScreen settingsScreen;
        public ConfigSaver(MainScreen2 form) : base(form) {}

        public void Start(SettingsScreen settingsScreen)
        {
            this.settingsScreen = settingsScreen;
            base.Start();
        }

        public override void DoWork(object sender, DoWorkEventArgs e) {
            this.form.SetNotificationText("Preparing configuration object");

            Config conf = Config.LoadConf();

            conf.app_cputemp = true;

            conf.app_timer = int.Parse(settingsScreen.appMainTimer.Text);
            conf.metadata_timer = int.Parse(settingsScreen.appMainTimer.Text);


            conf.exchange_name = settingsScreen.exchangeName.Text;
            conf.exchange_type = settingsScreen.exchangeType.SelectedItem.ToString();
            conf.exchange_durable = settingsScreen.exchangeSettings.GetItemChecked(0);
            conf.exchange_autodelete = settingsScreen.exchangeSettings.GetItemChecked(1);

            conf.queue_ttl = int.Parse(settingsScreen.queueMessageTTL.Text);
            conf.queue_prefix = settingsScreen.queueName.Text;
            conf.queue_exclusive = settingsScreen.queueSettings.GetItemChecked(0);
            conf.queue_durable = settingsScreen.queueSettings.GetItemChecked(1);
            conf.queue_autodelete = settingsScreen.queueSettings.GetItemChecked(2);

            conf.server_hostname = settingsScreen.serverHostname.Text;
            conf.server_port = int.Parse(settingsScreen.serverPortNumber.Text);
            conf.server_vhost = settingsScreen.serverPath.Text;
            conf.server_username = settingsScreen.serverUsername.Text;
            conf.server_password = settingsScreen.serverPassword.Text;

            conf.retry_timer = 5;

            this.form.SetNotificationText("Saving configuration to disk");
            Config.WriteConf(conf);
            this.form.SetNotificationText("Config Saved");
        }

        public override void Completed(object sender, RunWorkerCompletedEventArgs e) { }

    }
}
