// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlVisualizer
{
    internal partial class EditorControlsUserControl : UserControl
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

        public string activeState;
        public string originalXmlFile;
        public string appliedXsdFile;
        
        private string selectedValidationType;
        private bool failBeforeFormat;
        private bool failBeforeUnformat;
        private bool editorStatusTextBoxVisible;
        private bool doNotHandleFormat;
        private bool searchActivated;
        private bool anyChangesInEditor;
        private bool xsdError;

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
                case "XsdFile":
                    saveAsFileDialog.DefaultExt = "xsd";
                    saveAsFileDialog.Filter = "XSD files|*.xsd|All files|*.*";
                    WorkingDir = "LastXsdDir";
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

        public bool ValidateDocument(string validationType)
        {
            bool success = true;
            XmlDocument document = new XmlDocument();

            try
            {
                if (validationType == "Xml")
                {
                    document.LoadXml(editorUserControl.GetText());
                }
                else if (validationType == "XSL")
                {
                    XPathDocument xPathDoc = new XPathDocument(originalXmlFile);
                    XslCompiledTransform xslTrans = new XslCompiledTransform();
                    XmlReader inputFile = XmlReader.Create(new StringReader(editorUserControl.GetText()));
                    xslTrans.Load(inputFile);
                    TextWriter tw = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(tw);
                    xslTrans.Transform(xPathDoc, null, writer);
                    writer.Close();
                }
                else if (validationType == "XSD")
                {
                    if (String.IsNullOrEmpty(appliedXsdFile))
                    {
                        Util.ShowMessage("No XSD file applied. Cannot validate.");
                        success = false;
                    }
                    else
                    {
                        XmlReader xsdDoc = XmlReader.Create(appliedXsdFile);

                        XmlSchemaSet schemaSet = new XmlSchemaSet();
                        schemaSet.Add(null, xsdDoc);

                        XmlReaderSettings readerSettings = new XmlReaderSettings();
                        readerSettings.ValidationType = ValidationType.Schema;
                        readerSettings.Schemas = schemaSet;
                        readerSettings.ValidationEventHandler += XsdValidationCallBack;

                        XmlReader reader = XmlReader.Create(new StringReader(editorUserControl.GetText()), readerSettings);

                        while (reader.Read())
                        {
                        }

                        reader.Close();

                        success = !xsdError;
                        xsdError = false;
                    }
                }
            }
            catch (XsltException e)
            {
                success = false;

                SetEditorStatusTextBox(Util.GetDetailedErrorMessage(e));
                editorUserControl.GotoLine(e.LineNumber, e.LinePosition);
            }
            catch (XmlException e)
            {
                success = false;

                if (validationType == "XSL")
                {
                    Util.ShowMessage(string.Format("Error in Xml document: {0}\r\nPlease fix errors in the Xml document and try again.", Util.GetDetailedErrorMessage(e)));
                }
                else if (validationType == "XSD")
                {
                    Util.ShowMessage(string.Format("Error in XSD document: {0}\r\nPlease fix errors in the XSD document and try again.", Util.GetDetailedErrorMessage(e)));
                }
                else
                {
                    SetEditorStatusTextBox(Util.GetDetailedErrorMessage(e));
                    editorUserControl.GotoLine(e.LineNumber, e.LinePosition);
                }
            }
            catch (Exception e)
            {
                success = false;
                Util.ShowMessage(Util.GetDetailedErrorMessage(e));
            }

            return success;
        }

        private void XsdValidationCallBack(object sender, ValidationEventArgs e)
        {
            xsdError = true;

            SetEditorStatusTextBox(Util.GetDetailedErrorMessage(e.Exception));
            editorUserControl.GotoLine(e.Exception.LineNumber, e.Exception.LinePosition);
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
            StatusTextEvent(string.Format("Validate {0} document", GetDocumentType()));
        }

        private string GetDocumentType()
        {
            string text = "";

            switch (activeState)
            {
                case "InputFile":
                    text = "Xml";
                    break;
                case "XsltFile":
                    text = "XSL";
                    break;
                case "XsdFile":
                    text = "XSD";
                    break;
            }

            return text;
        }

        private void validateButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            bool shouldValidate;

            using (ValidateForm vf = new ValidateForm())
            {
                vf.Text = Util.GetTitle();
                vf.activeState = activeState;
                vf.documentType = GetDocumentType();
                vf.selectedValidationType = selectedValidationType;
                vf.ShowDialog();
                selectedValidationType = vf.selectedValidationType;
                shouldValidate = vf.shouldValidate;
            }

            if (shouldValidate)
            {
                if (ValidateDocument(selectedValidationType))
                {
                    Util.ShowMessage(string.Format("{0} document validated successfully.", GetDocumentType()));
                    CloseStatusBox();
                }
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
                    if (ValidateDocument("Xml"))
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
                            Util.ShowMessage("Cannot format Xml document with errors.\nPlease fix the errors and try again.");
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
            selectedValidationType = "Xml";

            if (formatXmlCheckBox.Checked)
            {
                HandleFormatXml(false);
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
