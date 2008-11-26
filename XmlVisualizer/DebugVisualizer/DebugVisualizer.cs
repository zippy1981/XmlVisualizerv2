// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace XmlVisualizer
{
    public class DebugVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            using (Visualizer visualizer = new Visualizer())
            {
                if (visualizer.IsDisposed())
                {
                    return;
                }

                visualizer.SetInputXml(objectProvider.GetObject().ToString(), objectProvider.IsObjectReplaceable);
                visualizer.ShowDialog();

                if (objectProvider.IsObjectReplaceable && visualizer.InjectEnabled() && visualizer.AnyChangesToInputXml())
                {
                    try
                    {
                        StreamReader sr = new StreamReader(visualizer.GetInputXmlFileName());
                        objectProvider.ReplaceObject(sr.ReadToEnd());
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Can't inject data back. Please make sure that the input file is correct.\r\nError: {0}", e.Message), "Xml Visualizer v.2", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }

                if (visualizer.DeleteInputXmlFile())
                {
                    if (File.Exists(visualizer.GetInputXmlFileName()))
                    {
                        File.Delete(visualizer.GetInputXmlFileName());
                    }
                }
            }
        }
    }
}
