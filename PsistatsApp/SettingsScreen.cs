using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App
{
    public partial class SettingsScreen : Psistats.App.Utils.BaseForm
    {
        private MainScreen2 mainScreen;
        delegate void ThreadShowCallback(Control control);
        private Config conf;

        public Config Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public SettingsScreen(MainScreen2 mainScreen)
        {

            this.mainScreen = mainScreen;
            InitializeComponent();
        }

        public void ThreadShow(Control control)
        {

            if (mainScreen.InvokeRequired)
            {
                ThreadShowCallback d = new ThreadShowCallback(ThreadShow);
                mainScreen.Invoke(d, new object[] { control });
            }
            else
            {
                Debug.WriteLine("threadShow()");
                control.Show();
            }
        }

        private void Psistats_Load(object sender, EventArgs e) { }

        private void button_save_settings_Click(object sender, EventArgs e)
        {
            conf.app_cputemp = true;

            conf.app_timer = int.Parse(appMainTimer.Text);
            conf.metadata_timer = int.Parse(appMainTimer.Text);

            conf.exchange_name = exchangeName.Text;

            if (exchangeType.SelectedItem != null)
            {
                conf.exchange_type = exchangeType.SelectedItem.ToString();
            }
            conf.exchange_durable = exchangeSettings.GetItemChecked(0);
            conf.exchange_autodelete = exchangeSettings.GetItemChecked(1);

            conf.queue_ttl = int.Parse(queueMessageTTL.Text);
            conf.queue_prefix = queueName.Text;
            conf.queue_exclusive = queueSettings.GetItemChecked(0);
            conf.queue_durable = queueSettings.GetItemChecked(1);
            conf.queue_autodelete = queueSettings.GetItemChecked(2);

            conf.server_hostname = serverHostname.Text;
            conf.server_port = int.Parse(serverPortNumber.Text);
            conf.server_vhost = serverPath.Text;
            conf.server_username = serverUsername.Text;
            conf.server_password = serverPassword.Text;

            conf.retry_timer = 5;


            Psistats.App.Workers.ConfigSaver worker = new Psistats.App.Workers.ConfigSaver(this.mainScreen, conf);
            worker.Start(this);
        }
    }
}
