/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Exceptions;
using ProdUI.Utility;
using System.Globalization;

/* Notes
 * -MenuBar-
 * Supported Patterns: 
 * IExpandCollapseProvider 
 * 
 * Proposed functionality:
 * ActivateItem - user should be able to specify a path to an item to have it traverse all subitems
 * CheckItem - if menu item supports checkstate
 */

namespace ProdUI.Controls
{
    /// <summary>
    ///   Handles the MenuItem Control Type
    /// </summary>
    public sealed class ProdMenuItem : BaseProdControl
    {

        ///// <summary>
        /////   Initializes a new instance of the ProdMenu class.
        ///// </summary>
        ///// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        //public ProdMenuItem(ProdWindow prodWindow)
        //{
        //    ParentWindow = prodWindow;
        //    UIAElement = GetMainMenuBar(ParentWindow.Window);

        //    if (UIAElement == null)
        //    {
        //        throw new ProdOperationException("Could Not find Menu Bar");
        //    }
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="ProdMenuItem" /> class.	
        /// </summary>
        /// <param name="prodWindow">The prod window.</param>
        /// <param name="automationId">The automation id.</param>
        /// <remarks></remarks>
        public ProdMenuItem(ProdWindow prodWindow, string automationId): base(prodWindow, automationId){}

        /// <summary>
        ///   Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdMenuItem(ProdWindow prodWindow, int treePosition): base(prodWindow, treePosition){}

        /// <summary>
        ///   Selects the menu item.
        /// </summary>
        /// <param name = "itemPath">The item path, with each item down the path as an item in the list</param>
        /// <remarks>
        ///   Menu item text MUST be exact (but not case-sensitive). 'Open' will not match an item 'Open...' but will match 'open'
        /// </remarks>
        public void SelectMenuItem(List<string> itemPath)
        {
            try
            {
                AutomationElementCollection menuItems = GetMenuItems(UIAElement);
                ExpandMenuItem(menuItems, itemPath);
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

        /// <summary>Invokes the menu item by accelerator key.</summary>
        /// <param name="keyCombonation">The key combonation.</param>
        /// <remarks>Converts from format of "Shift+CTRL+Y" into "+^(Y)"</remarks>
        public void InvokeByAcceleratorKey(string keyCombonation) 
        {         
            string cleaned = InternalUtilities.ConvertStringToSendKey(keyCombonation);
            ParentWindow.Activate();
            Prod.SendKeysTo((IntPtr)ParentWindow.Window.Current.NativeWindowHandle,cleaned);

        }

        /// <summary>Invokes the menu item by accelerator key.</summary>
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

        /// <summary>Invokes the menu item by access key.</summary>
        /// <param name="control">The menu item element.</param>
        public void InvokeByAccessKey(AutomationElement control)
        {
            if (control.Current.AccessKey.Length == 0)
            {
                return;
            }

            ParentWindow.Activate();
            Prod.SendKeysTo((IntPtr)ParentWindow.Window.Current.NativeWindowHandle, control.Current.AccessKey);
        }



        ///// <summary>
        /////   Gets the main menu bar.
        ///// </summary>
        ///// <param name = "window">The window.</param>
        ///// <returns></returns>
        //private static AutomationElement GetMainMenuBar(AutomationElement window)
        //{
        //    AutomationElementCollection menuBars = GetMenuBars(window);

        //    if (menuBars.Count == 0)
        //    {
        //        throw new ProdOperationException("Could Not find Menu Bar");
        //    }
        //    return menuBars[0];
        //}

        ///// <summary>
        /////   Gets the menu bars.
        ///// </summary>
        ///// <param name = "window">The window.</param>
        ///// <returns></returns>
        //private static AutomationElementCollection GetMenuBars(AutomationElement window)
        //{
        //    try
        //    {
        //        return window.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuBar));
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

        /// <summary>
        ///   Gets the menu items.
        /// </summary>
        /// <param name = "menubar">The menu bar.</param>
        /// <returns></returns>
        private static AutomationElementCollection GetMenuItems(AutomationElement menubar)
        {
            try
            {
                AutomationElementCollection ret = menubar.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                Debug.WriteLine("<>-----" + ret.Count);
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
        ///   Selects the menu item.
        /// </summary>
        /// <param name = "menuItems">The menu items.</param>
        /// <param name = "itemPath">The item path.</param>
        private static void ExpandMenuItem(AutomationElementCollection menuItems, IList<string> itemPath)
        {
            Debug.WriteLine(menuItems.Count + "****----ExpandMenuItem");
            foreach (AutomationElement item in menuItems)
            {
                Debug.WriteLine(item.Current.Name + "****----");
                /* Expand top menu */
                try
                {
                    string name = item.Current.Name;
                    if (string.Compare(name, itemPath[0], true, CultureInfo.CurrentCulture) != 0)
                    {
                        continue;
                    }


                    if (item.GetCurrentPattern(ExpandCollapsePattern.Pattern) != null)
                    {
                        ExpandCollapseHelper.Expand(item);
                        Debug.WriteLine(name + ">----No expand");
                        InvokePatternHelper.Invoke(item);
                    }
                    FindItem(item, itemPath);
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
        ///   Finds the item.
        /// </summary>
        /// <param name = "item">The item.</param>
        /// <param name = "itemPath">The item path.</param>
        private static void FindItem(AutomationElement item, IEnumerable<string> itemPath)
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