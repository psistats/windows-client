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
    public partial class MainScreen2 : Psistats.App.Utils.BaseForm
    {

        delegate void AddLogCallback(string logItem);

        private Config conf;
        private EventLog evtLog;

        public MainScreen2()
        {
            InitializeComponent();


            this.evtLog = new EventLog("Application");
            this.evtLog.EntryWritten += new EntryWrittenEventHandler(OnEventLog);
            this.evtLog.EnableRaisingEvents = true;

            this.AddLog("Loading configuration...");
            this.conf = Config.LoadConf();

            // TODO Normalize all these form field names!
            this.text_serverUrl.Text = conf.ServerUrl;

            this.check_cpu.Checked = conf.EnableCpu;
            this.check_cputemp.Checked = conf.EnableCpuTemp;
            this.check_mem.Checked = conf.EnableMem;
            this.check_uptime.Checked = conf.EnableUptime;
            this.check_hostname.Checked = conf.EnableHostname;

            this.exchangeName.Text = conf.ExchangeName;
            this.exchangeType.SelectedItem = conf.ExchangeType;
            this.exchangeSettings.SetItemChecked(0, conf.ExchangeDurable);
            this.exchangeSettings.SetItemChecked(1, conf.ExchangeAutodelete);

            this.queueName.Text = conf.QueuePrefix;
            this.queueMessageTTL.Text = conf.QueueTTL.ToString();
            this.queueSettings.SetItemChecked(0, conf.QueueExclusive);
            this.queueSettings.SetItemChecked(1, conf.QueueDurable);
            this.queueSettings.SetItemChecked(2, conf.QueueAutodelete);

            this.appPrimaryTimer.Text = conf.PrimaryTimer.ToString();
            this.appSecondaryTimer.Text = conf.SecondaryTimer.ToString();
            this.debug_enabled.Checked = conf.DebugEnabled;

        }

        public void AddLog(string logItem)
        {
            if (this.logBox.InvokeRequired)
            {
                AddLogCallback d = new AddLogCallback(AddLog);
                this.logBox.Invoke(d, new object[] { logItem });
            }
            else
            {
                this.logBox.Text += logItem + Environment.NewLine;
                this.logBox.SelectionStart = logBox.TextLength;
                this.logBox.ScrollToCaret();
            }
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

        private void button_startService_clicked(object sender, EventArgs e)
        {
            // TODO Config saving should be a background task
            this.AddLog("Saving configuration...");
            this.conf.ServerUrl = this.text_serverUrl.Text;

            this.conf.EnableCpu = this.check_cpu.Checked;
            this.conf.EnableMem = this.check_mem.Checked;
            this.conf.EnableCpuTemp = this.check_cputemp.Checked;
            this.conf.EnableUptime = this.check_uptime.Checked;
            this.conf.EnableHostname = this.check_hostname.Checked;

            this.conf.PrimaryTimer = int.Parse(appPrimaryTimer.Text);
            this.conf.SecondaryTimer = int.Parse(appSecondaryTimer.Text);

            this.conf.ExchangeName = exchangeName.Text;

            if (this.exchangeType.SelectedItem != null)
            {
                this.conf.ExchangeType = exchangeType.SelectedItem.ToString();
            }
            this.conf.ExchangeDurable = exchangeSettings.GetItemChecked(0);
            this.conf.ExchangeAutodelete = exchangeSettings.GetItemChecked(1);

            this.conf.QueueTTL = int.Parse(queueMessageTTL.Text);
            this.conf.QueuePrefix = queueName.Text;
            this.conf.QueueExclusive = queueSettings.GetItemChecked(0);
            this.conf.QueueDurable = queueSettings.GetItemChecked(1);
            this.conf.QueueAutodelete = queueSettings.GetItemChecked(2);

            this.conf.RetryTimer = 5;
            this.conf.DebugEnabled = debug_enabled.Checked;

            Config.WriteConf(conf);
            // FIXME ServiceStarter is now the only worker.
            var worker = new Psistats.App.Workers.ServiceStarter(this);
            worker.Start();
        }

        private void OnEventLog(object source, EntryWrittenEventArgs e)
        {
            if (e.Entry.Source == "PsistatsService")
            {
                this.AddLog(e.Entry.Message);
            }
        }
    }
}
