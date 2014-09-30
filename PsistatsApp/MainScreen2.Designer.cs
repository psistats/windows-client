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
            this.label1 = new System.Windows.Forms.Label();
            this.service_status_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cpu_meter_percentage_label = new System.Windows.Forms.Label();
            this.button_settings = new System.Windows.Forms.Button();
            this.button_service = new System.Windows.Forms.Button();
            this.cpu_meter_background = new System.Windows.Forms.Panel();
            this.cpu_meter_bar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label_notifications = new System.Windows.Forms.Label();
            this.cpu_meter_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service Status:";
            // 
            // service_status_label
            // 
            this.service_status_label.AutoSize = true;
            this.service_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.service_status_label.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.service_status_label.Location = new System.Drawing.Point(190, 73);
            this.service_status_label.Name = "service_status_label";
            this.service_status_label.Size = new System.Drawing.Size(41, 31);
            this.service_status_label.TabIndex = 2;
            this.service_status_label.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "CPU Usage (%)";
            // 
            // cpu_meter_percentage_label
            // 
            this.cpu_meter_percentage_label.AutoSize = true;
            this.cpu_meter_percentage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cpu_meter_percentage_label.Location = new System.Drawing.Point(168, 155);
            this.cpu_meter_percentage_label.Name = "cpu_meter_percentage_label";
            this.cpu_meter_percentage_label.Size = new System.Drawing.Size(32, 20);
            this.cpu_meter_percentage_label.TabIndex = 4;
            this.cpu_meter_percentage_label.Text = "0%";
            // 
            // button_settings
            // 
            this.button_settings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_settings.Location = new System.Drawing.Point(466, 73);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(142, 32);
            this.button_settings.TabIndex = 1;
            this.button_settings.Text = "Settings";
            this.button_settings.UseVisualStyleBackColor = false;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // button_service
            // 
            this.button_service.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_service.Enabled = false;
            this.button_service.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_service.Location = new System.Drawing.Point(318, 73);
            this.button_service.Name = "button_service";
            this.button_service.Size = new System.Drawing.Size(142, 32);
            this.button_service.TabIndex = 5;
            this.button_service.Text = "Start Service";
            this.button_service.UseVisualStyleBackColor = false;
            this.button_service.Click += new System.EventHandler(this.ResizeExpand);
            // 
            // cpu_meter_background
            // 
            this.cpu_meter_background.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cpu_meter_background.Controls.Add(this.cpu_meter_bar);
            this.cpu_meter_background.Location = new System.Drawing.Point(17, 131);
            this.cpu_meter_background.Name = "cpu_meter_background";
            this.cpu_meter_background.Size = new System.Drawing.Size(200, 17);
            this.cpu_meter_background.TabIndex = 6;
            // 
            // cpu_meter_bar
            // 
            this.cpu_meter_bar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.cpu_meter_bar.Location = new System.Drawing.Point(0, 0);
            this.cpu_meter_bar.Margin = new System.Windows.Forms.Padding(0);
            this.cpu_meter_bar.Name = "cpu_meter_bar";
            this.cpu_meter_bar.Size = new System.Drawing.Size(200, 17);
            this.cpu_meter_bar.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 73);
            this.label4.TabIndex = 7;
            this.label4.Text = "Psistats";
            // 
            // label_notifications
            // 
            this.label_notifications.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_notifications.Location = new System.Drawing.Point(252, 6);
            this.label_notifications.Name = "label_notifications";
            this.label_notifications.Size = new System.Drawing.Size(356, 19);
            this.label_notifications.TabIndex = 8;
            this.label_notifications.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainScreen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(624, 112);
            this.Controls.Add(this.label_notifications);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cpu_meter_background);
            this.Controls.Add(this.button_service);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.cpu_meter_percentage_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.service_status_label);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainScreen2";
            this.Text = "Psistats";
            this.Load += new System.EventHandler(this.MainScreen2_Load);
            this.cpu_meter_background.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cpu_meter_percentage_label;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.Panel cpu_meter_background;
        private System.Windows.Forms.Panel cpu_meter_bar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_notifications;
        public System.Windows.Forms.Label service_status_label;
        public System.Windows.Forms.Button button_service;



    }
}