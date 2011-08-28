//***********************************************************************
// Assembly         : ProdSessionConfiguration
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

namespace ProdSessionConfiguration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
