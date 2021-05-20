using System;
using System.Windows.Forms;

namespace PdfTester
{
    public partial class Gui : Form
    {
        private Startpage formStartpage;
        private Compare formCompare;
        private Ocr formOcr;
        private Settings formSettings;

        public Gui()
        {
            InitializeComponent();

            //Start window create and open
            formStartpage = new Startpage();
            formStartpage.MdiParent = this;
            formStartpage.WindowState = FormWindowState.Maximized;
            formStartpage.Show();

            //Compare window create and open
            formCompare = new Compare();
            formCompare.MdiParent = this;
            formCompare.WindowState = FormWindowState.Maximized;
            formCompare.Show();
            formCompare.Visible = false;

            //OCR window create and open
            formOcr = new Ocr();
            formOcr.MdiParent = this;
            formOcr.WindowState = FormWindowState.Maximized;
            formOcr.Show();
            formOcr.Visible = false;

            //Settings window create and open
            formSettings = new Settings();
            formSettings.MdiParent = this;
            formSettings.WindowState = FormWindowState.Maximized;
            formSettings.Show();
            formSettings.Visible = false;

        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCompare.Visible = false;
            formOcr.Visible = false;
            formSettings.Visible = false;
            formStartpage.Visible = true;
        }

        private void CompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStartpage.Visible = false;
            formOcr.Visible = false;
            formSettings.Visible = false;
            formCompare.Visible = true;
        }

        private void OCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStartpage.Visible = false;
            formCompare.Visible = false;
            formSettings.Visible = false;
            formOcr.Visible = true;
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStartpage.Visible = false;
            formCompare.Visible = false;
            formOcr.Visible = false;
            formSettings.Visible = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pDFTesterV04ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Visit us at pdf-insecurity.org", "PDF Insecurity Team", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }   
}
