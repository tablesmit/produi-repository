// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class MultipleSelectListBridge
    {
        /// <summary>
        /// Adds the list item to the current selection.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        internal static void AddToSelectionBridge(this IMultipleSelectionList extension, BaseProdControl control, int index)
        {
            try
            {
                UiaAddToSelection(control, index);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeAddToSelection(control, index);
            }
        }

        /// <summary>
        /// Adds the list item to the current selection using UIA
        /// </summary>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">Zero based index of the item.</param>
        private static void UiaAddToSelection(BaseProdControl control, int index)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementAddedToSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Adding " + index));
            SelectionItemPatternHelper.AddToSelection(control.UIAElement, index);
        }

        /// <summary>
        /// Adds the list item to the current selection using SendMessage
        /// </summary>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">Zero based index of the item.</param>
        private static void NativeAddToSelection(BaseProdControl control, int index)
        {
            ProdListBoxNative.AddSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
        }

        /// <summary>
        /// Adds the list item to the current selection.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        internal static void AddToSelectionBridge(this IMultipleSelectionList extension, BaseProdControl control, string itemText)
        {
            try
            {
                UiaAddToSelection(control, itemText);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeAddToSelection(control, itemText);
            }
        }

        /// <summary>
        /// Adds the list item to the current selection using UIA
        /// </summary>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        private static void UiaAddToSelection(BaseProdControl control, string itemText)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementAddedToSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Adding " + itemText));
            SelectionItemPatternHelper.AddToSelection(control.UIAElement, itemText);
        }

        /// <summary>
        /// Adds the list item to the current selection using SendMessage
        /// </summary>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        private static void NativeAddToSelection(BaseProdControl control, string itemText)
        {
            ProdListBoxNative.AddSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
        }

        /// <summary>
        /// Gets the selected indexes.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// A List of all the indexes of currently selected list items.
        /// </returns>
        internal static List<int> GetSelectedIndexesBridge(this IMultipleSelectionList extension, BaseProdControl control)
        {
            try
            {
                return UiaGetSelectedIndexes(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetSelectedIndexes(control);
            }
        }

        /// <summary>
        /// Gets the selected indexes using UIA
        /// </summary>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        /// A List of all the indexes of currently selected list items.
        /// </returns>
        private static List<int> UiaGetSelectedIndexes(BaseProdControl control)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");

            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            List<object> retList = new List<object> {
                                                        (selectedItems)
                                                    };
            List<int> selectedIndexes = new List<int>();

            foreach (AutomationElement item in selectedItems)
            {
                selectedIndexes.Add(SelectionItemPatternHelper.FindIndexByItem(control.UIAElement, item.Current.Name));
            }
            LogController.ReceiveLogMessage(new LogMessage("Selected Indexes", retList));
            return selectedIndexes;
        }

        /// <summary>
        /// Gets the selected indexes using SendMessage
        /// </summary>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        /// A List of all the indexes of currently selected list items.
        /// </returns>
        private static List<int> NativeGetSelectedIndexes(BaseProdControl control)
        {
            return ProdListBoxNative.GetSelectedIndexesNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        /// <summary>
        /// Gets the selected items.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        /// A List of all currently selected list items
        /// </returns>
        internal static List<object> GetSelectedItemsBridge(this IMultipleSelectionList extension, BaseProdControl control)
        {
            try
            {
                return UiaGetSelectedItems(control);
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

        private static List<object> UiaGetSelectedItems(BaseProdControl control)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            List<object> retList = new List<object> {
                                                        selectedItems
                                                    };
            LogController.ReceiveLogMessage(new LogMessage("Selected Items", retList));
            return retList;
        }

        /// <summary>
        /// Gets the selected item count.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// The count of selected items
        /// </returns>
        internal static int GetSelectedItemCountBridge(this IMultipleSelectionList extension, BaseProdControl control)
        {
            try
            {
                return UiaGetSelectedItemCount(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetSelectedItemCount(control);
            }
        }

        private static int NativeGetSelectedItemCount(BaseProdControl control)
        {
            return ProdListBoxNative.GetSelectedItemCountNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static int UiaGetSelectedItemCount(BaseProdControl control)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage("Count: " + selectedItems.Length));
            return selectedItems.Length;
        }

        /// <summary>
        /// Removes the selected list item from the current selection.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">The index of the item to deselect.</param>
        internal static void RemoveFromSelectionBridge(this IMultipleSelectionList extension, BaseProdControl control, int index)
        {
            try
            {
                UiaRemoveFromSelection(control, index);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeRemoveFromSelection(control, index);
            }
        }

        private static void NativeRemoveFromSelection(BaseProdControl control, int index)
        {
            ProdListBoxNative.DeSelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
        }

        private static void UiaRemoveFromSelection(BaseProdControl control, int index)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement itemToSelect = SelectionItemPatternHelper.FindItemByIndex(control.UIAElement, index);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Removing " + index));
            SelectionItemPatternHelper.RemoveFromSelection(itemToSelect);
        }

        /// <summary>
        /// Removes the selected list item from the current selection.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="itemText">The text of the item to deselect.</param>
        internal static void RemoveFromSelectionBridge(this IMultipleSelectionList extension, BaseProdControl control, string itemText)
        {
            try
            {
                UiaRemoveFromSelection(control, itemText);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeRemoveFromSelection(control, itemText);
            }
        }

        private static void NativeRemoveFromSelection(BaseProdControl control, string itemText)
        {
            ProdListBoxNative.DeSelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
        }

        private static void UiaRemoveFromSelection(BaseProdControl control, string itemText)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement itemToSelect = SelectionItemPatternHelper.FindItemByText(control.UIAElement, itemText);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Removing " + itemText));
            SelectionItemPatternHelper.RemoveFromSelection(itemToSelect);
        }

        /// <summary>
        /// Selects all items in a ListBox.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        internal static void SelectAllBridge(this IMultipleSelectionList extension, BaseProdControl control)
        {
            try
            {
                UiaSelectAll(control);
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
                //TODO: Finish native
                throw new ProdOperationException(err);
            }
        }

        private static void NativeSelectAll(BaseProdControl control)
        {
            ProdListBoxNative.SelectAll((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static void UiaSelectAll(BaseProdControl control)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");

            foreach (AutomationElement item in SelectionItemPatternHelper.GetListItems(control.UIAElement))
            {
                SelectionItemPatternHelper.AddToSelection(control.UIAElement, item.Current.Name);
            }
        }

        /// <summary>
        /// Sets the select indexes from a supplied list.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="indexes">The indexes to select.</param>
        internal static void SetSelectedIndexesBridge(this IMultipleSelectionList extension, BaseProdControl control, List<int> indexes)
        {
            try
            {
                UiaSetSelectedIndexes(control, indexes);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeSetSelectedIndexes(control, indexes);
            }
        }

        private static void UiaSetSelectedIndexes(BaseProdControl control, IEnumerable<int> indexes)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            List<object> logList = new List<object> {
                                                        indexes
                                                    };
            LogController.ReceiveLogMessage(new LogMessage("Adding", logList));
            foreach (int index in indexes)
            {
                SelectionItemPatternHelper.AddToSelection(control.UIAElement, index);
            }
        }

        private static void NativeSetSelectedIndexes(BaseProdControl control, IEnumerable<int> indexes)
        {
            foreach (int index in indexes)
            {
                ProdListBoxNative.SetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
            }
        }

        /// <summary>
        /// Sets the selected items from a supplied list.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="items">The text of the items to select.</param>
        internal static void SetSelectedItemsBridge(this IMultipleSelectionList extension, BaseProdControl control, Collection<string> items)
        {
            try
            {
                UiaSetSelectedItems(control, items);
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
                //Todo: finish native
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///     Uias the set selected item.
        /// </summary>
        /// <param name = "control">The base ProdUI control.</param>
        /// <param name = "items">The items.</param>
        private static void UiaSetSelectedItems(BaseProdControl control, IEnumerable<string> items)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            List<object> logList = new List<object> {
                                                        items
                                                    };
            LogController.ReceiveLogMessage(new LogMessage("Adding", logList));
            foreach (string item in items)
            {
                SelectionItemPatternHelper.AddToSelection(control.UIAElement, item);
            }
        }

        internal static bool CanSelectMultipleBridge(this IMultipleSelectionList extension, BaseProdControl control)
        {
            return UiaCanSelectMultiple(control);
        }

        private static bool UiaCanSelectMultiple(BaseProdControl control)
        {
            return SelectionPatternHelper.CanSelectMultiple(control.UIAElement);
        }
    }
}