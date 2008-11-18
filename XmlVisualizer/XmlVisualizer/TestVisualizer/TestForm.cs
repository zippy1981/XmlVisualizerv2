// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;

namespace TestVisualizer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            string test = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><catalog><cd country=\"USA\"><title>Empire Burlesque</title><artist>Bob Dylan</artist><price>10.90</price></cd><cd country=\"UK\"><title>Hide your heart</title><artist>Bonnie Tyler</artist><price>10.0</price></cd><cd country=\"USA\"><title>Greatest Hits</title><artist>Dolly Parton</artist><price>9.90</price></cd></catalog>";
            Microsoft.VisualStudio.DebuggerVisualizers.VisualizerDevelopmentHost host = new Microsoft.VisualStudio.DebuggerVisualizers.VisualizerDevelopmentHost(test, typeof(XmlVisualizer.Visualizer));
            host.ShowVisualizer();

            Close();
        }
    }
}
