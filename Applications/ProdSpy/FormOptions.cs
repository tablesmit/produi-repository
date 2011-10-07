// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Forms;
using ProdSpy.Properties;

namespace ProdSpy
{
    /// <summary>
    /// Form to provide options for the program
    /// </summary>
    public partial class FormOptions : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormOptions"/> class.
        /// </summary>
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            /* Set the UI */
            ChkShowFocus.Checked = Settings.Default.ShowFocus;
            ChkAutoHighlightFocus.Checked = Settings.Default.AutoHighlight;
            ChkExpandedGraph.Checked = !Settings.Default.CollapseGraph;
            ChkTreeNodeHighlight.Checked = Settings.Default.HighlightNode;
            ChkUpdateFromNode.Checked = Settings.Default.UpdateNode;
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowFocus = ChkShowFocus.Checked;
            Settings.Default.AutoHighlight = ChkAutoHighlightFocus.Checked;
            Settings.Default.CollapseGraph = !ChkExpandedGraph.Checked;
            Settings.Default.HighlightNode = ChkTreeNodeHighlight.Checked;
            Settings.Default.UpdateNode = ChkUpdateFromNode.Checked;
            Settings.Default.Save();
            Settings.Default.Reload();
            Close();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}