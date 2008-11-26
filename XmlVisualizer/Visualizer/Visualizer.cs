namespace XmlVisualizer
{
    public class Visualizer : System.IDisposable
    {
        private readonly MainForm mainForm;
        private bool inputSet;

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
                mainForm.SetStandAlone(true);
            }
        }

        public void ShowDialog()
        {
            if (!inputSet)
            {
                inputSet = true;
                mainForm.SetStandAlone(true);
                mainForm.SetInputXml("", false);
            }

            mainForm.ShowDialog();
        }

        public bool InjectEnabled()
        {
            return mainForm.inject;
        }

        public bool AnyChangesToInputXml()
        {
            return mainForm.AnyChangesToInputXml();
        }

        public bool DeleteInputXmlFile()
        {
            return mainForm.DeleteOriginalFile();
        }

        public string GetInputXmlFileName()
        {
            return mainForm.originalXmlFile;
        }
    }
}
