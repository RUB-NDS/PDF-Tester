namespace PdfTester
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
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.textBoxDiffValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaxHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialogTesseract = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOpenTesseract = new System.Windows.Forms.Button();
            this.textBoxTesseractPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxOcrLanguage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTessdata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Waiting time before closing the PDF application (in seconds):";
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
            this.textBoxWaitTime2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Waiting time after the PDF application was closed (in seconds):";
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(32, 472);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(100, 33);
            this.btnSaveAll.TabIndex = 0;
            this.btnSaveAll.Text = "Save settings";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.BtnSaveAll_Click);
            // 
            // textBoxDiffValue
            // 
            this.textBoxDiffValue.Location = new System.Drawing.Point(32, 169);
            this.textBoxDiffValue.MaxLength = 7;
            this.textBoxDiffValue.Name = "textBoxDiffValue";
            this.textBoxDiffValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxDiffValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(366, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Difference limit for successful screenshot comparison (floating point number):";
            // 
            // textBoxMaxHeight
            // 
            this.textBoxMaxHeight.Location = new System.Drawing.Point(32, 232);
            this.textBoxMaxHeight.MaxLength = 4;
            this.textBoxMaxHeight.Name = "textBoxMaxHeight";
            this.textBoxMaxHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxHeight.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(345, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maximum image height to consider for screenshot comparison (in pixels):";
            // 
            // btnOpenTesseract
            // 
            this.btnOpenTesseract.Location = new System.Drawing.Point(32, 396);
            this.btnOpenTesseract.Name = "btnOpenTesseract";
            this.btnOpenTesseract.Size = new System.Drawing.Size(98, 31);
            this.btnOpenTesseract.TabIndex = 7;
            this.btnOpenTesseract.Text = "Select folder";
            this.btnOpenTesseract.UseVisualStyleBackColor = true;
            this.btnOpenTesseract.Click += new System.EventHandler(this.BtnOpenTesseract_Click);
            // 
            // textBoxTesseractPath
            // 
            this.textBoxTesseractPath.Location = new System.Drawing.Point(32, 370);
            this.textBoxTesseractPath.Name = "textBoxTesseractPath";
            this.textBoxTesseractPath.ReadOnly = true;
            this.textBoxTesseractPath.Size = new System.Drawing.Size(560, 20);
            this.textBoxTesseractPath.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Path to the Tesseract folder:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(584, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Note: The language packages must be present as \"xyz.traineddata\" file in the \"tes" +
    "sdata\" subfolder of the Tesseract folder:";
            // 
            // comboBoxOcrLanguage
            // 
            this.comboBoxOcrLanguage.FormattingEnabled = true;
            this.comboBoxOcrLanguage.Location = new System.Drawing.Point(32, 309);
            this.comboBoxOcrLanguage.Name = "comboBoxOcrLanguage";
            this.comboBoxOcrLanguage.Size = new System.Drawing.Size(100, 21);
            this.comboBoxOcrLanguage.TabIndex = 5;
            this.comboBoxOcrLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOcrLanguage_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Language selection for OCR text recognition:";
            // 
            // labelTessdata
            // 
            this.labelTessdata.AutoSize = true;
            this.labelTessdata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTessdata.Location = new System.Drawing.Point(135, 312);
            this.labelTessdata.Name = "labelTessdata";
            this.labelTessdata.Size = new System.Drawing.Size(0, 13);
            this.labelTessdata.TabIndex = 18;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.labelTessdata);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxOcrLanguage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOpenTesseract);
            this.Controls.Add(this.textBoxTesseractPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMaxHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDiffValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.textBoxWaitTime2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWaitTime1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWaitTime1;
        private System.Windows.Forms.TextBox textBoxWaitTime2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.TextBox textBoxDiffValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaxHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTesseract;
        private System.Windows.Forms.Button btnOpenTesseract;
        private System.Windows.Forms.TextBox textBoxTesseractPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxOcrLanguage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTessdata;
    }
}