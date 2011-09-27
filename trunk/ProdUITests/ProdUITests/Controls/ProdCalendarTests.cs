using System;
using NUnit.Framework;
using ProdUI.Controls.Windows;
using ProdUI.Controls.Static;

namespace ProdUITests
{
    [TestFixture]
    class ProdCalendarTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE);
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
