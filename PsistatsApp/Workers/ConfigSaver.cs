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
        private Config conf;

        public ConfigSaver(MainScreen2 form, Config conf) : base(form) {
            this.conf = conf;
        }

        public void Start(SettingsScreen settingsScreen)
        {
            this.settingsScreen = settingsScreen;
            base.Start();
        }

        public override void DoWork(object sender, DoWorkEventArgs e) {
            this.form.SetNotificationText("Saving configuration to disk");
            Config.WriteConf(conf);
            this.form.SetNotificationText("Config Saved");
            this.settingsScreen.ThreadClose(this.settingsScreen);
        }
    }
}
