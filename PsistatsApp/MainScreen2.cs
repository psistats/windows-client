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
            this.text_serverUrl.Text = conf.server_url;

            this.check_cpu.Checked = conf.enabled_cpu;
            this.check_cputemp.Checked = conf.enabled_cputemp;
            this.check_mem.Checked = conf.enabled_mem;
            this.check_uptime.Checked = conf.enabled_uptime;
            this.check_hostname.Checked = conf.enabled_hostname;

            this.exchangeName.Text = conf.exchange_name;
            this.exchangeType.SelectedItem = conf.exchange_type;
            this.exchangeSettings.SetItemChecked(0, conf.exchange_durable);
            this.exchangeSettings.SetItemChecked(1, conf.exchange_autodelete);

            this.queueName.Text = conf.queue_prefix;
            this.queueMessageTTL.Text = conf.queue_ttl.ToString();
            this.queueSettings.SetItemChecked(0, conf.queue_exclusive);
            this.queueSettings.SetItemChecked(1, conf.queue_durable);
            this.queueSettings.SetItemChecked(2, conf.queue_autodelete);

            this.appPrimaryTimer.Text = conf.primary_timer.ToString();
            this.appSecondaryTimer.Text = conf.secondary_timer.ToString();
            this.debug_enabled.Checked = conf.debug_enabled;

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
            this.conf.server_url = this.text_serverUrl.Text;

            this.conf.enabled_cpu = this.check_cpu.Checked;
            this.conf.enabled_mem = this.check_mem.Checked;
            this.conf.enabled_cputemp = this.check_cputemp.Checked;
            this.conf.enabled_uptime = this.check_uptime.Checked;
            this.conf.enabled_hostname = this.check_hostname.Checked;

            this.conf.primary_timer = int.Parse(appPrimaryTimer.Text);
            this.conf.secondary_timer = int.Parse(appSecondaryTimer.Text);

            this.conf.exchange_name = exchangeName.Text;

            if (this.exchangeType.SelectedItem != null)
            {
                this.conf.exchange_type = exchangeType.SelectedItem.ToString();
            }
            this.conf.exchange_durable = exchangeSettings.GetItemChecked(0);
            this.conf.exchange_autodelete = exchangeSettings.GetItemChecked(1);

            this.conf.queue_ttl = int.Parse(queueMessageTTL.Text);
            this.conf.queue_prefix = queueName.Text;
            this.conf.queue_exclusive = queueSettings.GetItemChecked(0);
            this.conf.queue_durable = queueSettings.GetItemChecked(1);
            this.conf.queue_autodelete = queueSettings.GetItemChecked(2);

            this.conf.retry_timer = 5;
            this.conf.debug_enabled = debug_enabled.Checked;

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
