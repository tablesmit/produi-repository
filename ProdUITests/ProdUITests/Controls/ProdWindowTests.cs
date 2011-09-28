using NUnit.Framework;
using ProdUI.Controls.Windows;
using System.Windows.Automation;

namespace ProdUITests
{
    [TestFixture]
    class ProdWindowTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE);
        }

        /// <summary>
        ///A test for ProdWindow Constructor
        ///</summary>
        [Test]
        public void ProdWindowConstructorTest()
        {
            string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
            window = new ProdWindow(partialTitle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ProdWindow Constructor
        ///</summary>
        [Test]
        public void ProdWindowConstructorTest1()
        {
            System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            window = new ProdWindow(windowHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Activate
        ///</summary>
        [Test]
        public void ActivateTest()
        {
            window.Activate();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [Test]
        public void CloseTest()
        {
            window.Close();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A test for GetIsModal
        ///</summary>
        [Test]
        public void GetIsModalTest()
        {
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = window.GetIsModal();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetIsTopmost
        ///</summary>
        [Test]
        public void GetIsTopmostTest()
        {
            window.Activate();
            bool expected = true;
            bool actual;
            actual = window.GetIsTopmost();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTitle
        ///</summary>
        [Test]
        public void GetTitleTest()
        {
            string expected = WIN_TITLE;
            string actual;
            actual = window.GetTitle();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetWinState
        ///</summary>
        [Test]
        public void GetWinStateTest()
        {
            WindowInteractionState expected = window.GetWinState();
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetWindowVisualState
        ///</summary>
        [Test]
        public void GetWindowVisualStateTest()
        {
            System.Windows.Automation.WindowVisualState actual;
            window.Maximize();
            actual = window.GetWindowVisualState();
            Assert.AreEqual(WindowVisualState.Maximized, actual);
        }



        /// <summary>
        ///A test for Maximize
        ///</summary>
        [Test]
        public void MaximizeTest()
        {
            System.Windows.Automation.WindowVisualState actual;
            window.Maximize();
            actual = window.GetWindowVisualState();
            Assert.AreEqual(WindowVisualState.Maximized, actual);
        }

        /// <summary>
        ///A test for Minimize
        ///</summary>
        [Test]
        public void MinimizeTest()
        {
            System.Windows.Automation.WindowVisualState actual;
            window.Minimize();
            actual = window.GetWindowVisualState();
            Assert.AreEqual(WindowVisualState.Minimized, actual);
        }

        /// <summary>
        ///A test for Move
        ///</summary>
        [Test]
        public void MoveTest()
        {
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            window.Move(x, y);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Resize
        ///</summary>
        [Test]
        public void ResizeTest()
        {
            double width = 0F; // TODO: Initialize to an appropriate value
            double height = 0F; // TODO: Initialize to an appropriate value
            window.Resize(width, height);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Restore
        ///</summary>
        [Test]
        public void RestoreTest()
        {
            System.Windows.Automation.WindowVisualState actual;
            window.Restore();
            actual = window.GetWindowVisualState();
            Assert.AreEqual(WindowVisualState.Normal, actual);
        }

        /// <summary>
        ///A test for Rotate
        ///</summary>
        [Test]
        public void RotateTest()
        {
            double degrees = 0F; // TODO: Initialize to an appropriate value
            window.Rotate(degrees);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetTitle
        ///</summary>
        [Test]
        public void SetTitleTest()
        {
            string newTitle = "New Title";
            window.SetTitle(newTitle);
            Assert.AreEqual(window.GetTitle(), newTitle);
        }

        /// <summary>
        ///A test for WaitForInputIdle
        ///</summary>
        [Test]
        public void WaitForInputIdleTest()
        {
            int delay = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = window.WaitForInputIdle(delay);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

    }
}
