// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Threading;
using System.Windows.Forms;

namespace XmlVisualizer
{
    public class Visualizer : IDisposable
    {
        public delegate void OnDisposeEventHandler(string modifiedXml);
        public event OnDisposeEventHandler OnDisposeEvent;
        public static event OnDisposeEventHandler OnDisposeEventStatic;

        private static bool replaceObject;
        private VisualizerForm visualizerForm;

        /// <summary>
        /// Constructor for Xml Visualizer v.2.
        /// </summary>
        /// <param name="debugMode">Indicates if the visualizer should be used standalone or in debug mode.</param>
        private Visualizer(bool debugMode)
        {
            replaceObject = true;
            visualizerForm = new VisualizerForm();

            if (debugMode)
            {
                visualizerForm.SetDebugMode();
            }
        }

        /// <summary>
        /// Constructor for Xml Visualizer v.2.
        /// </summary>
        public Visualizer()
        {
            replaceObject = true;
            visualizerForm = new VisualizerForm();
        }

        /// <summary>
        /// Disposes Xml Visualizer v.2.
        /// </summary>
        public void Dispose()
        {
            string modifiedXml = visualizerForm.GetModifiedXml();

            if (visualizerForm != null)
            {
                if (!visualizerForm.IsDisposed)
                {
                    visualizerForm.Dispose();
                }

                visualizerForm = null;
            }

            if (OnDisposeEvent != null)
            {
                OnDisposeEvent(modifiedXml);
            }

            if (OnDisposeEventStatic != null)
            {
                OnDisposeEventStatic(modifiedXml);
            }
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
        private void LoadXmlFromString(string xml, bool replaceable)
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
        public string ShowDialog()
        {
            visualizerForm.ShowDialog();
            PostShow();

            return visualizerForm.GetModifiedXml();
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
        public static bool ReplaceObject()
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

        public static void ShowModeless_LoadXmlFromString(string xml)
        {
            ThreadStart threadDelegate = delegate
            {
                using (Visualizer visualizer = new Visualizer(false))
                {
                    visualizer.LoadXmlFromString(xml);
                    visualizer.Show();
                }
            };

            Thread thread = new Thread(threadDelegate);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public static void ShowModeless_LoadXmlFromFile(string fileName)
        {
            ThreadStart threadDelegate = delegate
            {
                using (Visualizer visualizer = new Visualizer(false))
                {
                    visualizer.LoadXmlFromFile(fileName);
                    visualizer.Show();
                }
            };

            Thread thread = new Thread(threadDelegate);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public static string ShowModal_LoadXmlFromString(string xml)
        {
            string modifiedXml;

            using (Visualizer visualizer = new Visualizer(false))
            {
                visualizer.LoadXmlFromString(xml);
                visualizer.ShowDialog();
                modifiedXml = visualizer.GetModifiedXml();
            }

            return modifiedXml;
        }

        public static string ShowModal_LoadXmlFromString(string xml, bool replaceable, bool debugMode)
        {
            string modifiedXml;

            using (Visualizer visualizer = new Visualizer(debugMode))
            {
                visualizer.LoadXmlFromString(xml, replaceable);
                visualizer.ShowDialog();
                modifiedXml = visualizer.GetModifiedXml();
            }

            return modifiedXml;
        }

        public static string ShowModal_LoadXmlFromFile(string fileName)
        {
            string modifiedXml;

            using (Visualizer visualizer = new Visualizer(false))
            {
                visualizer.LoadXmlFromFile(fileName);
                visualizer.ShowDialog();
                modifiedXml = visualizer.GetModifiedXml();
            }

            return modifiedXml;
        }
    }
}
