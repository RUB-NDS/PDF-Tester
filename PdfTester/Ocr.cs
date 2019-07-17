using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfTester
{
    public partial class Ocr : Form
    {
        private string path;
        private string screenshotPathStartFilename;
        private string screenshotPathOcrFilename;
        private string txtPathFilename;
        private string searchStringsFilename;
        private string tesseractPathFilename;
        private string settingsFilename;
        private string error;
        private string info;
        private string orgCancelText;

        private Boolean cancel;

        private Control con;

        public Ocr()
        {
            InitializeComponent();
            path = Names.path;
            screenshotPathStartFilename = Names.screenshotPathStartFilename;
            screenshotPathOcrFilename = Names.screenshotPathOcrFilename;
            txtPathFilename = Names.txtPathFilename;
            searchStringsFilename = Names.searchStringsFilename;
            tesseractPathFilename = Names.tesseractPathFilename;
            settingsFilename = Names.settingsFilename;
            error = Names.error;
            info = Names.info;

            backgroundWorkerOcr.WorkerReportsProgress = true;
            backgroundWorkerOcr.WorkerSupportsCancellation = true;

            con = new Control();
        }

        private void Ocr_Load(object sender, EventArgs e)
        {
            progressBarOcr.Minimum = 0;
            progressBarOcr.Value = progressBarOcr.Minimum;
            progressBarOcr.Step = 1;
            progressBarOcr.Visible = true;

            btnCancel.Enabled = false;
            btnCancel.Visible = false;

            orgCancelText = btnCancel.Text;

            cancel = false;

            string result = con.readConfig(screenshotPathOcrFilename);
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

            result = con.readConfig(txtPathFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxTxtPath.AppendText(result);
            }
            textBoxTxtPath.Text = textBoxTxtPath.Text.Trim();

            result = con.readConfig(searchStringsFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxSearchStrings.AppendText(result);
            }
            textBoxSearchStrings.Text = textBoxSearchStrings.Text.Trim();

        }

        private void BtnOpenScreenshot_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogScreenshot.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxScreenshotPath.Text = folderBrowserDialogScreenshot.SelectedPath;
                string resultWrite = con.writeConfig(textBoxScreenshotPath.Text, screenshotPathOcrFilename);
                if (resultWrite != "ok")
                    MessageBox.Show(resultWrite, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOpenTxt_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogTxt.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxTxtPath.Text = folderBrowserDialogTxt.SelectedPath;
                string resultWrite = con.writeConfig(textBoxTxtPath.Text, txtPathFilename);
                if (resultWrite != "ok")
                    MessageBox.Show(resultWrite, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnOpenScreenshot.Enabled = false;
            btnOpenTxt.Enabled = false;
            textBoxSearchStrings.Enabled = false;
            checkBoxLargeImg.Enabled = false;
            btnCancel.Enabled = true;

            btnStart.Visible = false;
            btnCancel.Visible = true;

            btnCancel.Text = orgCancelText;

            cancel = false;
            progressBarOcr.Value = progressBarOcr.Minimum;
            textBoxFounds.Text = "";
            textBoxInformations.Text = "";

            string result = con.readConfig(settingsFilename);
            string language = Names.language;
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string[] split = result.Split(';');
                    language = split[4];
                }
            }

            string tesseractPath = con.readConfig(tesseractPathFilename);
            tesseractPath = tesseractPath.Trim();
            if (tesseractPath.Length > 5)
            {
                if (tesseractPath.Substring(0, 6) == error)
                    MessageBox.Show(tesseractPath, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (textBoxSearchStrings.Text != "")
                    {
                        textBoxSearchStrings.Text = textBoxSearchStrings.Text.Trim();
                        string resultWrite = con.writeConfig(textBoxSearchStrings.Text, searchStringsFilename);
                        if (resultWrite != "ok")
                            MessageBox.Show(resultWrite, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (textBoxScreenshotPath.Text != "" || textBoxTxtPath.Text != "")
                        {
                            if (!Directory.Exists(textBoxScreenshotPath.Text))
                                MessageBox.Show("Fehler: der Screenshot Pfad '" + textBoxScreenshotPath.Text + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (!Directory.Exists(textBoxTxtPath.Text))
                                MessageBox.Show("Fehler: der Pfad zum Speichern der erkannten Texte '" + textBoxTxtPath.Text + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (!Directory.Exists(tesseractPath))
                                MessageBox.Show("Fehler: der Tesseract Pfad '" + tesseractPath + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (!Directory.Exists(tesseractPath + "\\tessdata"))
                                MessageBox.Show("Fehler: der tessdata-Ordner im Tesseract Pfad '" + tesseractPath + "\\tessdata" + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                string txtFilename = textBoxTxtPath.Text.Trim() + @"\PDF-Tester_OCR-Texterkennung_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";
                                string largeImg = "false";

                                //Texterkennung zusätzlich mit vergrößertem Screenshot
                                if (checkBoxLargeImg.Checked == true)
                                    largeImg = "true";

                                IEnumerable<string> count = Directory.GetFiles(textBoxScreenshotPath.Text.Trim(), "*.*").Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".tif") || s.EndsWith(".tiff"));

                                progressBarOcr.Maximum = count.Count();

                                foreach (string pdfDoc in Directory.GetFiles(textBoxScreenshotPath.Text.Trim(), "*.*").Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".tif") || s.EndsWith(".tiff")))
                                {
                                    if (cancel == true)
                                        break;

                                    while (backgroundWorkerOcr.IsBusy == true)
                                    {
                                        await Task.Delay(500);
                                    }

                                    backgroundWorkerOcr.RunWorkerAsync(txtFilename + ";" + tesseractPath + ";" + pdfDoc + ";" + language + ";" + largeImg);

                                    while (backgroundWorkerOcr.IsBusy == true)
                                    {
                                        await Task.Delay(500);
                                    }

                                    progressBarOcr.PerformStep();

                                }
                            }
                            progressBarOcr.Value = progressBarOcr.Maximum;
                        }
                        else
                        {
                            MessageBox.Show("Bitte wählen Sie die Pfade zu den Screenshots und zum Speicherort der txt-Datei.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bitte geben Sie mindestens einen Suchbegriff ein.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen sie in den Einstellungen den Pfad zum Tesseract-Ordner aus.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnStart.Enabled = true;
            btnOpenScreenshot.Enabled = true;
            btnOpenTxt.Enabled = true;
            textBoxSearchStrings.Enabled = true;
            checkBoxLargeImg.Enabled = true;
            btnCancel.Enabled = false;

            btnStart.Visible = true;
            btnCancel.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Verarbeitung wird abgebrochen...";
            cancel = true;
            backgroundWorkerOcr.CancelAsync();
        }

        private void BackgroundWorkerOcr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result.ToString();

            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                {
                    textBoxInformations.AppendText(result + Environment.NewLine);
                }
                else
                {
                    string[] splitResult = result.Split(';');
                    if (splitResult[0] == "Gefunden")
                    {
                        textBoxFounds.AppendText(splitResult[1] + " enthält Suchbegriff: " + splitResult[2] + Environment.NewLine);
                    }
                    else
                    {
                        textBoxInformations.AppendText(splitResult[1] + " enthält keinen Suchbegriff." + Environment.NewLine);
                    }
                }
            }
            
        }

        private void BackgroundWorkerOcr_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argument = e.Argument.ToString().Split(';');
            string[] filename = argument[2].Split('\\');
            string txtFilename = argument[0];
            string largeImg = argument[4];
            string searchStrings = textBoxSearchStrings.Text;
            string[] result = new string[2];

            BackgroundWorker worker = sender as BackgroundWorker;

            Boolean large = false;
            int choice, end = 1, t = 0;
            //Führt OCR Erkennung zusätzlich mit größerer Auflösung aus, falls Wert auf "true" gesetzt ist.
            if (largeImg == "true")
                end = 2;
            for (int i = 0; i < end; i++)
            {
                //Bricht die Verarbeitung ab
                if (worker.CancellationPending == true)
                {
                    break;
                }
                result[i] = con.startOcr(argument[1], argument[2], argument[3], large);
                if (result[i].Length > 5)
                {
                    if (result[i].Substring(0, 6) == error)
                    {
                        con.writeDebug("Fehler bei Datei: " + filename[filename.Length - 1] + Environment.NewLine + result[i]);
                        e.Result = "Fehler bei Datei: " + filename[filename.Length - 1] + ". Weitere Infos in Debug-Datei.";
                    }
                    else
                    {
                        foreach (string searchString in searchStrings.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                        {
                            if (searchString != "")
                            {
                                //Groß- und Kleinschreibung ignorieren
                                if (result[i].IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    t = 1;
                                    con.writeText("Dateiname: " + filename[filename.Length - 1] + " | Suchbegriff gefunden: ja | Suchbegriff: " + searchString + " | Inhalt:" + Environment.NewLine + "<START>" + Environment.NewLine + result[i].Trim() + Environment.NewLine + "<ENDE>", txtFilename);
                                    e.Result = "Gefunden;" + filename[filename.Length - 1] + ";" + searchString;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    e.Result = "Fehler bei Datei: " + filename[filename.Length - 1] + ". Keine Daten empfangen.";
                }
                if (t == 1)
                    break;
                else
                    large = true;
            }
            if (t == 0)
            {
                if (largeImg == "true" && worker.CancellationPending == false)
                {
                    //Verhindert, dass ein leeren String übergeben wird.
                    if (result[1].Trim() == "")
                        choice = 0;
                    else
                        choice = 1;
                }
                else
                    choice = 0;
                con.writeText("Dateiname: " + filename[filename.Length - 1] + " | Suchbegriff gefunden: nein | Suchbegriff: - | Inhalt:" + Environment.NewLine + "<START>" + Environment.NewLine + result[choice].Trim() + Environment.NewLine + "<ENDE>", txtFilename);
                e.Result = "Nichts gefunden;" + filename[filename.Length - 1];
            }  
        }
    }
}
