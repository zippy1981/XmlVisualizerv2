using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Fiddler;

namespace XmlVisualizer.Fiddler
{
    public abstract class XmlVisualizerInspectorBase : Inspector2
    {
        private byte[] _body;
        private VisualizerUserControl _inspector;

        public override void AddToTab(TabPage o)
        {
            _inspector = new VisualizerUserControl
                            {
                                Dock = DockStyle.Fill
                            };
            o.Text = "Xml Visualizer v2";
            o.Controls.Add(_inspector);
        }

        public void Clear()
        {
            _inspector.NewFile();
        }

        public override int GetOrder()
        {
            return 0;
        }

        public override int ScoreForContentType(string sMIMEType)
        {
            var mimeTypes = new List<string>
                                {
                                    "text/xml", 
                                    "application/xml", 
                                    "application/xhtml+xml", 
                                    "application/atom+xml",
                                    "application/rss+xml",
                                };
            if (mimeTypes.Contains(sMIMEType))
            {
                return 50;
            }
            if (sMIMEType.ToLower().Contains("xml"))
            {
                return 25;
            }
            return 0;
        }

        public override void ShowAboutBox()
        {
            AboutForm.ShowModal();
        }

        public bool bDirty { get; set; }
        public bool bReadOnly { get; set; }

        public byte[] body
        {
            get { return _body; }
            set
            {
                _body = value;
                _inspector.LoadXmlFromString(Encoding.UTF8.GetString(_body));
            }
        }
    }
}
