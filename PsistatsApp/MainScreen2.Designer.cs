namespace Psistats.App
{
    partial class MainScreen2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen2));
            this.text_serverUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_uptime = new System.Windows.Forms.CheckBox();
            this.check_hostname = new System.Windows.Forms.CheckBox();
            this.check_cputemp = new System.Windows.Forms.CheckBox();
            this.check_mem = new System.Windows.Forms.CheckBox();
            this.check_cpu = new System.Windows.Forms.CheckBox();
            this.button_service = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.exchangeName = new System.Windows.Forms.TextBox();
            this.exchangeType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.exchangeSettings = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.queueSettings = new System.Windows.Forms.CheckedListBox();
            this.queueMessageTTL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.queueName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.debug_enabled = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.appSecondaryTimer = new System.Windows.Forms.TextBox();
            this.appPrimaryTimer = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_serverUrl
            // 
            this.text_serverUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.text_serverUrl.Location = new System.Drawing.Point(95, 17);
            this.text_serverUrl.Name = "text_serverUrl";
            this.text_serverUrl.Size = new System.Drawing.Size(380, 20);
            this.text_serverUrl.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RabbitMQ URL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_uptime);
            this.groupBox2.Controls.Add(this.check_hostname);
            this.groupBox2.Controls.Add(this.check_cputemp);
            this.groupBox2.Controls.Add(this.check_mem);
            this.groupBox2.Controls.Add(this.check_cpu);
            this.groupBox2.Location = new System.Drawing.Point(221, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 45);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "What to Report";
            // 
            // check_uptime
            // 
            this.check_uptime.AutoSize = true;
            this.check_uptime.Location = new System.Drawing.Point(198, 19);
            this.check_uptime.Name = "check_uptime";
            this.check_uptime.Size = new System.Drawing.Size(59, 17);
            this.check_uptime.TabIndex = 5;
            this.check_uptime.Text = "Uptime";
            this.check_uptime.UseVisualStyleBackColor = true;
            // 
            // check_hostname
            // 
            this.check_hostname.AutoSize = true;
            this.check_hostname.Location = new System.Drawing.Point(401, 19);
            this.check_hostname.Name = "check_hostname";
            this.check_hostname.Size = new System.Drawing.Size(74, 17);
            this.check_hostname.TabIndex = 3;
            this.check_hostname.Text = "Hostname";
            this.check_hostname.UseVisualStyleBackColor = true;
            // 
            // check_cputemp
            // 
            this.check_cputemp.AutoSize = true;
            this.check_cputemp.Location = new System.Drawing.Point(279, 19);
            this.check_cputemp.Name = "check_cputemp";
            this.check_cputemp.Size = new System.Drawing.Size(111, 17);
            this.check_cputemp.TabIndex = 2;
            this.check_cputemp.Text = "CPU Temperature";
            this.check_cputemp.UseVisualStyleBackColor = true;
            // 
            // check_mem
            // 
            this.check_mem.AutoSize = true;
            this.check_mem.Location = new System.Drawing.Point(95, 20);
            this.check_mem.Name = "check_mem";
            this.check_mem.Size = new System.Drawing.Size(97, 17);
            this.check_mem.TabIndex = 1;
            this.check_mem.Text = "Memory Usage";
            this.check_mem.UseVisualStyleBackColor = true;
            // 
            // check_cpu
            // 
            this.check_cpu.AutoSize = true;
            this.check_cpu.Location = new System.Drawing.Point(7, 20);
            this.check_cpu.Name = "check_cpu";
            this.check_cpu.Size = new System.Drawing.Size(82, 17);
            this.check_cpu.TabIndex = 0;
            this.check_cpu.Text = "CPU Usage";
            this.check_cpu.UseVisualStyleBackColor = true;
            // 
            // button_service
            // 
            this.button_service.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_service.Enabled = false;
            this.button_service.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_service.Location = new System.Drawing.Point(10, 375);
            this.button_service.Name = "button_service";
            this.button_service.Size = new System.Drawing.Size(203, 30);
            this.button_service.TabIndex = 5;
            this.button_service.Text = "Start Service";
            this.button_service.UseVisualStyleBackColor = false;
            this.button_service.Click += new System.EventHandler(this.button_startService_clicked);
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(5, 18);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(472, 268);
            this.logBox.TabIndex = 13;
            this.logBox.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logBox);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(221, 119);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(482, 291);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.text_serverUrl);
            this.groupBox4.Location = new System.Drawing.Point(222, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(482, 48);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Server Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.exchangeName);
            this.groupBox1.Controls.Add(this.exchangeType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.exchangeSettings);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 111);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exchange Settings";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Type:";
            // 
            // exchangeName
            // 
            this.exchangeName.Location = new System.Drawing.Point(55, 20);
            this.exchangeName.Name = "exchangeName";
            this.exchangeName.Size = new System.Drawing.Size(100, 20);
            this.exchangeName.TabIndex = 2;
            // 
            // exchangeType
            // 
            this.exchangeType.FormattingEnabled = true;
            this.exchangeType.Items.AddRange(new object[] {
            "Direct",
            "Fanout",
            "Topic",
            "Headers"});
            this.exchangeType.Location = new System.Drawing.Point(55, 46);
            this.exchangeType.Name = "exchangeType";
            this.exchangeType.Size = new System.Drawing.Size(92, 21);
            this.exchangeType.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Name:";
            // 
            // exchangeSettings
            // 
            this.exchangeSettings.BackColor = System.Drawing.SystemColors.Control;
            this.exchangeSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exchangeSettings.FormattingEnabled = true;
            this.exchangeSettings.Items.AddRange(new object[] {
            "Durable",
            "Autodelete"});
            this.exchangeSettings.Location = new System.Drawing.Point(54, 73);
            this.exchangeSettings.Name = "exchangeSettings";
            this.exchangeSettings.Size = new System.Drawing.Size(129, 30);
            this.exchangeSettings.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.queueSettings);
            this.groupBox5.Controls.Add(this.queueMessageTTL);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.queueName);
            this.groupBox5.Location = new System.Drawing.Point(10, 129);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(203, 125);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Queue Settings";
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
            this.queueSettings.Location = new System.Drawing.Point(54, 70);
            this.queueSettings.Name = "queueSettings";
            this.queueSettings.Size = new System.Drawing.Size(129, 45);
            this.queueSettings.TabIndex = 12;
            // 
            // queueMessageTTL
            // 
            this.queueMessageTTL.Location = new System.Drawing.Point(96, 44);
            this.queueMessageTTL.Name = "queueMessageTTL";
            this.queueMessageTTL.Size = new System.Drawing.Size(51, 20);
            this.queueMessageTTL.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Message TTL:";
            // 
            // queueName
            // 
            this.queueName.Location = new System.Drawing.Point(55, 20);
            this.queueName.Name = "queueName";
            this.queueName.Size = new System.Drawing.Size(141, 20);
            this.queueName.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.debug_enabled);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.appSecondaryTimer);
            this.groupBox6.Controls.Add(this.appPrimaryTimer);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Location = new System.Drawing.Point(10, 265);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(203, 100);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Service Settings";
            // 
            // debug_enabled
            // 
            this.debug_enabled.AutoSize = true;
            this.debug_enabled.Location = new System.Drawing.Point(54, 73);
            this.debug_enabled.Name = "debug_enabled";
            this.debug_enabled.Size = new System.Drawing.Size(58, 17);
            this.debug_enabled.TabIndex = 12;
            this.debug_enabled.Text = "Debug";
            this.debug_enabled.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Main Timer:";
            // 
            // appSecondaryTimer
            // 
            this.appSecondaryTimer.Location = new System.Drawing.Point(100, 47);
            this.appSecondaryTimer.Name = "appSecondaryTimer";
            this.appSecondaryTimer.Size = new System.Drawing.Size(47, 20);
            this.appSecondaryTimer.TabIndex = 10;
            // 
            // appPrimaryTimer
            // 
            this.appPrimaryTimer.Location = new System.Drawing.Point(79, 26);
            this.appPrimaryTimer.Name = "appPrimaryTimer";
            this.appPrimaryTimer.Size = new System.Drawing.Size(47, 20);
            this.appPrimaryTimer.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Secondary Timer:";
            // 
            // MainScreen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(716, 416);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_service);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainScreen2";
            this.Text = "Psistats v0.1.0";
            this.Load += new System.EventHandler(this.MainScreen2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox text_serverUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox check_uptime;
        private System.Windows.Forms.CheckBox check_hostname;
        private System.Windows.Forms.CheckBox check_cputemp;
        private System.Windows.Forms.CheckBox check_mem;
        private System.Windows.Forms.CheckBox check_cpu;
        public System.Windows.Forms.Button button_service;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox exchangeName;
        public System.Windows.Forms.ComboBox exchangeType;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckedListBox exchangeSettings;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.CheckedListBox queueSettings;
        public System.Windows.Forms.TextBox queueMessageTTL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox queueName;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.CheckBox debug_enabled;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox appSecondaryTimer;
        public System.Windows.Forms.TextBox appPrimaryTimer;
        private System.Windows.Forms.Label label16;



    }
}