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
    public partial class SettingsScreen : Form
    {
        private MainScreen2 mainScreen;
        public SettingsScreen(MainScreen2 mainScreen)
        {
            this.mainScreen = mainScreen;
            InitializeComponent();
        }

        private void Psistats_Load(object sender, EventArgs e) { }

        private void button_save_settings_Click(object sender, EventArgs e)
        {
            Psistats.App.Workers.ConfigSaver worker = new Psistats.App.Workers.ConfigSaver(this.mainScreen);
            worker.Start(this);
        }
    }
}
