//References:
//https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.backgroundworker?view=netframework-4.8
//Microsoft Corporation

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfTester
{
    public partial class Compare : Form
    {
        private string screenshotPathStartFilename;
        private string screenshotPathCompareFilename;
        private string screenshotPathValidFilename;
        private string settingsFilename;
        private string error;
        private string info;
        private string maxHeight;
        private string orgCancelText;

        private Boolean cancel;

        private double diff;

        private Control con;
        public Compare()
        {
            InitializeComponent();
            screenshotPathStartFilename = Names.screenshotPathStartFilename;
            screenshotPathCompareFilename = Names.screenshotPathCompareFilename;
            screenshotPathValidFilename = Names.screenshotPathValidFilename;
            settingsFilename = Names.settingsFilename;
            error = Names.error;
            info = Names.info;
            maxHeight = Names.maxHeight;

            diff = Convert.ToDouble(Names.diffValue);

            backgroundWorkerCompare.WorkerReportsProgress = true;
            backgroundWorkerCompare.WorkerSupportsCancellation = true;

            con = new Control();
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            progressBarCompare.Minimum = 0;
            progressBarCompare.Value = progressBarCompare.Minimum;
            progressBarCompare.Step = 1;
            progressBarCompare.Visible = true;

            btnCancel.Enabled = false;
            btnCancel.Visible = false;

            orgCancelText = btnCancel.Text;

            cancel = false;

            string result = con.readConfig(screenshotPathCompareFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxScreenshotPath.AppendText(result);
            }
            else
            {
                result = con.readConfig(screenshotPathStartFilename);
                if (result.Length > 5)
                {
                    if (result.Substring(0, 6) == error)
                        MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        textBoxScreenshotPath.AppendText(result);
                }
            }
            textBoxScreenshotPath.Text = textBoxScreenshotPath.Text.Trim();

            result = con.readConfig(screenshotPathValidFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxScreenshotValidPath.AppendText(result);
            }
            textBoxScreenshotValidPath.Text = textBoxScreenshotValidPath.Text.Trim();


        }

        private void btnOpenScreenshot_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogScreenshot.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxScreenshotPath.Text = folderBrowserDialogScreenshot.SelectedPath;
                string resultWrite = con.writeConfig(textBoxScreenshotPath.Text, screenshotPathCompareFilename);
                if (resultWrite != "ok")
                    MessageBox.Show(resultWrite, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOpenScreenshotValid_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogValidScreenshot.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxScreenshotValidPath.Text = folderBrowserDialogValidScreenshot.SelectedPath;
                string resultWrite = con.writeConfig(textBoxScreenshotValidPath.Text, screenshotPathValidFilename);
                if (resultWrite != "ok")
                    MessageBox.Show(resultWrite, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnOpenScreenshot.Enabled = false;
            btnOpenScreenshotValid.Enabled = false;
            btnCancel.Enabled = true;

            btnStart.Visible = false;
            btnCancel.Visible = true;

            btnCancel.Text = orgCancelText;

            cancel = false;

            progressBarCompare.Value = progressBarCompare.Minimum;
            textBoxValidCompare.Text = "";
            textBoxAllCompare.Text = "";

            string result = con.readConfig(settingsFilename);
            if (result.Length > 2)
            {
                if (result.Length > 5 && result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        string[] split = result.Split(';');
                        double settingsDiff = Convert.ToDouble(split[2]);
                        diff = settingsDiff;
                    }
                    catch (Exception)
                    {
                        diff = Convert.ToDouble(Names.diffValue);
                        MessageBox.Show("Error: Difference value could not be converted." + Environment.NewLine + "Default value is used.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        string[] split = result.Split(';');
                        int settingsMaxHeight = Convert.ToInt32(split[3]);
                        maxHeight = split[3];
                    }
                    catch (Exception)
                    {
                        maxHeight = Names.maxHeight;
                        MessageBox.Show("Error: Value for maximum height could not be converted." + Environment.NewLine + "Default value is used.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (textBoxScreenshotPath.Text != "")
            {
                if (textBoxScreenshotValidPath.Text != "")
                { 
                    if (!Directory.Exists(textBoxScreenshotPath.Text))
                        MessageBox.Show("Error: the screenshot path '" + textBoxScreenshotPath.Text + "' does not exist.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (!Directory.Exists(textBoxScreenshotValidPath.Text))
                        MessageBox.Show("Error: the screenshot path '" + textBoxScreenshotValidPath.Text + "' does not exist.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        IEnumerable<string> count = Directory.GetFiles(textBoxScreenshotPath.Text.Trim(), "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".tif") || s.EndsWith(".tiff"));

                        progressBarCompare.Maximum = count.Count();

                        foreach (string pdfDoc in Directory.GetFiles(textBoxScreenshotPath.Text.Trim(), "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".tif") || s.EndsWith(".tiff")))
                        {
                            if (cancel == true)
                                break;

                            string[] testPdfName = pdfDoc.Split('_');
                            int t = 0;
                            foreach (string pdfDocValid in Directory.GetFiles(textBoxScreenshotValidPath.Text, "*.png", SearchOption.AllDirectories))
                            {
                                if (cancel == true)
                                    break;

                                string[] validPdfName = pdfDocValid.Split('_');
                                if (testPdfName[testPdfName.Length - 2] == validPdfName[validPdfName.Length - 2])
                                {
                                    t = 1;

                                    while (backgroundWorkerCompare.IsBusy == true)
                                    {
                                        await Task.Delay(500);
                                    }

                                    backgroundWorkerCompare.RunWorkerAsync(pdfDoc + ";" + pdfDocValid + ";" + maxHeight);

                                    while (backgroundWorkerCompare.IsBusy == true)
                                    {
                                        await Task.Delay(500);
                                    }
                                    progressBarCompare.PerformStep();
                                }
                            }
                            if (t == 0)
                                textBoxAllCompare.AppendText("No screenshot with matching program name to: '" + Path.GetFileName(pdfDoc).ToString() + "' existing." + Environment.NewLine);
                        }
                    }
                    progressBarCompare.Value = progressBarCompare.Maximum;
                }
                else
                {
                    MessageBox.Show("Please set a path to the valid screenshots.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please set a path to the screenshots.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            btnStart.Enabled = true;
            btnOpenScreenshot.Enabled = true;
            btnOpenScreenshotValid.Enabled = true;
            btnCancel.Enabled = false;

            btnStart.Visible = true;
            btnCancel.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Processing is canceled...";
            cancel = true;
            backgroundWorkerCompare.CancelAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            
            if (result != "")
            {
                try
                {
                    string[] split = result.Split(';');
                    double compareDiff = Convert.ToDouble(split[split.Length - 1]);
                    if (compareDiff <= diff)
                    {
                        textBoxValidCompare.AppendText(result + Environment.NewLine);
                        textBoxAllCompare.AppendText(result + Environment.NewLine);
                    }
                    else
                        textBoxAllCompare.AppendText(result + Environment.NewLine);
                }
                catch (Exception)
                {
                    textBoxAllCompare.AppendText(result + Environment.NewLine);
                } 
            } 
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argument = e.Argument.ToString().Split(';');
            string[] name1 = argument[0].Split('\\');
            string result = con.Compare(argument[0], argument[1], argument[2]);
            try
            {
                double compareDiff= Convert.ToDouble(result);
                e.Result = name1[name1.Length - 1] + "; Difference; " + result;
            }
            catch (Exception)
            {
                e.Result = name1[name1.Length - 1] + "; " + result;
            } 
        }        
    }
}
