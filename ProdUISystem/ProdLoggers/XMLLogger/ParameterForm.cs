// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Forms;

public partial class ParameterForm : Form
{
    internal string SavePath = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParameterForm" /> class.
    /// </summary>
    /// <remarks></remarks>
    public ParameterForm()
    {
        InitializeComponent();
    }

    private void CmdBrowse_Click(object sender, EventArgs e)
    {
        SaveFileDialog sfd = null;
        try
        {
            sfd = new SaveFileDialog
            {
                Title = @"Log output file",
                FileName = "TextLog.xml",
                Filter = @"XML files (*.xml)|*.xml"
            };

            if (sfd.ShowDialog() == DialogResult.Cancel || sfd.FileName.Length == 0)
            {
                return;
            }

            TxtOutput.Text = sfd.FileName;
        }
        finally
        {
            if (sfd != null) sfd.Dispose();
        }
    }

    private void CmdCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void CmdOk_Click(object sender, EventArgs e)
    {
        SavePath = TxtOutput.Text;
        Close();
    }
}