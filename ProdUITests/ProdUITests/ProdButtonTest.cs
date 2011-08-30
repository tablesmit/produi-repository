using System;
using NUnit.Framework;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITesting
{
    [TestFixture]
    public class ProdButtonTest
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

        [Test]
        public void Click()
        {
            ProdButton button = new ProdButton(window, "button1");
            ProdButton button2 = new ProdButton(window, "button2");

            button.Click();

            if (button2.IsEnabled)
                Assert.Pass();
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ClickEventNotification()
        {
            ProdButton button = new ProdButton(window, "button1");

            button.Click();
           
        }
    }
}
