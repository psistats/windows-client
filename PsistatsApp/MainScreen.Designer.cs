namespace Psistats.App
{
    partial class MainScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.server_hostname = new System.Windows.Forms.TextBox();
            this.server_port = new System.Windows.Forms.TextBox();
            this.server_username = new System.Windows.Forms.TextBox();
            this.server_password = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.server_vhost = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.exchange_name = new System.Windows.Forms.TextBox();
            this.exchange_durable = new System.Windows.Forms.CheckBox();
            this.exchange_autodelete = new System.Windows.Forms.CheckBox();
            this.exchange_type = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.app_main_timer = new System.Windows.Forms.TextBox();
            this.app_meta_timer = new System.Windows.Forms.TextBox();
            this.app_retry_timer = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.queue_exclusive = new System.Windows.Forms.CheckBox();
            this.queue_durable = new System.Windows.Forms.CheckBox();
            this.queue_autodelete = new System.Windows.Forms.CheckBox();
            this.queue_ttl = new System.Windows.Forms.TextBox();
            this.queue_prefix = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_validate = new System.Windows.Forms.Button();
            this.button_service = new System.Windows.Forms.Button();
            this.templabel = new System.Windows.Forms.Label();
            this.app_cputemp = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 284);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.server_hostname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.server_port, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.server_username, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.server_password, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.server_vhost, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 129);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hostname / IP Address";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port Number";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // server_hostname
            // 
            this.server_hostname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.server_hostname.Location = new System.Drawing.Point(164, 3);
            this.server_hostname.Name = "server_hostname";
            this.server_hostname.Size = new System.Drawing.Size(155, 20);
            this.server_hostname.TabIndex = 4;
            this.server_hostname.TextChanged += new System.EventHandler(this.server_hostname_TextChanged);
            // 
            // server_port
            // 
            this.server_port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.server_port.Location = new System.Drawing.Point(164, 28);
            this.server_port.Name = "server_port";
            this.server_port.Size = new System.Drawing.Size(55, 20);
            this.server_port.TabIndex = 5;
            this.server_port.TextChanged += new System.EventHandler(this.server_port_TextChanged);
            // 
            // server_username
            // 
            this.server_username.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.server_username.Location = new System.Drawing.Point(164, 53);
            this.server_username.Name = "server_username";
            this.server_username.Size = new System.Drawing.Size(155, 20);
            this.server_username.TabIndex = 6;
            this.server_username.TextChanged += new System.EventHandler(this.server_username_TextChanged);
            // 
            // server_password
            // 
            this.server_password.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.server_password.Location = new System.Drawing.Point(164, 78);
            this.server_password.Name = "server_password";
            this.server_password.Size = new System.Drawing.Size(155, 20);
            this.server_password.TabIndex = 7;
            this.server_password.TextChanged += new System.EventHandler(this.server_password_TextChanged);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Virtual Host";
            // 
            // server_vhost
            // 
            this.server_vhost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.server_vhost.Location = new System.Drawing.Point(164, 104);
            this.server_vhost.Name = "server_vhost";
            this.server_vhost.Size = new System.Drawing.Size(155, 20);
            this.server_vhost.TabIndex = 9;
            this.server_vhost.TextChanged += new System.EventHandler(this.server_vhost_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(0, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 121);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exchange Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.exchange_name, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.exchange_durable, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.exchange_autodelete, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.exchange_type, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(322, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Exchange Name";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Type";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Durable";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Autodelete";
            // 
            // exchange_name
            // 
            this.exchange_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exchange_name.Location = new System.Drawing.Point(164, 3);
            this.exchange_name.Name = "exchange_name";
            this.exchange_name.Size = new System.Drawing.Size(155, 20);
            this.exchange_name.TabIndex = 4;
            this.exchange_name.TextChanged += new System.EventHandler(this.exchange_name_TextChanged);
            // 
            // exchange_durable
            // 
            this.exchange_durable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exchange_durable.AutoSize = true;
            this.exchange_durable.Location = new System.Drawing.Point(164, 55);
            this.exchange_durable.Name = "exchange_durable";
            this.exchange_durable.Size = new System.Drawing.Size(15, 14);
            this.exchange_durable.TabIndex = 6;
            this.exchange_durable.UseVisualStyleBackColor = true;
            this.exchange_durable.CheckedChanged += new System.EventHandler(this.exchange_durable_CheckedChanged);
            // 
            // exchange_autodelete
            // 
            this.exchange_autodelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exchange_autodelete.AutoSize = true;
            this.exchange_autodelete.Location = new System.Drawing.Point(164, 80);
            this.exchange_autodelete.Name = "exchange_autodelete";
            this.exchange_autodelete.Size = new System.Drawing.Size(15, 14);
            this.exchange_autodelete.TabIndex = 7;
            this.exchange_autodelete.UseVisualStyleBackColor = true;
            this.exchange_autodelete.CheckedChanged += new System.EventHandler(this.exchange_autodelete_CheckedChanged);
            // 
            // exchange_type
            // 
            this.exchange_type.FormattingEnabled = true;
            this.exchange_type.Items.AddRange(new object[] {
            "Direct",
            "Fanout",
            "Topic",
            "Headers"});
            this.exchange_type.Location = new System.Drawing.Point(164, 28);
            this.exchange_type.Name = "exchange_type";
            this.exchange_type.Size = new System.Drawing.Size(92, 21);
            this.exchange_type.TabIndex = 8;
            this.exchange_type.SelectedIndexChanged += new System.EventHandler(this.exchange_type_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(358, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 284);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Location = new System.Drawing.Point(4, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 120);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Application Tweaks";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.app_cputemp, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.templabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.app_main_timer, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.app_meta_timer, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.app_retry_timer, 1, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(344, 102);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "CPU / Memory Timer";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Metadata Timer";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Connection Retry Timer";
            // 
            // app_main_timer
            // 
            this.app_main_timer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.app_main_timer.Location = new System.Drawing.Point(175, 3);
            this.app_main_timer.Name = "app_main_timer";
            this.app_main_timer.Size = new System.Drawing.Size(37, 20);
            this.app_main_timer.TabIndex = 3;
            this.app_main_timer.TextChanged += new System.EventHandler(this.app_main_timer_TextChanged);
            // 
            // app_meta_timer
            // 
            this.app_meta_timer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.app_meta_timer.Location = new System.Drawing.Point(175, 28);
            this.app_meta_timer.Name = "app_meta_timer";
            this.app_meta_timer.Size = new System.Drawing.Size(37, 20);
            this.app_meta_timer.TabIndex = 4;
            this.app_meta_timer.TextChanged += new System.EventHandler(this.app_meta_timer_TextChanged);
            // 
            // app_retry_timer
            // 
            this.app_retry_timer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.app_retry_timer.Location = new System.Drawing.Point(175, 53);
            this.app_retry_timer.Name = "app_retry_timer";
            this.app_retry_timer.Size = new System.Drawing.Size(37, 20);
            this.app_retry_timer.TabIndex = 5;
            this.app_retry_timer.TextChanged += new System.EventHandler(this.app_retry_timer_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 154);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Queue Settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.queue_exclusive, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.queue_durable, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.queue_autodelete, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.queue_ttl, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.queue_prefix, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(350, 129);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Prefix";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Exclusive";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Durable";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Autodelete";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "TTL";
            // 
            // queue_exclusive
            // 
            this.queue_exclusive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queue_exclusive.AutoSize = true;
            this.queue_exclusive.Location = new System.Drawing.Point(178, 30);
            this.queue_exclusive.Name = "queue_exclusive";
            this.queue_exclusive.Size = new System.Drawing.Size(15, 14);
            this.queue_exclusive.TabIndex = 5;
            this.queue_exclusive.UseVisualStyleBackColor = true;
            this.queue_exclusive.CheckedChanged += new System.EventHandler(this.queue_exclusive_CheckedChanged);
            // 
            // queue_durable
            // 
            this.queue_durable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queue_durable.AutoSize = true;
            this.queue_durable.Location = new System.Drawing.Point(178, 55);
            this.queue_durable.Name = "queue_durable";
            this.queue_durable.Size = new System.Drawing.Size(15, 14);
            this.queue_durable.TabIndex = 6;
            this.queue_durable.UseVisualStyleBackColor = true;
            this.queue_durable.CheckedChanged += new System.EventHandler(this.queue_durable_CheckedChanged);
            // 
            // queue_autodelete
            // 
            this.queue_autodelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queue_autodelete.AutoSize = true;
            this.queue_autodelete.Location = new System.Drawing.Point(178, 80);
            this.queue_autodelete.Name = "queue_autodelete";
            this.queue_autodelete.Size = new System.Drawing.Size(15, 14);
            this.queue_autodelete.TabIndex = 7;
            this.queue_autodelete.UseVisualStyleBackColor = true;
            this.queue_autodelete.CheckedChanged += new System.EventHandler(this.queue_autodelete_CheckedChanged);
            // 
            // queue_ttl
            // 
            this.queue_ttl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queue_ttl.Location = new System.Drawing.Point(178, 104);
            this.queue_ttl.Name = "queue_ttl";
            this.queue_ttl.Size = new System.Drawing.Size(56, 20);
            this.queue_ttl.TabIndex = 8;
            this.queue_ttl.TextChanged += new System.EventHandler(this.queue_ttl_TextChanged);
            // 
            // queue_prefix
            // 
            this.queue_prefix.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queue_prefix.Location = new System.Drawing.Point(178, 3);
            this.queue_prefix.Name = "queue_prefix";
            this.queue_prefix.Size = new System.Drawing.Size(166, 20);
            this.queue_prefix.TabIndex = 9;
            this.queue_prefix.TextChanged += new System.EventHandler(this.queue_prefix_TextChanged);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(640, 299);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_validate
            // 
            this.button_validate.Location = new System.Drawing.Point(559, 299);
            this.button_validate.Name = "button_validate";
            this.button_validate.Size = new System.Drawing.Size(75, 23);
            this.button_validate.TabIndex = 4;
            this.button_validate.Text = "Validate";
            this.button_validate.UseVisualStyleBackColor = true;
            this.button_validate.Click += new System.EventHandler(this.button_validate_Click);
            // 
            // button_service
            // 
            this.button_service.Location = new System.Drawing.Point(451, 299);
            this.button_service.Name = "button_service";
            this.button_service.Size = new System.Drawing.Size(102, 23);
            this.button_service.TabIndex = 5;
            this.button_service.Text = "Start Service";
            this.button_service.UseVisualStyleBackColor = true;
            this.button_service.Click += new System.EventHandler(this.button_service_Click);
            // 
            // templabel
            // 
            this.templabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.templabel.AutoSize = true;
            this.templabel.Location = new System.Drawing.Point(3, 82);
            this.templabel.Name = "templabel";
            this.templabel.Size = new System.Drawing.Size(92, 13);
            this.templabel.TabIndex = 6;
            this.templabel.Text = "CPU Temperature";
            this.templabel.Click += new System.EventHandler(this.label18_Click);
            // 
            // app_cputemp
            // 
            this.app_cputemp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.app_cputemp.AutoSize = true;
            this.app_cputemp.Location = new System.Drawing.Point(175, 81);
            this.app_cputemp.Name = "app_cputemp";
            this.app_cputemp.Size = new System.Drawing.Size(15, 14);
            this.app_cputemp.TabIndex = 10;
            this.app_cputemp.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 325);
            this.Controls.Add(this.button_service);
            this.Controls.Add(this.button_validate);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainScreen";
            this.Text = "Psistats";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox server_hostname;
        private System.Windows.Forms.TextBox server_port;
        private System.Windows.Forms.TextBox server_username;
        private System.Windows.Forms.TextBox server_password;
        private System.Windows.Forms.TextBox exchange_name;
        private System.Windows.Forms.CheckBox exchange_durable;
        private System.Windows.Forms.CheckBox exchange_autodelete;
        private System.Windows.Forms.ComboBox exchange_type;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox queue_exclusive;
        private System.Windows.Forms.CheckBox queue_durable;
        private System.Windows.Forms.CheckBox queue_autodelete;
        private System.Windows.Forms.TextBox queue_ttl;
        private System.Windows.Forms.TextBox queue_prefix;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox app_meta_timer;
        private System.Windows.Forms.TextBox app_retry_timer;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_validate;
        private System.Windows.Forms.Button button_service;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox server_vhost;
        public System.Windows.Forms.TextBox app_main_timer;
        private System.Windows.Forms.Label templabel;
        private System.Windows.Forms.CheckBox app_cputemp;
    }
}