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
        private string screenshotPathStartFilename;
        private string screenshotPathOcrFilename;
        private string txtPathFilename;
        private string searchStringsFilename;
        private string tesseractPathFilename;
        private string settingsFilename;
        private string ocrFilename;
        private string error;
        private string info;
        private string orgCancelText;
        private string tesseractPath;
        private string language;

        private Boolean cancel;

        private Control con;

        public Ocr()
        {
            InitializeComponent();
            screenshotPathStartFilename = Names.screenshotPathStartFilename;
            screenshotPathOcrFilename = Names.screenshotPathOcrFilename;
            txtPathFilename = Names.txtPathFilename;
            searchStringsFilename = Names.searchStringsFilename;
            tesseractPathFilename = Names.tesseractPathFilename;
            settingsFilename = Names.settingsFilename;
            ocrFilename = Names.ocrFilename;
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


            result = con.readConfig(ocrFilename);
            if (result.Length > 5 && result.Substring(0, 6) == error)
            {
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxGrayscale.Checked = true;
                checkBoxLargeImg.Checked = true;
            }
            else
            {
                try
                {
                    string[] split = result.Split(';');
                    if (split[0] == "true")
                        checkBoxGrayscale.Checked = true;
                    if (split[1] == "true")
                        checkBoxLargeImg.Checked = true;
                }
                catch (Exception)
                {
                    checkBoxGrayscale.Checked = true;
                    checkBoxLargeImg.Checked = true;
                }
            }

            result = con.readConfig(settingsFilename);
            if (result.Length > 2)
            {
                if (result.Length > 5 && result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        string[] split = result.Split(';');
                        language = split[4];
                    }
                    catch (Exception)
                    {
                        language = "";
                    }
                }
            }

            result = con.readConfig(tesseractPathFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    tesseractPath = con.readConfig(tesseractPathFilename);
                    tesseractPath = tesseractPath.Trim();
                }
            }

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
            checkBoxGrayscale.Enabled = false;
            btnCancel.Enabled = true;

            btnStart.Visible = false;
            btnCancel.Visible = true;

            btnCancel.Text = orgCancelText;

            cancel = false;
            progressBarOcr.Value = progressBarOcr.Minimum;
            textBoxFounds.Text = "";
            textBoxInformations.Text = "";

            if (tesseractPath.Length > 5)
            {
                if (tesseractPath.Substring(0, 6) == error)
                    MessageBox.Show(tesseractPath, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (language != "")
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
                                    MessageBox.Show("Error: the screenshot path '" + textBoxScreenshotPath.Text + "' does not exist.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (!Directory.Exists(textBoxTxtPath.Text))
                                    MessageBox.Show("Error: the path for saving the recognized texts '" + textBoxTxtPath.Text + "' does not exist.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (!Directory.Exists(tesseractPath))
                                    MessageBox.Show("Error: the Tesseract path '" + tesseractPath + "' does not exist.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (!Directory.Exists(tesseractPath + "\\tessdata"))
                                    MessageBox.Show("Error: the tessdata folder in the tesseract path '" + tesseractPath + "\\tessdata" + "' does not exist.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                {
                                    string txtFilename = textBoxTxtPath.Text.Trim() + @"\PDF-Tester_OCR_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";
                                    string largeImg = "false";
                                    string grayscaleImg = "false";

                                    //Text recognition additionally with upscaled screenshot
                                    if (checkBoxLargeImg.Checked == true)
                                        largeImg = "true";

                                    //Text recognition additionally with grayscale screenshot
                                    if (checkBoxGrayscale.Checked == true)
                                        grayscaleImg = "true";

                                    IEnumerable<string> count = Directory.GetFiles(textBoxScreenshotPath.Text.Trim(), "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".tif") || s.EndsWith(".tiff"));

                                    progressBarOcr.Maximum = count.Count();

                                    int found = 0;
                                    foreach (string pdfDoc in Directory.GetFiles(textBoxScreenshotPath.Text.Trim(), "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".tif") || s.EndsWith(".tiff")))
                                    {
                                        found = 1;
                                        if (cancel == true)
                                            break;

                                        while (backgroundWorkerOcr.IsBusy == true)
                                        {
                                            await Task.Delay(500);
                                        }

                                        backgroundWorkerOcr.RunWorkerAsync(txtFilename + ";" + tesseractPath + ";" + pdfDoc + ";" + language + ";" + largeImg + ";" + grayscaleImg);

                                        while (backgroundWorkerOcr.IsBusy == true)
                                        {
                                            await Task.Delay(500);
                                        }

                                        progressBarOcr.PerformStep();

                                    }
                                    if (found == 0)
                                    {
                                        MessageBox.Show("No screenshots found.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                progressBarOcr.Value = progressBarOcr.Maximum;
                            }
                            else
                            {
                                MessageBox.Show("Please select the paths to the screenshots and to the location of the txt file.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter at least one search term.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a OCR language in the settings.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the path to the Tesseract folder in the settings.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnStart.Enabled = true;
            btnOpenScreenshot.Enabled = true;
            btnOpenTxt.Enabled = true;
            textBoxSearchStrings.Enabled = true;
            checkBoxLargeImg.Enabled = true;
            checkBoxGrayscale.Enabled = true;
            btnCancel.Enabled = false;
            saveCheckboxes();

            btnStart.Visible = true;
            btnCancel.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Processing is canceled...";
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
                    if (splitResult[0] == "Found")
                    {
                        textBoxFounds.AppendText(splitResult[1] + " contains search term: " + splitResult[2] + Environment.NewLine);
                    }
                    else
                    {
                        textBoxInformations.AppendText(splitResult[1] + " does not contain a search term." + Environment.NewLine);
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
            string grayscaleImg = argument[5];
            string searchStrings = textBoxSearchStrings.Text;
            string foundStrings = "";

            BackgroundWorker worker = sender as BackgroundWorker;

            Boolean large = false;
            Boolean grayscale = false;
            int choice, end = 1, found = 0, count = 0;
            //Performs OCR recognition additionally with upscaled resolution or/and grayscale image if value is set to "true".
            //Can improve text recognition.
            if (grayscaleImg == "true" && largeImg == "true")
                end = 4;
            else if (grayscaleImg == "true")
                end = 2;
            else if (largeImg == "true")
                end = 2;

            string[] result = new string[end];        

            for (int i = 0; i < end; i++)
            {
                //Grayscale mode for second and fourth round
                if (grayscaleImg == "true" && i % 2 == 1)
                    grayscale = true;
                else
                    grayscale = false;

                //Upscaled mode for second or third and fourth round
                if (largeImg == "true")
                    if (end == 2 && i == 1)
                        large = true;
                    else if (end == 4 && i > 1)
                        large = true;
                    else
                        large = false;

                //Cancels processing
                if (worker.CancellationPending == true)
                {
                    break;
                }
                result[i] = con.startOcr(argument[1], argument[2], argument[3], large, grayscale);
                if (result[i].Length > 5)
                {
                    if (result[i].Substring(0, 6) == error)
                    {
                        con.writeDebug("Error with file: " + filename[filename.Length - 1] + Environment.NewLine + result[i]);
                        e.Result = "Error with file: " + filename[filename.Length - 1] + ". More info in debug file.";
                    }
                    else
                    {
                        foundStrings = "Found;" + filename[filename.Length - 1] + ";";
                        foreach (string searchString in searchStrings.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                        {
                            count++;
                            if (searchString != "")
                            {
                                //Ignore case sensitivity
                                if (result[i].IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    found++;
                                    con.writeText("File name: " + filename[filename.Length - 1] + " | Search term found: yes | Search term: " + searchString + " | Content:" + Environment.NewLine + "<START>" + Environment.NewLine + result[i].Trim() + Environment.NewLine + "<END>", txtFilename);
                                    foundStrings = foundStrings + searchString + " + ";
                                }
                            }
                        }
                        foundStrings = foundStrings.Substring(0, foundStrings.Length - 3);
                        e.Result = foundStrings;
                    }
                }
                else
                {
                    e.Result = "Error with file: " + filename[filename.Length - 1] + ". No data received.";
                }
                if (found == count)
                    break;
            }
            if (found == 0)
            {
                if (largeImg == "true" && worker.CancellationPending == false)
                {
                    //Prevents an empty string from being passed
                    if (result[1].Trim() == "")
                        choice = 0;
                    else
                        choice = 1;
                }
                else
                    choice = 0;
                con.writeText("File name: " + filename[filename.Length - 1] + " | Search term found: no | Search term: - | Content:" + Environment.NewLine + "<START>" + Environment.NewLine + result[choice].Trim() + Environment.NewLine + "<END>", txtFilename);
                e.Result = "Nothing found;" + filename[filename.Length - 1];
            }  
        }

        private void saveCheckboxes()
        {
            string content;

            if (checkBoxGrayscale.Checked == true)
                if (checkBoxLargeImg.Checked == true)
                    content = "true;true;";
                else
                    content = "true;false;";
            else if (checkBoxLargeImg.Checked == true)
                content = "false;true;";
            else
                content = "false;false;";

            string result = con.writeConfig(content, ocrFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
