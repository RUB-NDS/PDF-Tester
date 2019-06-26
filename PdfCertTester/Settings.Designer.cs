namespace PdfCertTester
{
    partial class Settings
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
            this.textBoxWaitTime1 = new System.Windows.Forms.TextBox();
            this.textBoxWaitTime2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveWaitTime = new System.Windows.Forms.Button();
            this.textBoxDiffValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wartezeit bevor das PDF Betrachtungsprogramm geschlossen wird (in Sekunden):";
            // 
            // textBoxWaitTime1
            // 
            this.textBoxWaitTime1.Location = new System.Drawing.Point(32, 42);
            this.textBoxWaitTime1.MaxLength = 3;
            this.textBoxWaitTime1.Name = "textBoxWaitTime1";
            this.textBoxWaitTime1.Size = new System.Drawing.Size(100, 20);
            this.textBoxWaitTime1.TabIndex = 1;
            // 
            // textBoxWaitTime2
            // 
            this.textBoxWaitTime2.Location = new System.Drawing.Point(32, 106);
            this.textBoxWaitTime2.MaxLength = 3;
            this.textBoxWaitTime2.Name = "textBoxWaitTime2";
            this.textBoxWaitTime2.Size = new System.Drawing.Size(100, 20);
            this.textBoxWaitTime2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wartezeit nachdem das PDF Betrachtungsprogramm geschlossen wurde (in Sekunden):";
            // 
            // btnSaveWaitTime
            // 
            this.btnSaveWaitTime.Location = new System.Drawing.Point(32, 210);
            this.btnSaveWaitTime.Name = "btnSaveWaitTime";
            this.btnSaveWaitTime.Size = new System.Drawing.Size(100, 33);
            this.btnSaveWaitTime.TabIndex = 4;
            this.btnSaveWaitTime.Text = "Speichern";
            this.btnSaveWaitTime.UseVisualStyleBackColor = true;
            this.btnSaveWaitTime.Click += new System.EventHandler(this.BtnSaveWaitTime_Click);
            // 
            // textBoxDiffValue
            // 
            this.textBoxDiffValue.Location = new System.Drawing.Point(32, 169);
            this.textBoxDiffValue.MaxLength = 7;
            this.textBoxDiffValue.Name = "textBoxDiffValue";
            this.textBoxDiffValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxDiffValue.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mindest-Differenzgrenze für Screenshotvergleich (Fließkommazahl)";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxDiffValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveWaitTime);
            this.Controls.Add(this.textBoxWaitTime2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWaitTime1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWaitTime1;
        private System.Windows.Forms.TextBox textBoxWaitTime2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveWaitTime;
        private System.Windows.Forms.TextBox textBoxDiffValue;
        private System.Windows.Forms.Label label3;
    }
}