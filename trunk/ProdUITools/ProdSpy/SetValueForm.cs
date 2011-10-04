using System;
using System.Windows.Forms;
using System.Windows.Automation;

namespace ProdSpy
{
    public partial class SetValueForm : Form
    {
        public string ParamName { get; set; }
        public string[] ParamChoices;
        public Type ParamType;
        public string returnValue;
        public ToggleState returnState;
      


        public SetValueForm()
        {
            InitializeComponent();
        }

        private void SetValueForm_Load(object sender, EventArgs e)
        {
            LblPrompt.Text = "Please enter a " + ParamName + " value";
            if (ParamType == typeof(ToggleState))
            {
                PnlOptions.Visible = true;
                TxtValue.Visible = false;
                return;
            }
                PnlOptions.Visible = false;
                TxtValue.Visible = true;
        }

        private void CmdOk_Click(object sender, EventArgs e)
        {
            returnValue = TxtValue.Text;
            Close();
        }

        private void RdoAffirm_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                returnState = ToggleState.On;
            }
        }

        private void RdoNegative_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                returnState = ToggleState.Off;
            }
        }

        private void RdoInconclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                returnState = ToggleState.Indeterminate;
            }
        }

    }
}
