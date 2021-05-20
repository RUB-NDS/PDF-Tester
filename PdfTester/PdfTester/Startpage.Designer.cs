namespace PdfTester
{
    partial class Startpage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up used resources.
        /// </summary>
        /// <param name="disposing">True if managed resources are to be deleted; otherwise False.</param>
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPdfPath = new System.Windows.Forms.TextBox();
            this.btnOpenPdf = new System.Windows.Forms.Button();
            this.btnOpenScreenshot = new System.Windows.Forms.Button();
            this.textBoxScreenshotsPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBarStart = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialogPdf = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogScreenshot = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxProgamList = new System.Windows.Forms.TextBox();
            this.btnOpenDebug = new System.Windows.Forms.Button();
            this.backgroundWorkerStart = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(487, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Input format: Application path;Name (optional);Waiting time for application start" +
    "up in seconds (optional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Example: C:\\Program Files (x86)\\Adobe\\Acrobat Reader DC\\Reader\\AcroRd32.exe;Adobe" +
    "DC;10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(590, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Path to the PDF documents to be checked:";
            // 
            // textBoxPdfPath
            // 
            this.textBoxPdfPath.Location = new System.Drawing.Point(593, 112);
            this.textBoxPdfPath.Name = "textBoxPdfPath";
            this.textBoxPdfPath.ReadOnly = true;
            this.textBoxPdfPath.Size = new System.Drawing.Size(560, 20);
            this.textBoxPdfPath.TabIndex = 2;
            // 
            // btnOpenPdf
            // 
            this.btnOpenPdf.Location = new System.Drawing.Point(593, 138);
            this.btnOpenPdf.Name = "btnOpenPdf";
            this.btnOpenPdf.Size = new System.Drawing.Size(98, 31);
            this.btnOpenPdf.TabIndex = 3;
            this.btnOpenPdf.Text = "Select folder";
            this.btnOpenPdf.UseVisualStyleBackColor = true;
            this.btnOpenPdf.Click += new System.EventHandler(this.BtnOpenPdf_Click);
            // 
            // btnOpenScreenshot
            // 
            this.btnOpenScreenshot.Location = new System.Drawing.Point(593, 258);
            this.btnOpenScreenshot.Name = "btnOpenScreenshot";
            this.btnOpenScreenshot.Size = new System.Drawing.Size(98, 31);
            this.btnOpenScreenshot.TabIndex = 5;
            this.btnOpenScreenshot.Text = "Select folder";
            this.btnOpenScreenshot.UseVisualStyleBackColor = true;
            this.btnOpenScreenshot.Click += new System.EventHandler(this.BtnOpenScreenshot_Click);
            // 
            // textBoxScreenshotsPath
            // 
            this.textBoxScreenshotsPath.Location = new System.Drawing.Point(593, 232);
            this.textBoxScreenshotsPath.Name = "textBoxScreenshotsPath";
            this.textBoxScreenshotsPath.ReadOnly = true;
            this.textBoxScreenshotsPath.Size = new System.Drawing.Size(560, 20);
            this.textBoxScreenshotsPath.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(590, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Path to the screenshots to be created:";
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(593, 580);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(98, 31);
            this.btnSaveAll.TabIndex = 8;
            this.btnSaveAll.Text = "Save inputs";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.BtnSaveAll_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(593, 496);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(560, 58);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Launch Screenshot Creator";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // progressBarStart
            // 
            this.progressBarStart.Location = new System.Drawing.Point(593, 467);
            this.progressBarStart.Name = "progressBarStart";
            this.progressBarStart.Size = new System.Drawing.Size(560, 23);
            this.progressBarStart.Step = 1;
            this.progressBarStart.TabIndex = 6;
            // 
            // textBoxProgamList
            // 
            this.textBoxProgamList.Location = new System.Drawing.Point(35, 93);
            this.textBoxProgamList.Multiline = true;
            this.textBoxProgamList.Name = "textBoxProgamList";
            this.textBoxProgamList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProgamList.Size = new System.Drawing.Size(500, 518);
            this.textBoxProgamList.TabIndex = 2;
            // 
            // btnOpenDebug
            // 
            this.btnOpenDebug.Location = new System.Drawing.Point(1055, 580);
            this.btnOpenDebug.Name = "btnOpenDebug";
            this.btnOpenDebug.Size = new System.Drawing.Size(98, 31);
            this.btnOpenDebug.TabIndex = 9;
            this.btnOpenDebug.Text = "Open debug file";
            this.btnOpenDebug.UseVisualStyleBackColor = true;
            this.btnOpenDebug.Click += new System.EventHandler(this.BtnOpenDebug_Click);
            // 
            // backgroundWorkerStart
            // 
            this.backgroundWorkerStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorkerStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(593, 497);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(560, 58);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel processing";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "List of PDF applications:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PdfTester.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(1105, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 60);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Startpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenDebug);
            this.Controls.Add(this.textBoxProgamList);
            this.Controls.Add(this.progressBarStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.btnOpenScreenshot);
            this.Controls.Add(this.textBoxScreenshotsPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOpenPdf);
            this.Controls.Add(this.textBoxPdfPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Startpage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Creator";
            this.Load += new System.EventHandler(this.Startpage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPdfPath;
        private System.Windows.Forms.Button btnOpenPdf;
        private System.Windows.Forms.Button btnOpenScreenshot;
        private System.Windows.Forms.TextBox textBoxScreenshotsPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBarStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPdf;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogScreenshot;
        private System.Windows.Forms.TextBox textBoxProgamList;
        private System.Windows.Forms.Button btnOpenDebug;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

