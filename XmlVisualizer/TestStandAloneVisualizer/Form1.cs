// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System.Windows.Forms;
using XmlVisualizer;

namespace TestStandAloneVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            using (Visualizer visualizer = new Visualizer())
            {
                visualizer.SetInputXml("");
                visualizer.ShowDialog();
            }

            Close();
        }
    }
}
