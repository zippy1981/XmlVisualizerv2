﻿// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace XmlVisualizer
{
    public partial class MainForm : Form
    {
        public bool inject;
        public string originalXmlFile;

        private const int numberOfXPathQueriesToSave = 10;
        private const int numberOfXsltFilesToSave = 10;
        private const int numberOfXmlFilesToSave = 10;
        private States ActiveState;
        private States StateBeforeNewFile;
        private States StateBeforeXsltError;
        private string previousXPathQuery;
        private string previousXsltFile;
        private string previousXmlFile;
        private string previousFileFromXPath;
        private string previousFileFromXslt;
        private string appliedXsltFile;
        private string appliedXPathFile;
        private string tmpDir;
        private string debugString;
        private static bool mainFormLoaded;
        private static bool errorInXslt;
        private static bool editorEnabled;
        private static bool treeviewEnabled;
        private static bool newFile;
        private static bool doNotDeleteFile;

        public MainForm()
        {
            CheckForCompatibleDpi();
            InitializeComponent();
            SetXPathDefaultType();
            FillXPathComboBox();
            FillXsltFileComboBox();
            FillInputFileComboBox();
            SetMainFormProperties(this);
            SetActive(States.InputFile);
            InitializeTreeViewEvents();
            InitializeEditorEvents();
        }

        public bool AnyChangesToInject()
        {
            return editorControlsUserControl.AnyChangesToInject();
        }

        public void SetDebugString(string objectString, bool replaceable)
        {
            debugString = objectString;
            HandleInjectAction(replaceable);
        }

        private void HandleInjectAction(bool replaceable)
        {
            if (replaceable)
            {
                injectCheckBox.Visible = true;
                ReadOnlyLabel.Visible = false;
            }
            else
            {
                injectCheckBox.Visible = false;
                ReadOnlyLabel.Visible = true;
            }
        }

        private void CheckForCompatibleDpi()
        {
            bool compatible = false;
            Graphics graphics = CreateGraphics();
            
            float dpiX = graphics.DpiX;
            float dpiY = graphics.DpiY;

            graphics.Dispose();

            if (dpiX == 96 && dpiY == 96)
            {
                compatible = true;
            }

            if (!compatible)
            {
                Util.ShowMessage("Sorry, only 96 DPI supported.");
                Dispose();
            }
        }

        private void InitializeTreeViewEvents()
        {
            treeViewUserControl.StatusTextEvent += treeViewUserControl_StatusTextEvent;
        }

        private void InitializeEditorEvents()
        {
            editorControlsUserControl.StatusTextEvent += editorControlsUserControl_StatusTextEvent;
            editorControlsUserControl.CloseEvent += editorControlsUserControl_CloseEvent;
            editorControlsUserControl.SaveEvent += editorControlsUserControl_SaveEvent;
            editorControlsUserControl.SaveAsEvent += editorControlsUserControl_SaveAsEvent;
            editorControlsUserControl.UnformatXmlEvent += editorControlsUserControl_UnformatXmlEvent;
            editorControlsUserControl.FormatXmlEvent += editorControlsUserControl_FormatXmlEvent;
            editorControlsUserControl.CaretChangeEvent += editorControlsUserControl_CaretChangeEvent;
        }

        void editorControlsUserControl_CaretChangeEvent(int line, int column)
        {
            toolStripStatusLabel.Text = string.Format("Ln {0}, Col {1}", line, column);
        }

        public bool DeleteOriginalFile()
        {
            return !doNotDeleteFile;
        }

        private void treeViewUserControl_StatusTextEvent(string statusText)
        {
            toolStripStatusLabel.Text = statusText;
        }

        private void editorControlsUserControl_StatusTextEvent(string statusText)
        {
            toolStripStatusLabel.Text = statusText;
        }

        private void editorControlsUserControl_CloseEvent()
        {
            DisableEditorControl(false);
        }

        private void SaveBeforeUnformating(string messageBoxText, string unformattedText)
        {
            bool saved = false;

            DialogResult dr = MessageBox.Show(messageBoxText, Util.GetTitle(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr.ToString() == "Yes")
            {
                if (newFile)
                {
                    saved = editorControlsUserControl.HandleSaveAs(false);
                }
                else
                {
                    saved = editorControlsUserControl.HandleSave(false);
                }
            }
            else if (dr.ToString() == "No")
            {
                editorControlsUserControl.ChangesInEditor = false;
                editorControlsUserControl.SetText(unformattedText);
            }
            else
            {
                editorControlsUserControl.SetDoNotHandleFormat(true);
                editorControlsUserControl.SetFormatXmlCheckBox(true);
                editorControlsUserControl.SetDoNotHandleFormat(false);
            }

            if (saved)
            {
                editorControlsUserControl.ChangesInEditor = false;
                editorControlsUserControl.useSaveAsOnSave = false;
            }
        }

        private void editorControlsUserControl_UnformatXmlEvent()
        {
            string unformattedText;

            switch (ActiveState)
            {
                case States.XsltFile:
                    if (newFile)
                    {
                        unformattedText = GetNewXslt();
                    }
                    else
                    {
                        unformattedText = File.ReadAllText(appliedXsltFile);
                    }

                    break;
                default:
                    if (newFile)
                    {
                        unformattedText = GetNewXml();
                    }
                    else
                    {
                        unformattedText = File.ReadAllText(originalXmlFile);
                    }

                    break;
            }
            
            if (editorControlsUserControl.ChangesInEditor)
            {
                SaveBeforeUnformating("Changes need to be saved before unformating.\r\nSave changes?", unformattedText);
            }
            else
            {
                editorControlsUserControl.SetText(unformattedText);
            }
        }

        private void editorControlsUserControl_FormatXmlEvent(string textToSave)
        {
            CommitFormatting();
        }

        private void CommitFormatting()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(editorControlsUserControl.GetText());

            XmlDeclaration dec = null;

            if (xml.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                dec = (XmlDeclaration)xml.FirstChild;
            }

            XmlWriterSettings writerSettings = new XmlWriterSettings();

            writerSettings.OmitXmlDeclaration = true;
            writerSettings.IndentChars = "\t";
            writerSettings.Indent = true;

            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, writerSettings);

            if (dec != null)
            {
                stringWriter.WriteLine(xml.CreateXmlDeclaration(dec.Version, dec.Encoding, dec.Standalone).OuterXml);
            }

            xmlWriter.Flush();
            stringWriter.Flush();

            xml.Save(xmlWriter);

            editorControlsUserControl.SetText(stringWriter.ToString());

            xmlWriter.Close();
            stringWriter.Dispose();
        }

        private void editorControlsUserControl_SaveEvent(bool applyAfterSave)
        {
            switch (ActiveState)
            {
                case States.XsltFile:
                    SaveEditorContent(xsltFileComboBox.Text, applyAfterSave);

                    break;
                case States.InputFile:
                    SaveEditorContent(originalXmlFile, applyAfterSave);

                    break;
            }
        }
        
        private void editorControlsUserControl_SaveAsEvent(string fileName, bool applyAfterSave)
        {
            switch (ActiveState)
            {
                case States.XsltFile:
                    xsltFileComboBox.Text = fileName;
                    SaveEditorContent(fileName, applyAfterSave);

                    break;
                case States.InputFile:
                    inputFileComboBox.Text = fileName;

                    if (originalXmlFile != inputFileComboBox.Text)
                    {
                        DeleteFile(originalXmlFile);
                        originalXmlFile = inputFileComboBox.Text;
                        doNotDeleteFile = true;
                    }

                    SaveEditorContent(fileName, applyAfterSave);

                    break;
            }
        }

        private void SaveEditorContent(string fileName, bool applyAfterSave)
        {
            switch (ActiveState)
            {
                case States.XsltFile:
                    File.WriteAllText(fileName, editorControlsUserControl.GetText());

                    if (applyAfterSave)
                    {
                        ApplyXsltFile();

                        if (!errorInXslt)
                        {
                            DisableEditorControl(true);
                        }
                    }

                    break;
                case States.InputFile:
                    File.WriteAllText(fileName, editorControlsUserControl.GetText());

                    if (applyAfterSave)
                    {
                        DisableEditorControl(true);
                        Reload();
                    }

                    break;
            }
        }

        private enum States
        {
            InputFile,
            XsltFile,
            XPath
        };

        private static void SetMainFormProperties(Form mainForm)
        {
            string MainFormWidth = Util.ReadFromRegistry("MainFormWidth");
            string MainFormHeight = Util.ReadFromRegistry("MainFormHeight");

            if (MainFormWidth != "")
            {
                mainForm.Width = Convert.ToInt32(MainFormWidth);
            }

            if (MainFormHeight != "")
            {
                mainForm.Height = Convert.ToInt32(MainFormHeight);
            }

            string MainFormLocationX = Util.ReadFromRegistry("MainFormLocationX");
            string MainFormLocationY = Util.ReadFromRegistry("MainFormLocationY");

            if (MainFormLocationX != "" && MainFormLocationY != "")
            {
                mainForm.Location = new Point(Convert.ToInt32(MainFormLocationX), Convert.ToInt32(MainFormLocationY));
            }
            else
            {
                mainForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }

            mainFormLoaded = true;

            if (mainForm.Width + mainForm.Location.X >= SystemInformation.PrimaryMonitorSize.Width || mainForm.Height + mainForm.Location.Y >= SystemInformation.PrimaryMonitorSize.Height)
            {
                mainForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }

            mainForm.Text = Util.GetTitle();
        }

        private void SetXPathDefaultType()
        {
            string xPathQueryType = Util.ReadFromRegistry("XPathQueryType");

            if (xPathQueryType == "")
            {
                xPathTypeComboBox.SelectedIndex = xPathTypeComboBox.FindString("InnerXml");
            }
            else
            {
                xPathTypeComboBox.SelectedIndex = xPathTypeComboBox.FindString(xPathQueryType);
            }

            if (xPathTypeComboBox.SelectedItem.ToString() == "Value")
            {
                treeViewCheckBox.Enabled = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (editorControlsUserControl.ChangesInEditor)
            {
                DialogResult dr = MessageBox.Show("Discard changes?", Util.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr.ToString() == "No")
                {
                    return;
                }
            }

            if (injectCheckBox.Checked)
            {
                inject = true;
            }

            Dispose();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            using (AboutForm af = new AboutForm())
            {
                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                af.ProgramVersion = version.Substring(0, version.Length - 4);
                af.Title = Util.GetTitle();
                af.ShowDialog();
            }
        }

        private void ReloadWebBrowser()
        {
            Uri uri = new Uri(inputFileComboBox.Text);
            webBrowser.Url = uri;
        }

        private void ApplyXsltFile()
        {
            string previousFile = inputFileComboBox.Text;

            DeleteAutoGeneratedFiles();

            try
            {
                string outputFile = string.Format(@"{0}\{1}.html", tmpDir, Guid.NewGuid());
                CommitXslt(outputFile);
                inputFileComboBox.Text = outputFile;
                previousFileFromXslt = outputFile;
                errorInXslt = false;
                appliedXsltFile = xsltFileComboBox.Text;

                Reload();
            }
            catch (System.Xml.Xsl.XsltException e)
            {
                Util.ShowMessage(Util.GetDetailedErrorMessage(e));
                inputFileComboBox.Text = previousFile;
                HandleXsltError();
                editorControlsUserControl.SetEditorStatusTextBox(Util.GetDetailedErrorMessage(e));
                editorControlsUserControl.GotoLine(e.LineNumber, e.LinePosition);
            }
            catch (Exception e)
            {
                Util.ShowMessage(Util.GetDetailedErrorMessage(e));
                inputFileComboBox.Text = previousFile;
            }
        }

        private void HandleXsltError()
        {
            if (!errorInXslt)
            {
                StateBeforeXsltError = ActiveState;
            }

            if (newFile)
            {
                StateBeforeXsltError = StateBeforeNewFile;
            }

            if (ActiveState != States.XsltFile)
            {
                SetActive(States.XsltFile);
            }

            errorInXslt = true;

            if (!editorEnabled)
            {
                HandleEditor();
            }
        }

        private void DeleteAutoGeneratedFiles()
        {
            if (!string.IsNullOrEmpty(previousFileFromXPath))
            {
                DeleteFile(previousFileFromXPath);
                previousFileFromXPath = "";
            }

            if (!string.IsNullOrEmpty(previousFileFromXslt))
            {
                DeleteFile(previousFileFromXslt);
                previousFileFromXslt = "";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteAutoGeneratedFiles();
        }

        private void ApplyXPathQuery()
        {
            string previousFile = inputFileComboBox.Text;

            DeleteAutoGeneratedFiles();

            try
            {
                string fileExtension = "xml";

                if (xPathTypeComboBox.SelectedItem.ToString() == "Value")
                {
                    fileExtension = "html";
                    treeViewCheckBox.Checked = false;
                    treeViewCheckBox.Enabled = false;
                }
                else
                {
                    treeViewCheckBox.Enabled = true;
                }

                inputFileComboBox.Text = string.Format(@"{0}\{1}.{2}", tmpDir, Guid.NewGuid(), fileExtension);
                previousFileFromXPath = inputFileComboBox.Text;
                appliedXPathFile = inputFileComboBox.Text;
                CommitXPath();

                Reload();
            }
            catch (Exception e)
            {
                inputFileComboBox.Text = previousFile;
                Util.ShowMessage(Util.GetDetailedErrorMessage(e));
            }
        }

        private void Reload()
        {
            if (treeviewEnabled)
            {
                if (!treeViewUserControl.ReloadTreeView(inputFileComboBox.Text))
                {
                    DisableTreeView();
                }
            }
            else
            {
                ReloadWebBrowser();
            }
        }

        private void CommitXslt(string outputFile)
        {
            XPathDocument xPathDoc = new XPathDocument(originalXmlFile);
            System.Xml.Xsl.XslCompiledTransform xslTrans = new System.Xml.Xsl.XslCompiledTransform();
            xslTrans.Load(xsltFileComboBox.Text);
            XmlTextWriter writer = new XmlTextWriter(outputFile, System.Text.Encoding.Default);
            xslTrans.Transform(xPathDoc, null, writer);
            writer.Close();

            if (previousXsltFile != xsltFileComboBox.Text)
            {
                previousXsltFile = xsltFileComboBox.Text;
                Util.SaveComboBoxItemToRegistry(xsltFileComboBox.Text, "XsltFile", numberOfXsltFilesToSave);
                FillXsltFileComboBox();
            }

            if (ActiveState != States.XsltFile)
            {
                SetActive(States.XsltFile);
            }
        }

        private void CommitXPath()
        {
            XPathDocument doc = new XPathDocument(originalXmlFile);
            XPathNavigator nav = doc.CreateNavigator();

            string result = "";

            if (nav.Evaluate(xPathComboBox.Text).GetType().ToString() == "MS.Internal.Xml.XPath.XPathSelectionIterator")
            {
                XPathNodeIterator iterator = (XPathNodeIterator)nav.Evaluate(xPathComboBox.Text);

                while (iterator.MoveNext())
                {
                    string resultType = "";

                    switch (xPathTypeComboBox.SelectedItem.ToString())
                    {
                        case "InnerXml":
                            resultType = iterator.Current.InnerXml;
                            break;
                        case "OuterXml":
                            resultType = iterator.Current.OuterXml;
                            break;
                        case "Value":
                            resultType = iterator.Current.Value;
                            break;
                    }

                    result += string.Format("{0}\r\n", resultType);
                }
            }
            else
            {
                result = string.Format("{0}\r\n", nav.Evaluate(xPathComboBox.Text));
            }

            if (xPathTypeComboBox.SelectedItem.ToString() == "Value")
            {
                result = string.Format("<pre>\r\n{0}</pre>", result);
            }
            else
            {
                result = string.Format("<xml>\r\n{0}</xml>", result);
            }

            File.WriteAllText(inputFileComboBox.Text, result);

            if (previousXPathQuery != xPathComboBox.Text)
            {
                previousXPathQuery = xPathComboBox.Text;
                Util.SaveComboBoxItemToRegistry(xPathComboBox.Text, "XPath", numberOfXPathQueriesToSave);
                FillXPathComboBox();
            }

            if (ActiveState != States.XPath)
            {
                SetActive(States.XPath);
            }
        }

        private void SetActive(States state)
        {
            switch (state)
            {
                case States.InputFile:
                    ActiveState = States.InputFile;
                    inputFileComboBox.Enabled = true;
                    applyXmlButton.Text = "Apply";
                    inputFilePictureBox.Visible = true;
                    xsltFilePictureBox.Visible = false;
                    xPathPictureBox.Visible = false;
                    editButton.Enabled = true;
                    treeViewCheckBox.Enabled = true;
                    break;
                case States.XsltFile:
                    ActiveState = States.XsltFile;
                    inputFileComboBox.Enabled = false;
                    applyXmlButton.Text = "Revert Xml";
                    xsltFilePictureBox.Visible = true;
                    inputFilePictureBox.Visible = false;
                    xPathPictureBox.Visible = false;
                    editButton.Enabled = true;
                    treeViewCheckBox.Enabled = true;
                    break;
                case States.XPath:
                    ActiveState = States.XPath;
                    inputFileComboBox.Enabled = false;
                    applyXmlButton.Text = "Revert Xml";
                    xPathPictureBox.Visible = true;
                    inputFilePictureBox.Visible = false;
                    xsltFilePictureBox.Visible = false;
                    editButton.Enabled = false;

                    if (xPathTypeComboBox.SelectedItem.ToString() == "Value")
                    {
                        treeViewCheckBox.Enabled = false;
                    }
                    else
                    {
                        treeViewCheckBox.Enabled = true;
                    }
                    
                    break;
            }
        }

        private void FillXsltFileComboBox()
        {
            xsltFileComboBox.Items.Clear();

            for (int i = 1; i <= numberOfXsltFilesToSave; i++)
            {
                string item = Util.ReadFromRegistry("XsltFile" + i);

                if (item != "")
                {
                    xsltFileComboBox.Items.Add(item);
                }
            }

            xsltFileComboBox.Text = Util.ReadFromRegistry("XsltFile1");
            previousXsltFile = xsltFileComboBox.Text;
            appliedXsltFile = xsltFileComboBox.Text;
        }

        private void FillInputFileComboBox()
        {
            inputFileComboBox.Items.Clear();

            for (int i = 1; i <= numberOfXmlFilesToSave; i++)
            {
                string item = Util.ReadFromRegistry("XmlFile" + i);

                if (item != "")
                {
                    inputFileComboBox.Items.Add(item);
                }
            }
        }

        private void FillXPathComboBox()
        {
            xPathComboBox.Items.Clear();

            for (int i = 1; i <= numberOfXPathQueriesToSave; i++)
            {
                string item = Util.ReadFromRegistry("XPath" + i);
                
                if (item != "")
                {
                    xPathComboBox.Items.Add(item);
                }
            }

            xPathComboBox.Text = Util.ReadFromRegistry("XPath1");
            previousXPathQuery = xPathComboBox.Text;
        }

        private void ToClipboardButton_Click(object sender, EventArgs e)
        {
            string sr;

            if (editorEnabled)
            {
                sr = editorControlsUserControl.GetText();
            }
            else
            {
                sr = File.ReadAllText(inputFileComboBox.Text);

                if (xPathTypeComboBox.SelectedItem.ToString() == "Value" && ActiveState == States.XPath)
                {
                    sr = sr.Substring(7, sr.Length - 15);
                }
            }

            StringBuilder sb = new StringBuilder(sr);

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i].ToString() == "\n")
                {
                    if (sb[i - 1].ToString() != "\r")
                    {
                        sb[i - 1] = Convert.ToChar("\r");
                    }
                }
            }

            Clipboard.SetDataObject(sb.ToString(), true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tmpDir = Environment.GetEnvironmentVariable("temp");
            originalXmlFile = string.Format(@"{0}\{1}.xml", tmpDir, Guid.NewGuid());
            previousXmlFile = originalXmlFile;
            inputFileComboBox.Text = originalXmlFile;
            File.WriteAllText(originalXmlFile, debugString);
            webBrowser.Url = new Uri(originalXmlFile);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                Util.SaveToRegistry("MainFormWidth", ActiveForm.Width.ToString());
                Util.SaveToRegistry("MainFormHeight", ActiveForm.Height.ToString());

                inputFileComboBox.Select(0, 0);
                xPathComboBox.Select(0, 0);
                xsltFileComboBox.Select(0, 0);
            }
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                if (ActiveForm.Location.X > 0 && ActiveForm.Location.Y > 0)
                {
                    Util.SaveToRegistry("MainFormLocationX", ActiveForm.Location.X.ToString());
                    Util.SaveToRegistry("MainFormLocationY", ActiveForm.Location.Y.ToString());
                }
            }
        }

        private void OpenInBrowserButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(Util.GetDefaultWebBrowser());
            psi.Arguments = inputFileComboBox.Text;
            System.Diagnostics.Process.Start(psi);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            HandleEditor();
        }

        private void HandleEditor()
        {
            string fileToEdit = "";

            switch (ActiveState)
            {
                case States.XsltFile:
                    if (errorInXslt)
                    {
                        fileToEdit = xsltFileComboBox.Text;
                    }
                    else
                    {
                        fileToEdit = appliedXsltFile;
                        xsltFileComboBox.Text = appliedXsltFile;
                    }
                    
                    break;
                case States.InputFile:
                    fileToEdit = originalXmlFile;
                    break;
            }

            editorControlsUserControl.SetText(File.ReadAllText(fileToEdit));

            EnableEditorControl();

            if (errorInXslt)
            {
                editorControlsUserControl.ValidateDocument();
            }
        }

        private void EnableEditorControl()
        {
            if (newFile)
            {
                editorControlsUserControl.useSaveAsOnSave = true;
            }
            else
            {
                editorControlsUserControl.useSaveAsOnSave = false;
            }

            newXmlFileButton.Enabled = false;
            inputFileComboBox.Enabled = false;
            newXsltFileButton.Enabled = false;
            xsltFileComboBox.Enabled = false;
            xPathComboBox.Enabled = false;
            xPathTypeComboBox.Enabled = false;
            applyXmlButton.Enabled = false;
            applyXpathButton.Enabled = false;
            applyXsltButton.Enabled = false;
            openInBrowserButton.Enabled = false;
            editButton.Enabled = false;
            selectXmlFileButton.Enabled = false;
            selectXsltFileButton.Enabled = false;
            treeViewCheckBox.Enabled = false;

            if (treeviewEnabled)
            {
                treeViewUserControl.Visible = false;
            }
            else
            {
                webBrowser.Visible = false;
            }

            editorControlsUserControl.originalXmlFile = originalXmlFile;
            editorControlsUserControl.activeState = ActiveState.ToString();
            editorControlsUserControl.EnableEditor();
            editorControlsUserControl.ReadFormatXmlState();
            editorControlsUserControl.Visible = true;
            editorEnabled = true;
        }

        private void DisableEditorControl(bool applyAfterSave)
        {
            States StateAfterClose = ActiveState;

            if (newFile)
            {
                if (!applyAfterSave)
                {
                    StateAfterClose = StateBeforeNewFile;
                }

                newFile = false;
            }
            
            if (errorInXslt)
            {
                if (StateBeforeXsltError == States.XsltFile)
                {
                    if (xsltFileComboBox.Text != appliedXsltFile)
                    {
                        xsltFileComboBox.Text = appliedXsltFile;
                    }
                    else
                    {
                        StateAfterClose = States.InputFile;
                        inputFileComboBox.Text = originalXmlFile;
                    }
                }
                else
                {
                    StateAfterClose = StateBeforeXsltError;
                }

                errorInXslt = false;
            }

            SetActive(StateAfterClose);

            switch (StateAfterClose)
            {
                case States.XPath:
                    inputFileComboBox.Text = appliedXPathFile;
                    break;
                case States.InputFile:
                    inputFileComboBox.Text = originalXmlFile;
                    break;
            }

            xsltFileComboBox.Text = appliedXsltFile;

            newXmlFileButton.Enabled = true;
            newXsltFileButton.Enabled = true;
            xsltFileComboBox.Enabled = true;
            xPathComboBox.Enabled = true;
            xPathTypeComboBox.Enabled = true;
            applyXmlButton.Enabled = true;
            applyXpathButton.Enabled = true;
            applyXsltButton.Enabled = true;
            openInBrowserButton.Enabled = true;
            selectXmlFileButton.Enabled = true;
            selectXsltFileButton.Enabled = true;

            if (treeviewEnabled)
            {
                treeViewUserControl.Visible = true;
            }
            else
            {
                webBrowser.Visible = true;
            }

            editorControlsUserControl.CloseStatusBox();
            editorControlsUserControl.Visible = false;
            editorEnabled = false;
        }

        private void XPathComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyXPathQuery();
            }
        }

        private void XPathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainFormLoaded)
            {
                ApplyXPathQuery();
            }
        }

        private void XPathTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainFormLoaded)
            {
                Util.SaveToRegistry("XPathQueryType", xPathTypeComboBox.SelectedItem.ToString());
                ApplyXPathQuery();
            }
        }

        private void XsltFileComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckForValidXsltInput();
            }
        }

        private void NewXsltFileButton_Click(object sender, EventArgs e)
        {
            editorControlsUserControl.SetText(GetNewXslt());
            xsltFileComboBox.Text = "";
            StateBeforeNewFile = ActiveState;
            SetActive(States.XsltFile);
            newFile = true;
            EnableEditorControl();
        }

        private static string GetNewXslt()
        {
            return "<?xml version=\"1.0\"?>\r\n<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">\r\n\t\r\n</xsl:stylesheet>\r\n";
        }

        private static string GetNewXml()
        {
            return "<?xml version=\"1.0\"?>\r\n<root>\r\n\t\r\n</root>\r\n";
        }

        private void EnableTreeView()
        {
            if (treeViewUserControl.ReloadTreeView(inputFileComboBox.Text))
            {
                webBrowser.Visible = false;
                treeviewEnabled = true;
                treeViewUserControl.Visible = true;
            }
            else
            {
                DisableTreeView();
            }
        }

        private void DisableTreeView()
        {
            ReloadWebBrowser();
            webBrowser.Visible = true;
            treeViewCheckBox.Checked = false;
            treeviewEnabled = false;
            treeViewUserControl.Visible = false;
        }

        private void TreeViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (treeViewCheckBox.Checked)
            {
                EnableTreeView();
            }
            else
            {
                DisableTreeView();
            }
        }

        private void XsltFileComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            xsltFileComboBox.Text = xsltFileComboBox.SelectedItem.ToString();
            CheckForValidXsltInput();
        }

        private void openInBrowserButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Open in Internet Explorer";
        }

        private void openInBrowserButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void aboutButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Format("About {0}", Util.GetTitle());
        }

        private void aboutButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void toClipboardButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Copy content to Clipboard";
        }

        private void toClipboardButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void editButton_MouseEnter(object sender, EventArgs e)
        {
            switch (ActiveState)
            {
                case States.InputFile:
                    toolStripStatusLabel.Text = "Edit Xml document";
                    break;
                case States.XsltFile:
                    toolStripStatusLabel.Text = "Edit XSLT document";
                    break;
            }
        }

        private void editButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void treeViewCheckBox_MouseEnter(object sender, EventArgs e)
        {
            switch (ActiveState)
            {
                case States.InputFile:
                    toolStripStatusLabel.Text = "Show Xml in Tree view";
                    break;
                case States.XPath:
                    toolStripStatusLabel.Text = "Show XPath result in Tree view";
                    break;
            }
        }

        private void treeViewCheckBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void injectCheckBox_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Inject Xml back into running application on Close";
        }

        private void injectCheckBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Format("Close {0}", Util.GetTitle());
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void xPathTypeComboBox_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Change representation of XPath result";
        }

        private void xPathTypeComboBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void xPathComboBox_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Enter XPath query or function";
        }

        private void xPathComboBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void selectXsltFileButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Open XSLT document";
        }

        private void selectXsltFileButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void newXsltFileButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Create new XSLT document";
        }

        private void newXsltFileButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void xsltFileComboBox_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Active XSLT document";
        }

        private void xsltFileComboBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void inputFileComboBox_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Active Xml document";
        }

        private void inputFileComboBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void applyXsltButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Apply XSL Transformation";
        }

        private void applyXsltButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void applyXpathButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Execute XPath query or function";
        }

        private void applyXpathButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void newXmlFileButton_Click(object sender, EventArgs e)
        {
            editorControlsUserControl.SetText(GetNewXml());
            inputFileComboBox.Text = "";
            StateBeforeNewFile = ActiveState;
            SetActive(States.InputFile);
            newFile = true;
            EnableEditorControl();
        }

        private void inputFileComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckForValidXmlInput();
            }
        }

        private void ApplyXmlFile()
        {
            originalXmlFile = inputFileComboBox.Text;
            
            SetActive(States.InputFile);

            if (previousXmlFile != inputFileComboBox.Text)
            {
                previousXmlFile = inputFileComboBox.Text;
                Util.SaveComboBoxItemToRegistry(inputFileComboBox.Text, "XmlFile", numberOfXmlFilesToSave);
                FillInputFileComboBox();
                inputFileComboBox.Text = originalXmlFile;
            }

            Reload();
        }

        private static void DeleteFile(string file)
        {
            Util.DeleteFile(file);
        }

        private void inputFileComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            inputFileComboBox.Text = inputFileComboBox.SelectedItem.ToString();
            CheckForValidXmlInput();
        }

        private void applyXmlButton_Click(object sender, EventArgs e)
        {
            CheckForValidXmlInput();
        }

        private void CheckForValidXmlInput()
        {
            if (inputFileComboBox.Text.Trim().ToLower() == originalXmlFile.ToLower())
            {
                return;
            }
            
            string fileToDelete = inputFileComboBox.Text;

            if (ActiveState != States.InputFile)
            {
                inputFileComboBox.Text = originalXmlFile;
            }

            inputFileComboBox.Text = inputFileComboBox.Text.Trim();

            if (inputFileComboBox.Text == "")
            {
                Util.ShowMessage("No Xml file specified.");
                inputFileComboBox.Text = originalXmlFile;
            }
            else if (!File.Exists(inputFileComboBox.Text))
            {
                Util.ShowMessage(string.Format("Xml file '{0}' not found.", inputFileComboBox.Text));
                inputFileComboBox.Text = originalXmlFile;
            }
            else
            {
                if (ActiveState == States.InputFile)
                {
                    if (!doNotDeleteFile)
                    {
                        DeleteFile(originalXmlFile);
                        doNotDeleteFile = true;
                    }
                }
                else
                {
                    DeleteFile(fileToDelete);
                }

                ApplyXmlFile();
            }
        }

        private void CheckForValidXsltInput()
        {
            xsltFileComboBox.Text = xsltFileComboBox.Text.Trim();

            if (xsltFileComboBox.Text == "")
            {
                Util.ShowMessage("No XSLT file specified.");
                xsltFileComboBox.Text = appliedXsltFile;
            }
            else if (!File.Exists(xsltFileComboBox.Text))
            {
                Util.ShowMessage(string.Format("XSLT file '{0}' not found.", xsltFileComboBox.Text));
                xsltFileComboBox.Text = appliedXsltFile;
            }
            else
            {
                ApplyXsltFile();
            }
        }

        private void applyXmlButton_MouseEnter(object sender, EventArgs e)
        {
            switch (ActiveState)
            {
                case States.InputFile:
                    toolStripStatusLabel.Text = "Load Xml document";
                    break;
                default:
                    toolStripStatusLabel.Text = "Revert back to original or last saved Xml document";
                    break;
            }
        }

        private void applyXmlButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void applyXsltButton_Click(object sender, EventArgs e)
        {
            CheckForValidXsltInput();
        }

        private void applyXpathButton_Click(object sender, EventArgs e)
        {
            xPathComboBox.Text = xPathComboBox.Text.Trim();

            if (xPathComboBox.Text == "")
            {
                Util.ShowMessage("No XPath Query specified.");
            }
            else
            {
                ApplyXPathQuery();
            }
        }

        private void SelectXsltFileButton_Click(object sender, EventArgs e)
        {
            openXsltFileDialog.Title = Util.GetTitle();
            openXsltFileDialog.InitialDirectory = Util.ReadFromRegistry("LastXsltDir");
            openXsltFileDialog.ShowDialog();
        }

        private void SelectXmlFileButton_Click(object sender, EventArgs e)
        {
            openXmlFileDialog.Title = Util.GetTitle();
            openXmlFileDialog.InitialDirectory = Util.ReadFromRegistry("LastXmlDir");
            openXmlFileDialog.ShowDialog();
        }

        private void OpenXsltFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xsltFileComboBox.Text = openXsltFileDialog.FileName;

            string dir = openXsltFileDialog.FileName.Substring(0, openXsltFileDialog.FileName.LastIndexOf("\\"));
            Util.SaveToRegistry("LastXsltDir", dir);

            CheckForValidXsltInput();
        }

        private void OpenXmlFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            inputFileComboBox.Text = openXmlFileDialog.FileName;

            string dir = openXmlFileDialog.FileName.Substring(0, openXmlFileDialog.FileName.LastIndexOf("\\"));
            Util.SaveToRegistry("LastXmlDir", dir);

            CheckForValidXmlInput();
        }

        private void newXmlFileButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Create new Xml document";
        }

        private void newXmlFileButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void selectXmlFileButton_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Open Xml document";
        }

        private void selectXmlFileButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }
    }
}