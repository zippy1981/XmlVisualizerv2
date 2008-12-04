// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

namespace XmlVisualizer
{
    internal partial class EditorControlsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.validateButton = new System.Windows.Forms.Button();
            this.saveAsEditButton = new System.Windows.Forms.Button();
            this.saveEditButton = new System.Windows.Forms.Button();
            this.cancelEditButton = new System.Windows.Forms.Button();
            this.formatXmlCheckBox = new System.Windows.Forms.CheckBox();
            this.saveAsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.editorStatusTextBox = new System.Windows.Forms.TextBox();
            this.searchForwardButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.editorUserControl = new XmlVisualizer.EditorUserControl();
            this.SuspendLayout();
            // 
            // validateButton
            // 
            this.validateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.validateButton.Image = global::XmlVisualizer.Properties.Resources.tick;
            this.validateButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.validateButton.Location = new System.Drawing.Point(3, 304);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(91, 23);
            this.validateButton.TabIndex = 29;
            this.validateButton.TabStop = false;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.MouseLeave += new System.EventHandler(this.validateButton_MouseLeave);
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            this.validateButton.MouseEnter += new System.EventHandler(this.validateButton_MouseEnter);
            // 
            // saveAsEditButton
            // 
            this.saveAsEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsEditButton.Image = global::XmlVisualizer.Properties.Resources.page_save;
            this.saveAsEditButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.saveAsEditButton.Location = new System.Drawing.Point(517, 304);
            this.saveAsEditButton.Name = "saveAsEditButton";
            this.saveAsEditButton.Size = new System.Drawing.Size(81, 23);
            this.saveAsEditButton.TabIndex = 27;
            this.saveAsEditButton.TabStop = false;
            this.saveAsEditButton.Text = "Save As...";
            this.saveAsEditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveAsEditButton.UseVisualStyleBackColor = true;
            this.saveAsEditButton.MouseLeave += new System.EventHandler(this.saveAsEditButton_MouseLeave);
            this.saveAsEditButton.Click += new System.EventHandler(this.SaveAsEditButton_Click);
            this.saveAsEditButton.MouseEnter += new System.EventHandler(this.saveAsEditButton_MouseEnter);
            // 
            // saveEditButton
            // 
            this.saveEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveEditButton.Image = global::XmlVisualizer.Properties.Resources.page_save;
            this.saveEditButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.saveEditButton.Location = new System.Drawing.Point(431, 304);
            this.saveEditButton.Name = "saveEditButton";
            this.saveEditButton.Size = new System.Drawing.Size(80, 23);
            this.saveEditButton.TabIndex = 25;
            this.saveEditButton.TabStop = false;
            this.saveEditButton.Text = "Save";
            this.saveEditButton.UseVisualStyleBackColor = true;
            this.saveEditButton.MouseLeave += new System.EventHandler(this.saveEditButton_MouseLeave);
            this.saveEditButton.Click += new System.EventHandler(this.SaveEditButton_Click);
            this.saveEditButton.MouseEnter += new System.EventHandler(this.saveEditButton_MouseEnter);
            // 
            // cancelEditButton
            // 
            this.cancelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEditButton.Location = new System.Drawing.Point(375, 304);
            this.cancelEditButton.Name = "cancelEditButton";
            this.cancelEditButton.Size = new System.Drawing.Size(50, 23);
            this.cancelEditButton.TabIndex = 24;
            this.cancelEditButton.TabStop = false;
            this.cancelEditButton.Text = "Cancel";
            this.cancelEditButton.UseVisualStyleBackColor = true;
            this.cancelEditButton.MouseLeave += new System.EventHandler(this.cancelEditButton_MouseLeave);
            this.cancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            this.cancelEditButton.MouseEnter += new System.EventHandler(this.cancelEditButton_MouseEnter);
            // 
            // formatXmlCheckBox
            // 
            this.formatXmlCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formatXmlCheckBox.AutoSize = true;
            this.formatXmlCheckBox.Location = new System.Drawing.Point(100, 308);
            this.formatXmlCheckBox.Name = "formatXmlCheckBox";
            this.formatXmlCheckBox.Size = new System.Drawing.Size(81, 17);
            this.formatXmlCheckBox.TabIndex = 28;
            this.formatXmlCheckBox.TabStop = false;
            this.formatXmlCheckBox.Text = "Format tags";
            this.formatXmlCheckBox.UseVisualStyleBackColor = true;
            this.formatXmlCheckBox.MouseLeave += new System.EventHandler(this.formatXmlCheckBox_MouseLeave);
            this.formatXmlCheckBox.MouseEnter += new System.EventHandler(this.formatXmlCheckBox_MouseEnter);
            this.formatXmlCheckBox.CheckedChanged += new System.EventHandler(this.formatXmlCheckBox_CheckedChanged);
            // 
            // editorStatusTextBox
            // 
            this.editorStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editorStatusTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.editorStatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorStatusTextBox.Location = new System.Drawing.Point(0, 278);
            this.editorStatusTextBox.Multiline = true;
            this.editorStatusTextBox.Name = "editorStatusTextBox";
            this.editorStatusTextBox.ReadOnly = true;
            this.editorStatusTextBox.Size = new System.Drawing.Size(600, 20);
            this.editorStatusTextBox.TabIndex = 31;
            this.editorStatusTextBox.Visible = false;
            // 
            // searchForwardButton
            // 
            this.searchForwardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchForwardButton.Image = global::XmlVisualizer.Properties.Resources.page_find;
            this.searchForwardButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.searchForwardButton.Location = new System.Drawing.Point(340, 304);
            this.searchForwardButton.Name = "searchForwardButton";
            this.searchForwardButton.Size = new System.Drawing.Size(29, 23);
            this.searchForwardButton.TabIndex = 32;
            this.searchForwardButton.UseVisualStyleBackColor = true;
            this.searchForwardButton.MouseLeave += new System.EventHandler(this.searchForwardButton_MouseLeave);
            this.searchForwardButton.Click += new System.EventHandler(this.searchForwardButton_Click);
            this.searchForwardButton.MouseEnter += new System.EventHandler(this.searchForwardButton_MouseEnter);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.searchTextBox.Location = new System.Drawing.Point(234, 306);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 33;
            this.searchTextBox.Text = "Search...";
            this.searchTextBox.MouseLeave += new System.EventHandler(this.searchTextBox_MouseLeave);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.MouseEnter += new System.EventHandler(this.searchTextBox_MouseEnter);
            // 
            // editorUserControl
            // 
            this.editorUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editorUserControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.editorUserControl.ChangesInEditor = false;
            this.editorUserControl.Location = new System.Drawing.Point(0, 0);
            this.editorUserControl.Name = "editorUserControl";
            this.editorUserControl.Size = new System.Drawing.Size(600, 298);
            this.editorUserControl.TabIndex = 30;
            // 
            // EditorControlsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchForwardButton);
            this.Controls.Add(this.editorStatusTextBox);
            this.Controls.Add(this.editorUserControl);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.saveAsEditButton);
            this.Controls.Add(this.saveEditButton);
            this.Controls.Add(this.cancelEditButton);
            this.Controls.Add(this.formatXmlCheckBox);
            this.Name = "EditorControlsUserControl";
            this.Size = new System.Drawing.Size(600, 330);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.Button saveAsEditButton;
        private System.Windows.Forms.Button saveEditButton;
        private System.Windows.Forms.Button cancelEditButton;
        private System.Windows.Forms.CheckBox formatXmlCheckBox;
        private EditorUserControl editorUserControl;
        private System.Windows.Forms.SaveFileDialog saveAsFileDialog;
        private System.Windows.Forms.TextBox editorStatusTextBox;
        private System.Windows.Forms.Button searchForwardButton;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}
