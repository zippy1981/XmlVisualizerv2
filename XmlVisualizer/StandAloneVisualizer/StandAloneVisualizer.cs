// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;
using XmlVisualizer;

namespace StandAloneVisualizer
{
    public static class StandAloneVisualizer
    {
        [STAThread]
        static void Main()
        {
            using (Visualizer visualizer = new Visualizer(false))
            {
                string[] args = Environment.GetCommandLineArgs();

                if (args.Length == 2)
                {
                    try
                    {
                        visualizer.LoadXmlFromFile(args[1]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Xml Visualizer v.2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                visualizer.Show();
            }
        }
    }
}
