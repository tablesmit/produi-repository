using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.Native;
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

        private static void UiaAddToSelection(BaseProdControl control, int index)
        {
            if (CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementAddedToSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Adding " + index));
            SelectionPatternHelper.AddToSelection(control.UIAElement, index);
        }

        private static void NativeAddToSelection(BaseProdControl control, int index)
        {
            ProdListBoxNative.AddSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
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

        private static void UiaAddToSelection(BaseProdControl control, string itemText)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementAddedToSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Adding " + itemText));
            SelectionPatternHelper.AddToSelection(control.UIAElement, itemText);
        }

        private static void NativeAddToSelection(BaseProdControl control, string itemText)
        {
            ProdListBoxNative.AddSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
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
        internal static List<int> GetSelectedIndexesBridge(this IMultipleSelectionList theInterface, BaseProdControl control)
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

        private static List<int> UiaGetSelectedIndexes(BaseProdControl control)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            List<object> retList = new List<object> {
                                                        (selectedItems)
                                                    };
            List<int> selectedIndexes = new List<int>();

            foreach (AutomationElement item in selectedItems)
            {
                selectedIndexes.Add(SelectionPatternHelper.FindIndexByItem(control.UIAElement, item.Current.Name));
            }
            LogController.ReceiveLogMessage(new LogMessage("Selected Indexes", retList));
            return selectedIndexes;
        }

        private static List<int> NativeGetSelectedIndexes(BaseProdControl control)
        {
            return ProdListBoxNative.GetSelectedIndexesNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
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
            catch (InvalidOperationException)
            {
                //TODO implement native
                NativeGetSelectedItems(control);
            }
        }

        private static List<object> UiaGetSelectedItems(BaseProdControl control)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            List<object> retList = new List<object> {
                                                        selectedItems
                                                    };
            LogController.ReceiveLogMessage(new LogMessage("Selected Items", retList));
            return retList;
        }

        private static List<object> NativeGetSelectedItems(BaseProdControl control)
        {
            throw new NotImplementedException();
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
            catch (InvalidOperationException )
            {
                return NativeGetSelectedItemCount(control);
            }
        }

        private static int NativeGetSelectedItemCount(BaseProdControl control)
        {
            return ProdListBoxNative.GetSelectedItemCountNative((IntPtr) control.UIAElement.Current.NativeWindowHandle);
        }

        private static int UiaGetSelectedItemCount(BaseProdControl control)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage("Count: " + selectedItems.Length));
            return selectedItems.Length;
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
            ProdListBoxNative.DeSelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle,index);
        }

        private static void UiaRemoveFromSelection(BaseProdControl control, int index)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control.UIAElement, index);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Removing " + index));
            SelectionPatternHelper.RemoveFromSelection(itemToSelect);
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
            ProdListBoxNative.DeSelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle,itemText);
        }

        private static void UiaRemoveFromSelection(BaseProdControl control, string itemText)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control.UIAElement, itemText);
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementRemovedFromSelectionEvent));

            LogController.ReceiveLogMessage(new LogMessage("Removing " + itemText));
            SelectionPatternHelper.RemoveFromSelection(itemToSelect);
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
            catch (InvalidOperationException)
            {
                //TODO: Finish native
                NativeSelectAll(control);
            }
        }

        private static void UiaSelectAll(BaseProdControl control)
        {
            if (!CanSelectMultiple(control.UIAElement)) throw new ProdOperationException("Does not support multiple selection");

            foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(control.UIAElement))
            {
                SelectionPatternHelper.AddToSelection(control.UIAElement, item.Current.Name);
            }
        }

        private static void NativeSelectAll(BaseProdControl control)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sets the select indexes from a supplied list.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="indexes">The indexes to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void SetSelectedIndexesBridge(this IMultipleSelectionList theInterface, BaseProdControl control, List<int> indexes)
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
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="items">The text of the items to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void SetSelectedItemsBridge(this IMultipleSelectionList theInterface, BaseProdControl control, Collection<string> items)
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
                NativeSetSelectedItems(control, items);
            }
        }

        /// <summary>
        /// Uias the set selected item.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="items">The items.</param>
        private static void UiaSetSelectedItems(BaseProdControl control, IEnumerable<string> items)
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

        private static void NativeSetSelectedItems(BaseProdControl control, IEnumerable<string> items)
        {
            throw new NotImplementedException();
        }



        private static bool CanSelectMultiple(AutomationElement uiaElement)
        {
            return SelectionPatternHelper.CanSelectMultiple(uiaElement);
        }
    }
}