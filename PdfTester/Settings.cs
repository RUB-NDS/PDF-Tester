using System;
using System.Linq;
using System.Windows.Forms;

namespace PdfTester
{
    public partial class Settings : Form
    {
        private string settingsFilename;
        private string tesseractPathFilename;
        private string waitTime1;
        private string waitTime2;
        private string diffValue;
        private string maxHeight;
        private string language;
        private string error;

        private Control con;
        public Settings()
        {
            InitializeComponent();

            settingsFilename = Names.settingsFilename;
            tesseractPathFilename = Names.tesseractPathFilename;
            waitTime1 = Names.waitTime1;
            waitTime2 = Names.waitTime2;
            diffValue = Names.diffValue;
            maxHeight = Names.maxHeight;
            language = Names.language;
            error = Names.error;

            con = new Control();
        }

        private void Settings_Load(object sender, System.EventArgs e)
        {
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
                        textBoxWaitTime1.AppendText(split[0]);
                        textBoxWaitTime2.AppendText(split[1]);
                        if (split[2].Contains('.'))
                            split[2] = split[2].Replace('.', ',');
                        textBoxDiffValue.AppendText(split[2]);
                        textBoxMaxHeight.AppendText(split[3]);
                        comboBoxOcrLanguage.Text = split[4];
                    }
                    catch (Exception)
                    {
                        textBoxWaitTime1.AppendText(waitTime1);
                        textBoxWaitTime2.AppendText(waitTime2);
                        textBoxDiffValue.AppendText(diffValue);
                        textBoxMaxHeight.AppendText(maxHeight);
                        comboBoxOcrLanguage.Text = language;
                    }
                }
            }
            else
            {
                textBoxWaitTime1.AppendText(waitTime1);
                textBoxWaitTime2.AppendText(waitTime2);
                textBoxDiffValue.AppendText(diffValue);
                textBoxMaxHeight.AppendText(maxHeight);
                comboBoxOcrLanguage.Text = language;
            }

            result = con.readConfig(tesseractPathFilename);
            if (result.Length > 5)
            {
                if (result.Substring(0, 6) == error)
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    textBoxTesseractPath.AppendText(result);
            }
            textBoxTesseractPath.Text = textBoxTesseractPath.Text.Trim();
        }

        private void BtnOpenTesseract_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogTesseract.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxTesseractPath.Text = folderBrowserDialogTesseract.SelectedPath;
                BtnSaveAll_Click(sender, e);
            }
        }

        private void ComboBoxOcrLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSaveAll_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                Convert.ToInt32(textBoxWaitTime1.Text);
                Convert.ToInt32(textBoxWaitTime2.Text);
                Convert.ToInt32(textBoxMaxHeight.Text);

                string diff = textBoxDiffValue.Text;
                if (diff.Contains('.'))
                    diff = diff.Replace('.', ',');
                

                string content = textBoxWaitTime1.Text + ";" + textBoxWaitTime2.Text + ";" + diff + ";" + textBoxMaxHeight.Text + ";" + comboBoxOcrLanguage.Text;
                result = con.writeConfig(content, settingsFilename);
                if (result != "ok")
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte geben Sie für die Wartezeit und die maximale Höhe nur ganze Zahlen an.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            result = con.writeConfig(textBoxTesseractPath.Text, tesseractPathFilename);
            if (result != "ok")
                MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
