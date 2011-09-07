using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DialogTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CmdOFD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open File Test",
                Filter = "All Files *.*|*.*",
                Multiselect = true
            };
            if (ofd.ShowDialog() != DialogResult.Cancel)
                TxtAnyText.Text = ofd.FileName;
        }

        private void CmdSFD_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Save File Test",
                Filter = "All Files *.*|*.*"
            };
            if (sfd.ShowDialog() != DialogResult.Cancel)
                TxtAnyText.Text = sfd.FileName;
        }

        private void CmdMbox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test MessageBox", "This is a Test", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }

        private void CmdFontDialog_Click(object sender, EventArgs e)
        {
            FontDialog fonts = new FontDialog
            {
                ShowColor = true,
                ShowEffects = true,
            };

            if (fonts.ShowDialog() != DialogResult.Cancel)
                TxtAnyText.Text = fonts.Font.Name;
        }

        private void CmdColorDialog_Click(object sender, EventArgs e)
        {
            ColorDialog colors = new ColorDialog {
                SolidColorOnly = true,
                AllowFullOpen = true,
                
                                                 };
            if (colors.ShowDialog() != DialogResult.Cancel)
                TxtAnyText.Text = colors.Color.Name;
        }

        private void CmdPrintDialog_Click(object sender, EventArgs e)
        {

        }

        private void CmdPageSetupDialog_Click(object sender, EventArgs e)
        {

        }

        private void CmdPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void CmdChild_Click(object sender, EventArgs e)
        {
            AboutBox abt = new AboutBox();
            abt.ShowDialog();
        }
    }
}
