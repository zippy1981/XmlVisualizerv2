namespace XmlVisualizer
{
    internal partial class ValidateForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xslRadioButton = new System.Windows.Forms.RadioButton();
            this.againstXSDRadioButton = new System.Windows.Forms.RadioButton();
            this.xmlRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(110, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xslRadioButton);
            this.groupBox1.Controls.Add(this.againstXSDRadioButton);
            this.groupBox1.Controls.Add(this.xmlRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select validation type";
            // 
            // xslRadioButton
            // 
            this.xslRadioButton.AutoSize = true;
            this.xslRadioButton.Location = new System.Drawing.Point(7, 68);
            this.xslRadioButton.Name = "xslRadioButton";
            this.xslRadioButton.Size = new System.Drawing.Size(86, 17);
            this.xslRadioButton.TabIndex = 2;
            this.xslRadioButton.TabStop = true;
            this.xslRadioButton.Text = "Validate XSL";
            this.xslRadioButton.UseVisualStyleBackColor = true;
            // 
            // againstXSDRadioButton
            // 
            this.againstXSDRadioButton.AutoSize = true;
            this.againstXSDRadioButton.Location = new System.Drawing.Point(7, 44);
            this.againstXSDRadioButton.Name = "againstXSDRadioButton";
            this.againstXSDRadioButton.Size = new System.Drawing.Size(14, 13);
            this.againstXSDRadioButton.TabIndex = 1;
            this.againstXSDRadioButton.UseVisualStyleBackColor = true;
            this.againstXSDRadioButton.Paint += new System.Windows.Forms.PaintEventHandler(this.againstXSDRadioButton_Paint);
            // 
            // xmlRadioButton
            // 
            this.xmlRadioButton.AutoSize = true;
            this.xmlRadioButton.Location = new System.Drawing.Point(7, 20);
            this.xmlRadioButton.Name = "xmlRadioButton";
            this.xmlRadioButton.Size = new System.Drawing.Size(83, 17);
            this.xmlRadioButton.TabIndex = 0;
            this.xmlRadioButton.TabStop = true;
            this.xmlRadioButton.Text = "Validate Xml";
            this.xmlRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 120);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ValidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 155);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValidateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ValidateForm_Layout);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton againstXSDRadioButton;
        private System.Windows.Forms.RadioButton xmlRadioButton;
        private System.Windows.Forms.RadioButton xslRadioButton;
        private System.Windows.Forms.Button cancelButton;
    }
}