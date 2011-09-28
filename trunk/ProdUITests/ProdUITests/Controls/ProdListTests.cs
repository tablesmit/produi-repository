using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.Utility;
using ProdUI.Controls.Windows;
using ProdUI.Interaction.UIAPatterns;

namespace ProdUITests
{
    [TestFixture]
    class ProdListTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static List<string> singleBoxItems = new List<string>() {"Blue", "Black","Red" };
        private static List<string> multiBoxItems = new List<string>() { "Iowa", "Wisconsin", "Utah", "Texas" };

        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE);
        }

        [Test]
        [Description("General")]
        public void GetItems()
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            List<object> ret = list.GetItems();
            AutomationElementCollection r = (AutomationElementCollection)ret[0];

            for (int i = 0; i < r.Count; i++)
            {
               if (string.Compare(r[i].Current.Name,singleBoxItems[i],false) != 0)
                   Assert.Fail("Unmatched item");
            }

            Assert.Pass();
        }


        [Test]
        [Description("General")]
        public void GetItemCount()
        {
            /* there are currently 3 items in the test-forms ComboBox */
            ProdList list = new ProdList(window, "listBoxSingleTest");
            List<object> ret = list.GetItems();
            AutomationElementCollection r = (AutomationElementCollection)ret[0];

            Assert.AreEqual(singleBoxItems.Count, r.Count);
        }

        [Test]
        [Description("General")]
        public void CanSelectMultipleOnMultiple()
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            bool retVal = (bool)list.GetUIAPropertyValue(SelectionPattern.CanSelectMultipleProperty);

            Assert.That(retVal);
        }

        [Test]
        [Description("General")]
        public void CanSelectMultipleOnSingle()
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            bool retVal = list.CanSelectMutiple();

            Assert.That(!retVal);
        }


        #region Single Select

        [Test, Description("Single Select")]
        [Category("Single")]
        public void GetSelectedItem([Values("Red", "Blue", "Black")] string itemText)
        {
            /* Initially, the selected Items text is "New" (index 0) */
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.SetSelectedItem(itemText);

            Assert.That(list.GetSelectedItem(), Is.EqualTo(itemText));
        }

        [Test, Description("Single Select")]
        [Category("Single")]
        public void GetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.SetSelectedIndex(index);
            int z = list.GetSelectedIndex();

            Assert.That(list.GetSelectedIndex(), Is.EqualTo(index));
        }

        [Test, Description("Single Select")]
        [Category("Single")]
        public void SetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.SetSelectedIndex(index);

            int ret = list.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Single Select"),ExpectedException("System.IndexOutOfRangeException")]
        [Category("Single")]
        public void SetSelectedIndexFail([Values(-1, 3)] int index)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(list.ThisElement, index);
            SelectionPatternHelper.Select(indexedItem);

            int ret = list.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Single Select")]
        [Category("Single")]
        public void SetSelectedIndexEventNotification(int index)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.SetSelectedIndex(1);

            Thread.Sleep(2000);
            Assert.That(list.eventTriggered, Is.True);
        }

        [Test, Description("Single Select")]
        [Category("Single")]
        public void SetSelectedItem([Values("Red", "Blue", "Black")] string itemText)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.SetSelectedItem(itemText);

            Assert.That(list.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Single Select")]
        [Category("Single")]
        public void SetSelectedItemFail([Values("Nuts")] string itemText)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            AutomationElement control = SelectionPatternHelper.FindItemByText(list.ThisElement, itemText);
            SelectionPatternHelper.Select(control);

            Assert.That(list.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

       [Test, Description("Single Select")]
       [Category("Single")]
        public void SetSelectedItemEventNotification([Values("Red", "Blue", "Black")] string itemText)
        {
            ProdList list = new ProdList(window, "listBoxSingleTest");
            list.SetSelectedItem(itemText);

            Thread.Sleep(2000);
            Assert.That(list.eventTriggered);
        }

        #endregion

        #region Multi Select specific

        [Test, Description("Multi Select")]
        [Category("Multi")]
        public void AddToSelectionByIndex([Values(1, 2, 0)] int index)
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(index);
            //AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            //List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            //Assert.That(ret, Has.Member(index));

        }

        [Test, Description("Multi Select"), ExpectedException("System.IndexOutOfRangeException")]
        [Category("Multi")]
        public void AddToSelectionByInvalidIndex([Values(-5, 5)] int index)
        {
            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(index);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(index));

        }

        [Test, Description("Multi Select")]
        [Category("Multi")]
        public void AddToSelectionByText([Values("Iowa", "Wisconsin", "Utah", "Texas")] string itemText)
        {

            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(itemText);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(itemText));
        }

        [Test, Description("Multi Select")]
        [Category("Multi")]
        public void AddToSelectionByInvalidText([Values("California")] string itemText)
        {

            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(itemText);
            AutomationElementCollection aec = SelectionPatternHelper.GetSelectionItems(list.ThisElement);
            List<object> ret = InternalUtilities.AutomationCollToObjectList(aec);

            Assert.That(ret, Has.Member(itemText));
        }

        [Test, Description("Multi Select")]
        [Category("Multi")]
        public void AddToSelectionByTextEventNotification([Values("Iowa", "Wisconsin", "Utah", "Texas")] string itemText)
        {

            ProdList list = new ProdList(window, "listBoxMultipleTest");
            list.AddToSelection(itemText);

            Thread.Sleep(2000);
            Assert.That(list.eventTriggered);
        }

        [Test, Description("Multi Select")]
        [Category("Multi")]
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
