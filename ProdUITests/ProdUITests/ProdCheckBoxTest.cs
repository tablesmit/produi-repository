using System;
using System.Diagnostics;
using NUnit.Framework;
using ProdUI.Controls;
using ProdUI.Controls.Native;
using ProdUI.Exceptions;
using ProdUI.Session;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;

namespace ProdUITests
{
     [TestFixture]
    class ProdCheckBoxTest
    {

        const string WIN_TITLE = "WPF Test Form";
        private static ProdSession session;
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            session = new ProdSession("test.ses");
            window = new ProdWindow(WIN_TITLE, session.Loggers);

        }


         [Test]
         public void GetCheckState()
         {
             ProdCheckBox check = new ProdCheckBox(window,"testCheckBoxA");
                  ToggleState ret = TogglePatternHelper.GetToggleState(check.ThisElement);
             Assert.IsNotNull(ret,"Error creating Checkbox");
             Debug.WriteLine(ret);

         }
    }
}
