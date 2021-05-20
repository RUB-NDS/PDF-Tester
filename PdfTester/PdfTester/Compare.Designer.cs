namespace PdfTester
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
            this.btnOpenScreenshotValid = new System.Windows.Forms.Button();
            this.textBoxScreenshotValidPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxValidCompare = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAllCompare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarCompare = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialogValidScreenshot = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorkerCompare = new System.ComponentModel.BackgroundWorker();
            this.btnOpenScreenshot = new System.Windows.Forms.Button();
            this.textBoxScreenshotPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialogScreenshot = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenScreenshotValid
            // 
            this.btnOpenScreenshotValid.Location = new System.Drawing.Point(17, 149);
            this.btnOpenScreenshotValid.Name = "btnOpenScreenshotValid";
            this.btnOpenScreenshotValid.Size = new System.Drawing.Size(98, 31);
            this.btnOpenScreenshotValid.TabIndex = 5;
            this.btnOpenScreenshotValid.Text = "Select folder";
            this.btnOpenScreenshotValid.UseVisualStyleBackColor = true;
            this.btnOpenScreenshotValid.Click += new System.EventHandler(this.BtnOpenScreenshotValid_Click);
            // 
            // textBoxScreenshotValidPath
            // 
            this.textBoxScreenshotValidPath.Location = new System.Drawing.Point(17, 123);
            this.textBoxScreenshotValidPath.Name = "textBoxScreenshotValidPath";
            this.textBoxScreenshotValidPath.ReadOnly = true;
            this.textBoxScreenshotValidPath.Size = new System.Drawing.Size(539, 20);
            this.textBoxScreenshotValidPath.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(315, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Path to the screenshots of valid PDF documents:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(598, 57);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(560, 58);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Launch Screenshot Comparer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // textBoxValidCompare
            // 
            this.textBoxValidCompare.Location = new System.Drawing.Point(17, 231);
            this.textBoxValidCompare.Multiline = true;
            this.textBoxValidCompare.Name = "textBoxValidCompare";
            this.textBoxValidCompare.ReadOnly = true;
            this.textBoxValidCompare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxValidCompare.Size = new System.Drawing.Size(539, 384);
            this.textBoxValidCompare.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Successful comparisons:";
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
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "All messages:";
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
            // btnOpenScreenshot
            // 
            this.btnOpenScreenshot.Location = new System.Drawing.Point(17, 57);
            this.btnOpenScreenshot.Name = "btnOpenScreenshot";
            this.btnOpenScreenshot.Size = new System.Drawing.Size(98, 31);
            this.btnOpenScreenshot.TabIndex = 3;
            this.btnOpenScreenshot.Text = "Select folder";
            this.btnOpenScreenshot.UseVisualStyleBackColor = true;
            this.btnOpenScreenshot.Click += new System.EventHandler(this.btnOpenScreenshot_Click);
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
            this.label2.TabIndex = 28;
            this.label2.Text = "Path to the screenshots of PDF documents to be checked:";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(598, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(560, 58);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel processing";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenScreenshot);
            this.Controls.Add(this.textBoxScreenshotPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBarCompare);
            this.Controls.Add(this.textBoxAllCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxValidCompare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOpenScreenshotValid);
            this.Controls.Add(this.textBoxScreenshotValidPath);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Compare";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Comparer";
            this.Load += new System.EventHandler(this.Compare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenScreenshotValid;
        private System.Windows.Forms.TextBox textBoxScreenshotValidPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxValidCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAllCompare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarCompare;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogValidScreenshot;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCompare;
        private System.Windows.Forms.Button btnOpenScreenshot;
        private System.Windows.Forms.TextBox textBoxScreenshotPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogScreenshot;
        private System.Windows.Forms.Button btnCancel;
    }
}