// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlVisualizer
{
    public partial class EditorControlsUserControl : UserControl
    {
        public delegate void StatusTextEventHandler(string statusText);
        public event StatusTextEventHandler StatusTextEvent;

        public delegate void EditorControlsSaveEventHandler(bool applyAfterSave);
        public event EditorControlsSaveEventHandler SaveEvent;

        public delegate void EditorControlsSaveAsEventHandler(string fileName, bool applyAfterSave);
        public event EditorControlsSaveAsEventHandler SaveAsEvent;

        public delegate void EditorControlsCloseEventHandler();
        public event EditorControlsCloseEventHandler CloseEvent;

        public delegate void EditorControlsFormatXmlEventHandler(string textToSave);
        public event EditorControlsFormatXmlEventHandler FormatXmlEvent;

        public delegate void EditorControlsUnformatXmlEventHandler();
        public event EditorControlsUnformatXmlEventHandler UnformatXmlEvent;

        public delegate void CaretChangeEventHandler(int line, int column);
        public event CaretChangeEventHandler CaretChangeEvent;

        public bool useSaveAsOnSave;
        public bool disableSaveAsButton;

        public string activeState;
        public string originalXmlFile;

        private static bool failBeforeFormat;
        private static bool failBeforeUnformat;
        private static bool editorStatusTextBoxVisible;
        private static bool doNotHandleFormat;
        private static bool searchActivated;
        private static bool anyChangesInEditor;

        public EditorControlsUserControl()
        {
            InitializeComponent();
            editorUserControl.CaretChangeEvent += editorUserControl_CaretChangeEvent;
        }

        public void ReadFormatXmlState()
        {
            string formatXml = Util.ReadFromRegistry("FormatXml");
            bool format = false;

            if (formatXml == "True")
            {
                format = true;
            }

            formatXmlCheckBox.Checked = format;
        }

        void editorUserControl_CaretChangeEvent(int line, int column)
        {
            CaretChangeEvent(line, column);
        }

        public string GetText()
        {
            return editorUserControl.GetText();
        }

        public void SetText(string text)
        {
            editorUserControl.SetText(text);
        }

        private void SaveAsEditButton_Click(object sender, EventArgs e)
        {
            HandleSaveAs(true);
        }

        public bool HandleSave(bool applyAfterSave)
        {
            bool saved;

            if (useSaveAsOnSave)
            {
                saved = HandleSaveAs(applyAfterSave);
            }
            else
            {
                SaveEvent(applyAfterSave);
                saved = true;
            }

            return saved;
        }

        public bool HandleSaveAs(bool applyAfterSave)
        {
            bool saved = false;
            string WorkingDir = "";

            saveAsFileDialog.FileName = "";

            switch (activeState)
            {
                case "XsltFile":
                    saveAsFileDialog.DefaultExt = "xslt";
                    saveAsFileDialog.Filter = "XSLT files|*.xslt|All files|*.*";
                    WorkingDir = "LastXsltDir";
                    break;
                case "InputFile":
                    saveAsFileDialog.DefaultExt = "xml";
                    saveAsFileDialog.Filter = "Xml files|*.xml|All files|*.*";
                    WorkingDir = "LastXmlDir";
                    break;
            }

            saveAsFileDialog.InitialDirectory = Util.ReadFromRegistry(WorkingDir);
            saveAsFileDialog.Title = Util.GetTitle();
            DialogResult dr = saveAsFileDialog.ShowDialog();

            if (dr.ToString() == "OK")
            {
                string dir = saveAsFileDialog.FileName.Substring(0, saveAsFileDialog.FileName.LastIndexOf("\\"));
                Util.SaveToRegistry(WorkingDir, dir); 
                SaveAsEvent(saveAsFileDialog.FileName, applyAfterSave);
                saved = true;
            }
            else
            {
                editorUserControl.SetFocus();
            }

            return saved;
        }

        private void SaveEditButton_Click(object sender, EventArgs e)
        {
            bool saved = HandleSave(true);

            if (saved)
            {
                if (editorUserControl.ChangesInEditor)
                {
                    if (activeState == "InputFile")
                    {
                        anyChangesInEditor = true;
                    }

                    editorUserControl.ChangesInEditor = false;
                }

                useSaveAsOnSave = false;
            }
        }

        public bool ChangesInEditor
        {
            get
            {
                return editorUserControl.ChangesInEditor;
            }
            set
            {
                editorUserControl.ChangesInEditor = value;
            }
        }

        public bool AnyChangesToInject()
        {
            return anyChangesInEditor;
        }

        public bool ValidateDocument()
        {
            bool success = true;
            XmlDocument document = new XmlDocument();
            string xsltFile = "";
            string outputFile = "";

            if (activeState == "XsltFile")
            {
                string tmpDir = Environment.GetEnvironmentVariable("temp");
                xsltFile = string.Format(@"{0}\{1}.xml", tmpDir, Guid.NewGuid());
                outputFile = string.Format(@"{0}\{1}.html", tmpDir, Guid.NewGuid());
            }

            try
            {
                if (activeState == "InputFile")
                {
                    document.LoadXml(editorUserControl.GetText());
                }
                else if (activeState == "XsltFile")
                {
                    File.WriteAllText(xsltFile, editorUserControl.GetText());

                    XPathDocument xPathDoc = new XPathDocument(originalXmlFile);
                    XslCompiledTransform xslTrans = new XslCompiledTransform();
                    xslTrans.Load(xsltFile);
                    XmlTextWriter writer = new XmlTextWriter(outputFile, System.Text.Encoding.Default);
                    xslTrans.Transform(xPathDoc, null, writer);
                    writer.Close();
                }
            }
            catch (XmlException e)
            {
                success = false;

                SetEditorStatusTextBox(Util.GetDetailedErrorMessage(e));
                editorUserControl.GotoLine(e.LineNumber, e.LinePosition);
            }
            catch (XsltException e)
            {
                success = false;

                SetEditorStatusTextBox(Util.GetDetailedErrorMessage(e));
                editorUserControl.GotoLine(e.LineNumber, e.LinePosition);
            }
            finally
            {
                if (activeState == "XsltFile")
                {
                    Util.DeleteFile(xsltFile);
                    Util.DeleteFile(outputFile);
                }
            }

            return success;
        }

        public void SetEditorStatusTextBox(string text)
        {
            if (!editorStatusTextBoxVisible)
            {
                editorUserControl.Height = editorUserControl.Height - (editorStatusTextBox.Height + editorUserControl.Margin.Top);
                editorStatusTextBox.Visible = true;
                editorStatusTextBoxVisible = true;
                editorStatusTextBox.Location = new System.Drawing.Point(editorStatusTextBox.Location.X, editorUserControl.Height + editorUserControl.Margin.Top);
            }

            editorStatusTextBox.Text = text;

            if (editorStatusTextBox.GetLineFromCharIndex(editorStatusTextBox.Text.Length) > 0)
            {
                editorStatusTextBox.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                editorStatusTextBox.ScrollBars = ScrollBars.None;
            }
        }

        public void GotoLine(int line, int column)
        {
            editorUserControl.GotoLine(line, column);
        }

        public void SetFormatXmlCheckBox(bool value)
        {
            formatXmlCheckBox.Checked = value;
        }

        public void SetFailBeforeFormat(bool value)
        {
            failBeforeFormat = value;
        }

        private void validateButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Validate document");
        }

        private void validateButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            if (ValidateDocument())
            {
                Util.ShowMessage("Document validated successfully");
                CloseStatusBox();
            }
        }

        public void CloseStatusBox()
        {
            if (editorStatusTextBoxVisible)
            {
                editorUserControl.Height = editorUserControl.Height + editorStatusTextBox.Height + editorUserControl.Margin.Top;
                editorStatusTextBox.Visible = false;
                editorStatusTextBoxVisible = false;
            }
        }

        public void SetDoNotHandleFormat(bool value)
        {
            doNotHandleFormat = value;
        }

        private void formatXmlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!doNotHandleFormat)
            {
                HandleFormatXml(true);
            }
        }

        private void HandleFormatXml(bool showInvalidFormatWarning)
        {
            if (failBeforeFormat)
            {
                failBeforeFormat = false;
                return;
            }

            if (failBeforeUnformat)
            {
                failBeforeUnformat = false;
                return;
            }

            if (formatXmlCheckBox.Checked)
            {
                if (!failBeforeUnformat)
                {
                    if (ValidateDocument())
                    {
                        CloseStatusBox();
                        failBeforeFormat = false;
                        FormatXmlEvent(editorUserControl.GetText());
                    }
                    else
                    {
                        failBeforeFormat = true;
                        formatXmlCheckBox.Checked = false;

                        if (showInvalidFormatWarning)
                        {
                            Util.ShowMessage("Cannot format document with errors.\nFix the errors and try again.");
                        }
                    }
                }
            }
            else
            {
                if (!failBeforeFormat)
                {
                    failBeforeUnformat = false;
                    UnformatXmlEvent();
                }
                else
                {
                    failBeforeUnformat = true;
                    formatXmlCheckBox.Checked = true;
                }
            }

            SaveFormatXmlState();
        }

        private void SaveFormatXmlState()
        {
            Util.SaveToRegistry("FormatXml", formatXmlCheckBox.Checked.ToString());
        }

        private void cancelEditButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Close editor");
        }

        private void cancelEditButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void saveEditButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Save current file and apply the file");
        }

        private void saveEditButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void saveAsEditButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Save as new file and apply the file");
        }

        private void saveAsEditButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void formatXmlCheckBox_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Format tags on individual lines");
        }

        private void formatXmlCheckBox_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            if (editorUserControl.ChangesInEditor)
            {
                DialogResult dr = MessageBox.Show("Discard changes?", Util.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr.ToString() == "Yes")
                {
                    DisableEditor();
                }
            }
            else
            {
                DisableEditor();
            }
        }

        public void EnableEditor()
        {
            if (formatXmlCheckBox.Checked)
            {
                HandleFormatXml(false);
            }

            if (disableSaveAsButton)
            {
                saveAsEditButton.Enabled = false;
            }
            else
            {
                saveAsEditButton.Enabled = true;
            }

            editorUserControl.SetFocus();
        }

        private void DisableEditor()
        {
            editorUserControl.ChangesInEditor = false;
            Visible = false;
            CloseEvent();
        }

        private void searchForwardButton_Click(object sender, EventArgs e)
        {
            if (searchActivated)
            {
                Search(searchTextBox.Text);
            }
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(searchTextBox.Text);
            }

            searchTextBox.Focus();
        }

        private void Search(string searchText)
        {
            editorUserControl.Search(searchText);
        }

        private void searchTextBox_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Search in document");
        }

        private void searchTextBox_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void searchForwardButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Find next occurence of search text");
        }

        private void searchForwardButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (!searchActivated)
            {
                searchTextBox.ForeColor = System.Drawing.Color.Black;
                searchTextBox.Text = "";
                searchActivated = true;
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
                searchTextBox.Text = "Search...";
                searchActivated = false;
            }
        }
    }
}
