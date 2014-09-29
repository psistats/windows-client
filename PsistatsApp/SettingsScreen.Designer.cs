namespace Psistats.App
{
    partial class SettingsScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverSettingsPanel = new System.Windows.Forms.Panel();
            this.serverPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.serverUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.serverPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serverPortNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverHostname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.queueSettingsPanel = new System.Windows.Forms.Panel();
            this.queueSettings = new System.Windows.Forms.CheckedListBox();
            this.queueMessageTTL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.queueName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.exchangeSettingsPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.exchangeType = new System.Windows.Forms.ComboBox();
            this.exchangeSettings = new System.Windows.Forms.CheckedListBox();
            this.exchangeRoutingKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.exchangeName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.serviceSettingsPanel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.appSecondaryTimer = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.appMainTimer = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button_save_settings = new System.Windows.Forms.Button();
            this.serverSettingsPanel.SuspendLayout();
            this.queueSettingsPanel.SuspendLayout();
            this.exchangeSettingsPanel.SuspendLayout();
            this.serviceSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverSettingsPanel
            // 
            this.serverSettingsPanel.Controls.Add(this.serverPassword);
            this.serverSettingsPanel.Controls.Add(this.label7);
            this.serverSettingsPanel.Controls.Add(this.serverUsername);
            this.serverSettingsPanel.Controls.Add(this.label6);
            this.serverSettingsPanel.Controls.Add(this.serverPath);
            this.serverSettingsPanel.Controls.Add(this.label5);
            this.serverSettingsPanel.Controls.Add(this.serverPortNumber);
            this.serverSettingsPanel.Controls.Add(this.label4);
            this.serverSettingsPanel.Controls.Add(this.serverHostname);
            this.serverSettingsPanel.Controls.Add(this.label3);
            this.serverSettingsPanel.Controls.Add(this.label2);
            this.serverSettingsPanel.Location = new System.Drawing.Point(12, 11);
            this.serverSettingsPanel.Name = "serverSettingsPanel";
            this.serverSettingsPanel.Size = new System.Drawing.Size(217, 147);
            this.serverSettingsPanel.TabIndex = 3;
            // 
            // serverPassword
            // 
            this.serverPassword.Location = new System.Drawing.Point(92, 118);
            this.serverPassword.Name = "serverPassword";
            this.serverPassword.PasswordChar = '*';
            this.serverPassword.Size = new System.Drawing.Size(100, 20);
            this.serverPassword.TabIndex = 10;
            this.serverPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Password:";
            // 
            // serverUsername
            // 
            this.serverUsername.Location = new System.Drawing.Point(92, 96);
            this.serverUsername.Name = "serverUsername";
            this.serverUsername.Size = new System.Drawing.Size(100, 20);
            this.serverUsername.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Username:";
            // 
            // serverPath
            // 
            this.serverPath.Location = new System.Drawing.Point(92, 74);
            this.serverPath.Name = "serverPath";
            this.serverPath.Size = new System.Drawing.Size(100, 20);
            this.serverPath.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Path:";
            // 
            // serverPortNumber
            // 
            this.serverPortNumber.Location = new System.Drawing.Point(92, 53);
            this.serverPortNumber.Name = "serverPortNumber";
            this.serverPortNumber.Size = new System.Drawing.Size(50, 20);
            this.serverPortNumber.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port Number:";
            // 
            // serverHostname
            // 
            this.serverHostname.Location = new System.Drawing.Point(92, 31);
            this.serverHostname.Name = "serverHostname";
            this.serverHostname.Size = new System.Drawing.Size(100, 20);
            this.serverHostname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hostname / IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Configure settings for your RabbitMQ Server";
            // 
            // queueSettingsPanel
            // 
            this.queueSettingsPanel.Controls.Add(this.queueSettings);
            this.queueSettingsPanel.Controls.Add(this.queueMessageTTL);
            this.queueSettingsPanel.Controls.Add(this.label8);
            this.queueSettingsPanel.Controls.Add(this.queueName);
            this.queueSettingsPanel.Controls.Add(this.label12);
            this.queueSettingsPanel.Controls.Add(this.label13);
            this.queueSettingsPanel.Location = new System.Drawing.Point(12, 164);
            this.queueSettingsPanel.Name = "queueSettingsPanel";
            this.queueSettingsPanel.Size = new System.Drawing.Size(217, 163);
            this.queueSettingsPanel.TabIndex = 12;
            // 
            // queueSettings
            // 
            this.queueSettings.BackColor = System.Drawing.SystemColors.Control;
            this.queueSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.queueSettings.FormattingEnabled = true;
            this.queueSettings.Items.AddRange(new object[] {
            "Exclusive",
            "Durable",
            "Autodelete"});
            this.queueSettings.Location = new System.Drawing.Point(88, 74);
            this.queueSettings.Name = "queueSettings";
            this.queueSettings.Size = new System.Drawing.Size(129, 45);
            this.queueSettings.TabIndex = 12;
            // 
            // queueMessageTTL
            // 
            this.queueMessageTTL.Location = new System.Drawing.Point(89, 48);
            this.queueMessageTTL.Name = "queueMessageTTL";
            this.queueMessageTTL.PasswordChar = '*';
            this.queueMessageTTL.Size = new System.Drawing.Size(100, 20);
            this.queueMessageTTL.TabIndex = 10;
            this.queueMessageTTL.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Message TTL:";
            // 
            // queueName
            // 
            this.queueName.Location = new System.Drawing.Point(89, 24);
            this.queueName.Name = "queueName";
            this.queueName.Size = new System.Drawing.Size(100, 20);
            this.queueName.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Configure the Queue";
            // 
            // exchangeSettingsPanel
            // 
            this.exchangeSettingsPanel.Controls.Add(this.label14);
            this.exchangeSettingsPanel.Controls.Add(this.exchangeType);
            this.exchangeSettingsPanel.Controls.Add(this.exchangeSettings);
            this.exchangeSettingsPanel.Controls.Add(this.exchangeRoutingKey);
            this.exchangeSettingsPanel.Controls.Add(this.label9);
            this.exchangeSettingsPanel.Controls.Add(this.exchangeName);
            this.exchangeSettingsPanel.Controls.Add(this.label10);
            this.exchangeSettingsPanel.Controls.Add(this.label11);
            this.exchangeSettingsPanel.Location = new System.Drawing.Point(235, 200);
            this.exchangeSettingsPanel.Name = "exchangeSettingsPanel";
            this.exchangeSettingsPanel.Size = new System.Drawing.Size(217, 163);
            this.exchangeSettingsPanel.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Type:";
            // 
            // exchangeType
            // 
            this.exchangeType.FormattingEnabled = true;
            this.exchangeType.Items.AddRange(new object[] {
            "Direct",
            "Fanout",
            "Topic",
            "Headers"});
            this.exchangeType.Location = new System.Drawing.Point(89, 71);
            this.exchangeType.Name = "exchangeType";
            this.exchangeType.Size = new System.Drawing.Size(92, 21);
            this.exchangeType.TabIndex = 13;
            // 
            // exchangeSettings
            // 
            this.exchangeSettings.BackColor = System.Drawing.SystemColors.Control;
            this.exchangeSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exchangeSettings.FormattingEnabled = true;
            this.exchangeSettings.Items.AddRange(new object[] {
            "Durable",
            "Autodelete"});
            this.exchangeSettings.Location = new System.Drawing.Point(89, 98);
            this.exchangeSettings.Name = "exchangeSettings";
            this.exchangeSettings.Size = new System.Drawing.Size(129, 30);
            this.exchangeSettings.TabIndex = 12;
            // 
            // exchangeRoutingKey
            // 
            this.exchangeRoutingKey.Location = new System.Drawing.Point(89, 48);
            this.exchangeRoutingKey.Name = "exchangeRoutingKey";
            this.exchangeRoutingKey.PasswordChar = '*';
            this.exchangeRoutingKey.Size = new System.Drawing.Size(100, 20);
            this.exchangeRoutingKey.TabIndex = 10;
            this.exchangeRoutingKey.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Routing Key:";
            // 
            // exchangeName
            // 
            this.exchangeName.Location = new System.Drawing.Point(89, 24);
            this.exchangeName.Name = "exchangeName";
            this.exchangeName.Size = new System.Drawing.Size(100, 20);
            this.exchangeName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Configure the Exchange";
            // 
            // serviceSettingsPanel
            // 
            this.serviceSettingsPanel.Controls.Add(this.label15);
            this.serviceSettingsPanel.Controls.Add(this.appSecondaryTimer);
            this.serviceSettingsPanel.Controls.Add(this.label16);
            this.serviceSettingsPanel.Controls.Add(this.appMainTimer);
            this.serviceSettingsPanel.Controls.Add(this.label17);
            this.serviceSettingsPanel.Controls.Add(this.label18);
            this.serviceSettingsPanel.Location = new System.Drawing.Point(235, 11);
            this.serviceSettingsPanel.Name = "serviceSettingsPanel";
            this.serviceSettingsPanel.Size = new System.Drawing.Size(217, 183);
            this.serviceSettingsPanel.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(3, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(199, 109);
            this.label15.TabIndex = 11;
            this.label15.Text = "Timers are in seconds.\r\n\r\nThe main timer controls how often CPU and memory usage " +
    "and cpu temperature are reported.\r\n\r\nThe secondary timer controls how often upti" +
    "me and IP addresses are reported.";
            // 
            // appSecondaryTimer
            // 
            this.appSecondaryTimer.Location = new System.Drawing.Point(111, 45);
            this.appSecondaryTimer.Name = "appSecondaryTimer";
            this.appSecondaryTimer.PasswordChar = '*';
            this.appSecondaryTimer.Size = new System.Drawing.Size(47, 20);
            this.appSecondaryTimer.TabIndex = 10;
            this.appSecondaryTimer.UseSystemPasswordChar = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Secondary Timer:";
            // 
            // appMainTimer
            // 
            this.appMainTimer.Location = new System.Drawing.Point(111, 24);
            this.appMainTimer.Name = "appMainTimer";
            this.appMainTimer.Size = new System.Drawing.Size(47, 20);
            this.appMainTimer.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Main Timer:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Configure the Service";
            // 
            // button_save_settings
            // 
            this.button_save_settings.Location = new System.Drawing.Point(12, 340);
            this.button_save_settings.Name = "button_save_settings";
            this.button_save_settings.Size = new System.Drawing.Size(217, 23);
            this.button_save_settings.TabIndex = 16;
            this.button_save_settings.Text = "Save Settings";
            this.button_save_settings.UseVisualStyleBackColor = true;
            this.button_save_settings.Click += new System.EventHandler(this.button_save_settings_Click);
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 372);
            this.Controls.Add(this.button_save_settings);
            this.Controls.Add(this.serviceSettingsPanel);
            this.Controls.Add(this.exchangeSettingsPanel);
            this.Controls.Add(this.queueSettingsPanel);
            this.Controls.Add(this.serverSettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsScreen";
            this.Text = "Psistats";
            this.Load += new System.EventHandler(this.Psistats_Load);
            this.serverSettingsPanel.ResumeLayout(false);
            this.serverSettingsPanel.PerformLayout();
            this.queueSettingsPanel.ResumeLayout(false);
            this.queueSettingsPanel.PerformLayout();
            this.exchangeSettingsPanel.ResumeLayout(false);
            this.exchangeSettingsPanel.PerformLayout();
            this.serviceSettingsPanel.ResumeLayout(false);
            this.serviceSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel serverSettingsPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel queueSettingsPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel exchangeSettingsPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel serviceSettingsPanel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button_save_settings;
        public System.Windows.Forms.TextBox serverHostname;
        public System.Windows.Forms.TextBox serverPath;
        public System.Windows.Forms.TextBox serverPortNumber;
        public System.Windows.Forms.TextBox serverUsername;
        public System.Windows.Forms.TextBox serverPassword;
        public System.Windows.Forms.TextBox queueMessageTTL;
        public System.Windows.Forms.TextBox queueName;
        public System.Windows.Forms.CheckedListBox queueSettings;
        public System.Windows.Forms.CheckedListBox exchangeSettings;
        public System.Windows.Forms.TextBox exchangeRoutingKey;
        public System.Windows.Forms.TextBox exchangeName;
        public System.Windows.Forms.ComboBox exchangeType;
        public System.Windows.Forms.TextBox appSecondaryTimer;
        public System.Windows.Forms.TextBox appMainTimer;


    }
}