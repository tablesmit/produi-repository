using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using ProdUI.Utility;
using System.Diagnostics;

namespace ProdUITests
{
    [TestFixture]
    class TabControlTests
    {
        const string WIN_TITLE = "WPF Test Form";
        const int NUM_OF_TABS = 3;
        private static ProdSession session;
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            session = new ProdSession("test.ses");
            window = new ProdWindow(WIN_TITLE, session.Loggers);
        }

        [Test]
        public void GetItemCount()
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            Assert.That(tabs.GetItemCount(), Is.EqualTo(NUM_OF_TABS));
            Debug.WriteLine(tabs.GetItemCount() + " = " + NUM_OF_TABS);
        }

        [Test]
        public void GetItems()
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            List<object> items = tabs.GetItems(); //Note: not too sure what this will return
        }

        [Test]
        public void IsSelected([Values(1, 2, 0)]int index)
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            tabs.SelectTab(index);

            Assert.That(tabs.IsSelected(index));
        }

        [Test]
        public void IsSelected([Values("one", "Two", "Three")]string itemText)
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            tabs.SelectTab(itemText);
            Assert.That(tabs.IsSelected(itemText));
        }

        [Test]
        public void TabCount()
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");

            Assert.That(tabs.TabCount(),Is.EqualTo(NUM_OF_TABS));
        }

        [Test]
        public void SelectedTab([Values("two", "One", "Three")]string itemText)
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            tabs.SelectTab(itemText);
            
            /* the function to select the tab is not case-sensative, so the test isn't either */
            int result = string.Compare(tabs.SelectedTab().Current.Name, itemText, true);
            Assert.That(result == 0);
        }

        [Test]
        public void SelectTab([Values(1, 2, 0)]int index)
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            tabs.SelectTab(index);

            Assert.That(tabs.IsSelected(index));
        }

        [Test]
        public void SelectTab([Values("one", "Two", "Three")]string itemText)
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            tabs.SelectTab(itemText);
            AutomationElement tab = tabs.SelectedTab();

            /* the function to select the tab is not case-sensative, so the test isn't either */
            int result = string.Compare(tab.Current.Name,itemText,true);
            Assert.That(result == 0);
        }

        [Test]
        public void SelectTabEventNotification([Values(1)]int index)
        {
            ProdTab tabs = new ProdTab(window, "tabControl1");
            tabs.SelectTab(index);

            Thread.Sleep(2000);
            Assert.That(tabs.eventTriggered);
        }
    }
}
