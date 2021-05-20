namespace PdfTester
{
    partial class Ocr
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
            this.btnOpenScreenshot = new System.Windows.Forms.Button();
            this.textBoxScreenshotPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarOcr = new System.Windows.Forms.ProgressBar();
            this.textBoxInformations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchStrings = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxFounds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenTxt = new System.Windows.Forms.Button();
            this.textBoxTxtPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialogScreenshot = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogTxt = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorkerOcr = new System.ComponentModel.BackgroundWorker();
            this.checkBoxLargeImg = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxGrayscale = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOpenScreenshot
            // 
            this.btnOpenScreenshot.Location = new System.Drawing.Point(17, 57);
            this.btnOpenScreenshot.Name = "btnOpenScreenshot";
            this.btnOpenScreenshot.Size = new System.Drawing.Size(98, 31);
            this.btnOpenScreenshot.TabIndex = 3;
            this.btnOpenScreenshot.Text = "Select folder";
            this.btnOpenScreenshot.UseVisualStyleBackColor = true;
            this.btnOpenScreenshot.Click += new System.EventHandler(this.BtnOpenScreenshot_Click);
            // 
            // textBoxScreenshotPath
            // 
            this.textBoxScreenshotPath.Location = new System.Drawing.Point(17, 31);
            this.textBoxScreenshotPath.Name = "textBoxScreenshotPath";
            this.textBoxScreenshotPath.ReadOnly = true;
            this.textBoxScreenshotPath.Size = new System.Drawing.Size(539, 20);
            this.textBoxScreenshotPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Path to the screenshots of PDF documents to be checked:";
            // 
            // progressBarOcr
            // 
            this.progressBarOcr.Location = new System.Drawing.Point(598, 31);
            this.progressBarOcr.Name = "progressBarOcr";
            this.progressBarOcr.Size = new System.Drawing.Size(560, 23);
            this.progressBarOcr.TabIndex = 36;
            // 
            // textBoxInformations
            // 
            this.textBoxInformations.Location = new System.Drawing.Point(17, 505);
            this.textBoxInformations.Multiline = true;
            this.textBoxInformations.Name = "textBoxInformations";
            this.textBoxInformations.ReadOnly = true;
            this.textBoxInformations.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInformations.Size = new System.Drawing.Size(1141, 110);
            this.textBoxInformations.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Other messages:";
            // 
            // textBoxSearchStrings
            // 
            this.textBoxSearchStrings.Location = new System.Drawing.Point(17, 218);
            this.textBoxSearchStrings.Multiline = true;
            this.textBoxSearchStrings.Name = "textBoxSearchStrings";
            this.textBoxSearchStrings.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSearchStrings.Size = new System.Drawing.Size(539, 256);
            this.textBoxSearchStrings.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Search terms (one string per line):";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(598, 57);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(560, 58);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Launch Screenshot Analyzer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // textBoxFounds
            // 
            this.textBoxFounds.Location = new System.Drawing.Point(598, 218);
            this.textBoxFounds.Multiline = true;
            this.textBoxFounds.Name = "textBoxFounds";
            this.textBoxFounds.ReadOnly = true;
            this.textBoxFounds.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFounds.Size = new System.Drawing.Size(560, 256);
            this.textBoxFounds.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(595, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Found search terms in screenshot:";
            // 
            // btnOpenTxt
            // 
            this.btnOpenTxt.Location = new System.Drawing.Point(17, 149);
            this.btnOpenTxt.Name = "btnOpenTxt";
            this.btnOpenTxt.Size = new System.Drawing.Size(98, 31);
            this.btnOpenTxt.TabIndex = 5;
            this.btnOpenTxt.Text = "Select folder";
            this.btnOpenTxt.UseVisualStyleBackColor = true;
            this.btnOpenTxt.Click += new System.EventHandler(this.BtnOpenTxt_Click);
            // 
            // textBoxTxtPath
            // 
            this.textBoxTxtPath.Location = new System.Drawing.Point(17, 123);
            this.textBoxTxtPath.Name = "textBoxTxtPath";
            this.textBoxTxtPath.ReadOnly = true;
            this.textBoxTxtPath.Size = new System.Drawing.Size(539, 20);
            this.textBoxTxtPath.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Path to save the recognized text to a file:";
            // 
            // backgroundWorkerOcr
            // 
            this.backgroundWorkerOcr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerOcr_DoWork);
            this.backgroundWorkerOcr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerOcr_RunWorkerCompleted);
            // 
            // checkBoxLargeImg
            // 
            this.checkBoxLargeImg.AutoSize = true;
            this.checkBoxLargeImg.Checked = true;
            this.checkBoxLargeImg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLargeImg.Location = new System.Drawing.Point(598, 140);
            this.checkBoxLargeImg.Name = "checkBoxLargeImg";
            this.checkBoxLargeImg.Size = new System.Drawing.Size(380, 17);
            this.checkBoxLargeImg.TabIndex = 6;
            this.checkBoxLargeImg.Text = "Perform OCR text recognition additionally with upscaled screenshot (slower)";
            this.checkBoxLargeImg.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(598, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(560, 58);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel processing";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // checkBoxGrayscale
            // 
            this.checkBoxGrayscale.AutoSize = true;
            this.checkBoxGrayscale.Checked = true;
            this.checkBoxGrayscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrayscale.Location = new System.Drawing.Point(598, 121);
            this.checkBoxGrayscale.Name = "checkBoxGrayscale";
            this.checkBoxGrayscale.Size = new System.Drawing.Size(382, 17);
            this.checkBoxGrayscale.TabIndex = 43;
            this.checkBoxGrayscale.Text = "Perform OCR text recognition additionally with grayscale screenshot (slower)";
            this.checkBoxGrayscale.UseVisualStyleBackColor = true;
            // 
            // Ocr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxGrayscale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkBoxLargeImg);
            this.Controls.Add(this.btnOpenTxt);
            this.Controls.Add(this.textBoxTxtPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFounds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenScreenshot);
            this.Controls.Add(this.textBoxScreenshotPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBarOcr);
            this.Controls.Add(this.textBoxInformations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearchStrings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ocr";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "OCR Analyzer";
            this.Load += new System.EventHandler(this.Ocr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenScreenshot;
        private System.Windows.Forms.TextBox textBoxScreenshotPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarOcr;
        private System.Windows.Forms.TextBox textBoxInformations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchStrings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxFounds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenTxt;
        private System.Windows.Forms.TextBox textBoxTxtPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogScreenshot;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTxt;
        private System.ComponentModel.BackgroundWorker backgroundWorkerOcr;
        private System.Windows.Forms.CheckBox checkBoxLargeImg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxGrayscale;
    }
}