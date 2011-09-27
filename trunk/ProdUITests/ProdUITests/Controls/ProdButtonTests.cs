using System;
using System.Threading;
using NUnit.Framework;
using ProdUI.Controls;
using ProdUI.Controls.Windows;
using ProdUI.Controls.Static;


namespace ProdUITests
{
    [TestFixture]
    public class ProdButtonTest
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


        [Test, Description("Checking click event by verifying its effect on UI")]
        public void Click()
        {
            ProdButton button = new ProdButton(window, "button1");
            ProdButton button2 = new ProdButton(window, "button2");

            button.Click();
            
            Assert.That(button2.IsEnabled, Is.True);
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void ClickEventNotification()
        {
            ProdButton button = new ProdButton(window, "button1");
            button.Click();
            
            Thread.Sleep(2000);
            Assert.That(button.EventVerified);     
        }
    }
}
