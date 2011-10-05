/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Forms;

namespace WinMap
{
    /// <summary>
    /// Form to allow user to provide a custom identifier for a control
    /// </summary>
    public partial class CustomIdForm : Form
    {

        /// <summary>
        /// The custom id string
        /// </summary>
        public string Id{get;set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomIdForm"/> class.
        /// </summary>
        public CustomIdForm()
        {
            InitializeComponent();
        }

        private void CmdOk_Click(object sender, EventArgs e)
        {
            if (TxtId.Text.Length > 0)
            {
                Id = TxtId.Text;
            }
            Close();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
