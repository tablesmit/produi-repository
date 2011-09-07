using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using ProdUI.Utility;

namespace ProdUITests
{
    [TestFixture]
    class ProdMenuItemTests
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
        public void ConstructorWithHandle()
        {
            IntPtr handle = Prod.GetWindowHandle("Button1");
            if (handle == IntPtr.Zero)
                Assert.Pass("Unable to create button using handle");
            ProdButton button = new ProdButton(window, handle);
        }

        [Test]
        public void ConstructorWithId()
        {
            ProdButton button = new ProdButton(window, "button1");
            Assert.Pass("Button Created");
        }

        [Test]
        public void ConstructorWithTreePosition()
        {
            //ProdButton button = new ProdButton(window, "button1");
            Assert.Fail("Not implemented");
        }

        [Test]
        public void SelectMenuItem(List<string> itemPath)
        {
            AutomationElementCollection menuItems = GetMenuItems(ThisElement);
            ExpandMenuItem(menuItems, itemPath);
        }

        [Test]
        public void InvokeByAcceleratorKey(string keyCombonation)
        {
            string cleaned = InternalUtilities.ConvertStringToSendKey(keyCombonation);
            ParentWindow.Activate();
            Prod.SendKeysTo((IntPtr)ParentWindow.Window.Current.NativeWindowHandle, cleaned);

        }

        [Test]
        public void InvokeByAcceleratorKey(AutomationElement control)
        {
            if (control.Current.AcceleratorKey.Length == 0)
            {
                return;
            }


            string cleaned = InternalUtilities.ConvertStringToSendKey(control.Current.AcceleratorKey);
            ParentWindow.Activate();
            Prod.SendKeysTo((IntPtr)ParentWindow.Window.Current.NativeWindowHandle, cleaned);

        }

        [Test]
        public void InvokeByAccessKey(AutomationElement control)
        {
            if (control.Current.AccessKey.Length == 0)
            {
                return;
            }

            ParentWindow.Activate();
            Prod.SendKeysTo((IntPtr)ParentWindow.Window.Current.NativeWindowHandle, control.Current.AccessKey);
        }

        [Test]
        public void GetMenuItems(AutomationElement menubar)
        {
                AutomationElementCollection ret = menubar.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                return ret;
        }

        [Test]
        public void ExpandMenuItem(AutomationElementCollection menuItems, IList<string> itemPath)
        {
            foreach (AutomationElement item in menuItems)
            {
                /* Expand top menu */

                string name = item.Current.Name;
                if (string.Compare(name, itemPath[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    continue;
                }

                if (item.GetCurrentPattern(ExpandCollapsePattern.Pattern) != null)
                {
                    ExpandCollapseHelper.Expand(item);
                    InvokePatternHelper.Invoke(item);
                }
                FindItem(item, itemPath);

            }
        }

        [Test]
        public void FindItem(AutomationElement item, IEnumerable<string> itemPath)
        {
            /* Loop through supplied menu path */
            foreach (string t in itemPath)
            {
                try
                {
                    /* Get next item */
                    string y = t;
                    AutomationElement ael = item.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, y, PropertyConditionFlags.IgnoreCase));
                    if (ael == null)
                    {
                        throw new ProdOperationException("Menu Item '" + y + "' doesn't exist");
                    }
                    /* Expand next item */
                    ExpandCollapseHelper.Expand(ael);

                    try
                    {
                        ael.SetFocus();
                    }
                    catch (InvalidOperationException)
                    {
                        InvokePatternHelper.Invoke(ael);
                    }
                    InvokePatternHelper.Invoke(ael);
                }
                catch (InvalidOperationException err)
                {
                    Debug.WriteLine(t + "<----No expand");
                    throw new ProdOperationException(err.Message, err);
                }
                catch (ElementNotAvailableException err)
                {
                    throw new ProdOperationException(err.Message, err);
                }
            }
            return;
        }

    }
}
