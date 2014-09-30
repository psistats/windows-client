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
            Psistats.App.Workers.Service service = new Psistats.App.Workers.Service(this);
            service.Start();
        }

        private void button_settings_Click(object sender, EventArgs e)
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
            this.SetLabelContent(this.label_notifications, p);
        }

        private void SetTextFieldContent(Label label, string p)
        {
            throw new NotImplementedException();
        }
    }
}
