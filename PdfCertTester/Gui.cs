using System;
using System.Windows.Forms;

namespace PdfCertTester
{
    public partial class Gui : Form
    {
        private Startpage formStartpage;
        private Compare formCompare;
        private Settings formSettings;

        public Gui()
        {
            InitializeComponent();

            //Startseite erstellen und aufrufen
            formStartpage = new Startpage();
            formStartpage.MdiParent = this;
            formStartpage.WindowState = FormWindowState.Maximized;
            formStartpage.Show();


            //Vergleichsseite erstellen und aufrufen
            formCompare = new Compare();
            formCompare.MdiParent = this;
            formCompare.WindowState = FormWindowState.Maximized;
            formCompare.Show();
            formCompare.Visible = false;

            //Einstellungsseite erstellen und aufrufen
            formSettings = new Settings();
            formSettings.MdiParent = this;
            formSettings.WindowState = FormWindowState.Maximized;
            formSettings.Show();
            formSettings.Visible = false;

        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCompare.Visible = false;
            formSettings.Visible = false;
            formStartpage.Visible = true;
        }

        private void EinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStartpage.Visible = false;
            formCompare.Visible = false;
            formSettings.Visible = true;
        }

        private void VergleichToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStartpage.Visible = false;
            formSettings.Visible = false;
            formCompare.Visible = true;
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
