// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Drawing;
using System.Windows.Forms;

namespace XmlVisualizer
{
    internal partial class VisualizerForm : Form
    {
        private bool mainFormPropertiesSet;
        private string modifiedXml;

        public VisualizerForm()
        {
            InitializeComponent();
            visualizerUserControl.CloseEvent += visualizerUserControl_CloseEvent;
            SetMainFormProperties(this);
            visualizerUserControl.SetStandAlone();
            visualizerUserControl.SetCloseButtonText("Close");
        }

        public void SetDebugMode()
        {
            visualizerUserControl.SetDebugMode();
        }

        public void LoadXmlFromString(string xml)
        {
            visualizerUserControl.LoadXmlFromString(xml);
        }

        public void LoadXmlFromString(string xml, bool replaceable)
        {
            visualizerUserControl.LoadXmlFromString(xml, replaceable);
        }

        public void LoadXmlFromFile(string fileName)
        {
            visualizerUserControl.LoadXmlFromFile(fileName);
        }

        public bool Inject()
        {
            return visualizerUserControl.inject;
        }

        public bool AnyChangesToInputXml()
        {
            return visualizerUserControl.AnyChangesToInputXml();
        }

        public void ShowMessage(string message)
        {
            Util.ShowMessage(message);
        }

        public string GetModifiedXml()
        {
            return modifiedXml;
        }

        private void visualizerUserControl_CloseEvent()
        {
            modifiedXml = visualizerUserControl.GetModifiedXml();
            Dispose(true);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (ActiveForm != null && mainFormPropertiesSet)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    Util.SaveToRegistry("MainFormWidth", (ActiveForm.Width).ToString());
                    Util.SaveToRegistry("MainFormHeight", (ActiveForm.Height).ToString());
                    SaveMainFormLocation();
                }
            }
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (ActiveForm != null && mainFormPropertiesSet)
            {
                if (ActiveForm.Location.X >= 0 && ActiveForm.Location.Y >= 0)
                {
                    SaveMainFormLocation();
                }
            }
        }

        private static void SaveMainFormLocation()
        {
            Util.SaveToRegistry("MainFormLocationX", (ActiveForm.Location.X).ToString());
            Util.SaveToRegistry("MainFormLocationY", (ActiveForm.Location.Y).ToString());
        }

        private void SetMainFormProperties(Form mainForm)
        {
            string MainFormWidth = Util.ReadFromRegistry("MainFormWidth");
            string MainFormHeight = Util.ReadFromRegistry("MainFormHeight");

            if (MainFormWidth != "")
            {
                mainForm.Width = Convert.ToInt32(MainFormWidth);
            }

            if (MainFormHeight != "")
            {
                mainForm.Height = Convert.ToInt32(MainFormHeight);
            }

            string MainFormLocationX = Util.ReadFromRegistry("MainFormLocationX");
            string MainFormLocationY = Util.ReadFromRegistry("MainFormLocationY");

            if (MainFormLocationX != "" && MainFormLocationY != "")
            {
                mainForm.Location = new Point(Convert.ToInt32(MainFormLocationX), Convert.ToInt32(MainFormLocationY));
            }
            else
            {
                mainForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }

            if (mainForm.Width + mainForm.Location.X > SystemInformation.PrimaryMonitorSize.Width || mainForm.Height + mainForm.Location.Y > SystemInformation.PrimaryMonitorSize.Height)
            {
                mainForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }

            if (mainForm.Location.X < 0 - SystemInformation.FrameBorderSize.Width || mainForm.Location.Y < 0 - SystemInformation.FrameBorderSize.Height)
            {
                mainForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }

            mainForm.Text = Util.GetTitle();
            mainFormPropertiesSet = true;
        }
    }
}
