// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

namespace XmlVisualizer
{
    partial class AboutForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.urlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.line = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.mailLinkLabel = new System.Windows.Forms.LinkLabel();
            this.mailLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.byLabel = new System.Windows.Forms.Label();
            this.iconsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.iconsLabel = new System.Windows.Forms.Label();
            this.editorLabel = new System.Windows.Forms.Label();
            this.editorLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(180, 204);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 13);
            this.titleLabel.TabIndex = 1;
            // 
            // urlLinkLabel
            // 
            this.urlLinkLabel.AutoSize = true;
            this.urlLinkLabel.Location = new System.Drawing.Point(12, 61);
            this.urlLinkLabel.Name = "urlLinkLabel";
            this.urlLinkLabel.Size = new System.Drawing.Size(197, 13);
            this.urlLinkLabel.TabIndex = 2;
            this.urlLinkLabel.TabStop = true;
            this.urlLinkLabel.Text = "http://www.codeplex.com/XmlVisualizer";
            this.urlLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlLinkLabel_LinkClicked);
            // 
            // line
            // 
            this.line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line.Location = new System.Drawing.Point(4, 190);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(260, 2);
            this.line.TabIndex = 14;
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = global::XmlVisualizer.Properties.Resources.bug;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(239, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(16, 16);
            this.pictureBox.TabIndex = 15;
            this.pictureBox.TabStop = false;
            // 
            // mailLinkLabel
            // 
            this.mailLinkLabel.AutoSize = true;
            this.mailLinkLabel.Location = new System.Drawing.Point(37, 109);
            this.mailLinkLabel.Name = "mailLinkLabel";
            this.mailLinkLabel.Size = new System.Drawing.Size(105, 13);
            this.mailLinkLabel.TabIndex = 16;
            this.mailLinkLabel.TabStop = true;
            this.mailLinkLabel.Text = "larshove@gmail.com";
            this.mailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mailLinkLabel_LinkClicked);
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Location = new System.Drawing.Point(12, 109);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(28, 13);
            this.mailLabel.TabIndex = 17;
            this.mailLabel.Text = "mail:";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(12, 27);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(30, 13);
            this.versionLabel.TabIndex = 18;
            this.versionLabel.Text = "Build";
            // 
            // byLabel
            // 
            this.byLabel.AutoSize = true;
            this.byLabel.Location = new System.Drawing.Point(12, 94);
            this.byLabel.Name = "byLabel";
            this.byLabel.Size = new System.Drawing.Size(131, 13);
            this.byLabel.TabIndex = 19;
            this.byLabel.Text = "By Lars Hove Christiansen";
            // 
            // iconsLinkLabel
            // 
            this.iconsLinkLabel.AutoSize = true;
            this.iconsLinkLabel.Location = new System.Drawing.Point(140, 136);
            this.iconsLinkLabel.Name = "iconsLinkLabel";
            this.iconsLinkLabel.Size = new System.Drawing.Size(112, 13);
            this.iconsLinkLabel.TabIndex = 20;
            this.iconsLinkLabel.TabStop = true;
            this.iconsLinkLabel.Text = "http://famfamfam.com";
            this.iconsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconsLinkLabel_LinkClicked);
            // 
            // iconsLabel
            // 
            this.iconsLabel.AutoSize = true;
            this.iconsLabel.Location = new System.Drawing.Point(12, 136);
            this.iconsLabel.Name = "iconsLabel";
            this.iconsLabel.Size = new System.Drawing.Size(113, 13);
            this.iconsLabel.TabIndex = 21;
            this.iconsLabel.Text = "Icons by FamFamFam:";
            // 
            // editorLabel
            // 
            this.editorLabel.AutoSize = true;
            this.editorLabel.Location = new System.Drawing.Point(12, 152);
            this.editorLabel.Name = "editorLabel";
            this.editorLabel.Size = new System.Drawing.Size(122, 13);
            this.editorLabel.TabIndex = 22;
            this.editorLabel.Text = "Editor by SharpDevelop:";
            // 
            // editorLinkLabel
            // 
            this.editorLinkLabel.AutoSize = true;
            this.editorLinkLabel.Location = new System.Drawing.Point(140, 152);
            this.editorLinkLabel.Name = "editorLinkLabel";
            this.editorLinkLabel.Size = new System.Drawing.Size(120, 13);
            this.editorLinkLabel.TabIndex = 23;
            this.editorLinkLabel.TabStop = true;
            this.editorLinkLabel.Text = "http://sharpdevelop.net";
            this.editorLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editorLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 239);
            this.ControlBox = false;
            this.Controls.Add(this.editorLinkLabel);
            this.Controls.Add(this.editorLabel);
            this.Controls.Add(this.iconsLinkLabel);
            this.Controls.Add(this.iconsLabel);
            this.Controls.Add(this.byLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.mailLinkLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.line);
            this.Controls.Add(this.urlLinkLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.LinkLabel urlLinkLabel;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.LinkLabel mailLinkLabel;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label byLabel;
        private System.Windows.Forms.LinkLabel iconsLinkLabel;
        private System.Windows.Forms.Label iconsLabel;
        private System.Windows.Forms.Label editorLabel;
        private System.Windows.Forms.LinkLabel editorLinkLabel;
    }
}
