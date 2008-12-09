// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

namespace XmlVisualizer
{
    internal partial class TreeViewUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewUserControl));
            this.treeView = new System.Windows.Forms.TreeView();
            this.findPictureBox = new System.Windows.Forms.PictureBox();
            this.findPreviousButton = new System.Windows.Forms.Button();
            this.searchTreeTextBox = new System.Windows.Forms.TextBox();
            this.findNextButton = new System.Windows.Forms.Button();
            this.expandTreeButton = new System.Windows.Forms.Button();
            this.collapseTreeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.findPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(524, 257);
            this.treeView.TabIndex = 20;
            this.treeView.TabStop = false;
            // 
            // findPictureBox
            // 
            this.findPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.findPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("findPictureBox.Image")));
            this.findPictureBox.Location = new System.Drawing.Point(220, 266);
            this.findPictureBox.Name = "findPictureBox";
            this.findPictureBox.Size = new System.Drawing.Size(16, 19);
            this.findPictureBox.TabIndex = 22;
            this.findPictureBox.TabStop = false;
            // 
            // findPreviousButton
            // 
            this.findPreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.findPreviousButton.Location = new System.Drawing.Point(348, 263);
            this.findPreviousButton.Name = "findPreviousButton";
            this.findPreviousButton.Size = new System.Drawing.Size(84, 23);
            this.findPreviousButton.TabIndex = 27;
            this.findPreviousButton.TabStop = false;
            this.findPreviousButton.Text = "Find Previous";
            this.findPreviousButton.UseVisualStyleBackColor = true;
            this.findPreviousButton.MouseLeave += new System.EventHandler(this.findPreviousButton_MouseLeave);
            this.findPreviousButton.Click += new System.EventHandler(this.FindPreviousButton_Click);
            this.findPreviousButton.MouseEnter += new System.EventHandler(this.findPreviousButton_MouseEnter);
            // 
            // searchTreeTextBox
            // 
            this.searchTreeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTreeTextBox.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.searchTreeTextBox.Location = new System.Drawing.Point(242, 265);
            this.searchTreeTextBox.Name = "searchTreeTextBox";
            this.searchTreeTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTreeTextBox.TabIndex = 26;
            this.searchTreeTextBox.TabStop = false;
            this.searchTreeTextBox.Text = "Search...";
            this.searchTreeTextBox.MouseLeave += new System.EventHandler(this.searchTreeTextBox_MouseLeave);
            this.searchTreeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTreeTextBox_KeyDown);
            this.searchTreeTextBox.Leave += new System.EventHandler(this.searchTreeTextBox_Leave);
            this.searchTreeTextBox.Enter += new System.EventHandler(this.searchTreeTextBox_Enter);
            this.searchTreeTextBox.MouseEnter += new System.EventHandler(this.searchTreeTextBox_MouseEnter);
            // 
            // findNextButton
            // 
            this.findNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.findNextButton.Location = new System.Drawing.Point(438, 263);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(84, 23);
            this.findNextButton.TabIndex = 25;
            this.findNextButton.TabStop = false;
            this.findNextButton.Text = "Find Next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.MouseLeave += new System.EventHandler(this.findNextButton_MouseLeave);
            this.findNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            this.findNextButton.MouseEnter += new System.EventHandler(this.findNextButton_MouseEnter);
            // 
            // expandTreeButton
            // 
            this.expandTreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expandTreeButton.Location = new System.Drawing.Point(3, 263);
            this.expandTreeButton.Name = "expandTreeButton";
            this.expandTreeButton.Size = new System.Drawing.Size(75, 23);
            this.expandTreeButton.TabIndex = 23;
            this.expandTreeButton.TabStop = false;
            this.expandTreeButton.Text = "Expand All";
            this.expandTreeButton.UseVisualStyleBackColor = true;
            this.expandTreeButton.MouseLeave += new System.EventHandler(this.expandTreeButton_MouseLeave);
            this.expandTreeButton.Click += new System.EventHandler(this.ExpandTreeButton_Click);
            this.expandTreeButton.MouseEnter += new System.EventHandler(this.expandTreeButton_MouseEnter);
            // 
            // collapseTreeButton
            // 
            this.collapseTreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.collapseTreeButton.Location = new System.Drawing.Point(84, 263);
            this.collapseTreeButton.Name = "collapseTreeButton";
            this.collapseTreeButton.Size = new System.Drawing.Size(75, 23);
            this.collapseTreeButton.TabIndex = 24;
            this.collapseTreeButton.TabStop = false;
            this.collapseTreeButton.Text = "Collapse All";
            this.collapseTreeButton.UseVisualStyleBackColor = true;
            this.collapseTreeButton.MouseLeave += new System.EventHandler(this.collapseTreeButton_MouseLeave);
            this.collapseTreeButton.Click += new System.EventHandler(this.CollapseTreeButton_Click);
            this.collapseTreeButton.MouseEnter += new System.EventHandler(this.collapseTreeButton_MouseEnter);
            // 
            // TreeViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.findPictureBox);
            this.Controls.Add(this.findPreviousButton);
            this.Controls.Add(this.searchTreeTextBox);
            this.Controls.Add(this.findNextButton);
            this.Controls.Add(this.expandTreeButton);
            this.Controls.Add(this.collapseTreeButton);
            this.Controls.Add(this.treeView);
            this.Name = "TreeViewUserControl";
            this.Size = new System.Drawing.Size(525, 289);
            ((System.ComponentModel.ISupportInitialize)(this.findPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.PictureBox findPictureBox;
        private System.Windows.Forms.Button findPreviousButton;
        private System.Windows.Forms.TextBox searchTreeTextBox;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.Button expandTreeButton;
        private System.Windows.Forms.Button collapseTreeButton;
    }
}
