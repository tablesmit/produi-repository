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
    class ProdTreeViewTests
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
        ///A test for ProdTreeView Constructor
        ///</summary>
        [Test]
        public void ProdTreeViewConstructorTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ProdTreeView Constructor
        ///</summary>
        [Test]
        public void ProdTreeViewConstructorTest1()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            int treePosition = 0; // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, treePosition);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ProdTreeView Constructor
        ///</summary>
        [Test]
        public void ProdTreeViewConstructorTest2()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            string automationId = string.Empty; // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, automationId);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CollapseNode
        ///</summary>
        [Test]
        public void CollapseNodeTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CollapseNode(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CollapseNode
        ///</summary>
        [Test]
        public void CollapseNodeTest1()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            string itemText = string.Empty; // TODO: Initialize to an appropriate value
            target.CollapseNode(itemText);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DefaultAction
        ///</summary>
        [Test]
        public void DefaultActionTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement actual;
            actual = target.DefaultAction(index);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumControlElements
        ///</summary>
        [Test]
        public void EnumControlElementsTest()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView_Accessor target = new ProdUI.Controls.ProdTreeView_Accessor(param0); // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement aeRoot = null; // TODO: Initialize to an appropriate value
            target.EnumControlElements(aeRoot);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExpandNode
        ///</summary>
        [Test]
        public void ExpandNodeTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            string itemText = string.Empty; // TODO: Initialize to an appropriate value
            target.ExpandNode(itemText);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExpandNode
        ///</summary>
        [Test]
        public void ExpandNodeTest1()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.ExpandNode(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetNodeCount
        ///</summary>
        [Test]
        public void GetNodeCountTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetNodeCount();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSelectedNode
        ///</summary>
        [Test]
        public void GetSelectedNodeTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement actual;
            actual = target.GetSelectedNode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSelectedNodeIndex
        ///</summary>
        [Test]
        public void GetSelectedNodeIndexTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetSelectedNodeIndex();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectNode
        ///</summary>
        [Test]
        public void SelectNodeTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            string itemText = string.Empty; // TODO: Initialize to an appropriate value
            target.SelectNode(itemText);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectNode
        ///</summary>
        [Test]
        public void SelectNodeTest1()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            string[] nodePath = null; // TODO: Initialize to an appropriate value
            target.SelectNode(nodePath);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectNode
        ///</summary>
        [Test]
        public void SelectNodeTest2()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            ProdUI.Controls.ProdTreeView target = new ProdUI.Controls.ProdTreeView(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.SelectNode(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AllNodes
        ///</summary>
        [Test]
        public void AllNodesTest()
        {
            System.Collections.ObjectModel.Collection<System.Windows.Automation.AutomationElement> expected = null; // TODO: Initialize to an appropriate value
            System.Collections.ObjectModel.Collection<System.Windows.Automation.AutomationElement> actual;
            target.AllNodes = expected;
            actual = target.AllNodes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

    }
}