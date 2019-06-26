using System;
using System.Linq;
using System.Windows.Forms;

namespace PdfCertTester
{
    public partial class Settings : Form
    {
        private string settingsFilename;
        private string waitTime1;
        private string waitTime2;
        private string diffValue;
        private string error;
        private string info;

        private Control con;
        public Settings()
        {
            InitializeComponent();

            settingsFilename = Names.settingsFilename;
            waitTime1 = Names.waitTime1;
            waitTime2 = Names.waitTime2;
            diffValue = Names.diffValue;
            error = Names.error;
            info = Names.info;

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
                    }
                    catch (Exception)
                    {
                        textBoxWaitTime1.AppendText(waitTime1);
                        textBoxWaitTime2.AppendText(waitTime2);
                        textBoxDiffValue.AppendText(diffValue);
                    }
                }
            }
            else
            {
                textBoxWaitTime1.AppendText(waitTime1);
                textBoxWaitTime2.AppendText(waitTime2);
                textBoxDiffValue.AppendText(diffValue);
            }
        }

        private void BtnSaveWaitTime_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                Convert.ToInt32(textBoxWaitTime1.Text);
                Convert.ToInt32(textBoxWaitTime2.Text);

                string diff = textBoxDiffValue.Text;
                if (diff.Contains('.'))
                    diff = diff.Replace('.', ',');
                

                string content = textBoxWaitTime1.Text + ";" + textBoxWaitTime2.Text + ";" + diff;
                result = con.writeConfig(content, settingsFilename);
                if (result != "ok")
                    MessageBox.Show(result, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte geben Sie für die Wartezeit nur ganze Zahlen an.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
