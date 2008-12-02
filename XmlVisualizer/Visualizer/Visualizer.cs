namespace XmlVisualizer
{
    public class Visualizer : System.IDisposable
    {
        private readonly MainForm mainForm;
        private bool inputSet;
        private bool fileLoaded;

        public Visualizer()
        {
            mainForm = new MainForm();
        }

        public void Dispose()
        {
            mainForm.Dispose();
        }

        public bool IsDisposed()
        {
            return mainForm.IsDisposed;
        }

        public void SetInputXml(string xml)
        {
            CheckXml(xml);
            mainForm.SetInputXml(xml, false);
        }

        public void SetInputXml(string xml, bool replaceable)
        {
            CheckXml(xml);
            mainForm.SetInputXml(xml, replaceable);
        }

        private void CheckXml(string xml)
        {
            inputSet = true;

            if (xml == null)
            {
                mainForm.SetStandAlone();
            }
        }

        public void ShowDialog()
        {
            PreShow();
            mainForm.ShowDialog();
        }

        public void Show()
        {
            PreShow();
            mainForm.Show();
        }
        
        private void PreShow()
        {
            if (!inputSet && !fileLoaded)
            {
                inputSet = true;
                mainForm.SetStandAlone();
                mainForm.SetInputXml("", false);
                mainForm.SetNoInputFileOptions();
            }
        }

        public bool InjectEnabled()
        {
            return mainForm.inject;
        }

        public bool AnyChangesToInputXml()
        {
            return mainForm.AnyChangesToInputXml();
        }

        public bool GetDeleteInputXmlFile()
        {
            return mainForm.GetDeleteOriginalFile();
        }

        public string GetInputXmlFileName()
        {
            return mainForm.originalXmlFile;
        }

        public void LoadXmlFile(string fileName)
        {
            inputSet = true;
            fileLoaded = true;
            mainForm.LoadXmlFileFromArgument(fileName);
            mainForm.SetInputFileOptions();
        }
    }
}
