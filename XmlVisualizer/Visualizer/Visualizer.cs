namespace XmlVisualizer
{
    public class Visualizer : System.IDisposable
    {
        private readonly MainForm mainForm;

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
            mainForm.SetInputXml(xml, false);
        }

        public void SetInputXml(string xml, bool replaceable)
        {
            mainForm.SetInputXml(xml, replaceable);
        }

        public void ShowDialog()
        {
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
