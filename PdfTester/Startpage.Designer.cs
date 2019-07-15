namespace PdfCertTester
{
    partial class Startpage
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startpage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPdfPath = new System.Windows.Forms.TextBox();
            this.btnOpenPdf = new System.Windows.Forms.Button();
            this.btnOpenScreenshot = new System.Windows.Forms.Button();
            this.textBoxScreenshotsPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBarStart = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialogPdf = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogScreenshot = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxProgamList = new System.Windows.Forms.TextBox();
            this.btnOpenDebug = new System.Windows.Forms.Button();
            this.backgroundWorkerStart = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "PDF Programmliste";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Eingabeformat: Programmpfad;Name (optional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(449, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Beispiel: C:\\Program Files (x86)\\Adobe\\Acrobat Reader DC\\Reader\\AcroRd32.exe;Adob" +
    "eDC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(588, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "PDF Dateien";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(590, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pfadangabe:";
            // 
            // textBoxPdfPath
            // 
            this.textBoxPdfPath.Location = new System.Drawing.Point(593, 90);
            this.textBoxPdfPath.Name = "textBoxPdfPath";
            this.textBoxPdfPath.ReadOnly = true;
            this.textBoxPdfPath.Size = new System.Drawing.Size(560, 20);
            this.textBoxPdfPath.TabIndex = 10;
            // 
            // btnOpenPdf
            // 
            this.btnOpenPdf.Location = new System.Drawing.Point(593, 116);
            this.btnOpenPdf.Name = "btnOpenPdf";
            this.btnOpenPdf.Size = new System.Drawing.Size(98, 31);
            this.btnOpenPdf.TabIndex = 11;
            this.btnOpenPdf.Text = "Ordner wählen";
            this.btnOpenPdf.UseVisualStyleBackColor = true;
            this.btnOpenPdf.Click += new System.EventHandler(this.BtnOpenPdf_Click);
            // 
            // btnOpenScreenshot
            // 
            this.btnOpenScreenshot.Location = new System.Drawing.Point(593, 295);
            this.btnOpenScreenshot.Name = "btnOpenScreenshot";
            this.btnOpenScreenshot.Size = new System.Drawing.Size(98, 31);
            this.btnOpenScreenshot.TabIndex = 15;
            this.btnOpenScreenshot.Text = "Ordner wählen";
            this.btnOpenScreenshot.UseVisualStyleBackColor = true;
            this.btnOpenScreenshot.Click += new System.EventHandler(this.BtnOpenScreenshot_Click);
            // 
            // textBoxScreenshotsPath
            // 
            this.textBoxScreenshotsPath.Location = new System.Drawing.Point(593, 269);
            this.textBoxScreenshotsPath.Name = "textBoxScreenshotsPath";
            this.textBoxScreenshotsPath.ReadOnly = true;
            this.textBoxScreenshotsPath.Size = new System.Drawing.Size(560, 20);
            this.textBoxScreenshotsPath.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pfadangabe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(588, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ablageort Screenshots";
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(593, 580);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(98, 31);
            this.btnSaveAll.TabIndex = 16;
            this.btnSaveAll.Text = "Speichern";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.BtnSaveAll_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(593, 496);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(560, 58);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "PDF Tester starten";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // progressBarStart
            // 
            this.progressBarStart.Location = new System.Drawing.Point(593, 467);
            this.progressBarStart.Name = "progressBarStart";
            this.progressBarStart.Size = new System.Drawing.Size(560, 23);
            this.progressBarStart.Step = 1;
            this.progressBarStart.TabIndex = 18;
            // 
            // textBoxProgamList
            // 
            this.textBoxProgamList.Location = new System.Drawing.Point(31, 90);
            this.textBoxProgamList.Multiline = true;
            this.textBoxProgamList.Name = "textBoxProgamList";
            this.textBoxProgamList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProgamList.Size = new System.Drawing.Size(500, 520);
            this.textBoxProgamList.TabIndex = 19;
            // 
            // btnOpenDebug
            // 
            this.btnOpenDebug.Location = new System.Drawing.Point(1055, 580);
            this.btnOpenDebug.Name = "btnOpenDebug";
            this.btnOpenDebug.Size = new System.Drawing.Size(98, 31);
            this.btnOpenDebug.TabIndex = 20;
            this.btnOpenDebug.Text = "Debug öffnen";
            this.btnOpenDebug.UseVisualStyleBackColor = true;
            this.btnOpenDebug.Click += new System.EventHandler(this.BtnOpenDebug_Click);
            // 
            // backgroundWorkerStart
            // 
            this.backgroundWorkerStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorkerStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // Startpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.btnOpenDebug);
            this.Controls.Add(this.textBoxProgamList);
            this.Controls.Add(this.progressBarStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.btnOpenScreenshot);
            this.Controls.Add(this.textBoxScreenshotsPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOpenPdf);
            this.Controls.Add(this.textBoxPdfPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Startpage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Startpage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPdfPath;
        private System.Windows.Forms.Button btnOpenPdf;
        private System.Windows.Forms.Button btnOpenScreenshot;
        private System.Windows.Forms.TextBox textBoxScreenshotsPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBarStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPdf;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogScreenshot;
        private System.Windows.Forms.TextBox textBoxProgamList;
        private System.Windows.Forms.Button btnOpenDebug;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStart;
    }
}

