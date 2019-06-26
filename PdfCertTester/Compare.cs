//Quellen:
//https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.backgroundworker?view=netframework-4.8
//Microsoft Corporation, abgerufen am 11.06.2019

using System;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfCertTester
{
    public partial class Compare : Form
    {
        private string path;
        private string pdfValidPathFilename;
        private string screenshotPathFilename;
        private string settingsFilename;
        private string error;
        private string info;

        private double diff;

        private Control con;
        public Compare()
        {
            InitializeComponent();
            path = Names.path;
            pdfValidPathFilename = Names.pdfValidPathFilename;
            screenshotPathFilename = Names.screenshotPathFilename;
            settingsFilename = Names.settingsFilename;
            error = Names.error;
            info = Names.info;

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
            
            string result = con.readConfig(pdfValidPathFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxPdfPath.AppendText(result);
            }
            textBoxPdfPath.Text = textBoxPdfPath.Text.Trim();

            
        }
        private void BtnOpenPdf_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogPdf.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxPdfPath.Text = folderBrowserDialogPdf.SelectedPath;
                string resultWrite = con.writeConfig(textBoxPdfPath.Text, pdfValidPathFilename);
                if (resultWrite != "ok")
                    MessageBox.Show(resultWrite, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnOpenPdf.Enabled = false;
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
                        double settingsDiff = Convert.ToDouble(split[split.Length - 1]);
                        diff = settingsDiff;
                    }
                    catch (Exception)
                    {
                        diff = Convert.ToDouble(Names.diffValue);
                        MessageBox.Show("Fehler: Differenzwert konnte nicht konvertiert werden." + Environment.NewLine + "Standardwert wird verwendet.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (textBoxPdfPath.Text != "")
            {
                result = con.readConfig(screenshotPathFilename);
                if (result.Length > 5)
                {
                    if (result.Substring(0, 6) == error)
                        MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (!Directory.Exists(result))
                            MessageBox.Show("Fehler: der Screenshot Pfad '" + result + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (!Directory.Exists(textBoxPdfPath.Text))
                            MessageBox.Show("Fehler: der Screenshot Pfad '" + textBoxPdfPath.Text + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            progressBarCompare.Maximum = Directory.GetFiles(result.Trim()).Length;

                            foreach (string pdfDoc in Directory.GetFiles(result.Trim(), "*.png"))
                            {
                                string[] testPdfName = pdfDoc.Split('_');
                                int t = 0;
                                foreach (string pdfDocValid in Directory.GetFiles(textBoxPdfPath.Text, "*.png"))
                                {

                                    string[] validPdfName = pdfDocValid.Split('_');
                                    if (testPdfName[testPdfName.Length - 2] == validPdfName[validPdfName.Length - 2])
                                    {
                                        t = 1;


                                        while (backgroundWorkerCompare.IsBusy == true)
                                        {
                                            await Task.Delay(500);
                                        }

                                        backgroundWorkerCompare.RunWorkerAsync(pdfDoc + ";" + pdfDocValid);

                                        while (backgroundWorkerCompare.IsBusy == true)
                                        {
                                            await Task.Delay(500);
                                        }
                                        progressBarCompare.PerformStep();
                                    }

                                }
                                if (t == 0)
                                    textBoxAllCompare.AppendText("Kein Screenshot mit passendem Programmnamen zu: '" + Path.GetFileName(pdfDoc).ToString() + "' vorhanden." + Environment.NewLine);

                            }
                        }
                    }
                    progressBarCompare.Value = progressBarCompare.Maximum;
                }
                else
                {
                    MessageBox.Show("Bitte legen Sie auf der Startseite den Screenshot-Pfad fest.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bitte legen Sie einen Pfad zu den validen Screenshots fest.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            btnStart.Enabled = true;
            btnOpenPdf.Enabled = true;
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
            string[] img = e.Argument.ToString().Split(';');
            string[] name1 = img[0].Split('\\');
            string result = con.Compare(img[0], img[1]);
            try
            {
                double compareDiff= Convert.ToDouble(result);
                e.Result = name1[name1.Length - 1] + ";" + result;
            }
            catch (Exception)
            {
                e.Result = name1[name1.Length - 1] + ";" + result;
            } 
        }

    }
}
