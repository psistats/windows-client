using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using RabbitMQ.Client.Exceptions;

namespace Psistats.App
{
    public partial class MainScreen : Form
    {
        private Thread configThread;

        private DoerBox box;

        private bool changed;

        public delegate void UpdateBoxDelegate(string msg, int progress, bool ok);
        public delegate void ErrorBoxDelegate(string msg, int progress);
        public delegate void SetTextDelegate(TextBox control, string msg);
        public delegate void SetComboBoxTextDelegate(ComboBox control, string msg);
        public delegate void SetCheckedDelegate(CheckBox control, bool chkd);
        public delegate void ToggleServiceButtonDelegate(bool running);
        public delegate void UpdateSaveButtonDelegate();

        public MainScreen()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.form_onload);
        }

        private void form_onload(object sender, EventArgs e)
        {

            this.GetDoerBox();
            this.UpdateBox("Loading configuration...", 25, true);

            try
            {

                Config conf = Config.LoadConf();

                this.SetText(this.server_hostname, conf.server_hostname);
                this.SetText(this.server_port, conf.server_port.ToString());
                this.SetText(this.server_username, conf.server_username);
                this.SetText(this.server_password, conf.server_password);
                this.SetText(this.server_vhost, conf.server_vhost);

                this.SetText(this.exchange_name, conf.exchange_name);
                this.SetComboBoxText(this.exchange_type, conf.exchange_type);
                this.SetChecked(this.exchange_autodelete, conf.exchange_autodelete);
                this.SetChecked(this.exchange_durable, conf.exchange_durable);

                this.SetText(this.queue_prefix, conf.queue_prefix);
                this.SetChecked(this.queue_autodelete, conf.queue_autodelete);
                this.SetChecked(this.queue_durable, conf.queue_durable);
                this.SetChecked(this.queue_exclusive, conf.queue_exclusive);
                this.SetText(this.queue_ttl, conf.queue_ttl.ToString());

                this.SetText(this.app_main_timer, conf.app_timer.ToString());
                this.SetText(this.app_meta_timer, conf.metadata_timer.ToString());
                this.SetText(this.app_retry_timer, conf.retry_timer.ToString());

                this.UpdateBox("Checking service", 50, false);

                if (PsistatsServiceUtils.IsRunning())
                {
                    this.button_service.Text = "Stop Service";
                }

                box.Close();
            }
            catch (Exception exc)
            {
                this.ErrorBox(exc.Message, 100);
            }
        }

        private DoerBox GetDoerBox()
        {
            if (box != null)
            {
                box.Dispose();
            }

            box = new DoerBox();
            this.Enabled = false;
            box.Show();
            box.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReEnable);

            return box;
        }

        private void ReEnable(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        public int GetNumber(TextBox control, int nullalt = 0)
        {
            String text = GetText(control);

            if (text != null && text.Length > 0)
            {
                return int.Parse(text);
            }
            else
            {
                return nullalt;
            }
        }

        public string GetComboBoxText(ComboBox control)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    Func<ComboBox, string> deleg = new Func<ComboBox, string>(GetComboBoxText);
                    return control.Invoke(deleg, new object[] { control }).ToString();
                }
                else
                {
                    try
                    {
                        return control.Text;
                    }
                    catch (NullReferenceException e)
                    {
                        return "";
                    }
                }
            }
            return "";
        }

        public void SetComboBoxText(ComboBox control, string txt)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetComboBoxTextDelegate(SetComboBoxText), new object[] { control, txt });
            }
            else
            {
                control.Text = txt;
            }
        }

        public bool GetChecked(CheckBox control)
        {
            if (control.InvokeRequired)
            {
                Func<CheckBox, bool> deleg = new Func<CheckBox, bool>(GetChecked);
                return (bool)control.Invoke(deleg, new object[] { control });
            }
            else
            {
                return control.Checked;
            }
        }

        public void SetChecked(CheckBox control, bool chkd)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetCheckedDelegate(SetChecked), new object[] { control, chkd });
            }
            else
            {
                control.Checked = chkd;
            }
        }


        public string GetText(TextBox control)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    Func<TextBox, string> deleg = new Func<TextBox, string>(GetText);
                    return control.Invoke(deleg, new object[] { control }).ToString();
                }
                else
                {
                    return control.Text;
                }
            }
            return "";
        }

        public void SetText(TextBox control, string txt)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetTextDelegate(SetText), new object[] { control, txt });
            }
            else
            {
                control.Text = txt;
            }
        }



        private Config FactoryConfig()
        {
            Config conf = Config.LoadConf();
            conf.server_hostname = this.GetText(this.server_hostname);
            conf.server_port = this.GetNumber(this.server_port);
            conf.server_username = this.GetText(this.server_username);
            conf.server_password = this.GetText(this.server_password);
            conf.server_vhost = this.GetText(this.server_vhost);

            conf.queue_autodelete = this.GetChecked(this.queue_autodelete);
            conf.queue_durable = this.GetChecked(this.queue_durable);
            conf.queue_exclusive = this.GetChecked(this.queue_exclusive);
            conf.queue_prefix = this.GetText(this.queue_prefix);
            conf.queue_ttl = this.GetNumber(this.queue_ttl);

            conf.exchange_autodelete = this.GetChecked(this.exchange_autodelete);
            conf.exchange_durable = this.GetChecked(this.exchange_durable);
            conf.exchange_type = this.GetComboBoxText(this.exchange_type);
            conf.exchange_name = this.GetText(this.exchange_name);

            conf.app_timer = this.GetNumber(app_main_timer);
            conf.metadata_timer = this.GetNumber(app_meta_timer);
            conf.retry_timer = this.GetNumber(app_retry_timer);
            conf.app_cputemp = this.GetChecked(app_cputemp);

            return conf;
        }

        private void ValidateSettings()
        {
            this.GetDoerBox();

            Logger logger = new Logger("Psistats");

            try
            {
                Stat stat = new Stat();

                this.UpdateBox("Creating config object", 10, false);
                Config conf = FactoryConfig();

                logger.Debug(string.Concat("Server Name: ", conf.server_hostname));
                logger.Debug(string.Concat("Server Port: ", conf.server_port.ToString()));
                logger.Debug("Server Username: " + conf.server_username.ToString());
                logger.Debug("Server Vhost: " + conf.server_vhost);

                logger.Debug("Exchange Name: " + conf.exchange_name);
                logger.Debug("Exchange Autodelete: " + conf.exchange_autodelete.ToString());
                logger.Debug("Exchange Durable: " + conf.exchange_durable.ToString());
                logger.Debug("Exchange Type: " + conf.exchange_type);

                this.UpdateBox("Connecting to RabbitMQ Server", 50, false);
                PsistatsServer ps = new PsistatsServer(conf);
                ps.Connect();

                this.UpdateBox("Creating queue", 50, false);
                ps.Bind(stat.hostname);

                this.UpdateBox("Deleting queue", 75, false);
                ps.DeleteQueue();
                ps.Close();
                this.UpdateBox("Settings validated!", 100, true);

            }
            catch (BrokerUnreachableException e)
            {
                this.ErrorBox(e.Message, 100);
            }
            catch (OperationInterruptedException e)
            {
                this.ErrorBox(e.Message, 100);
            }
        }

        private void SaveConfig()
        {
            try
            {
                this.UpdateBox("Create config object", 50, true);
                Config conf = FactoryConfig();   
                Config.WriteConf(conf);
                this.UpdateBox("Configuration saved!", 100, true);
                this.UpdateSaveButton();
            } catch (Exception e) {
                this.ErrorBox(e.Message, 100);
            }
        }

        private void UpdateSaveButton()
        {
            if (this.button_save.InvokeRequired)
            {
                this.button_save.Invoke(new UpdateSaveButtonDelegate(UpdateSaveButton), new object[] { });
            }
            else
            {
                this.button_save.Text = "Save";
                this.changed = false;
            }
        }

        public void ErrorBox(string msg, int progress)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new ErrorBoxDelegate(ErrorBox), new object[] { msg, progress });
            }
            else
            {
                box.progressBar.BackColor = Color.Red;
                box.progressBar.ForeColor = Color.Red;
                box.progressBar.Value = progress;
                box.label.Text = msg;
                box.ok.Enabled = true;
            }
        }

        public void ToggleServiceButton(bool running)
        {
            if (button_service.InvokeRequired)
            {
                button_service.Invoke(new ToggleServiceButtonDelegate(ToggleServiceButton), new object[] { running });
            }
            else
            {
                if (running == false)
                {
                    button_service.Text = "Start Service";
                }
                else
                {
                    button_service.Text = "Stop Service";
                }
            }
        }

        public void UpdateBox(string msg, int progress, bool ok)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new UpdateBoxDelegate(UpdateBox), new object[] { msg, progress, ok });
            }
            else
            {
                if (msg != null)
                {
                    box.label.Text = msg;
                }

                if (progress != null)
                {
                    box.progressBar.Value = progress;
                }

                if (ok != null && ok == true)
                {
                    box.ok.Enabled = true;
                }
                else if (ok != null && ok == false)
                {
                    box.ok.Enabled = false;
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.GetDoerBox();

            box.progressBar.Value = 10;
            box.label.Text = "Saving configuration...";

            configThread = new Thread(new ThreadStart(SaveConfig));
            configThread.Start();
            box.progressBar.Value = 20;
        }

        private void button_validate_Click(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void ToggleService()
        {
            try
            {
                UpdateBox("Checking service...", 25, false);

                if (PsistatsServiceUtils.IsInstalled())
                {
                    if (PsistatsServiceUtils.IsRunning())
                    {
                        UpdateBox("Stopping service...", 50, false);
                        PsistatsServiceUtils.StopService();
                        while (PsistatsServiceUtils.IsRunning()) {
                            Thread.Sleep(500);
                        }
                    } else {
                        UpdateBox("Starting service...", 50, false);
                        PsistatsServiceUtils.StartService();

                        while (PsistatsServiceUtils.IsRunning() == false) {
                            Thread.Sleep(500);
                        }
                    }
                } else {
                    UpdateBox("Installing service...", 50, false);
                    PsistatsServiceUtils.InstallService();

                    UpdateBox("Starting service...", 75, false);
                    PsistatsServiceUtils.StartService();

                    while (PsistatsServiceUtils.IsRunning() == false) {
                        Thread.Sleep(500);
                    }
                }

                UpdateBox("Done!", 100, true);

                this.ToggleServiceButton(PsistatsServiceUtils.IsRunning());
            }
            catch (InvalidOperationException e)
            {
                ErrorBox("Error starting service: " + e.Message, 100);
            }
        }

        private void button_service_Click(object sender, EventArgs e)
        {
            this.GetDoerBox();
            Thread serviceThread = new Thread(new ThreadStart(ToggleService));
            serviceThread.Start();
            
        }

        private void server_hostname_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void settings_changed()
        {
            if (this.changed != true)
            {
                this.button_save.Text = this.button_save.Text += " *";
                this.changed = true;
            }
            
        }

        private void server_port_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void server_username_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void server_password_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void server_vhost_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void exchange_name_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void exchange_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void exchange_durable_CheckedChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void exchange_autodelete_CheckedChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void queue_prefix_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void queue_exclusive_CheckedChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void queue_durable_CheckedChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void queue_autodelete_CheckedChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void queue_ttl_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void app_main_timer_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void app_meta_timer_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void app_retry_timer_TextChanged(object sender, EventArgs e)
        {
            this.settings_changed();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

    }
}
