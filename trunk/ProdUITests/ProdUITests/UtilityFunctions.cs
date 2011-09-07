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
    class UtilityFunctions
    {


        /// <summary>
        ///A test for AutomationCollToArrayList
        ///</summary>
        [Test]
        public void AutomationCollToArrayListTest()
        {
            System.Windows.Automation.AutomationElementCollection ret = null; // TODO: Initialize to an appropriate value
            System.Collections.ArrayList expected = null; // TODO: Initialize to an appropriate value
            System.Collections.ArrayList actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.AutomationCollToArrayList(ret);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AutomationCollToObjectList
        ///</summary>
        [Test]
        public void AutomationCollToObjectListTest()
        {
            System.Windows.Automation.AutomationElementCollection ret = null; // TODO: Initialize to an appropriate value
            System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
            System.Collections.Generic.List<object> actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.AutomationCollToObjectList(ret);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConvertStringToSendKey
        ///</summary>
        [Test]
        public void ConvertStringToSendKeyTest()
        {
            string keys = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.ConvertStringToSendKey(keys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumChildProc
        ///</summary>
        [Test]
        public void EnumChildProcTest()
        {
            System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            int lParam = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.EnumChildProc(windowHandle, lParam);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumWindowsProc
        ///</summary>
        [Test]
        public void EnumWindowsProcTest()
        {
            System.IntPtr windowHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            int lParam = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.EnumWindowsProc(windowHandle, lParam);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumerateExistingChildren
        ///</summary>
        [Test]
        public void EnumerateExistingChildrenTest()
        {
            string theChildTitle = string.Empty; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.EnumerateExistingChildren(theChildTitle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumerateExistingWindowsPartial
        ///</summary>
        [Test]
        public void EnumerateExistingWindowsPartialTest()
        {
            string thePartialTitle = string.Empty; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.EnumerateExistingWindowsPartial(thePartialTitle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindWindowPartial
        ///</summary>
        [Test]
        public void FindWindowPartialTest()
        {
            string thePartialTitle = string.Empty; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.FindWindowPartial(thePartialTitle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetChildHandle
        ///</summary>
        [Test]
        public void GetChildHandleTest()
        {
            System.IntPtr theParentHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            int controlId = 0; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.GetChildHandle(theParentHandle, controlId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetChildHandle
        ///</summary>
        [Test]
        public void GetChildHandleTest1()
        {
            System.IntPtr theParentHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            string theControlText = string.Empty; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.GetChildHandle(theParentHandle, theControlText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetChildWindow
        ///</summary>
        [Test]
        public void GetChildWindowTest()
        {
            System.IntPtr theParentHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            string theChildTitle = string.Empty; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.GetChildWindow(theParentHandle, theChildTitle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetHandlelessElement
        ///</summary>
        [Test]
        public void GetHandlelessElementTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            string automationId = string.Empty; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.GetHandlelessElement(prodWindow, automationId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetStackTrace
        ///</summary>
        [Test]
        public void GetStackTraceTest()
        {
            System.Diagnostics.StackFrame[] frames = null; // TODO: Initialize to an appropriate value
            System.Collections.ObjectModel.Collection<string> expected = null; // TODO: Initialize to an appropriate value
            System.Collections.ObjectModel.Collection<string> actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.GetStackTrace(frames);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MoveMouseToPoint
        ///</summary>
        [Test]
        public void MoveMouseToPointTest()
        {
            System.Drawing.Point pt = new System.Drawing.Point(); // TODO: Initialize to an appropriate value
            ProdUI.Utility.InternalUtilities_Accessor.MoveMouseToPoint(pt);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendMouseInput
        ///</summary>
        [Test]
        public void SendMouseInputTest()
        {
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            int data = 0; // TODO: Initialize to an appropriate value
            ProdUI.Utility.MOUSEEVENTF_Accessor flags = null; // TODO: Initialize to an appropriate value
            ProdUI.Utility.InternalUtilities_Accessor.SendMouseInput(x, y, data, flags);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WinWaitSearch
        ///</summary>
        [Test]
        public void WinWaitSearchTest()
        {
            string thePartialTitle = string.Empty; // TODO: Initialize to an appropriate value
            System.IntPtr expected = new System.IntPtr(); // TODO: Initialize to an appropriate value
            System.IntPtr actual;
            actual = ProdUI.Utility.InternalUtilities_Accessor.WinWaitSearch(thePartialTitle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
