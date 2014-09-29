using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Psistats.App.Workers
{
    class LoadSettingsScreen : BasicFormWorker
    {
        public LoadSettingsScreen(MainScreen2 form) : base(form) { }

        public override void DoWork(object sender, DoWorkEventArgs e) {
            this.form.SetNotificationText("Loading configuration");

            Config conf = Config.LoadConf();

            SettingsScreen settingsScreen = new SettingsScreen(this.form);

            settingsScreen.appMainTimer.Text = conf.app_timer.ToString();
            settingsScreen.appSecondaryTimer.Text = conf.metadata_timer.ToString();

            settingsScreen.exchangeName.Text = conf.exchange_name;
            settingsScreen.exchangeSettings.SetItemChecked(0, conf.exchange_durable);
            settingsScreen.exchangeSettings.SetItemChecked(1, conf.exchange_autodelete);

        }

        public override void Completed(object sender, RunWorkerCompletedEventArgs e) { }
    }
}
