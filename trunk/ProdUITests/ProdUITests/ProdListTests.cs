using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using ProdUI.Utility;

namespace ProdUITests
{
    [TestFixture]
    class ProdListTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static List<string> singleBoxItems = new List<string>() { "Red", "Blue", "Black" };
        private static List<string> multiBoxItems = new List<string>() { "Iowa", "Wisconsin", "Utah", "Texas" };
        private static ProdSession session;
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            session = new ProdSession("test.ses");
            window = new ProdWindow(WIN_TITLE, session.Loggers);
        }

        [Test]
        public void GetItems()
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.GetItems();
            Assert.AreEqual(singleBoxItems, list.GetItems());
        }


        [Test]
        public void GetItemCount()
        {
            /* there are currently 3 items in the test-forms ComboBox */
            ProdList list = new ProdList(window, "listBoxSingleTest");
            Assert.That(list.GetItemCount(), Is.EqualTo(singleBoxItems.Count));
        }

        [Test]
        public void CanSelectMultipleOnMultiple()
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            bool retVal = list.CanSelectMultiple();

            Assert.That(retVal);
        }

        [Test]
        public void CanSelectMultipleOnSingle()
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            bool retVal = list.CanSelectMultiple();

            Assert.That(!retVal);
        }


        #region Single Select

        [Test]
        public void GetSelectedItem([Values("Red", "Blue", "Black")] string itemText)
        {
            /* Initially, the selected Items text is "New" (index 0) */
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            combo.SetSelectedItem(itemText);

            AutomationElement[] retVal = SelectionPatternHelper.GetSelection(combo.ThisElement);

            Assert.That(retVal[0].Current.Name, Is.EqualTo(itemText));
        }

        [Test]
        public void GetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            combo.GetSelectedIndex();

            AutomationElement[] element = SelectionPatternHelper.GetSelection(combo.ThisElement);
            int retVal = SelectionPatternHelper.FindIndexByItem(element[0]);

            Assert.That(retVal, Is.EqualTo(index));
        }

        [Test]
        public void SetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(combo.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            int ret = combo.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Tests to see if invalid indexes will throw")]
        public void SetSelectedIndexFail([Values(-1, 3)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(combo.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            int ret = combo.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetSelectedIndexEventNotification([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(combo.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            Thread.Sleep(2000);
            Assert.That(combo.eventTriggered, Is.True);
        }

        [Test]
        public void SetSelectedItem([Values("Red", "Blue", "Black")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(combo.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Checks to see selection of item in list")]
        public void SetSelectedItemFail([Values("Nuts")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(combo.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetSelectedItemEventNotification([Values("Red", "Blue", "Black")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "listBoxSingleTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(combo.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Thread.Sleep(2000);
            Assert.That(combo.eventTriggered);
        }

        #endregion

        #region Multi Select specific

        [Test]
        public void AddToSelectionByIndex([Values(1, 2, 0)] int index)
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(index);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(index));

        }

        [Test]
        public void AddToSelectionByInvalidIndex([Values(-5, 5)] int index)
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(index);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(index));

        }

        [Test]
        public void AddToSelectionByText([Values("Iowa", "Wisconsin", "Utah", "Texas")] string itemText)
        {

            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(itemText);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(itemText));
        }

        [Test]
        public void AddToSelectionByInvalidText([Values("California")] string itemText)
        {

            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(itemText);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(itemText));
        }

        [Test]
        public void AddToSelectionByTextEventNotification([Values("Iowa", "Wisconsin", "Utah", "Texas")] string itemText)
        {

            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(itemText);

            Thread.Sleep(2000);
            Assert.That(list.eventTriggered);
        }

        [Test]
        public void GetSelectedIndexes()
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            List<object> retList = list.GetSelectedIndexes();
            Assert.That(retList,Is.EqualTo(multiBoxItems));
        }

        //[Test]
        //public List<object> GetSelectedItems()
        //{
        //    if (!CanSelectMultiple())
        //    {
        //        throw new ProdOperationException(Name + " does not allow multiple selection");
        //    }

        //    try
        //    {
        //        AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(ThisElement);
        //        List<object> retList = new List<object>() { selectedItems };

        //        Logmessage = "Items: ";
        //        VerboseInformation = retList;
        //        LogEntry();

        //        return retList;
        //    }
        //    catch (ProdOperationException err)
        //    {
        //        ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
        //        throw;
        //    }
        //}

        //[Test]
        //public int GetSelectedItemCount()
        //{
        //    if (!CanSelectMultiple())
        //    {
        //        return -1;
        //    }

        //    try
        //    {
        //        AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(ThisElement);

        //        Logmessage = "Count: " + selectedItems.Length;
        //        LogEntry();

        //        return selectedItems.Length;
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        return -1;
        //    }
        //    catch (ElementNotAvailableException err)
        //    {
        //        throw new ProdOperationException(err.Message, err);
        //    }
        //}

        //[Test]
        //public void RemoveFromSelection(int index)
        //{
        //    if (!CanSelectMultiple())
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        SubscribeToEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
        //        AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(ThisElement, index);
        //        SelectionPatternHelper.RemoveFromSelection(itemToSelect);

        //        Logmessage = "Index: " + index;
        //        LogEntry();
        //    }
        //    catch (ProdOperationException err)
        //    {
        //        ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
        //        throw;
        //    }
        //}

        //[Test]
        //public void RemoveFromSelection(string itemText)
        //{
        //    try
        //    {
        //        if (!CanSelectMultiple())
        //        {
        //            return;
        //        }


        //        SubscribeToEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
        //        AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(ThisElement, itemText);
        //        SelectionPatternHelper.RemoveFromSelection(itemToSelect);

        //        Logmessage = "Item: " + itemText;
        //        LogEntry();
        //    }
        //    catch (ProdOperationException err)
        //    {
        //        ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
        //        throw;
        //    }
        //}

        //[Test]
        //public void SelectAll()
        //{
        //    try
        //    {
        //        if (!CanSelectMultiple())
        //        {
        //            return;
        //        }

        //        Logmessage = "Select All";
        //        LogEntry();

        //        foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(ThisElement))
        //        {
        //            AddToSelection(item.Current.Name);
        //        }
        //    }
        //    catch (InvalidOperationException err)
        //    {
        //        throw new ProdOperationException(err.Message, err);
        //    }
        //    catch (ElementNotAvailableException err)
        //    {
        //        throw new ProdOperationException(err.Message, err);
        //    }
        //}


        //[Test]
        //public void SetSelectIndexes(Collection<int> indexes)
        //{
        //    try
        //    {
        //        if (!CanSelectMultiple())
        //        {
        //            return;
        //        }


        //        foreach (int index in indexes)
        //        {
        //            AddToSelection(index);
        //        }

        //        List<object> retList = new List<object>() { indexes };

        //        Logmessage = "Indexes";
        //        VerboseInformation = retList;
        //        LogEntry();
        //    }
        //    catch (ProdOperationException err)
        //    {
        //        ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
        //        throw;
        //    }
        //}

        //[Test]
        //public void SetSelectedItems(Collection<string> items)
        //{
        //    try
        //    {
        //        foreach (string item in items)
        //        {
        //            AddToSelection(item);
        //        }

        //        List<object> retList = new List<object>(items);
        //        Logmessage = "Items";
        //        VerboseInformation = retList;
        //        LogEntry();
        //    }
        //    catch (ProdOperationException err)
        //    {
        //        ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
        //        throw;
        //    }
        //}


        #endregion

    }
}
