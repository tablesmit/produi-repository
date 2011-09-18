// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        #region Static Methods

        /// <summary>
        ///     Selects the menu item.
        /// </summary>
        /// <param name = "parentWindowHandle">The parent window handle.</param>
        /// <param name = "itemPath">The 'path' to the menu item.</param>
        /// <remarks>
        ///     Menu item text MUST be exact (but not case-sensitive). 'Open' will not match an item 'Open...' but will match 'open'
        /// </remarks>
        public static void SelectMenuItem(IntPtr parentWindowHandle, List<string> itemPath)
        {
            try
            {
                AutomationElement mainMenu = GetMainMenuBar(AutomationElement.FromHandle(parentWindowHandle));
                AutomationElementCollection menuItems = GetMenuItems(mainMenu);
                SelectMenuItemStatic(menuItems, itemPath);
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
        ///     Finds an AutomationElement in a list.
        /// </summary>
        /// <param name = "item">The item to search for.</param>
        /// <param name = "itemPath">The 'path' to the menu item.</param>
        private static void FindItemStatic(AutomationElement item, IList<string> itemPath)
        {
            /* Loop through supplied menu path */
            for (int i = 1; i < itemPath.Count; i++)
            {
                try
                {
                    /* Get next item */
                    AutomationElement ael = item.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, itemPath[i], PropertyConditionFlags.IgnoreCase));
                    /* Expand next item */
                    ExpandCollapseHelper.Expand(ael);
                    ael.SetFocus();
                    InvokePatternHelper.Invoke(ael);
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
            return;
        }

        /// <summary>
        ///     Selects the menu item.
        /// </summary>
        /// <param name = "menuItems">The menu items.</param>
        /// <param name = "itemPath">The 'path' to the menu item.</param>
        private static void SelectMenuItemStatic(AutomationElementCollection menuItems, IList<string> itemPath)
        {
            foreach (AutomationElement item in menuItems)
            {
                /* Expand top menu */
                try
                {
                    string name = item.Current.Name;
                    if (string.Compare(name, itemPath[0], true, CultureInfo.CurrentCulture) != 0)
                    {
                        continue;
                    }

                    ExpandCollapseHelper.Expand(item);
                    FindItemStatic(item, itemPath);
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

        #endregion

        /// <summary>
        ///     Gets the main menu bar attached to the target window.
        /// </summary>
        /// <param name = "window">The target window.</param>
        /// <returns>
        ///     The main menu bar as an AutomationElement
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
        ///     Gets all the MenuBars attached to a window.
        /// </summary>
        /// <param name = "window">The target window.</param>
        /// <returns>
        ///     The menubars as an AutomationElementCollection
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


        /// <summary>
        ///     Gets the all of menu items attached to a MenuBar.
        /// </summary>
        /// <param name = "menubar">The menu bar that contains the items.</param>
        /// <returns>
        ///     All of menu items
        /// </returns>
        private static AutomationElementCollection GetMenuItems(AutomationElement menubar)
        {
            try
            {
                AutomationElementCollection ret = menubar.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
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
    }
}