// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;

namespace XmlVisualizer
{
    internal partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            SetAboutFormProperties();
        }

        private void SetAboutFormProperties()
        {
            Text = Util.GetTitle();
        }

        public string ProgramVersion
        {
            set { versionLabel.Text = versionLabel.Text + " " + value; }
        }

        public string Title
        {
            set { titleLabel.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void urlLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(Util.GetDefaultWebBrowser());
            psi.Arguments  = "http://www.codeplex.com/XmlVisualizer";
            System.Diagnostics.Process.Start(psi);
            Close();
        }

        private void mailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:larshove@gmail.com");
            Close();
        }

        private void iconsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(Util.GetDefaultWebBrowser());
            psi.Arguments = "http://famfamfam.com/";
            System.Diagnostics.Process.Start(psi);
            Close();
        }

        private void editorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(Util.GetDefaultWebBrowser());
            psi.Arguments = "http://sharpdevelop.net/";
            System.Diagnostics.Process.Start(psi);
            Close();
        }
    }
}
