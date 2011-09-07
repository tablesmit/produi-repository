using NUnit.Framework;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
    class ProdWindowTests
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

            /// <summary>
            ///A test for ProdWindow Constructor
            ///</summary>
            [Test]
            public void ProdWindowConstructorTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(partialTitle, loggers);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            /// <summary>
            ///A test for ProdWindow Constructor
            ///</summary>
            [Test]
            public void ProdWindowConstructorTest1()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            /// <summary>
            ///A test for Activate
            ///</summary>
            [Test]
            public void ActivateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                target.Activate();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Close
            ///</summary>
            [Test]
            public void CloseTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                target.Close();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for CreateMessage
            ///</summary>
            [Test]
            public void CreateMessageTest()
            {
                target.CreateMessage();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for GetIsModal
            ///</summary>
            [Test]
            public void GetIsModalTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.GetIsModal();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetIsTopmost
            ///</summary>
            [Test]
            public void GetIsTopmostTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.GetIsTopmost();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetTitle
            ///</summary>
            [Test]
            public void GetTitleTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.GetTitle();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetWinState
            ///</summary>
            [Test]
            public void GetWinStateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                ProdUI.Utility.WindowState expected = new ProdUI.Utility.WindowState(); // TODO: Initialize to an appropriate value
                ProdUI.Utility.WindowState actual;
                actual = target.GetWinState();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetWindowVisualState
            ///</summary>
            [Test]
            public void GetWindowVisualStateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState expected = new System.Windows.Automation.WindowVisualState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState actual;
                actual = target.GetWindowVisualState();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for LogEntry
            ///</summary>
            [Test]
            public void LogEntryTest()
            {                            
                target.LogEntry();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Maximize
            ///</summary>
            [Test]
            public void MaximizeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                target.Maximize();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Minimize
            ///</summary>
            [Test]
            public void MinimizeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                target.Minimize();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Move
            ///</summary>
            [Test]
            public void MoveTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                double x = 0F; // TODO: Initialize to an appropriate value
                double y = 0F; // TODO: Initialize to an appropriate value
                target.Move(x, y);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Resize
            ///</summary>
            [Test]
            public void ResizeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                double width = 0F; // TODO: Initialize to an appropriate value
                double height = 0F; // TODO: Initialize to an appropriate value
                target.Resize(width, height);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Restore
            ///</summary>
            [Test]
            public void RestoreTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                target.Restore();
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Rotate
            ///</summary>
            [Test]
            public void RotateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                double degrees = 0F; // TODO: Initialize to an appropriate value
                target.Rotate(degrees);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetTitle
            ///</summary>
            [Test]
            public void SetTitleTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                string newTitle = string.Empty; // TODO: Initialize to an appropriate value
                target.SetTitle(newTitle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WaitForInputIdle
            ///</summary>
            [Test]
            public void WaitForInputIdleTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<ProdUI.Logging.ProdLogger> loggers = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdWindow target = new ProdUI.Controls.ProdWindow(windowHandle, loggers); // TODO: Initialize to an appropriate value
                int delay = 0; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.WaitForInputIdle(delay);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        
    }
}
