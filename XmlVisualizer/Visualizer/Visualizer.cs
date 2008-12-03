// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;
using System.Windows.Forms;

namespace XmlVisualizer
{
    public class Visualizer : IDisposable
    {
        private MainForm mainForm;
        private bool inputSet;
        private bool fileLoaded;
        private bool replaceObject;
        private bool standAlone;
        private string injectBackString;

        /// <summary>
        /// Constructor for Xml Visualizer v.2.
        /// </summary>
        public Visualizer(bool useAsStandAlone)
        {
            mainForm = new MainForm();

            if (useAsStandAlone)
            {
                standAlone = true;
                mainForm.SetStandAlone();
            }
        }

        /// <summary>
        /// Disposes Xml Visualizer v.2.
        /// </summary>
        public void Dispose()
        {
            if (mainForm != null)
            {
                if (!mainForm.IsDisposed)
                {
                    mainForm.Dispose();
                }

                mainForm = null;
            }
        }

        /// <summary>
        /// Returns value indicating if the main window of Xml Visualizer v.2 is disposed.
        /// </summary>
        public bool IsDisposed()
        {
            return mainForm.IsDisposed;
        }

        /// <summary>
        /// Loads Xml string into Xml Visualizer v.2.
        /// </summary>
        /// <param name="xml">The Xml string to load.</param>
        public void LoadXmlFromString(string xml)
        {
            inputSet = true;
            mainForm.LoadXmlFromString(xml, true);
        }

        /// <summary>
        /// Loads Xml string into Xml Visualizer v.2.
        /// </summary>
        /// <param name="xml">The Xml string to load.</param>
        /// <param name="replaceable">Indicates if the objects is replaceable. Is only used if Xml Visualizer v.2 is not standalone.</param>
        public void LoadXmlFromString(string xml, bool replaceable)
        {
            inputSet = true;
            replaceObject = replaceable;
            mainForm.LoadXmlFromString(xml, replaceable);
        }

        /// <summary>
        /// Loads Xml file into Xml Visualizer v.2.
        /// </summary>
        /// <param name="fileName">The name of the file to load.</param>
        public void LoadXmlFromFile(string fileName)
        {
            inputSet = true;
            fileLoaded = true;
            mainForm.LoadXmlFromFile(fileName);
            mainForm.SetInputFileOptions();
        }

        /// <summary>
        /// Show the Xml Visualizer v.2 main window as a modal dialog.
        /// </summary>
        public void ShowDialog()
        {
            PreShow();
            mainForm.ShowDialog();
            PostShow();
        }

        /// <summary>
        /// Show the Xml Visualizer v.2 main window as a modeless dialog.
        /// </summary>
        public void Show()
        {
            PreShow();
            Application.Run(mainForm);
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
            return injectBackString;
        }

        private void PostShow()
        {
            if (!mainForm.inject || !mainForm.AnyChangesToInputXml())
            {
                replaceObject = false;
            }

            try
            {
                if (mainForm.originalXmlFile != "")
                {
                    injectBackString = File.ReadAllText(mainForm.originalXmlFile);
                }
            }
            catch (Exception e)
            {
                Util.ShowMessage(string.Format("Can't inject data back. Please make sure that the input file is correct.\r\nError: {0}", e.Message));
            }

            if (mainForm.GetDeleteOriginalFile())
            {
                if (File.Exists(mainForm.originalXmlFile))
                {
                    File.Delete(mainForm.originalXmlFile);
                }
            }

            mainForm = null;
        }

        private void PreShow()
        {
            if (standAlone)
            {
                mainForm.ClearMainForm();
            }

            if (mainForm == null)
            {
                mainForm = new MainForm();
            }

            if (!inputSet && !fileLoaded)
            {
                inputSet = true;
                mainForm.SetStandAlone();
                mainForm.SetNoInputFileOptions();
            }

            inputSet = false;
            fileLoaded = false;
        }
    }
}
