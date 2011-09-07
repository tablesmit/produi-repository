using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using System;
using System.Windows.Automation;
using ProdUI.Utility;
using System.Globalization;
using System.Collections.Generic;

namespace ProdUITests
{
    [TestFixture]
    class ProdCalendarTests
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
        public void ConstructorWithHandle()
        {
            IntPtr handle = Prod.GetWindowHandle("Button1");
            if (handle == IntPtr.Zero)
                Assert.Pass("Unable to create button using handle");
            ProdButton button = new ProdButton(window, handle);
        }

        [Test]
        public void ConstructorWithId()
        {
            ProdButton button = new ProdButton(window, "button1");
            Assert.Pass("Button Created");
        }

        [Test]
        public void ConstructorWithTreePosition()
        {
            //ProdButton button = new ProdButton(window, "button1");
            Assert.Fail("Not implemented");
        }
    }
}
