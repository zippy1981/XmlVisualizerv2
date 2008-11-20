// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

namespace XmlVisualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.applyXsltButton = new System.Windows.Forms.Button();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.xsltFileLabel = new System.Windows.Forms.Label();
            this.applyXmlButton = new System.Windows.Forms.Button();
            this.openXsltFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.xPathLabel = new System.Windows.Forms.Label();
            this.applyXpathButton = new System.Windows.Forms.Button();
            this.xPathTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showLabel = new System.Windows.Forms.Label();
            this.injectCheckBox = new System.Windows.Forms.CheckBox();
            this.xPathComboBox = new System.Windows.Forms.ComboBox();
            this.xsltFileComboBox = new System.Windows.Forms.ComboBox();
            this.treeViewCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectXsltFileButton = new System.Windows.Forms.Button();
            this.inputFileComboBox = new System.Windows.Forms.ComboBox();
            this.selectXmlFileButton = new System.Windows.Forms.Button();
            this.openXmlFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.newXmlFileButton = new System.Windows.Forms.Button();
            this.newXsltFileButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.openInBrowserButton = new System.Windows.Forms.Button();
            this.xPathPictureBox = new System.Windows.Forms.PictureBox();
            this.xsltFilePictureBox = new System.Windows.Forms.PictureBox();
            this.inputFilePictureBox = new System.Windows.Forms.PictureBox();
            this.toClipboardButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.ReadOnlyLabel = new System.Windows.Forms.Label();
            this.editorControlsUserControl = new XmlVisualizer.EditorControlsUserControl();
            this.treeViewUserControl = new XmlVisualizer.TreeViewUserControl();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPathPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsltFilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputFilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(18, 104);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(556, 274);
            this.webBrowser.TabIndex = 5;
            this.webBrowser.TabStop = false;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // applyXsltButton
            // 
            this.applyXsltButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyXsltButton.Location = new System.Drawing.Point(505, 38);
            this.applyXsltButton.Name = "applyXsltButton";
            this.applyXsltButton.Size = new System.Drawing.Size(75, 23);
            this.applyXsltButton.TabIndex = 8;
            this.applyXsltButton.Text = "Apply";
            this.applyXsltButton.UseVisualStyleBackColor = true;
            this.applyXsltButton.MouseLeave += new System.EventHandler(this.applyXsltButton_MouseLeave);
            this.applyXsltButton.Click += new System.EventHandler(this.applyXsltButton_Click);
            this.applyXsltButton.MouseEnter += new System.EventHandler(this.applyXsltButton_MouseEnter);
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(9, 16);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(47, 13);
            this.inputFileLabel.TabIndex = 6;
            this.inputFileLabel.Text = "Input file";
            // 
            // xsltFileLabel
            // 
            this.xsltFileLabel.AutoSize = true;
            this.xsltFileLabel.Location = new System.Drawing.Point(9, 42);
            this.xsltFileLabel.Name = "xsltFileLabel";
            this.xsltFileLabel.Size = new System.Drawing.Size(50, 13);
            this.xsltFileLabel.TabIndex = 7;
            this.xsltFileLabel.Text = "XSLT file";
            // 
            // applyXmlButton
            // 
            this.applyXmlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyXmlButton.Location = new System.Drawing.Point(505, 12);
            this.applyXmlButton.Name = "applyXmlButton";
            this.applyXmlButton.Size = new System.Drawing.Size(75, 23);
            this.applyXmlButton.TabIndex = 4;
            this.applyXmlButton.Text = "Apply";
            this.applyXmlButton.UseVisualStyleBackColor = true;
            this.applyXmlButton.MouseLeave += new System.EventHandler(this.applyXmlButton_MouseLeave);
            this.applyXmlButton.Click += new System.EventHandler(this.applyXmlButton_Click);
            this.applyXmlButton.MouseEnter += new System.EventHandler(this.applyXmlButton_MouseEnter);
            // 
            // openXsltFileDialog
            // 
            this.openXsltFileDialog.Filter = "XSLT files|*.xslt|All files|*.*";
            this.openXsltFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenXsltFileDialog_FileOk);
            // 
            // xPathLabel
            // 
            this.xPathLabel.AutoSize = true;
            this.xPathLabel.Location = new System.Drawing.Point(9, 69);
            this.xPathLabel.Name = "xPathLabel";
            this.xPathLabel.Size = new System.Drawing.Size(36, 13);
            this.xPathLabel.TabIndex = 8;
            this.xPathLabel.Text = "XPath";
            // 
            // applyXpathButton
            // 
            this.applyXpathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyXpathButton.Location = new System.Drawing.Point(505, 64);
            this.applyXpathButton.Name = "applyXpathButton";
            this.applyXpathButton.Size = new System.Drawing.Size(75, 23);
            this.applyXpathButton.TabIndex = 11;
            this.applyXpathButton.Text = "Apply";
            this.applyXpathButton.UseVisualStyleBackColor = true;
            this.applyXpathButton.MouseLeave += new System.EventHandler(this.applyXpathButton_MouseLeave);
            this.applyXpathButton.Click += new System.EventHandler(this.applyXpathButton_Click);
            this.applyXpathButton.MouseEnter += new System.EventHandler(this.applyXpathButton_MouseEnter);
            // 
            // xPathTypeComboBox
            // 
            this.xPathTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xPathTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xPathTypeComboBox.FormattingEnabled = true;
            this.xPathTypeComboBox.Items.AddRange(new object[] {
            "InnerXml",
            "OuterXml",
            "Value"});
            this.xPathTypeComboBox.Location = new System.Drawing.Point(352, 65);
            this.xPathTypeComboBox.Name = "xPathTypeComboBox";
            this.xPathTypeComboBox.Size = new System.Drawing.Size(112, 21);
            this.xPathTypeComboBox.TabIndex = 10;
            this.xPathTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.XPathTypeComboBox_SelectedIndexChanged);
            this.xPathTypeComboBox.MouseEnter += new System.EventHandler(this.xPathTypeComboBox_MouseEnter);
            this.xPathTypeComboBox.MouseLeave += new System.EventHandler(this.xPathTypeComboBox_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.editorControlsUserControl);
            this.groupBox1.Controls.Add(this.treeViewUserControl);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 292);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // showLabel
            // 
            this.showLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showLabel.AutoSize = true;
            this.showLabel.Location = new System.Drawing.Point(312, 69);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(34, 13);
            this.showLabel.TabIndex = 15;
            this.showLabel.Text = "Show";
            // 
            // injectCheckBox
            // 
            this.injectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.injectCheckBox.AutoSize = true;
            this.injectCheckBox.Checked = true;
            this.injectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.injectCheckBox.Location = new System.Drawing.Point(427, 400);
            this.injectCheckBox.Name = "injectCheckBox";
            this.injectCheckBox.Size = new System.Drawing.Size(72, 17);
            this.injectCheckBox.TabIndex = 17;
            this.injectCheckBox.Text = "Inject Xml";
            this.injectCheckBox.UseVisualStyleBackColor = true;
            this.injectCheckBox.MouseLeave += new System.EventHandler(this.injectCheckBox_MouseLeave);
            this.injectCheckBox.MouseEnter += new System.EventHandler(this.injectCheckBox_MouseEnter);
            // 
            // xPathComboBox
            // 
            this.xPathComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xPathComboBox.FormattingEnabled = true;
            this.xPathComboBox.Location = new System.Drawing.Point(65, 65);
            this.xPathComboBox.Name = "xPathComboBox";
            this.xPathComboBox.Size = new System.Drawing.Size(241, 21);
            this.xPathComboBox.TabIndex = 9;
            this.xPathComboBox.SelectedIndexChanged += new System.EventHandler(this.XPathComboBox_SelectedIndexChanged);
            this.xPathComboBox.MouseEnter += new System.EventHandler(this.xPathComboBox_MouseEnter);
            this.xPathComboBox.MouseLeave += new System.EventHandler(this.xPathComboBox_MouseLeave);
            this.xPathComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XPathComboBox_KeyDown);
            // 
            // xsltFileComboBox
            // 
            this.xsltFileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xsltFileComboBox.FormattingEnabled = true;
            this.xsltFileComboBox.Location = new System.Drawing.Point(65, 39);
            this.xsltFileComboBox.Name = "xsltFileComboBox";
            this.xsltFileComboBox.Size = new System.Drawing.Size(339, 21);
            this.xsltFileComboBox.TabIndex = 5;
            this.xsltFileComboBox.SelectionChangeCommitted += new System.EventHandler(this.XsltFileComboBox_SelectionChangeCommitted);
            this.xsltFileComboBox.MouseEnter += new System.EventHandler(this.xsltFileComboBox_MouseEnter);
            this.xsltFileComboBox.MouseLeave += new System.EventHandler(this.xsltFileComboBox_MouseLeave);
            this.xsltFileComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XsltFileComboBox_KeyDown);
            // 
            // treeViewCheckBox
            // 
            this.treeViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewCheckBox.AutoSize = true;
            this.treeViewCheckBox.Location = new System.Drawing.Point(294, 400);
            this.treeViewCheckBox.Name = "treeViewCheckBox";
            this.treeViewCheckBox.Size = new System.Drawing.Size(92, 17);
            this.treeViewCheckBox.TabIndex = 16;
            this.treeViewCheckBox.Text = "Show as Tree";
            this.treeViewCheckBox.UseVisualStyleBackColor = true;
            this.treeViewCheckBox.MouseLeave += new System.EventHandler(this.treeViewCheckBox_MouseLeave);
            this.treeViewCheckBox.MouseEnter += new System.EventHandler(this.treeViewCheckBox_MouseEnter);
            this.treeViewCheckBox.CheckedChanged += new System.EventHandler(this.TreeViewCheckBox_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(592, 22);
            this.statusStrip.TabIndex = 16;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // selectXsltFileButton
            // 
            this.selectXsltFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectXsltFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectXsltFileButton.Image = global::XmlVisualizer.Properties.Resources.dir;
            this.selectXsltFileButton.Location = new System.Drawing.Point(410, 38);
            this.selectXsltFileButton.Name = "selectXsltFileButton";
            this.selectXsltFileButton.Size = new System.Drawing.Size(24, 23);
            this.selectXsltFileButton.TabIndex = 6;
            this.selectXsltFileButton.UseVisualStyleBackColor = true;
            this.selectXsltFileButton.MouseLeave += new System.EventHandler(this.selectXsltFileButton_MouseLeave);
            this.selectXsltFileButton.Click += new System.EventHandler(this.SelectXsltFileButton_Click);
            this.selectXsltFileButton.MouseEnter += new System.EventHandler(this.selectXsltFileButton_MouseEnter);
            // 
            // inputFileComboBox
            // 
            this.inputFileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFileComboBox.FormattingEnabled = true;
            this.inputFileComboBox.Location = new System.Drawing.Point(65, 13);
            this.inputFileComboBox.Name = "inputFileComboBox";
            this.inputFileComboBox.Size = new System.Drawing.Size(339, 21);
            this.inputFileComboBox.TabIndex = 1;
            this.inputFileComboBox.SelectionChangeCommitted += new System.EventHandler(this.inputFileComboBox_SelectionChangeCommitted);
            this.inputFileComboBox.MouseEnter += new System.EventHandler(this.inputFileComboBox_MouseEnter);
            this.inputFileComboBox.MouseLeave += new System.EventHandler(this.inputFileComboBox_MouseLeave);
            this.inputFileComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputFileComboBox_KeyDown);
            // 
            // selectXmlFileButton
            // 
            this.selectXmlFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectXmlFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectXmlFileButton.Image = global::XmlVisualizer.Properties.Resources.dir;
            this.selectXmlFileButton.Location = new System.Drawing.Point(410, 12);
            this.selectXmlFileButton.Name = "selectXmlFileButton";
            this.selectXmlFileButton.Size = new System.Drawing.Size(24, 23);
            this.selectXmlFileButton.TabIndex = 2;
            this.selectXmlFileButton.UseVisualStyleBackColor = true;
            this.selectXmlFileButton.MouseLeave += new System.EventHandler(this.selectXmlFileButton_MouseLeave);
            this.selectXmlFileButton.Click += new System.EventHandler(this.SelectXmlFileButton_Click);
            this.selectXmlFileButton.MouseEnter += new System.EventHandler(this.selectXmlFileButton_MouseEnter);
            // 
            // openXmlFileDialog
            // 
            this.openXmlFileDialog.Filter = "Xml files|*.xml|All files|*.*";
            this.openXmlFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenXmlFileDialog_FileOk);
            // 
            // newXmlFileButton
            // 
            this.newXmlFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newXmlFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newXmlFileButton.Image = global::XmlVisualizer.Properties.Resources.page_add;
            this.newXmlFileButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.newXmlFileButton.Location = new System.Drawing.Point(440, 12);
            this.newXmlFileButton.Name = "newXmlFileButton";
            this.newXmlFileButton.Size = new System.Drawing.Size(24, 23);
            this.newXmlFileButton.TabIndex = 3;
            this.newXmlFileButton.UseVisualStyleBackColor = true;
            this.newXmlFileButton.MouseLeave += new System.EventHandler(this.newXmlFileButton_MouseLeave);
            this.newXmlFileButton.Click += new System.EventHandler(this.newXmlFileButton_Click);
            this.newXmlFileButton.MouseEnter += new System.EventHandler(this.newXmlFileButton_MouseEnter);
            // 
            // newXsltFileButton
            // 
            this.newXsltFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newXsltFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newXsltFileButton.Image = global::XmlVisualizer.Properties.Resources.page_add;
            this.newXsltFileButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.newXsltFileButton.Location = new System.Drawing.Point(440, 38);
            this.newXsltFileButton.Name = "newXsltFileButton";
            this.newXsltFileButton.Size = new System.Drawing.Size(24, 23);
            this.newXsltFileButton.TabIndex = 7;
            this.newXsltFileButton.UseVisualStyleBackColor = true;
            this.newXsltFileButton.MouseLeave += new System.EventHandler(this.newXsltFileButton_MouseLeave);
            this.newXsltFileButton.Click += new System.EventHandler(this.NewXsltFileButton_Click);
            this.newXsltFileButton.MouseEnter += new System.EventHandler(this.newXsltFileButton_MouseEnter);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.Image = global::XmlVisualizer.Properties.Resources.page_edit;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.editButton.Location = new System.Drawing.Point(213, 396);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 15;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.MouseLeave += new System.EventHandler(this.editButton_MouseLeave);
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            this.editButton.MouseEnter += new System.EventHandler(this.editButton_MouseEnter);
            // 
            // openInBrowserButton
            // 
            this.openInBrowserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openInBrowserButton.Image = global::XmlVisualizer.Properties.Resources.page_world;
            this.openInBrowserButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.openInBrowserButton.Location = new System.Drawing.Point(51, 396);
            this.openInBrowserButton.Name = "openInBrowserButton";
            this.openInBrowserButton.Size = new System.Drawing.Size(75, 23);
            this.openInBrowserButton.TabIndex = 13;
            this.openInBrowserButton.Text = "Open";
            this.openInBrowserButton.UseVisualStyleBackColor = true;
            this.openInBrowserButton.MouseLeave += new System.EventHandler(this.openInBrowserButton_MouseLeave);
            this.openInBrowserButton.Click += new System.EventHandler(this.OpenInBrowserButton_Click);
            this.openInBrowserButton.MouseEnter += new System.EventHandler(this.openInBrowserButton_MouseEnter);
            // 
            // xPathPictureBox
            // 
            this.xPathPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xPathPictureBox.BackgroundImage = global::XmlVisualizer.Properties.Resources.accept;
            this.xPathPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.xPathPictureBox.ErrorImage = null;
            this.xPathPictureBox.InitialImage = null;
            this.xPathPictureBox.Location = new System.Drawing.Point(470, 65);
            this.xPathPictureBox.Name = "xPathPictureBox";
            this.xPathPictureBox.Size = new System.Drawing.Size(29, 22);
            this.xPathPictureBox.TabIndex = 13;
            this.xPathPictureBox.TabStop = false;
            this.xPathPictureBox.Visible = false;
            // 
            // xsltFilePictureBox
            // 
            this.xsltFilePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xsltFilePictureBox.BackgroundImage = global::XmlVisualizer.Properties.Resources.accept;
            this.xsltFilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.xsltFilePictureBox.ErrorImage = null;
            this.xsltFilePictureBox.InitialImage = null;
            this.xsltFilePictureBox.Location = new System.Drawing.Point(470, 39);
            this.xsltFilePictureBox.Name = "xsltFilePictureBox";
            this.xsltFilePictureBox.Size = new System.Drawing.Size(29, 22);
            this.xsltFilePictureBox.TabIndex = 12;
            this.xsltFilePictureBox.TabStop = false;
            this.xsltFilePictureBox.Visible = false;
            // 
            // inputFilePictureBox
            // 
            this.inputFilePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFilePictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("inputFilePictureBox.BackgroundImage")));
            this.inputFilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.inputFilePictureBox.ErrorImage = null;
            this.inputFilePictureBox.InitialImage = null;
            this.inputFilePictureBox.Location = new System.Drawing.Point(470, 13);
            this.inputFilePictureBox.Name = "inputFilePictureBox";
            this.inputFilePictureBox.Size = new System.Drawing.Size(29, 22);
            this.inputFilePictureBox.TabIndex = 11;
            this.inputFilePictureBox.TabStop = false;
            this.inputFilePictureBox.Visible = false;
            // 
            // toClipboardButton
            // 
            this.toClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toClipboardButton.Image = global::XmlVisualizer.Properties.Resources.page_copy;
            this.toClipboardButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toClipboardButton.Location = new System.Drawing.Point(132, 396);
            this.toClipboardButton.Name = "toClipboardButton";
            this.toClipboardButton.Size = new System.Drawing.Size(75, 23);
            this.toClipboardButton.TabIndex = 14;
            this.toClipboardButton.Text = "Copy";
            this.toClipboardButton.UseVisualStyleBackColor = true;
            this.toClipboardButton.MouseLeave += new System.EventHandler(this.toClipboardButton_MouseLeave);
            this.toClipboardButton.Click += new System.EventHandler(this.ToClipboardButton_Click);
            this.toClipboardButton.MouseEnter += new System.EventHandler(this.toClipboardButton_MouseEnter);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aboutButton.Location = new System.Drawing.Point(13, 396);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(32, 23);
            this.aboutButton.TabIndex = 12;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.MouseLeave += new System.EventHandler(this.aboutButton_MouseLeave);
            this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            this.aboutButton.MouseEnter += new System.EventHandler(this.aboutButton_MouseEnter);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Image = global::XmlVisualizer.Properties.Resources.door_in;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.closeButton.Location = new System.Drawing.Point(505, 396);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 18;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            // 
            // ReadOnlyLabel
            // 
            this.ReadOnlyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadOnlyLabel.AutoSize = true;
            this.ReadOnlyLabel.Location = new System.Drawing.Point(405, 401);
            this.ReadOnlyLabel.Name = "ReadOnlyLabel";
            this.ReadOnlyLabel.Size = new System.Drawing.Size(94, 13);
            this.ReadOnlyLabel.TabIndex = 19;
            this.ReadOnlyLabel.Text = "Object is read only";
            this.ReadOnlyLabel.Visible = false;
            // 
            // editorControlsUserControl
            // 
            this.editorControlsUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editorControlsUserControl.ChangesInEditor = false;
            this.editorControlsUserControl.Location = new System.Drawing.Point(6, 12);
            this.editorControlsUserControl.Name = "editorControlsUserControl";
            this.editorControlsUserControl.Size = new System.Drawing.Size(556, 274);
            this.editorControlsUserControl.TabIndex = 26;
            this.editorControlsUserControl.Visible = false;
            // 
            // treeViewUserControl
            // 
            this.treeViewUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewUserControl.Location = new System.Drawing.Point(6, 12);
            this.treeViewUserControl.Name = "treeViewUserControl";
            this.treeViewUserControl.Size = new System.Drawing.Size(557, 274);
            this.treeViewUserControl.TabIndex = 25;
            this.treeViewUserControl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 453);
            this.Controls.Add(this.ReadOnlyLabel);
            this.Controls.Add(this.newXmlFileButton);
            this.Controls.Add(this.selectXmlFileButton);
            this.Controls.Add(this.inputFileComboBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.treeViewCheckBox);
            this.Controls.Add(this.newXsltFileButton);
            this.Controls.Add(this.xsltFileComboBox);
            this.Controls.Add(this.xPathComboBox);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.injectCheckBox);
            this.Controls.Add(this.openInBrowserButton);
            this.Controls.Add(this.showLabel);
            this.Controls.Add(this.xPathPictureBox);
            this.Controls.Add(this.xsltFilePictureBox);
            this.Controls.Add(this.inputFilePictureBox);
            this.Controls.Add(this.toClipboardButton);
            this.Controls.Add(this.xPathTypeComboBox);
            this.Controls.Add(this.applyXpathButton);
            this.Controls.Add(this.xPathLabel);
            this.Controls.Add(this.selectXsltFileButton);
            this.Controls.Add(this.applyXmlButton);
            this.Controls.Add(this.xsltFileLabel);
            this.Controls.Add(this.inputFileLabel);
            this.Controls.Add(this.applyXsltButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPathPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsltFilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputFilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button applyXsltButton;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Label xsltFileLabel;
        private System.Windows.Forms.Button applyXmlButton;
        private System.Windows.Forms.OpenFileDialog openXsltFileDialog;
        private System.Windows.Forms.Button selectXsltFileButton;
        private System.Windows.Forms.Label xPathLabel;
        private System.Windows.Forms.Button applyXpathButton;
        private System.Windows.Forms.ComboBox xPathTypeComboBox;
        private System.Windows.Forms.Button toClipboardButton;
        private System.Windows.Forms.PictureBox inputFilePictureBox;
        private System.Windows.Forms.PictureBox xsltFilePictureBox;
        private System.Windows.Forms.PictureBox xPathPictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.Button openInBrowserButton;
        private System.Windows.Forms.CheckBox injectCheckBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ComboBox xPathComboBox;
        private System.Windows.Forms.ComboBox xsltFileComboBox;
        private System.Windows.Forms.Button newXsltFileButton;
        private System.Windows.Forms.CheckBox treeViewCheckBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private XmlVisualizer.TreeViewUserControl treeViewUserControl;
        private EditorControlsUserControl editorControlsUserControl;
        private System.Windows.Forms.ComboBox inputFileComboBox;
        private System.Windows.Forms.Button newXmlFileButton;
        private System.Windows.Forms.Button selectXmlFileButton;
        private System.Windows.Forms.OpenFileDialog openXmlFileDialog;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label ReadOnlyLabel;

    }
}