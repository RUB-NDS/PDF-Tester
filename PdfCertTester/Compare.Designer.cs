namespace PdfCertTester
{
    partial class Compare
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
            this.btnOpenPdf = new System.Windows.Forms.Button();
            this.textBoxPdfPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxValidCompare = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAllCompare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarCompare = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialogPdf = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorkerCompare = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnOpenPdf
            // 
            this.btnOpenPdf.Location = new System.Drawing.Point(17, 57);
            this.btnOpenPdf.Name = "btnOpenPdf";
            this.btnOpenPdf.Size = new System.Drawing.Size(98, 31);
            this.btnOpenPdf.TabIndex = 15;
            this.btnOpenPdf.Text = "Ordner wählen";
            this.btnOpenPdf.UseVisualStyleBackColor = true;
            this.btnOpenPdf.Click += new System.EventHandler(this.BtnOpenPdf_Click);
            // 
            // textBoxPdfPath
            // 
            this.textBoxPdfPath.Location = new System.Drawing.Point(17, 31);
            this.textBoxPdfPath.Name = "textBoxPdfPath";
            this.textBoxPdfPath.ReadOnly = true;
            this.textBoxPdfPath.Size = new System.Drawing.Size(539, 20);
            this.textBoxPdfPath.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pfadangabe zu Screenshots von validen PDF Dokumenten:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(598, 57);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(560, 58);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Screenshot Vergleich starten";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // textBoxValidCompare
            // 
            this.textBoxValidCompare.Location = new System.Drawing.Point(17, 149);
            this.textBoxValidCompare.Multiline = true;
            this.textBoxValidCompare.Name = "textBoxValidCompare";
            this.textBoxValidCompare.ReadOnly = true;
            this.textBoxValidCompare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxValidCompare.Size = new System.Drawing.Size(539, 466);
            this.textBoxValidCompare.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Erfolgreiche Vergleiche + Differenz:";
            // 
            // textBoxAllCompare
            // 
            this.textBoxAllCompare.Location = new System.Drawing.Point(598, 149);
            this.textBoxAllCompare.Multiline = true;
            this.textBoxAllCompare.Name = "textBoxAllCompare";
            this.textBoxAllCompare.ReadOnly = true;
            this.textBoxAllCompare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAllCompare.Size = new System.Drawing.Size(560, 466);
            this.textBoxAllCompare.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(595, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Gesamter Verlauf + Differenz:";
            // 
            // progressBarCompare
            // 
            this.progressBarCompare.Location = new System.Drawing.Point(598, 31);
            this.progressBarCompare.Name = "progressBarCompare";
            this.progressBarCompare.Size = new System.Drawing.Size(560, 23);
            this.progressBarCompare.TabIndex = 27;
            // 
            // backgroundWorkerCompare
            // 
            this.backgroundWorkerCompare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorkerCompare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarCompare);
            this.Controls.Add(this.textBoxAllCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxValidCompare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOpenPdf);
            this.Controls.Add(this.textBoxPdfPath);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Compare";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Vergleich";
            this.Load += new System.EventHandler(this.Compare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenPdf;
        private System.Windows.Forms.TextBox textBoxPdfPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxValidCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAllCompare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarCompare;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPdf;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCompare;
    }
}