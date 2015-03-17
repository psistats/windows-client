using OpenHardwareMonitor.Hardware;
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


            evtLog = new EventLog("Application");
            evtLog.EntryWritten += new EntryWrittenEventHandler(OnEventLog);
            evtLog.EnableRaisingEvents = true;

            this.AddLog("Loading configuration...");
            conf = Config.LoadConf();

            // TODO Normalize all these form field names!
            text_serverUrl.Text = conf.server_url;

            check_cpu.Checked = conf.enabled_cpu;
            check_cputemp.Checked = conf.enabled_cputemp;
            check_mem.Checked = conf.enabled_mem;
            check_uptime.Checked = conf.enabled_uptime;
            check_hostname.Checked = conf.enabled_hostname;

            exchangeName.Text = conf.exchange_name;
            exchangeType.SelectedItem = conf.exchange_type;
            exchangeSettings.SetItemChecked(0, conf.exchange_durable);
            exchangeSettings.SetItemChecked(1, conf.exchange_autodelete);

            queueName.Text = conf.queue_prefix;
            queueMessageTTL.Text = conf.queue_ttl.ToString();
            queueSettings.SetItemChecked(0, conf.queue_exclusive);
            queueSettings.SetItemChecked(1, conf.queue_durable);
            queueSettings.SetItemChecked(2, conf.queue_autodelete);

            appPrimaryTimer.Text = conf.primary_timer.ToString();
            appSecondaryTimer.Text = conf.secondary_timer.ToString();
            debug_enabled.Checked = conf.debug_enabled;

        }

        public void AddLog(string logItem)
        {
            if (logBox.InvokeRequired)
            {
                AddLogCallback d = new AddLogCallback(AddLog);
                logBox.Invoke(d, new object[] { logItem });
            }
            else
            {
                logBox.Text += logItem + Environment.NewLine;
                logBox.SelectionStart = logBox.TextLength;
                logBox.ScrollToCaret();
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
            conf.server_url = this.text_serverUrl.Text;
            
            conf.enabled_cpu = this.check_cpu.Checked;
            conf.enabled_mem = this.check_mem.Checked;
            conf.enabled_cputemp = this.check_cputemp.Checked;
            conf.enabled_uptime = this.check_uptime.Checked;
            conf.enabled_hostname = this.check_hostname.Checked;

            conf.primary_timer = int.Parse(appPrimaryTimer.Text);
            conf.secondary_timer = int.Parse(appSecondaryTimer.Text);

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

            conf.retry_timer = 5;
            conf.debug_enabled = debug_enabled.Checked;

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
