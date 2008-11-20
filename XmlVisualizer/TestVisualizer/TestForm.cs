// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;
using System.Windows.Forms;

namespace TestVisualizer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            CreateXsltTestDoc();
        }

        private static void CreateXsltTestDoc()
        {
            const string xsltDoc = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"><xsl:template match=\"/\"><html><body><h2>My CD Collection</h2><table border=\"1\"><tr bgcolor=\"#9acd32\"><th align=\"left\">Title</th><th align=\"left\">Artist</th></tr><xsl:for-each select=\"catalog/cd\"><tr><td><xsl:value-of select=\"title\" /></td><td><xsl:value-of select=\"artist\" /></td></tr></xsl:for-each></table></body></html></xsl:template></xsl:stylesheet>";
            string tmpDir = Environment.GetEnvironmentVariable("temp");
            string xsltFile = string.Format(@"{0}\test.xslt", tmpDir);
            File.WriteAllText(xsltFile, xsltDoc);
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
