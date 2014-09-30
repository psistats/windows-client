using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App
{
    public partial class MainScreen2 : Psistats.App.Utils.BaseForm
    {


        private SettingsScreen view;
        

        public MainScreen2()
        {
            InitializeComponent();
        }

        public void ResizeExpand(object sender, EventArgs e)
        {
            Psistats.App.Workers.ServiceStarter service = new Psistats.App.Workers.ServiceStarter(this);
            service.Start();
        }

        private void Button_settings_Click(object sender, EventArgs e)
        {
            if (view == null || view.IsDisposed == true)
            {
                view = new SettingsScreen(this);
            }
            var worker = new Psistats.App.Workers.LoadSettingsScreen(this, view);
            worker.Start();
        }

        public void SetNotificationText(string p)
        {
            this.SetTextContent(this.label_notifications, p);
        }

        public void SetServiceButton(bool started)
        {
            this.ThreadEnable(this.button_service, true);

            var button_text = "Start Service";

            if (started == true)
            {
                button_text = "Stop Service";
            }
            this.SetTextContent(this.button_service, button_text);
        }

        private void MainScreen2_Load(object sender, EventArgs e)
        {
            var worker = new Psistats.App.Workers.ServiceChecker(this);
            worker.Start();
        }
    }
}
