//***********************************************************************
// Assembly         : TextFileLogger
// Author           : HRoark
// Created          : 08-14-2011
//
// Last Modified By : HRoark
// Last Modified On : 08-14-2011
// Description      : 
//
// Copyright        : (c) . All rights reserved.
//***********************************************************************
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
            SaveFileDialog sfd=null;
            try
            {
            sfd = new SaveFileDialog { Title = @"Log output file", FileName = "TextLog.txt" };

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
