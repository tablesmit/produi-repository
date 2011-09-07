using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using ProdUI.Exceptions;

namespace ProdUITests
{
    [TestFixture]
    class StaticProdsTests
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
            public void AddToSelectionTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.AddToSelection(prodwindow, automationId, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ActivateWindow
            ///</summary>
            [Test]
            public void ActivateWindowTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ActivateWindow(partialTitle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ActivateWindow
            ///</summary>
            [Test]
            public void ActivateWindowTest1()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ActivateWindow(windowHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowWaitForIdle
            ///</summary>
            [Test]
            public void WindowWaitForIdleTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int delay = 0; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.WindowWaitForIdle(windowHandle, delay);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowSetTitle
            ///</summary>
            [Test]
            public void WindowSetTitleTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowSetTitle(windowHandle, newText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowRotate
            ///</summary>
            [Test]
            public void WindowRotateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double degrees = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowRotate(windowHandle, degrees);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowRestore
            ///</summary>
            [Test]
            public void WindowRestoreTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowRestore(windowHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowResize
            ///</summary>
            [Test]
            public void WindowResizeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double width = 0F; // TODO: Initialize to an appropriate value
                double height = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowResize(windowHandle, width, height);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowMoveFromCurrent
            ///</summary>
            [Test]
            public void WindowMoveFromCurrentTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double xOffset = 0F; // TODO: Initialize to an appropriate value
                double yOffset = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowMoveFromCurrent(windowHandle, xOffset, yOffset);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowMove
            ///</summary>
            [Test]
            public void WindowMoveTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double x = 0F; // TODO: Initialize to an appropriate value
                double y = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowMove(windowHandle, x, y);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowMinimize
            ///</summary>
            [Test]
            public void WindowMinimizeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowMinimize(windowHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowMaximize
            ///</summary>
            [Test]
            public void WindowMaximizeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowMaximize(windowHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowIsTopmost
            ///</summary>
            [Test]
            public void WindowIsTopmostTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.WindowIsTopmost(windowHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowGetWindowState
            ///</summary>
            [Test]
            public void WindowGetWindowStateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Utility.WindowState expected = new ProdUI.Utility.WindowState(); // TODO: Initialize to an appropriate value
                ProdUI.Utility.WindowState actual;
                actual = ProdUI.Controls.Prod.WindowGetWindowState(windowHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowGetVisualState
            ///</summary>
            [Test]
            public void WindowGetVisualStateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState expected = new System.Windows.Automation.WindowVisualState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState actual;
                actual = ProdUI.Controls.Prod.WindowGetVisualState(windowHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowGetTitle
            ///</summary>
            [Test]
            public void WindowGetTitleTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = ProdUI.Controls.Prod.WindowGetTitle(windowHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowGetModal
            ///</summary>
            [Test]
            public void WindowGetModalTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.WindowGetModal(windowHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowGetHandle
            ///</summary>
            [Test]
            public void WindowGetHandleTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.IntPtr actual;
                actual = ProdUI.Controls.Prod.WindowGetHandle(partialTitle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowExists
            ///</summary>
            [Test]
            public void WindowExistsTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.WindowExists(partialTitle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WindowClose
            ///</summary>
            [Test]
            public void WindowCloseTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowClose(windowHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WindowActivate
            ///</summary>
            [Test]
            public void WindowActivateTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.WindowActivate(windowHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for WinWaitExists
            ///</summary>
            [Test]
            public void WinWaitExistsTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                int delay = 0; // TODO: Initialize to an appropriate value
                System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.IntPtr actual;
                actual = ProdUI.Controls.Prod.WinWaitExists(partialTitle, delay);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for WinWaitClose
            ///</summary>
            [Test]
            public void WinWaitCloseTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                int delay = 0; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.WinWaitClose(partialTitle, delay);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for ToggleCheckState
            ///</summary>
            [Test]
            public void ToggleCheckStateTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ToggleCheckState(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ToggleCheckState
            ///</summary>
            [Test]
            public void ToggleCheckStateTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ToggleCheckState(prodwindow, automationId);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for TimeDelay
            ///</summary>
            [Test]
            public void TimeDelayTest()
            {
                double seconds = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.TimeDelay(seconds);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for TabsGet
            ///</summary>
            [Test]
            public void TabsGetTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.ArrayList expected = null; // TODO: Initialize to an appropriate value
                System.Collections.ArrayList actual;
                actual = ProdUI.Controls.Prod.TabsGet(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabsGet
            ///</summary>
            [Test]
            public void TabsGetTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.ArrayList expected = null; // TODO: Initialize to an appropriate value
                System.Collections.ArrayList actual;
                actual = ProdUI.Controls.Prod.TabsGet(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabSelect
            ///</summary>
            [Test]
            public void TabSelectTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.TabSelect(prodwindow, automationId, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for TabSelect
            ///</summary>
            [Test]
            public void TabSelectTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.TabSelect(prodwindow, automationId, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for TabSelect
            ///</summary>
            [Test]
            public void TabSelectTest2()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.TabSelect(controlHandle, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for TabSelect
            ///</summary>
            [Test]
            public void TabSelectTest3()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.TabSelect(controlHandle, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for TabIsSelected
            ///</summary>
            [Test]
            public void TabIsSelectedTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.TabIsSelected(controlHandle, index);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabIsSelected
            ///</summary>
            [Test]
            public void TabIsSelectedTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.TabIsSelected(controlHandle, itemText);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabIsSelected
            ///</summary>
            [Test]
            public void TabIsSelectedTest2()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.TabIsSelected(prodwindow, automationId, index);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabIsSelected
            ///</summary>
            [Test]
            public void TabIsSelectedTest3()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.TabIsSelected(prodwindow, automationId, itemText);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabGetSelected
            ///</summary>
            [Test]
            public void TabGetSelectedTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                object expected = null; // TODO: Initialize to an appropriate value
                object actual;
                actual = ProdUI.Controls.Prod.TabGetSelected(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabGetSelected
            ///</summary>
            [Test]
            public void TabGetSelectedTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement actual;
                actual = ProdUI.Controls.Prod.TabGetSelected(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabGetCount
            ///</summary>
            [Test]
            public void TabGetCountTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.TabGetCount(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for TabGetCount
            ///</summary>
            [Test]
            public void TabGetCountTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.TabGetCount(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SpinnerSetValue
            ///</summary>
            [Test]
            public void SpinnerSetValueTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double value = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SpinnerSetValue(controlHandle, value);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SpinnerSetValue
            ///</summary>
            [Test]
            public void SpinnerSetValueTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double value = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SpinnerSetValue(prodwindow, automationId, value);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SpinnerGetValue
            ///</summary>
            [Test]
            public void SpinnerGetValueTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SpinnerGetValue(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SpinnerGetValue
            ///</summary>
            [Test]
            public void SpinnerGetValueTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SpinnerGetValue(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SpinnerGetMinValue
            ///</summary>
            [Test]
            public void SpinnerGetMinValueTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SpinnerGetMinValue(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SpinnerGetMinValue
            ///</summary>
            [Test]
            public void SpinnerGetMinValueTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SpinnerGetMinValue(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SpinnerGetMaxValue
            ///</summary>
            [Test]
            public void SpinnerGetMaxValueTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SpinnerGetMaxValue(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SpinnerGetMaxValue
            ///</summary>
            [Test]
            public void SpinnerGetMaxValueTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SpinnerGetMaxValue(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderSetValue
            ///</summary>
            [Test]
            public void SliderSetValueTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double value = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SliderSetValue(prodwindow, automationId, value);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SliderSetValue
            ///</summary>
            [Test]
            public void SliderSetValueTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double value = 0F; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SliderSetValue(controlHandle, value);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SliderGetValue
            ///</summary>
            [Test]
            public void SliderGetValueTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetValue(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetValue
            ///</summary>
            [Test]
            public void SliderGetValueTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetValue(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetSmallChange
            ///</summary>
            [Test]
            public void SliderGetSmallChangeTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetSmallChange(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetSmallChange
            ///</summary>
            [Test]
            public void SliderGetSmallChangeTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetSmallChange(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetMinValue
            ///</summary>
            [Test]
            public void SliderGetMinValueTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetMinValue(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetMinValue
            ///</summary>
            [Test]
            public void SliderGetMinValueTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetMinValue(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetMaxValue
            ///</summary>
            [Test]
            public void SliderGetMaxValueTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetMaxValue(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetMaxValue
            ///</summary>
            [Test]
            public void SliderGetMaxValueTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetMaxValue(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetLargeChange
            ///</summary>
            [Test]
            public void SliderGetLargeChangeTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetLargeChange(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SliderGetLargeChange
            ///</summary>
            [Test]
            public void SliderGetLargeChangeTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = ProdUI.Controls.Prod.SliderGetLargeChange(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SetText
            ///</summary>
            [Test]
            public void SetTextTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetText(prodwindow, automationId, newText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetText
            ///</summary>
            [Test]
            public void SetTextTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetText(controlHandle, newText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedItems
            ///</summary>
            [Test]
            public void SetSelectedItemsTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.ObjectModel.Collection<string> items = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedItems(controlHandle, items);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedItems
            ///</summary>
            [Test]
            public void SetSelectedItemsTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.ObjectModel.Collection<string> items = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedItems(prodwindow, automationId, items);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedItem
            ///</summary>
            [Test]
            public void SetSelectedItemTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedItem(controlHandle, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedItem
            ///</summary>
            [Test]
            public void SetSelectedItemTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedItem(prodwindow, automationId, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedItem
            ///</summary>
            [Test]
            public void SetSelectedItemTest2()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedItem(prodwindow, automationId, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedItem
            ///</summary>
            [Test]
            public void SetSelectedItemTest3()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedItem(controlHandle, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedIndexes
            ///</summary>
            [Test]
            public void SetSelectedIndexesTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.ObjectModel.Collection<int> indexes = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedIndexes(controlHandle, indexes);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetSelectedIndexes
            ///</summary>
            [Test]
            public void SetSelectedIndexesTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.ObjectModel.Collection<int> indexes = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetSelectedIndexes(prodwindow, automationId, indexes);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetFocus
            ///</summary>
            [Test]
            public void SetFocusTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetFocus(control);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetFocus
            ///</summary>
            [Test]
            public void SetFocusTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetFocus(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetCheckState
            ///</summary>
            [Test]
            public void SetCheckStateTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.ToggleState isChecked = new System.Windows.Automation.ToggleState(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetCheckState(controlHandle, isChecked);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SetCheckState
            ///</summary>
            [Test]
            public void SetCheckStateTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Windows.Automation.ToggleState isChecked = new System.Windows.Automation.ToggleState(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SetCheckState(prodwindow, automationId, isChecked);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SendMouseClick
            ///</summary>
            [Test]
            public void SendMouseClickTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                ProdUI.Utility.MouseClick clickType = new ProdUI.Utility.MouseClick(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SendMouseClick(control, clickType);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SendKeysTo
            ///</summary>
            [Test]
            public void SendKeysToTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string theKeys = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SendKeysTo(windowHandle, theKeys);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SendKeysTo
            ///</summary>
            [Test]
            public void SendKeysToTest1()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                string theKeys = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SendKeysTo(partialTitle, theKeys);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SelectedItemCount
            ///</summary>
            [Test]
            public void SelectedItemCountTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.SelectedItemCount(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SelectedItemCount
            ///</summary>
            [Test]
            public void SelectedItemCountTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.SelectedItemCount(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SelectRadio
            ///</summary>
            [Test]
            public void SelectRadioTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SelectRadio(prodwindow, automationId);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SelectRadio
            ///</summary>
            [Test]
            public void SelectRadioTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SelectRadio(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SelectMenuItemStatic
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void SelectMenuItemStaticTest()
            {
                System.Windows.Automation.AutomationElementCollection menuItems = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.IList<string> itemPath = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod_Accessor.SelectMenuItemStatic(menuItems, itemPath);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for SelectMenuItem
            ///</summary>
            [Test]
            public void SelectMenuItemTest()
            {
                System.IntPtr parentWindowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<string> itemPath = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.SelectMenuItem(parentWindowHandle, itemPath);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for MoveMouseToControl
            ///</summary>
            [Test]
            public void MoveMouseToControlTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.MoveMouseToControl(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for MoveMouseToControl
            ///</summary>
            [Test]
            public void MoveMouseToControlTest1()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.MoveMouseToControl(control);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for IsEnabled
            ///</summary>
            [Test]
            public void IsEnabledTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.IsEnabled(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for IsEnabled
            ///</summary>
            [Test]
            public void IsEnabledTest1()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.IsEnabled(control);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for InsertText
            ///</summary>
            [Test]
            public void InsertTextTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                int insertIndex = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.InsertText(prodwindow, automationId, newText, insertIndex);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for InsertText
            ///</summary>
            [Test]
            public void InsertTextTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                int insertIndex = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.InsertText(controlHandle, newText, insertIndex);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for GetWindowHandle
            ///</summary>
            [Test]
            public void GetWindowHandleTest()
            {
                string partialTitle = string.Empty; // TODO: Initialize to an appropriate value
                System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.IntPtr actual;
                actual = ProdUI.Controls.Prod.GetWindowHandle(partialTitle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetText
            ///</summary>
            [Test]
            public void GetTextTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = ProdUI.Controls.Prod.GetText(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetText
            ///</summary>
            [Test]
            public void GetTextTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = ProdUI.Controls.Prod.GetText(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedItems
            ///</summary>
            [Test]
            public void GetSelectedItemsTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = ProdUI.Controls.Prod.GetSelectedItems(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedItems
            ///</summary>
            [Test]
            public void GetSelectedItemsTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = ProdUI.Controls.Prod.GetSelectedItems(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedItem
            ///</summary>
            [Test]
            public void GetSelectedItemTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement actual;
                actual = ProdUI.Controls.Prod.GetSelectedItem(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedItem
            ///</summary>
            [Test]
            public void GetSelectedItemTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                object expected = null; // TODO: Initialize to an appropriate value
                object actual;
                actual = ProdUI.Controls.Prod.GetSelectedItem(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedIndexes
            ///</summary>
            [Test]
            public void GetSelectedIndexesTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = ProdUI.Controls.Prod.GetSelectedIndexes(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedIndexes
            ///</summary>
            [Test]
            public void GetSelectedIndexesTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = ProdUI.Controls.Prod.GetSelectedIndexes(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedIndex
            ///</summary>
            [Test]
            public void GetSelectedIndexTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.GetSelectedIndex(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSelectedIndex
            ///</summary>
            [Test]
            public void GetSelectedIndexTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.GetSelectedIndex(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetReadOnly
            ///</summary>
            [Test]
            public void GetReadOnlyTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.GetReadOnly(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetReadOnly
            ///</summary>
            [Test]
            public void GetReadOnlyTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.GetReadOnly(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetRadioState
            ///</summary>
            [Test]
            public void GetRadioStateTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.GetRadioState(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetRadioState
            ///</summary>
            [Test]
            public void GetRadioStateTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.GetRadioState(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetMenuItems
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void GetMenuItemsTest()
            {
                System.Windows.Automation.AutomationElement menubar = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElementCollection expected = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElementCollection actual;
                actual = ProdUI.Controls.Prod_Accessor.GetMenuItems(menubar);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetMenuBars
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void GetMenuBarsTest()
            {
                System.Windows.Automation.AutomationElement window = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElementCollection expected = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElementCollection actual;
                actual = ProdUI.Controls.Prod_Accessor.GetMenuBars(window);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetMainMenuBar
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void GetMainMenuBarTest()
            {
                System.Windows.Automation.AutomationElement window = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement actual;
                actual = ProdUI.Controls.Prod_Accessor.GetMainMenuBar(window);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetItems
            ///</summary>
            [Test]
            public void GetItemsTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = ProdUI.Controls.Prod.GetItems(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetItems
            ///</summary>
            [Test]
            public void GetItemsTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = ProdUI.Controls.Prod.GetItems(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetItemCount
            ///</summary>
            [Test]
            public void GetItemCountTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.GetItemCount(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetItemCount
            ///</summary>
            [Test]
            public void GetItemCountTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.Controls.Prod.GetItemCount(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetHandleFromTree
            ///</summary>
            [Test]
            public void GetHandleFromTreeTest()
            {
                System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int position = 0; // TODO: Initialize to an appropriate value
                System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.IntPtr actual;
                actual = ProdUI.Controls.Prod.GetHandleFromTree(windowHandle, position);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetElement
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void GetElementTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement actual;
                actual = ProdUI.Controls.Prod_Accessor.GetElement(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetControlHandle
            ///</summary>
            [Test]
            public void GetControlHandleTest()
            {
                System.IntPtr parentHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int controlId = 0; // TODO: Initialize to an appropriate value
                System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.IntPtr actual;
                actual = ProdUI.Controls.Prod.GetControlHandle(parentHandle, controlId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetControlHandle
            ///</summary>
            [Test]
            public void GetControlHandleTest1()
            {
                System.IntPtr parentHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string controlText = string.Empty; // TODO: Initialize to an appropriate value
                System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.IntPtr actual;
                actual = ProdUI.Controls.Prod.GetControlHandle(parentHandle, controlText);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetCheckState
            ///</summary>
            [Test]
            public void GetCheckStateTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                System.Windows.Automation.ToggleState expected = new System.Windows.Automation.ToggleState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.ToggleState actual;
                actual = ProdUI.Controls.Prod.GetCheckState(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetCheckState
            ///</summary>
            [Test]
            public void GetCheckStateTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.ToggleState expected = new System.Windows.Automation.ToggleState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.ToggleState actual;
                actual = ProdUI.Controls.Prod.GetCheckState(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetCaption
            ///</summary>
            [Test]
            public void GetCaptionTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = ProdUI.Controls.Prod.GetCaption(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for FindItemStatic
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void FindItemStaticTest()
            {
                System.Windows.Automation.AutomationElement item = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.IList<string> itemPath = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod_Accessor.FindItemStatic(item, itemPath);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for DeselectItem
            ///</summary>
            [Test]
            public void DeselectItemTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.DeselectItem(controlHandle, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for DeselectItem
            ///</summary>
            [Test]
            public void DeselectItemTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.DeselectItem(prodwindow, automationId, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for DeselectItem
            ///</summary>
            [Test]
            public void DeselectItemTest2()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.DeselectItem(controlHandle, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for DeselectItem
            ///</summary>
            [Test]
            public void DeselectItemTest3()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.DeselectItem(prodwindow, automationId, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for CopyToCltargetipBoard
            ///</summary>
            [Test]
            public void CopyToCltargetipBoardTest()
            {
                System.Windows.Forms.DataFormats format = null; // TODO: Initialize to an appropriate value
                object item = null; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.CopyToCltargetipBoard(format, item);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ConvertFromInteractionState
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void ConvertFromInteractionStateTest()
            {
                System.Windows.Automation.WindowInteractionState state = new System.Windows.Automation.WindowInteractionState(); // TODO: Initialize to an appropriate value
                ProdUI.Utility.WindowState expected = new ProdUI.Utility.WindowState(); // TODO: Initialize to an appropriate value
                ProdUI.Utility.WindowState actual;
                actual = ProdUI.Controls.Prod_Accessor.ConvertFromInteractionState(state);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for ControlWaitReady
            ///</summary>
            [Test]
            public void ControlWaitReadyTest()
            {
                ProdUI.Controls.BaseProdControl control = null; // TODO: Initialize to an appropriate value
                int delay = 0; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.ControlWaitReady(control, delay);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for Click
            ///</summary>
            [Test]
            public void ClickTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.Click(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for Click
            ///</summary>
            [Test]
            public void ClickTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.Click(prodwindow, automationId);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ClearText
            ///</summary>
            [Test]
            public void ClearTextTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ClearText(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ClearText
            ///</summary>
            [Test]
            public void ClearTextTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ClearText(prodwindow, automationId);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for CheckBoxClick
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void CheckBoxClickTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod_Accessor.CheckBoxClick(prodwindow, automationId);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for CheckBoxClick
            ///</summary>
            [Test]
            [DeploymentItem("ProdUI.dll")]
            public void CheckBoxClickTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod_Accessor.CheckBoxClick(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for CanSelectMultiple
            ///</summary>
            [Test]
            public void CanSelectMultipleTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.CanSelectMultiple(prodwindow, automationId);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for CanSelectMultiple
            ///</summary>
            [Test]
            public void CanSelectMultipleTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = ProdUI.Controls.Prod.CanSelectMultiple(controlHandle);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for ButtonClick
            ///</summary>
            [Test]
            public void ButtonClickTest()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ButtonClick(controlHandle);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for ButtonClick
            ///</summary>
            [Test]
            public void ButtonClickTest1()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.ButtonClick(prodwindow, automationId);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for AppendText
            ///</summary>
            [Test]
            public void AppendTextTest()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.AppendText(prodwindow, automationId, newText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for AppendText
            ///</summary>
            [Test]
            public void AppendTextTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string newText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.AppendText(controlHandle, newText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for AddToSelection
            ///</summary>
            [Test]
            public void AddToSelectionTest1()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.AddToSelection(controlHandle, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for AddToSelection
            ///</summary>
            [Test]
            public void AddToSelectionTest2()
            {
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                int index = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.AddToSelection(controlHandle, index);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }

            /// <summary>
            ///A test for AddToSelection
            ///</summary>
            [Test]
            public void AddToSelectionTest3()
            {
                ProdUI.Controls.ProdWindow prodwindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                string itemText = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.Prod.AddToSelection(prodwindow, automationId, itemText);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }
        
    }
}
