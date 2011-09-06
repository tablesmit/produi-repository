/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProdSpy.Properties;

namespace ProdSpy
{
    /// <summary>
    ///   Used to provide a way for users to provide a parameter for a Prod
    /// </summary>
    public partial class SetValueForm : Form
    {

        #region Fields

        Lazy<List<RadioButton>> _buttons;

        /// <summary>
        /// Gets or sets the name of the needed parameter.
        /// </summary>
        /// <value>
        /// The name of the parameter.
        /// </value>
        public string ParamName { get; set; }

        /// <summary>
        /// Gets or sets the value of the needed parameter.
        /// </summary>
        /// <value>
        /// The parameter value.
        /// </value>
        public object ParamValue { get; set; }

        /// <summary>
        /// Gets or sets the any extra choices of the needed parameter.
        /// </summary>
        /// <value>
        /// The parameter choices.
        /// </value>
        public string[] ParamChoices { get; set; }

        /// <summary>
        /// Gets or sets the Type of the parameter.
        /// </summary>
        /// <value>
        /// The type of the parameter.
        /// </value>
        public Type ParamType { get; set; }

        #endregion

        /// <summary>
        ///   Initializes a new instance of the <see cref = "SetValueForm" /> class.
        /// </summary>
        public SetValueForm()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Load event of the SetValue control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SetValue_Load(object sender, EventArgs e)
        {
            TxtPrompt.Text = Resources.Setvaluefor + ParamName;

            if (ParamChoices == null)
            {
                return;
            }

            if (ParamChoices.Length > 0 )
            {
                SetChoices();
            }
        }

        /// <summary>Handles the Click event of the CmdOk control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdOk_Click(object sender, EventArgs e)
        {
            if (_buttons == null)
            {
                ParamValue = TxtValue.Text;
            }
            Close();
        }

        /// <summary>Creates a set of radio buttons for Prods that have multiple possible values.</summary>
        private void SetChoices()
        {
            TxtValue.Visible = false;
            int ctr = 10;
            double radioallotment = PnlParams.Width / ParamChoices.Length;

            _buttons = new Lazy<List<RadioButton>>();
            foreach (string item in ParamChoices)
            {
                RadioButton rdo = new RadioButton
                {
                    AutoSize = true,
                    Text = item,
                    Left = ctr,  
                };


                Padding mar = new Padding {Right = 10};
                rdo.Margin = mar;
                rdo.CheckedChanged += rdo_CheckedChanged;
                _buttons.Value.Add(rdo);

                ctr += (int)radioallotment + ((int)radioallotment - rdo.Width);
            }
            PnlParams.Controls.AddRange(_buttons.Value.ToArray());
        }

        /// <summary>Handles the CheckedChanged event of the rdo control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton button in _buttons.Value)
            {
                if (button.Checked)
                {
                    ParamValue = button.Text;
                }
            }
        }

    }
}