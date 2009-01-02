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
            string modifiedXml = Visualizer.ShowModal_LoadXmlFromString(objectProvider.GetObject().ToString(), objectProvider.IsObjectReplaceable, true);

            if (Visualizer.ReplaceObject())
            {
                StringReader sr = new StringReader(modifiedXml);
                objectProvider.ReplaceObject(sr.ReadToEnd());
                sr.Close();
            }
        }
    }
}
