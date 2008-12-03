// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

namespace TestStandAloneVisualizer
{
    partial class Form1
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
            this.modelessButton = new System.Windows.Forms.Button();
            this.modalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // modelessButton
            // 
            this.modelessButton.Location = new System.Drawing.Point(12, 12);
            this.modelessButton.Name = "modelessButton";
            this.modelessButton.Size = new System.Drawing.Size(113, 23);
            this.modelessButton.TabIndex = 0;
            this.modelessButton.Text = "Open Modeless";
            this.modelessButton.UseVisualStyleBackColor = true;
            this.modelessButton.Click += new System.EventHandler(this.modelessButton_Click);
            // 
            // modalButton
            // 
            this.modalButton.Location = new System.Drawing.Point(13, 42);
            this.modalButton.Name = "modalButton";
            this.modalButton.Size = new System.Drawing.Size(112, 23);
            this.modalButton.TabIndex = 1;
            this.modalButton.Text = "Open Modal";
            this.modalButton.UseVisualStyleBackColor = true;
            this.modalButton.Click += new System.EventHandler(this.modalButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(138, 80);
            this.Controls.Add(this.modalButton);
            this.Controls.Add(this.modelessButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button modalButton;
        private System.Windows.Forms.Button modelessButton;
    }
}

