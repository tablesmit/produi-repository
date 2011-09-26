// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Interaction.Bridge;
using System.Collections.Generic;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        ///     Gets a collection of all items in the list control
        /// </summary>
        /// <param name = "controlHandle">The target controls handle.</param>
        /// <returns>
        ///     list containing all items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static ArrayList TabsGet(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection aec = SelectionItemPatternHelper.GetListItems(control);
                return InternalUtilities.AutomationCollToArrayList(aec);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Gets a collection of all items in the list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     list containing all items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static List<object> TabsGet(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetItemsBridge(null, control);
        }

        /// <summary>
        ///     Determines whether the specified index is selected.
        /// </summary>
        /// <param name = "controlHandle">The control handle.</param>
        /// <param name = "index">The zero-based index of the tab to select.</param>
        /// <returns>
        ///     <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                bool ret = SelectionItemPatternHelper.SelectItem(SelectionItemPatternHelper.FindItemByIndex(control, index));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Determines whether the specified item text is selected.
        /// </summary>
        /// <param name = "controlHandle">The control handle.</param>
        /// <param name = "itemText">The item text.</param>
        /// <returns>
        ///     <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                bool ret = SelectionPatternHelper.GetSelection(control) (SelectionItemPatternHelper.FindItemByText(control, itemText));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Determines whether the specified index is selected.
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "index">The zero-based index of the tab to verify.</param>
        /// <returns>
        ///     <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(ProdWindow prodwindow, string automationId, int index)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.IsItemSelectedBridge(null, control,index);
        }

        /// <summary>
        ///     Determines whether the specified item text is selected.
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "itemText">The item text that identifies the tab.</param>
        /// <returns>
        ///     <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(ProdWindow prodwindow, string automationId, string itemText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.IsItemSelectedBridge(null, control, itemText);
        }

        /// <summary>
        ///     Gets the number of child tabs contained in the tab control
        /// </summary>
        /// <param name = "controlHandle">The target controls handle.</param>
        /// <returns>
        ///     The number of tabs in a TabControl
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static int TabGetCount(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                int retVal = SelectionItemPatternHelper.GetListItemCount(control);

                if (retVal == -1)
                {
                    ProdTabNative.GetTabCount(controlHandle);
                }
                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Gets the number of child tabs contained in the tab control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     The number of tabs contained in a TabControl
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static int TabGetCount(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetItemCountBridge(null, control);
        }

        /// <summary>
        ///     Retrieves the selected tab
        /// </summary>
        /// <param name = "controlHandle">The target controls handle.</param>
        /// <returns>
        ///     Selected TabItem
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static AutomationElement TabGetSelected(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control);
                return retVal[0];
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Retrieves the selected tab
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     Selected TabItem
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static object TabGetSelected(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetSelectedItemBridge(null, control);
        }

        /// <summary>
        ///     Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "controlHandle">The target controls handle.</param>
        /// <param name = "index">The zero based index of the TabItem</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection aec = SelectionItemPatternHelper.GetListItems(control);

                /* When using the GetListItems() methods, item index 0 is the tab control itself, so add on to get to correct TabItem */
                int adjustedIndex = index + 1;
                string itemText = aec[adjustedIndex].Current.Name;

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);
                SelectionItemPatternHelper.SelectItem(SelectionItemPatternHelper.FindItemByText(control, itemText));

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));              
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdTabNative.SetSelectedTab(controlHandle, index);
            }
        }

        /// <summary>
        ///     Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "controlHandle">The target controls handle.</param>
        /// <param name = "itemText">The TabItem text</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);
                SelectionItemPatternHelper.SelectItem(SelectionItemPatternHelper.FindItemByText(control, itemText));

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "index">The zero based index of the TabItem</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(ProdWindow prodwindow, string automationId, int index)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            SingleSelectListBridge.SetSelectedIndexBridge(null, control, index);
        }

        /// <summary>
        ///     Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "itemText">The TabItem text</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(ProdWindow prodwindow, string automationId, string itemText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            SingleSelectListBridge.SetSelectedItemBridge(null, control, itemText);
        }
    }
}