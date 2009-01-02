// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace XmlVisualizer
{
    public class DebugVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            using (Visualizer visualizer = new Visualizer(true))
            {
                if (visualizer.IsDisposed())
                {
                    return;
                }

                visualizer.LoadXmlFromString(objectProvider.GetObject().ToString(), objectProvider.IsObjectReplaceable);
                visualizer.ShowDialog();

                if (visualizer.ReplaceObject())
                {
                    StringReader sr = new StringReader(visualizer.GetModifiedXml());
                    objectProvider.ReplaceObject(sr.ReadToEnd());
                    sr.Close();
                }
            }
        }
    }
}
