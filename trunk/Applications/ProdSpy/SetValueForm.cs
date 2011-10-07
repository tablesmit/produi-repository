// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdSpy.Properties;

namespace ProdSpy
{
    public partial class SetValueForm : Form
    {
        public string[] ParamChoices;
        public Type ParamType;
        public ToggleState ReturnState;
        public string ReturnValue;

        public SetValueForm()
        {
            InitializeComponent();
        }

        public string ParamName { get; set; }

        private void SetValueForm_Load(object sender, EventArgs e)
        {
            LblPrompt.Text = Resources.SetValueForm_Prompt + ParamName + @" value";
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
            ReturnValue = TxtValue.Text;
            Close();
        }

        private void RdoAffirm_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ReturnState = ToggleState.On;
            }
        }

        private void RdoNegative_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ReturnState = ToggleState.Off;
            }
        }

        private void RdoInconclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ReturnState = ToggleState.Indeterminate;
            }
        }
    }
}