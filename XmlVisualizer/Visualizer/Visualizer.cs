// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;

namespace XmlVisualizer
{
    public class Visualizer : IDisposable
    {
        private bool replaceObject;
        private VisualizerForm visualizerForm;

        /// <summary>
        /// Constructor for Xml Visualizer v.2.
        /// </summary>
        public Visualizer(bool debugMode)
        {
            visualizerForm = new VisualizerForm();

            if (debugMode)
            {
                visualizerForm.SetDebugMode();
            }
        }

        /// <summary>
        /// Disposes Xml Visualizer v.2.
        /// </summary>
        public void Dispose()
        {
            if (visualizerForm != null)
            {
                if (!visualizerForm.IsDisposed)
                {
                    visualizerForm.Dispose();
                }

                visualizerForm = null;
            }
        }

        /// <summary>
        /// Returns value indicating if the main window of Xml Visualizer v.2 is disposed.
        /// </summary>
        public bool IsDisposed()
        {
            return visualizerForm.IsDisposed;
        }

        /// <summary>
        /// Loads Xml string into Xml Visualizer v.2.
        /// </summary>
        /// <param name="xml">The Xml string to load.</param>
        public void LoadXmlFromString(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                visualizerForm.LoadXmlFromString(xml);
            }
        }

        /// <summary>
        /// Loads Xml string into Xml Visualizer v.2.
        /// </summary>
        /// <param name="xml">The Xml string to load.</param>
        /// <param name="replaceable">Indicates if the objects is replaceable. Is only used if Xml Visualizer v.2 is used as a debug visualizer.</param>
        public void LoadXmlFromString(string xml, bool replaceable)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                replaceObject = replaceable;
                visualizerForm.LoadXmlFromString(xml, replaceable);
            }
        }

        /// <summary>
        /// Loads Xml file into Xml Visualizer v.2.
        /// </summary>
        /// <param name="fileName">The name of the file to load.</param>
        public void LoadXmlFromFile(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                visualizerForm.LoadXmlFromFile(fileName);
            }
        }

        /// <summary>
        /// Show the Xml Visualizer v.2 main window as a modal dialog.
        /// </summary>
        public void ShowDialog()
        {
            visualizerForm.ShowDialog();
            PostShow();
        }

        /// <summary>
        /// Show the Xml Visualizer v.2 main window as a modeless dialog.
        /// </summary>
        public void Show()
        {
            Application.Run(visualizerForm);
            PostShow();
        }

        /// <summary>
        /// Returns value indicating if the object is replaceable, if any changes has been made to the object and if the 'Inject Xml' checkbox is checked.
        /// </summary>
        public bool ReplaceObject()
        {
            return replaceObject;
        }

        /// <summary>
        /// Returns modified Xml.
        /// </summary>
        public string GetModifiedXml()
        {
            return visualizerForm.GetModifiedXml();
        }

        private void PostShow()
        {
            if (!visualizerForm.Inject() || !visualizerForm.AnyChangesToInputXml())
            {
                replaceObject = false;
            }
        }
    }
}
