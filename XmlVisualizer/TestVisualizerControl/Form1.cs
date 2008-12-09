// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System.Windows.Forms;

namespace TestVisualizerControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            visualizerUserControl.LoadXmlFromString("<xml>test</xml>");
        }

        private void visualizerUserControl_CloseEvent()
        {
            MessageBox.Show(visualizerUserControl.GetModifiedXml());
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            visualizerUserControl.LoadXmlFromString("");
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            visualizerUserControl.LoadXmlFromString("<xml>test</xml>");
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            visualizerUserControl.LoadXmlFromFile("c:\\temp\\test.xml");
        }
    }
}
