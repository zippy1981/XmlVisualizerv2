// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

namespace XmlVisualizer
{
    partial class VisualizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizerForm));
            this.visualizerUserControl = new XmlVisualizer.VisualizerUserControl();
            this.SuspendLayout();
            // 
            // visualizerUserControl
            // 
            this.visualizerUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizerUserControl.Location = new System.Drawing.Point(0, 0);
            this.visualizerUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.visualizerUserControl.MinimumSize = new System.Drawing.Size(592, 300);
            this.visualizerUserControl.Name = "visualizerUserControl";
            this.visualizerUserControl.Size = new System.Drawing.Size(592, 373);
            this.visualizerUserControl.TabIndex = 0;
            // 
            // VisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.visualizerUserControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "VisualizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.VisualizerForm_Activated);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualizerUserControl visualizerUserControl;
    }
}