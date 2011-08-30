using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
    class ProdListTests
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
        public void GetItems()//TODO: need to verify collection
        {
            ProdList list = new ProdList(window, "listBoxTest");
            AutomationElementCollection retVal = SelectionPatternHelper.GetListItems(list.ThisElement);

            Assert.That(retVal.Count, Is.EqualTo(3));
        }


        [Test]
        public void GetItemCount()//TODO: need to verify collection
        {
            /* there are currently 3 items in the test-forms ComboBox */
            ProdList list = new ProdList(window, "listBoxTest");
            AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(list.ThisElement);

            Assert.That(list.GetItemCount(), Is.EqualTo(aec.Count));
        }

        [Test]
        public void CanSelectMultipleOnMultiple()
        {
            ProdList list = new ProdList(window, "listBoxTest");
            bool retVal = list.CanSelectMultiple();

            Assert.That(retVal, Is.True);
        }

        [Test]
        public void CanSelectMultipleOnSingle()
        {
            ProdList list = new ProdList(window, "listBoxTest");
            bool retVal = list.CanSelectMultiple();

            Assert.That(retVal, Is.False);
        }


        #region Single Select

        [Test]
        public void GetSelectedItem([Values("New", "Old", "Used")] string itemText)
        {
            /* Initially, the selected Items text is "New" (index 0) */
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem(itemText);

            AutomationElement[] retVal = SelectionPatternHelper.GetSelection(combo.ThisElement);

            Assert.That(retVal[0].Current.Name, Is.EqualTo(itemText));
        }

        [Test]
        public void GetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.GetSelectedIndex();

            AutomationElement[] element = SelectionPatternHelper.GetSelection(combo.ThisElement);
            int retVal = SelectionPatternHelper.FindIndexByItem(element[0]);

            Assert.That(retVal, Is.EqualTo(index));
        }

        [Test]
        public void SetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(combo.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            int ret = combo.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Tests to see if invalid indexes will throw")]
        public void SetSelectedIndexFail([Values(-1, 3)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(combo.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            int ret = combo.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetSelectedIndexEventNotification([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(combo.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            Thread.Sleep(2000);
            Assert.That(combo.eventTriggered, Is.True);
        }

        [Test]
        public void SetSelectedItem([Values("New", "Old", "Used")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(combo.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Checks to see selection of item in list")]
        public void SetSelectedItemFail([Values("Nuts")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(combo.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetSelectedItemEventNotification([Values("New", "Old", "Used")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(combo.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Thread.Sleep(2000);
            Assert.That(combo.eventTriggered);
        } 

        #endregion

        [Test]
        public void IsSelectedByIndex()
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem("New");

            Assert.That(combo.IsSelected(0));
        }

        [Test]
        public void IsSelectedByText()
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem("New");

            Assert.That(combo.IsSelected("New"));
        }


    }
}
