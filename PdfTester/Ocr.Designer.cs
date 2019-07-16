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
            this.SuspendLayout();
            // 
            // btnOpenScreenshot
            // 
            this.btnOpenScreenshot.Location = new System.Drawing.Point(17, 57);
            this.btnOpenScreenshot.Name = "btnOpenScreenshot";
            this.btnOpenScreenshot.Size = new System.Drawing.Size(98, 31);
            this.btnOpenScreenshot.TabIndex = 39;
            this.btnOpenScreenshot.Text = "Ordner wählen";
            this.btnOpenScreenshot.UseVisualStyleBackColor = true;
            this.btnOpenScreenshot.Click += new System.EventHandler(this.BtnOpenScreenshot_Click);
            // 
            // textBoxScreenshotPath
            // 
            this.textBoxScreenshotPath.Location = new System.Drawing.Point(17, 31);
            this.textBoxScreenshotPath.Name = "textBoxScreenshotPath";
            this.textBoxScreenshotPath.ReadOnly = true;
            this.textBoxScreenshotPath.Size = new System.Drawing.Size(539, 20);
            this.textBoxScreenshotPath.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Pfadangabe zu Screenshots von zu überprüfenden PDF Dokumenten:";
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
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Weitere Meldungen:";
            // 
            // textBoxSearchStrings
            // 
            this.textBoxSearchStrings.Location = new System.Drawing.Point(17, 218);
            this.textBoxSearchStrings.Multiline = true;
            this.textBoxSearchStrings.Name = "textBoxSearchStrings";
            this.textBoxSearchStrings.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSearchStrings.Size = new System.Drawing.Size(539, 256);
            this.textBoxSearchStrings.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Suchbegriffe (ein String pro Zeile):";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(598, 57);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(560, 58);
            this.btnStart.TabIndex = 31;
            this.btnStart.Text = "Screenshot Analyse starten";
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
            this.label4.Size = new System.Drawing.Size(194, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Gefundene Suchbegriffe in Screenshot:";
            // 
            // btnOpenTxt
            // 
            this.btnOpenTxt.Location = new System.Drawing.Point(17, 149);
            this.btnOpenTxt.Name = "btnOpenTxt";
            this.btnOpenTxt.Size = new System.Drawing.Size(98, 31);
            this.btnOpenTxt.TabIndex = 44;
            this.btnOpenTxt.Text = "Ordner wählen";
            this.btnOpenTxt.UseVisualStyleBackColor = true;
            this.btnOpenTxt.Click += new System.EventHandler(this.BtnOpenTxt_Click);
            // 
            // textBoxTxtPath
            // 
            this.textBoxTxtPath.Location = new System.Drawing.Point(17, 123);
            this.textBoxTxtPath.Name = "textBoxTxtPath";
            this.textBoxTxtPath.ReadOnly = true;
            this.textBoxTxtPath.Size = new System.Drawing.Size(539, 20);
            this.textBoxTxtPath.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Pfadangabe zum Speichern des erkannten Textes in eine Datei:";
            // 
            // backgroundWorkerOcr
            // 
            this.backgroundWorkerOcr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerOcr_DoWork);
            this.backgroundWorkerOcr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerOcr_RunWorkerCompleted);
            // 
            // checkBoxLargeImg
            // 
            this.checkBoxLargeImg.AutoSize = true;
            this.checkBoxLargeImg.Location = new System.Drawing.Point(598, 125);
            this.checkBoxLargeImg.Name = "checkBoxLargeImg";
            this.checkBoxLargeImg.Size = new System.Drawing.Size(437, 17);
            this.checkBoxLargeImg.TabIndex = 45;
            this.checkBoxLargeImg.Text = "Führe OCR Texterkennung zusätzlich mit hochskaliertem Screenshot durch (langsamer" +
    ")";
            this.checkBoxLargeImg.UseVisualStyleBackColor = true;
            // 
            // Ocr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
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
            this.Text = "OCR";
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
    }
}