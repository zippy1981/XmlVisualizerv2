// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;
using XmlVisualizer;

namespace StandAloneVisualizer
{
    public partial class StandAloneVisualizer : Form
    {
        public StandAloneVisualizer()
        {
            InitializeComponent();
        }

        private void StandAloneVisualizer_Load(object sender, EventArgs e)
        {
            using (Visualizer visualizer = new Visualizer())
            {
                string[] args = Environment.GetCommandLineArgs();

                if (args.Length == 2)
                {
                    try
                    {
                        visualizer.LoadXmlFile(args[1]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Xml Visualizer v.2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                visualizer.ShowDialog();
            }

            Close();
        }
    }
}
