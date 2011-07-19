using Fiddler;

namespace XmlVisualizer.Fiddler
{
    public sealed class XmlVisualizerResponseInspector : XmlVisualizerInspectorBase, IResponseInspector2
    {
        HTTPResponseHeaders IResponseInspector2.headers
        {
            get { return null; }
            set { }
        }
    }
}