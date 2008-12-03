// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;

namespace TestDebugVisualizer
{
    public static class TestDebugVisualizer
    {
        [STAThread]
        static void Main()
        {
            CreateXsltTestDoc();
            CreateXsdTestDoc();
            LoadVisualizer();
        }

        private static void CreateXsltTestDoc()
        {
            const string xsltDoc = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"><xsl:template match=\"/\"><html><body><h2>My CD Collection</h2><table border=\"1\"><tr bgcolor=\"#9acd32\"><th align=\"left\">Title</th><th align=\"left\">Artist</th></tr><xsl:for-each select=\"catalog/cd\"><tr><td><xsl:value-of select=\"title\" /></td><td><xsl:value-of select=\"artist\" /></td></tr></xsl:for-each></table></body></html></xsl:template></xsl:stylesheet>";
            string xsltFile = string.Format(@"{0}test.xslt", Path.GetTempPath());
            File.WriteAllText(xsltFile, xsltDoc);
        }

        private static void CreateXsdTestDoc()
        {
            const string xsdDoc = "<xsd:schema xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"urn:bookstore-schema\" elementFormDefault=\"qualified\" targetNamespace=\"urn:bookstore-schema\"><xsd:element name=\"bookstore\" type=\"bookstoreType\" /><xsd:complexType name=\"bookstoreType\"><xsd:sequence maxOccurs=\"unbounded\"><xsd:element name=\"book\" type=\"bookType\" /></xsd:sequence></xsd:complexType><xsd:complexType name=\"bookType\"><xsd:sequence><xsd:element name=\"title\" type=\"xsd:string\" /><xsd:element name=\"author\" type=\"authorName\" /><xsd:element name=\"price\" type=\"xsd:decimal\" /></xsd:sequence><xsd:attribute name=\"genre\" type=\"xsd:string\" /></xsd:complexType><xsd:complexType name=\"authorName\"><xsd:sequence><xsd:element name=\"first-name\" type=\"xsd:string\" /><xsd:element name=\"last-name\" type=\"xsd:string\" /></xsd:sequence></xsd:complexType></xsd:schema>";
            string xsdFile = string.Format(@"{0}test.xsd", Path.GetTempPath());
            File.WriteAllText(xsdFile, xsdDoc);
        }

        private static void LoadVisualizer()
        {
            //string xmlDoc = "<?xml version=\"1.0\"?><bookstore xmlns=\"urn:bookstore-schema\"><book><title>test 123</title><author><first-name>Benjamin</first-name><last-name>Franklin</last-name></author></book><book genre=\"novel\"><title>The Confidence Man</title><author><first-name>Herman</first-name><last-name>Melville</last-name></author><price>11.99</price></book><book genre=\"philosophy\"><title>The Gorgias</title><author><first-name>Herman</first-name><last-name>Melville</last-name></author><price>9.99</price></book></bookstore>";
            string xmlDoc = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><catalog><cd country=\"USA\"><title>Empire Burlesque</title><artist>Bob Dylan</artist><price>10.90</price></cd><cd country=\"UK\"><title>Hide your heart</title><artist>Bonnie Tyler</artist><price>10.0</price></cd><cd country=\"USA\"><title>Greatest Hits</title><artist>Dolly Parton</artist><price>9.90</price></cd></catalog>";
            Microsoft.VisualStudio.DebuggerVisualizers.VisualizerDevelopmentHost host = new Microsoft.VisualStudio.DebuggerVisualizers.VisualizerDevelopmentHost(xmlDoc, typeof(XmlVisualizer.DebugVisualizer));
            host.ShowVisualizer();
        }
    }
}
