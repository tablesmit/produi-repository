// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class MultipleSelectListBridge
    {
        /// <summary>
        ///     Adds the selected list item to the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "index">The zero-based index of the item to select.</param>
        internal static void AddToSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, int index)
        {
            if (CanSelectMultiple(control.UIAElement))
            {
                throw new ProdOperationException("Does not support multiple selection");
            }

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            SelectionPatternHelper.AddToSelection(control.UIAElement, index);
        }

        /// <summary>
        ///     Adds the selected list item to the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "itemText">The text of the item to select.</param>
        internal static void AddToSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, string itemText)
        {
            if (!CanSelectMultiple(control.UIAElement))
            {
                throw new ProdOperationException("Does not support multiple selection");
            }
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            SelectionPatternHelper.AddToSelection(control.UIAElement, itemText);
        }

        /// <summary>
        ///     Gets the selected indexes.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     An ArrayList of all the indexes of currently selected list items.
        /// </returns>
        internal static List<object> GetSelectedIndexesBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            if (!CanSelectMultiple(control.UIAElement))
            {
                throw new ProdOperationException("Does not support multiple selection");
            }
            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            List<object> retList = new List<object> {
                                                        (selectedItems)
                                                    };

            return retList;
        }

        /// <summary>
        ///     Gets the selected items.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     An ArrayList of all currently selected list items
        /// </returns>
        internal static List<object> GetSelectedItemsBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            if (!CanSelectMultiple(control.UIAElement))
            {
                throw new ProdOperationException("Does not allow multiple selection");
            }

            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            List<object> retList = new List<object> {
                                                        selectedItems
                                                    };
            return retList;
        }

        /// <summary>
        ///     Gets the selected item count.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     The count of selected items
        /// </returns>
        internal static int GetSelectedItemCountBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
        {
            try
            {
                if (!CanSelectMultiple(control.UIAElement))
                {
                    throw new ProdOperationException("Does not allow multiple selection");
                }
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
                return selectedItems.Length;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "index">The index of the item to deselect.</param>
        internal static void RemoveFromSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, int index)
        {
            if (!CanSelectMultiple(control.UIAElement))
            {
                throw new ProdOperationException("Does not allow multiple selection");
            }
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control.UIAElement, index);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));
            SelectionPatternHelper.RemoveFromSelection(itemToSelect);
        }

        /// <summary>
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "itemText">The text of the item to deselect.</param>
        internal static void RemoveFromSelectionBridge(this IMultipleSelectionList theInterface, BaseProdControl control, string itemText)
        {
            if (!CanSelectMultiple(control.UIAElement))
            {
                throw new ProdOperationException("Does not allow multiple selection");
            }

            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control.UIAElement, itemText);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));
            SelectionPatternHelper.RemoveFromSelection(itemToSelect);
        }

        /// <summary>
        ///     Selects all items in a ListBox.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        internal static void SelectAllBridge(this IMultipleSelectionList theInterface, AutomationElement control)
        {
            try
            {
                if (!CanSelectMultiple(control))
                {
                    throw new ProdOperationException("Does not allow multiple selection");
                }

                foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(control))
                {
                    SelectionPatternHelper.AddToSelection(control, item.Current.Name);
                }
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
        ///     Sets the select indexes from a supplied list.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "indexes">The indexes to select.</param>
        internal static void SetSelectIndexesBridge(this IMultipleSelectionList theInterface, AutomationElement control, Collection<int> indexes)
        {
            if (!CanSelectMultiple(control))
            {
                throw new ProdOperationException("Does not allow multiple selection");
            }

            foreach (int index in indexes)
            {
                SelectionPatternHelper.AddToSelection(control, index);
            }
        }

        /// <summary>
        ///     Sets the selected items from a supplied list.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <param name = "items">The text of the items to select.</param>
        internal static void SetSelectedItemsBridge(this IMultipleSelectionList theInterface, AutomationElement control, Collection<string> items)
        {
            if (!CanSelectMultiple(control))
            {
                throw new ProdOperationException("Does not allow multiple selection");
            }

            foreach (string item in items)
            {
                SelectionPatternHelper.AddToSelection(control, item);
            }
        }

        private static bool CanSelectMultiple(AutomationElement UIAElement)
        {
            return SelectionPatternHelper.CanSelectMultiple(UIAElement);
        }
    }
}