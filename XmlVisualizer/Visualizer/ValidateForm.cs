using System;
using System.Windows.Forms;

namespace XmlVisualizer
{
    internal partial class ValidateForm : Form
    {
        public string selectedValidationType;
        public string activeState;
        public string documentType;
        public bool shouldValidate;

        public ValidateForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string validationType = "";

            shouldValidate = true;

            if (xmlRadioButton.Checked)
            {
                validationType = "Xml";
            }
            else if (againstXSDRadioButton.Checked)
            {
                validationType = "XSD";
            }
            else if (xslRadioButton.Checked)
            {
                validationType = "XSL";
            }

            selectedValidationType = validationType;
            Close();
        }

        private void againstXSDRadioButton_Paint(object sender, PaintEventArgs e)
        {
            againstXSDRadioButton.Text = string.Format("Validate {0} against XSD", documentType);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ValidateForm_Layout(object sender, LayoutEventArgs e)
        {
            switch (activeState)
            {
                case "InputFile":
                    xslRadioButton.Enabled = false;
                    break;
                case "XsdFile":
                    xslRadioButton.Enabled = false;
                    againstXSDRadioButton.Enabled = false;
                    break;
            }

            switch (selectedValidationType)
            {
                case "XSL":
                    xslRadioButton.Checked = true;
                    break;
                case "XSD":
                    againstXSDRadioButton.Checked = true;
                    break;
                default:
                    xmlRadioButton.Checked = true;
                    selectedValidationType = "Xml";
                    break;
            }
        }
    }
}
