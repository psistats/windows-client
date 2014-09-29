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
    public partial class MainScreen2 : Form
    {
        delegate void SetNotificationTextCallback(string text);
        delegate void SetWindowHeightCallback(int height);

        private SettingsScreen settingsScreen;

        public MainScreen2()
        {
            InitializeComponent();
        }

        public void SetNotificationText(string text)
        {
            if (this.label_notifications.InvokeRequired)
            {
                SetNotificationTextCallback d = new SetNotificationTextCallback(SetNotificationText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label_notifications.Text = text;
            }
        }

        public void SetWindowHeight(int height)
        {
            if (this.InvokeRequired)
            {
                SetWindowHeightCallback d = new SetWindowHeightCallback(SetWindowHeight);
                this.Invoke(d, new object[] { height });
            }
            else
            {
                this.Height = height;
            }
        }

        public void ResizeExpand(object sender, EventArgs e)
        {
            Psistats.App.Workers.Service service = new Psistats.App.Workers.Service(this);
            service.Start();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            settingsScreen = new SettingsScreen(this);
            settingsScreen.Show();
        }
    }
}
