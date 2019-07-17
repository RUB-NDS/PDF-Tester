using System;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PdfTester
{
    public partial class Startpage : Form
    {
        private string path;
        private string programListFilename;
        private string pdfPathFilename;
        private string screenshotPathStartFilename;
        private string screenshotPathValidFilename;
        private string screenshotPathCompareFilename;
        private string screenshotPathOcrFilename;
        private string txtPathFilename;
        private string searchStringsFilename;
        private string tesseractPathFilename;
        private string settingsFilename;
        private string pdfFilename;
        private string libreOfficeLockFile;
        private string error;
        private string info;
        private string orgCancelText;

        private int t;

        private Boolean cancel;

        private Control con;

        public Startpage()
        {
            InitializeComponent();

            path = Names.path;
            programListFilename = Names.programListFilename;
            pdfPathFilename = Names.pdfPathFilename;
            screenshotPathStartFilename = Names.screenshotPathStartFilename;
            screenshotPathCompareFilename = Names.screenshotPathCompareFilename;
            screenshotPathValidFilename = Names.screenshotPathValidFilename;
            screenshotPathOcrFilename = Names.screenshotPathOcrFilename;
            txtPathFilename = Names.txtPathFilename;
            searchStringsFilename = Names.searchStringsFilename;
            tesseractPathFilename = Names.tesseractPathFilename;
            settingsFilename = Names.settingsFilename;
            pdfFilename = Names.pdfFilename;
            libreOfficeLockFile = Names.libreOfficeLockFile;
            error = Names.error;
            info = Names.info;

            backgroundWorkerStart.WorkerReportsProgress = true;
            backgroundWorkerStart.WorkerSupportsCancellation = true;

            con = new Control();
        }

        private void Startpage_Load(object sender, EventArgs e)
        {
            progressBarStart.Minimum = 0;
            progressBarStart.Value = progressBarStart.Minimum;
            progressBarStart.Step = 1;
            progressBarStart.Visible = true;

            btnCancel.Enabled = false;
            btnCancel.Visible = false;

            orgCancelText = btnCancel.Text;

            cancel = false;

            string result;

            result = con.createDebug();
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(programListFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(pdfPathFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(screenshotPathStartFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(screenshotPathCompareFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(screenshotPathValidFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(screenshotPathOcrFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(txtPathFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(settingsFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(searchStringsFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.createConfig(tesseractPathFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.readConfig(tesseractPathFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                result = con.writeConfig(path + "tesseract", tesseractPathFilename);
                if (result != "ok")
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            result = con.readConfig(programListFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxProgamList.AppendText(result);
            }
            textBoxProgamList.Text = textBoxProgamList.Text.Trim();
            
            result = con.readConfig(pdfPathFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxPdfPath.Text = result;
            }
            textBoxPdfPath.Text = textBoxPdfPath.Text.Trim();

            result = con.readConfig(screenshotPathStartFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxScreenshotsPath.Text = result;
            }
            textBoxScreenshotsPath.Text = textBoxScreenshotsPath.Text.Trim();
        }

        private void BtnOpenPdf_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogPdf.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxPdfPath.Text = folderBrowserDialogPdf.SelectedPath;
                BtnSaveAll_Click(sender, e);
            }
        }

        private void BtnOpenScreenshot_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogScreenshot.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxScreenshotsPath.Text = folderBrowserDialogScreenshot.SelectedPath;
                BtnSaveAll_Click(sender, e);
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            string result, pdfName, programName, programFile;
            string[] seperator = { "\r\n" };
            int waitTime1, waitTime2;

            t = 0;

            progressBarStart.Value = progressBarStart.Minimum;
            textBoxProgamList.Enabled = false;
            btnOpenPdf.Enabled = false;
            btnOpenScreenshot.Enabled = false;
            btnStart.Enabled = false;
            btnSaveAll.Enabled = false;
            btnOpenDebug.Enabled = false;
            btnCancel.Enabled = true;

            btnStart.Visible = false;
            btnCancel.Visible = true;

            btnCancel.Text = orgCancelText;

            cancel = false;


            BtnSaveAll_Click(sender, e);

            string programList = textBoxProgamList.Text;
            string pdfPath = textBoxPdfPath.Text;
            string screenshotPath = textBoxScreenshotsPath.Text;

            if (programList != "" && pdfPath != "" && screenshotPath != "")
            {
                result = con.readConfig(settingsFilename);
                if (result.Length > 2)
                {
                    if (result.Length > 5 && result.Substring(0, 6) == error)
                    {
                        waitTime1 = Convert.ToInt32(Names.waitTime1);
                        waitTime2 = Convert.ToInt32(Names.waitTime2);
                        MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            string[] split = result.Split(';');
                            waitTime1 = Convert.ToInt32(split[0]);
                            waitTime2 = Convert.ToInt32(split[1]);
                        }
                        catch (Exception e1)
                        {
                            waitTime1 = Convert.ToInt32(Names.waitTime1);
                            waitTime2 = Convert.ToInt32(Names.waitTime2);
                            MessageBox.Show("Fehler (Startpage.BtnStart_Click): Fehler beim Konvertieren der Wartezeiten." + Environment.NewLine + "Es werden die Standardwerte verwendet." + Environment.NewLine + e1.ToString(), error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    waitTime1 = Convert.ToInt32(Names.waitTime1);
                    waitTime2 = Convert.ToInt32(Names.waitTime2);
                }

                if (!Directory.Exists(pdfPath))
                    MessageBox.Show("Fehler: der PDF Pfad '" + pdfPath + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!Directory.Exists(screenshotPath))
                    MessageBox.Show("Fehler: der Screenshot Pfad '" + screenshotPath + "' exisiert nicht.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        //Fenster minimieren
                        MdiParent.WindowState = FormWindowState.Minimized;

                        progressBarStart.Maximum = (Directory.GetFiles(pdfPath.Trim(), "*.pdf").Length * programList.Split(seperator, StringSplitOptions.None).Length);

                        //LibreOffice Lock-File löschen
                        if (File.Exists(pdfPath + libreOfficeLockFile))
                            File.Delete(pdfPath + libreOfficeLockFile);

                        string pdfFilenameNew = @"\PDF-Tester-Dokument_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".pdf";
                        //Bei gleichem Dateinamen: umbenennen
                        if (File.Exists(pdfPath + pdfFilename))
                            File.Move(pdfPath + pdfFilename, pdfPath + pdfFilenameNew);

                        foreach (string pdfDoc in Directory.GetFiles(pdfPath, "*.pdf"))
                        {
                            if (cancel == true)
                                break;

                            pdfName = Path.GetFileNameWithoutExtension(pdfDoc);

                            //PDF Dokumentname für Screenshot ändern
                            File.Move(pdfDoc, pdfPath + pdfFilename);

                            foreach (string program in programList.Split(seperator, StringSplitOptions.None))
                            {
                                if (cancel == true)
                                    break;

                                if (program.Contains(';'))
                                {
                                    string[] split = program.Split(';');
                                    programFile = split[0];
                                    programName = pdfName + "_" + split[1] + "_" + DateTime.Now.ToString("yyyyMMdd") + ".png";
                                }
                                else
                                {
                                    programFile = program;
                                    programName = pdfName + "_" + Path.GetFileNameWithoutExtension(program) + "_" + DateTime.Now.ToString("yyyyMMdd") + ".png";
                                }

                                while (backgroundWorkerStart.IsBusy == true)
                                {
                                    await Task.Delay(500);
                                }

                                backgroundWorkerStart.RunWorkerAsync(programFile + ";" + pdfPath + pdfFilename + ";" + screenshotPath + "\\" + programName + ";" + waitTime1.ToString() + ";" + waitTime2.ToString());

                                while (backgroundWorkerStart.IsBusy == true)
                                {
                                    await Task.Delay(500);
                                }
                                progressBarStart.PerformStep();

                            }
                            //PDF Dokumentname wiederherstellen
                            File.Move(pdfPath + pdfFilename, pdfDoc);

                            //LibreOffice Lock-File löschen
                            if (File.Exists(pdfPath + libreOfficeLockFile))
                                File.Delete(pdfPath + libreOfficeLockFile);   
                        }
                    }
                    catch (Exception e1)
                    {
                        t = 1;
                        con.writeDebug("Fehler (Startpage.BtnStart_Click):" + Environment.NewLine + e1.ToString());
                    }
                }
                        
            }
            else
            {
                MessageBox.Show("Bitte tragen Sie die gewünschten Programmpfade, sowie die Pfadangaben zu den PDF Dokumenten und zum Ablageordner der Screenshots ein.", info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            progressBarStart.Value = progressBarStart.Maximum;

            if (t == 1)
                MessageBox.Show("Es ist mindestens ein Fehler bei Verarbeitung aufgetreten." + Environment.NewLine + "Prüfen Sie die Debug-Datei.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxProgamList.Enabled = true;
            btnOpenPdf.Enabled = true;
            btnOpenScreenshot.Enabled = true;
            btnStart.Enabled = true;
            btnSaveAll.Enabled = true;
            btnOpenDebug.Enabled = true;
            btnCancel.Enabled = false;

            btnStart.Visible = true;
            btnCancel.Visible = false;

            //Fenster anzeigen
            MdiParent.WindowState = FormWindowState.Normal;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Verarbeitung wird abgebrochen...";
            cancel = true;
            backgroundWorkerStart.CancelAsync();
        }

        private void BtnSaveAll_Click(object sender, EventArgs e)
        {
            string result;

            textBoxProgamList.Text = textBoxProgamList.Text.Trim();

            result = con.writeConfig(textBoxProgamList.Text, programListFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.writeConfig(textBoxPdfPath.Text, pdfPathFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            result = con.writeConfig(textBoxScreenshotsPath.Text, screenshotPathStartFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);   
        }

        private void BtnOpenDebug_Click(object sender, EventArgs e)
        {
            string result = con.openDebug();
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show("Fehler (BtnOpenDebug_Click): Debug-Datei konnte nicht geöffnet werden.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                {
                    con.writeDebug(result);
                    t = 1;
                }
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] arg = e.Argument.ToString().Split(';');
            string result = con.processStart(arg[0], arg[1]);

            BackgroundWorker worker = sender as BackgroundWorker;

            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                {
                    e.Result = "Fehler bei Programm: " + arg[0] + " und PDF-Dokument: " + arg[1] + Environment.NewLine + result;
                }
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(result);

                    //Prüft alle Wartezeit/20 Sekunden, ob der Vorgang abgebrochen wurde.
                    for (int i = 0; i < 20; i++)
                    {
                        if (worker.CancellationPending == true)
                            break;
                        else
                            Thread.Sleep(Convert.ToInt32(arg[3]) * (1000/20));
                    }

                    con.makeScreenshot(arg[2]);

                    con.processStop(id);

                    Thread.Sleep(Convert.ToInt32(arg[4]) * 1000);
                    e.Result = result;
                }
                catch (Exception e1)
                {
                    e.Result = "Fehler bei Programm: " + arg[0] + " und PDF-Dokument: " + arg[1] + Environment.NewLine + result + Environment.NewLine + e1.ToString();
                }
            }
        }

        
    }
}
