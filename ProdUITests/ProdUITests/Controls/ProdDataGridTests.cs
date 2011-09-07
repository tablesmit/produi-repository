using NUnit.Framework;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
    class ProdDataGridTests
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
        ///A test for ProdDataGrid Constructor
        ///</summary>
        [Test]
        public void ProdDataGridConstructorTest()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ProdDataGrid Constructor
        ///</summary>
        [Test]
        public void ProdDataGridConstructorTest1()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            int treePosition = 0; // TODO: Initialize to an appropriate value
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ProdDataGrid Constructor
        ///</summary>
        [Test]
        public void ProdDataGridConstructorTest2()
        {
            ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
            string automationId = string.Empty; // TODO: Initialize to an appropriate value
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddToSelection
        ///</summary>
        [Test]
        public void AddToSelectionTest()
        {
            int row = 0; // TODO: Initialize to an appropriate value
            int column = 0; // TODO: Initialize to an appropriate value
            target.AddToSelection(row, column);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddToSelection
        ///</summary>
        [Test]
        public void AddToSelectionTest1()
        {
            System.Windows.Automation.AutomationElement dataItem = null; // TODO: Initialize to an appropriate value
            target.AddToSelection(dataItem);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CanSelectMultiple
        ///</summary>
        [Test]
        public void CanSelectMultipleTest()
        {
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanSelectMultiple();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetColumnCount
        ///</summary>
        [Test]
        public void GetColumnCountTest()
        {
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetColumnCount();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetColumnHeaders
        ///</summary>
        [Test]
        public void GetColumnHeadersTest()
        {
            System.Windows.Automation.AutomationElement[] expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement[] actual;
            actual = target.GetColumnHeaders();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetItem
        ///</summary>
        [Test]
        public void GetItemTest()
        {
            int row = 0; // TODO: Initialize to an appropriate value
            int column = 0; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement actual;
            actual = target.GetItem(row, column);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetItemColumnSpan
        ///</summary>
        [Test]
        public void GetItemColumnSpanTest()
        {
            System.Windows.Automation.AutomationElement dataItem = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetItemColumnSpan(dataItem);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetItemRowSpan
        ///</summary>
        [Test]
        public void GetItemRowSpanTest()
        {
            System.Windows.Automation.AutomationElement dataItem = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetItemRowSpan(dataItem);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRowCount
        ///</summary>
        [Test]
        public void GetRowCountTest()
        {
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetRowCount();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRowHeaders
        ///</summary>
        [Test]
        public void GetRowHeadersTest()
        {
            System.Windows.Automation.AutomationElement[] expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Automation.AutomationElement[] actual;
            actual = target.GetRowHeaders();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRowOrColumnMajor
        ///</summary>
        [Test]
        public void GetRowOrColumnMajorTest()
        {
            System.Windows.Automation.RowOrColumnMajor expected = new System.Windows.Automation.RowOrColumnMajor(); // TODO: Initialize to an appropriate value
            System.Windows.Automation.RowOrColumnMajor actual;
            actual = target.GetRowOrColumnMajor();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveFromSelection
        ///</summary>
        [Test]
        public void RemoveFromSelectionTest()
        {
            System.Windows.Automation.AutomationElement dataItem = null; // TODO: Initialize to an appropriate value
            target.RemoveFromSelection(dataItem);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RemoveFromSelection
        ///</summary>
        [Test]
        public void RemoveFromSelectionTest1()
        {
            int row = 0; // TODO: Initialize to an appropriate value
            int column = 0; // TODO: Initialize to an appropriate value
            target.RemoveFromSelection(row, column);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectItem
        ///</summary>
        [Test]
        public void SelectItemTest()
        {
            target.SelectItem(dataItem);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectItem
        ///</summary>
        [Test]
        public void SelectItemTest1()
        {
            int row = 0; // TODO: Initialize to an appropriate value
            int column = 0; // TODO: Initialize to an appropriate value
            target.SelectItem(row, column);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
