namespace Psistats.App
{
    partial class DoerBox
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
            this.ok = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Enabled = false;
            this.ok.Location = new System.Drawing.Point(141, 120);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar.ForeColor = System.Drawing.Color.LawnGreen;
            this.progressBar.Location = new System.Drawing.Point(12, 91);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(340, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            this.progressBar.Value = 50;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(13, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(339, 79);
            this.label.TabIndex = 2;
            this.label.Text = "hahaha";
            // 
            // DoerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(364, 155);
            this.Controls.Add(this.label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoerBox";
            this.Text = "DoerBox";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ok;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label label;
    }
}