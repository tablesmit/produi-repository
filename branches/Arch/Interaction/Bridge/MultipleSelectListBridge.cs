using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class MultipleSelectListBridge
    {
        /// <summary>
        /// Adds the selected list item to the current selection.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void AddToSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, int index)
        {
            try
            {
                if (CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

                AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementAddedToSelectionEvent));

                LogController.ReceiveLogMessage(new LogMessage("Adding " + index));
                SelectionPatternHelper.AddToSelection(control.UIAElement, index);
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
        ///     Adds the selected list item to the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void AddToSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, string itemText)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

                AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementAddedToSelectionEvent));

                LogController.ReceiveLogMessage(new LogMessage("Adding " + itemText));
                SelectionPatternHelper.AddToSelection(control.UIAElement, itemText);
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
        ///     Gets the selected indexes.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     An ArrayList of all the indexes of currently selected list items.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static List<object> GetSelectedIndexesBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
                List<object> retList = new List<object> {
                                                        (selectedItems)
                                                        };
                LogController.ReceiveLogMessage(new LogMessage("Selected Indexes", retList));
                return retList;
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
        ///     Gets the selected items.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     A List of all currently selected list items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static List<object> GetSelectedItemsBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
                List<object> retList = new List<object> {
                                                        selectedItems
                                                    };
                LogController.ReceiveLogMessage(new LogMessage("Selected Items", retList));
                return retList;
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
        ///     Gets the selected item count.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     The count of selected items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static int GetSelectedItemCountBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
                LogController.ReceiveLogMessage(new LogMessage("Count: " + selectedItems.Length));
                return selectedItems.Length;
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
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "index">The index of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void RemoveFromSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, int index)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control.UIAElement, index);
                AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));

                LogController.ReceiveLogMessage(new LogMessage("Removing " + index));
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);
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
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "itemText">The text of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void RemoveFromSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, string itemText)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control.UIAElement, itemText);
                AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));

                LogController.ReceiveLogMessage(new LogMessage("Removing " + itemText));
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);
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
        ///     Selects all items in a ListBox.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SelectAllBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

                foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(control.UIAElement))
                {
                    SelectionPatternHelper.AddToSelection(control.UIAElement, item.Current.Name);
                }
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
        /// Sets the select indexes from a supplied list.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="indexes">The indexes to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void SetSelectIndexesBridge(this IMultipleSelectionList theInterface, BaseProdControl control, Collection<int> indexes)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
                List<object> logList = new List<object>  {
                                                        indexes
                                                        };
                LogController.ReceiveLogMessage(new LogMessage("Adding", logList));
                foreach (int index in indexes)
                {
                    SelectionPatternHelper.AddToSelection(control.UIAElement, index);
                }
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
        /// Sets the selected items from a supplied list.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="items">The text of the items to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void SetSelectedItemsBridge(this IMultipleSelectionList theInterface, BaseProdControl control, Collection<string> items)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
                List<object> logList = new List<object>  {
                                                        items
                                                        };
                LogController.ReceiveLogMessage(new LogMessage("Adding", logList));
                foreach (string item in items)
                {
                    SelectionPatternHelper.AddToSelection(control.UIAElement, item);
                }
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

        private static bool CanSelectMultiple(AutomationElement uiaElement)
        {
            return SelectionPatternHelper.CanSelectMultiple(uiaElement);
        }
    }
}