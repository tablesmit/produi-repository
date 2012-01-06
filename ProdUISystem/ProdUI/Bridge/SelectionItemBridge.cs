using System;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Bridge
{
    class SelectionItemBridge
    {

#region Required

		        /// <summary>
        /// Gets a value that indicates whether an item is selected.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        ///   <c>true</c> if selected, <c>false</c> otherwise
        /// </returns>
        public static bool IsSelectedHook(this SelectionItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetIsSelected(control);
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
                if (control.UIAElement.Current.ControlType != ControlType.RadioButton) throw new ProdOperationException("This method only works with selectable RadioButtons");
                return NativeGetIsSelected(control);
            }
        }

        private static bool NativeGetIsSelected(BaseProdControl control)
        {
            return ProdRadioButtonNative.GetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static bool UiaGetIsSelected(BaseProdControl control)
        {
            bool retVal = SelectionItemPatternHelper.IsItemSelected(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }



        /// <summary>
        /// Adds the list item to the current selection.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        public static void AddToSelectionHook(this SelectionItemAdapter extension, BaseProdControl control, int index)
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
            SelectionItemPatternHelper.AddToSelection(control.UIAElement);
        }

        /// <summary>
        /// Adds the list item to the current selection using SendMessage
        /// </summary>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">Zero based index of the item.</param>
        private static void NativeAddToSelection(BaseProdControl control, int index)
        {
            //NOTE: ProdListBoxNative.AddSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
        }

        /// <summary>
        /// Adds the list item to the current selection.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="text">The text of the item to select.</param>
        public static void AddToSelectionHook(this SelectionItemAdapter extension, BaseProdControl control, string text)
        {
            try
            {
                UiaAddToSelection(control, text);
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
                NativeAddToSelection(control, text);
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
            SelectionItemPatternHelper.AddToSelection(control.UIAElement);
        }

        /// <summary>
        /// Adds the list item to the current selection using SendMessage
        /// </summary>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        private static void NativeAddToSelection(BaseProdControl control, string itemText)
        {
            //NOTE: ProdListBoxNative.AddSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
        }



        /// <summary>
        /// Removes the current element from the collection of selected items.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="index">The index of the item to deselect.</param>
        public static void RemoveFromSelectionHook(this SelectionItemAdapter extension, BaseProdControl control, int index)
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
        /// Removes the current element from the collection of selected items.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="text">The text of the item to deselect.</param>
        public static void RemoveFromSelectionHook(this SelectionItemAdapter extension, BaseProdControl control, string text)
        {
            try
            {
                UiaRemoveFromSelection(control, text);
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
                NativeRemoveFromSelection(control, text);
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
        /// Gets the AutomationElement that supports the SelectionPattern control pattern and acts as the container for the calling object.
        /// </summary>
        public static AutomationElement SelectionContainer(this SelectionItemAdapter extension, BaseProdControl control) {throw new NotImplementedException() };


        /// <summary>
        /// Deselects any selected items and then selects the current element
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        internal static void SelectHook(this SelectionItemAdapter extension, BaseProdControl control, int index)
        {
            try
            {
                UiaSetSelectedIndex(control, index);
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
                NativeSetSelectedIndex(control, index);
            }
        }

        private static void UiaSetSelectedIndex(BaseProdControl control, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Selecting " + index));

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            AutomationElement indexedItem = SelectionItemPatternHelper.FindItemByIndex(control.UIAElement, index);
            SelectionItemPatternHelper.SelectItem(indexedItem);
        }

        private static void NativeSetSelectedIndex(BaseProdControl control, int index)
        {
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                ProdComboBoxNative.SelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);

            ProdListBoxNative.SetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
        }

        /// <summary>
        /// Deselects any selected items and then selects the current element
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">The text of the item to select.</param>
        internal static void SelectHook(this SelectionItemAdapter extension, BaseProdControl control, string text)
        {
            try
            {
                UiaSelectItem(control, text);
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
                NativeSelectItem(control, text);
            }
        }

        private static void UiaSelectItem(BaseProdControl control, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Selecting " + itemText));

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            AutomationElement element = SelectionItemPatternHelper.FindItemByText(control.UIAElement, itemText);
            SelectionItemPatternHelper.SelectItem(element);
        }

        private static void NativeSelectItem(BaseProdControl control, string itemText)
        {
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                ProdComboBoxNative.SelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);

            ProdListBoxNative.SelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
        } 

	#endregion


         /// <summary>
        /// Gets the list items.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns></returns>
        public static Collection<object> GetItemsHook(this SelectionItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetItems(control);
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
                return NativeGetItems(control);
            }
        }

        private static Collection<object> UiaGetItems(BaseProdControl control)
        {
            AutomationElementCollection convRet = SelectionItemPatternHelper.GetListItems(control.UIAElement);

            Collection<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);
            LogController.ReceiveLogMessage(new LogMessage("List Items: ", retVal));
            return retVal;
        }

        /// <summary>
        /// Natives the get items.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        private static Collection<object> NativeGetItems(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                return ProdComboBoxNative.GetItemsNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return ProdListBoxNative.GetItemsNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }


        /// <summary>
        /// Gets the selected indexes.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// A List of all the indexes of currently selected list items.
        /// </returns>
        public static Collection<int> GetSelectedIndexesHook(this SelectionItemAdapter extension, BaseProdControl control)
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
        private static Collection<int> UiaGetSelectedIndexes(BaseProdControl control)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");

            AutomationElement[] selectedItems = SelectionPatternHelper.SelectedItems(control.UIAElement);
            Collection<object> retList = new Collection<object> {
                                                        (selectedItems)
                                                    };
            Collection<int> selectedIndexes = new Collection<int>();

            foreach (AutomationElement item in selectedItems)
            {
                //NOTE: ADD selectedIndexes.Add(SelectionItemPatternHelper.FindIndexByItem(control.UIAElement, item.Current.Name));
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
        private static Collection<int> NativeGetSelectedIndexes(BaseProdControl control)
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
        public static Collection<string> GetSelectedItemsHook(this SelectionItemAdapter extension, BaseProdControl control)
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

        private static Collection<string> UiaGetSelectedItems(BaseProdControl control)
        {
            if (!UiaCanSelectMultiple(control)) throw new ProdOperationException("Does not support multiple selection");
            AutomationElement[] selectedItems = SelectionPatternHelper.SelectedItems(control.UIAElement);
            Collection<string> retList = new Collection<string>();
            foreach (AutomationElement item in selectedItems)
            {
                retList.Add(item.Current.Name);
            }

            LogController.ReceiveLogMessage(new LogMessage("Selected Items", new Collection<object>(selectedItems)));
            return retList;
        }

        /// <summary>
        /// Selects all items in a ListBox.
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        internal static void SelectAllHook(this SelectionItemAdapter extension, BaseProdControl control)
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
                NativeSelectAll(control);
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


        public static bool CanSelectMultipleHook(this SelectionItemAdapter extension, BaseProdControl control)
        {
            return UiaCanSelectMultiple(control);
        }

        private static bool UiaCanSelectMultiple(BaseProdControl control)
        {
            return SelectionPatternHelper.CanSelectMultiple(control.UIAElement);
        }
    }
}
