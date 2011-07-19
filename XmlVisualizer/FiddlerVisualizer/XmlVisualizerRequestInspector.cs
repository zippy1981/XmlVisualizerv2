using Fiddler;

namespace XmlVisualizer.Fiddler
{
    public sealed class XmlVisualizerRequestInspector: XmlVisualizerInspectorBase, IRequestInspector2
    {
        HTTPRequestHeaders IRequestInspector2.headers
        {
            get { return null; }
            set { }
        }
    }
}