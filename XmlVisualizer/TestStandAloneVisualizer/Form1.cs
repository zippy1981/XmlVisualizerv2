// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;
using XmlVisualizer;

namespace TestStandAloneVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Visualizer.OnDisposeEvent += Visualizer_OnDisposeEvent;
            InitializeComponent();
        }

        private void modelessButton_Click(object sender, EventArgs e)
        {
            Visualizer.ShowModeless_LoadXmlFromString("<xml>test</xml>");
            //Visualizer.ShowModeless_LoadXmlFromFile("c:\\temp\\test.xml");
        }

        private void modalButton_Click(object sender, EventArgs e)
        {
            Visualizer.ShowModal_LoadXmlFromString("<xml>test</xml>");
            //Visualizer.ShowModal_LoadXmlFromFile("c:\\temp\\test.xml");
        }

        private static void Visualizer_OnDisposeEvent(string modifiedXml)
        {
            MessageBox.Show(string.Format("Returned from Xml Visualizer v.2:\r\n{0}", modifiedXml));
        }
    }
}
