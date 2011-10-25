using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class MenuBridge
    {
        static int ctr = 0;

        /// <summary>
        /// Selects the menu item.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <param name="itemPath">The item path, with each item down the path as an item in the list</param>
        /// <remarks>
        /// Menu item text MUST be exact (but not case-sensitive). 'Open' will not match an item 'Open...' but will match 'open'
        /// </remarks>
        internal static void SelectMenuItemBridge(this IExpandCollapse extension, BaseProdControl control, string[] itemPath)
        {
            ctr = 0;
            try
            {
                UiaSelectMenuItem(control, itemPath);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static void UiaSelectMenuItem(BaseProdControl control, string[] itemPath)
        {
            AutomationElementCollection menuItems = UiaGetMenuItems(control);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(string.Join(",",itemPath)));
            ExpandMenuItem(menuItems, itemPath);
        }


        /// <summary>
        /// Gets the menu items contained in the current Menu Bar.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        internal static AutomationElementCollection GetMenuItemsBridge(this IExpandCollapse extension, BaseProdControl control)
        {
            try
            {
                return UiaGetMenuItems(control);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        private static AutomationElementCollection UiaGetMenuItems(BaseProdControl control)
        {
            try
            {
                AutomationElementCollection retVal = control.UIAElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                Collection<object> retColl = InternalUtilities.AutomationCollToObjectList(retVal);
                LogController.ReceiveLogMessage(new LogMessage(string.Join("Items", retColl)));
                return retVal;
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }



        /// <summary>
        /// Invokes the menu item by accelerator key.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <remarks>
        /// Retrieves accelerator keys from supplied controls properties
        /// </remarks>
        internal static void InvokeByAcceleratorKeyBridge(this IInvoke extension, BaseProdControl control)
        {
            try
            {
                UiaInvokeByAcceleratorKey(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        /// Invokes the menu item by accelerator key.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <param name="keyCombination">The key combination.</param>
        /// <remarks>
        /// Converts from format of "Shift+CTRL+Y" into "+^(Y)"
        /// </remarks>
        internal static void InvokeByAcceleratorKeyBridge(this IInvoke extension, BaseProdControl control, string keyCombination)
        {
            try
            {
                UiaInvokeByAcceleratorKey(control, keyCombination);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static void UiaInvokeByAcceleratorKey(BaseProdControl control)
        {
            if (control.UIAElement.Current.AcceleratorKey.Length == 0)
            {
                return;
            }
            string cleaned = InternalUtilities.ConvertStringToSendKey(control.UIAElement.Current.AcceleratorKey);
            control.SetFocus();
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(cleaned));
            InternalUtilities.SendKeysSetText(control.UIAElement, cleaned);
        }

        private static void UiaInvokeByAcceleratorKey(BaseProdControl control, string keyCombination)
        {
            string cleaned = InternalUtilities.ConvertStringToSendKey(keyCombination);
            control.SetFocus();
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(cleaned));
            InternalUtilities.SendKeysSetText(control.UIAElement, cleaned);
        }



        /// <summary>
        /// Invokes the menu item by access key.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The menu item element.</param>
        internal static void InvokeByAccessKeyBridge(this IInvoke extension, BaseProdControl control)
        {
            try
            {
                UiaInvokeByAccessKey(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        /// Invokes the menu item by access key.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The menu item element.</param>
        /// <param name="keyCombination">The key combination.</param>
        internal static void InvokeByAccessKeyBridge(this IInvoke extension, BaseProdControl control, string keyCombination)
        {
            try
            {
                UiaInvokeByAccessKey(control, keyCombination);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static void UiaInvokeByAccessKey(BaseProdControl control)
        {
            if (control.UIAElement.Current.AccessKey.Length == 0)
            {
                return;
            }
            string cleaned = InternalUtilities.ConvertStringToSendKey(control.UIAElement.Current.AccessKey);
            control.SetFocus();
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(cleaned));
            InternalUtilities.SendKeysSetText(control.UIAElement, cleaned);
        }

        private static void UiaInvokeByAccessKey(BaseProdControl control, string keyCombination)
        {
            string cleaned = InternalUtilities.ConvertStringToSendKey(keyCombination);
            control.SetFocus();
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(cleaned));
            InternalUtilities.SendKeysSetText(control.UIAElement, cleaned);
        }


        /* helper functions */

        /// <summary>
        /// Gets the child menu items.
        /// </summary>
        /// <param name="item">The parent MenuItems.</param>
        /// <returns>A collection of MenuItems</returns>
        private static AutomationElementCollection GetChildMenuItems(AutomationElement item)
        {
            try
            {
                AutomationElementCollection ret = item.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Expands the menu item.
        /// </summary>
        /// <param name="menuItems">The menu items.</param>
        /// <param name="itemPath">The item path.</param>
        private static void ExpandMenuItem(AutomationElementCollection menuItems, string[] itemPath)
        {
            foreach (AutomationElement item in menuItems)
            {
                /* Expand top menu */
                try
                {
                    string name = item.Current.Name;
                    if (string.Compare(name, itemPath[ctr], true, CultureInfo.CurrentCulture) != 0) continue;

                    if (CommonUIAPatternHelpers.CheckPatternSupport(ExpandCollapsePattern.Pattern, item) != null)
                    {
                        ExpandCollapseHelper.Expand(item);

                        AutomationElementCollection items = GetChildMenuItems(item);
                        ctr++;
                        ExpandMenuItem(items, itemPath);
                    }

                    if (CommonUIAPatternHelpers.CheckPatternSupport(InvokePattern.Pattern, item) == null) return;
                    InvokePatternHelper.Invoke(item);
                }
                catch (InvalidOperationException err)
                {
                    throw new ProdOperationException(err.Message, err);
                }
                catch (ElementNotAvailableException err)
                {
                    throw new ProdOperationException(err.Message, err);
                }
            }
        }

        /// <summary>
        /// Gets the main menu bar attached to the target window.
        /// </summary>
        /// <param name="window">The target window.</param>
        /// <returns>
        /// The main menu bar as an AutomationElement
        /// </returns>
        private static AutomationElement GetMainMenuBar(AutomationElement window)
        {
            AutomationElementCollection menuBars = GetMenuBars(window);

            if (menuBars.Count == 0)
            {
                throw new ProdOperationException("Could Not find Menu Bar");
            }
            return menuBars[0];
        }

        /// <summary>
        /// Gets all the MenuBars attached to a window.
        /// </summary>
        /// <param name="window">The target window.</param>
        /// <returns>
        /// The menu bars as an AutomationElementCollection
        /// </returns>
        private static AutomationElementCollection GetMenuBars(AutomationElement window)
        {
            try
            {
                return window.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuBar));
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}
