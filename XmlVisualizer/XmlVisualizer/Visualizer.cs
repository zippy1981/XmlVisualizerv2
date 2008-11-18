// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace XmlVisualizer
{
    public class Visualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            using (MainForm mainForm = new MainForm())
            {
                if (mainForm.IsDisposed)
                {
                    return;
                }

                mainForm.SetDebugString(objectProvider.GetObject().ToString(), objectProvider.IsObjectReplaceable);
                windowService.ShowDialog(mainForm);
                
                if (objectProvider.IsObjectReplaceable && mainForm.inject && mainForm.AnyChangesToInject())
                {
                    try
                    {
                        StreamReader sr = new StreamReader(mainForm.originalXmlFile);
                        objectProvider.ReplaceObject(sr.ReadToEnd());
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        Util.ShowMessage(string.Format("Can't inject data back. Please make sure that the input file is correct.\r\n{0}", e.Message));
                    }
                }

                if (mainForm.DeleteOriginalFile())
                {
                    Util.DeleteFile(mainForm.originalXmlFile);
                }
            }
        }
    }
}
