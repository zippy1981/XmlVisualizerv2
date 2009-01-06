// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Threading;
using System.Windows.Forms;
using XmlVisualizer;

namespace TestStandAloneVisualizer
{
    public partial class Form1 : Form
    {
        //public Form1()
        //{
        //    Visualizer.OnDisposeEventStatic += Visualizer_OnDisposeEvent;
        //    InitializeComponent();
        //}

        //private void modelessButton_Click(object sender, EventArgs e)
        //{
        //    Visualizer.ShowModeless_LoadXmlFromString("<xml>test</xml>");
        //}

        //private void modalButton_Click(object sender, EventArgs e)
        //{
        //    Visualizer.ShowModal_LoadXmlFromString("<xml>test</xml>");
        //}

        //private static void Visualizer_OnDisposeEvent(string modifiedXml)
        //{
        //    MessageBox.Show(string.Format("Returned from Xml Visualizer v.2:\r\n{0}", modifiedXml));
        //}

        public Form1()
        {
            InitializeComponent();
        }

        private void modelessButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(delegate(object textObject)
            {
                Visualizer v = new Visualizer();
                v.OnDisposeEvent += v_OnDisposeEvent;
                v.LoadXmlFromString(textObject.ToString());
                v.Show();
                v.Dispose();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start("<xml>test</xml>");
        }

        private static void v_OnDisposeEvent(string modifiedXml)
        {
            MessageBox.Show(string.Format("Returned from Xml Visualizer v.2:\r\n{0}", modifiedXml));
        }

        private void modalButton_Click(object sender, EventArgs e)
        {
            Visualizer v = new Visualizer();
            v.LoadXmlFromString("<xml>test</xml>");
            string modifiedXml = v.ShowDialog();

            MessageBox.Show(string.Format("Returned from Xml Visualizer v.2:\r\n{0}", modifiedXml));
        }
    }
}
