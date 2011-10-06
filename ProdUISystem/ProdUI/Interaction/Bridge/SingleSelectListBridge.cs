// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class SingleSelectListBridge
    {
        /// <summary>
        /// Gets the list items.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns></returns>
        internal static List<object> GetItemsBridge(this ISingleSelectList extension, BaseProdControl control)
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

        private static List<object> UiaGetItems(BaseProdControl control)
        {
            AutomationElementCollection convRet = SelectionItemPatternHelper.GetListItems(control.UIAElement);

            List<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);
            LogController.ReceiveLogMessage(new LogMessage("List Items: ", retVal));
            return retVal;
        }

        private static List<object> NativeGetItems(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                return ProdComboBoxNative.GetItemsNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return ProdListBoxNative.GetItemsNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        internal static int GetItemCountBridge(this ISingleSelectList extension, BaseProdControl control)
        {
            try
            {
                return UiaGetItemCount(control);
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
                return NativeGetItemCount(control);
            }
        }

        private static int UiaGetItemCount(BaseProdControl control)
        {
            AutomationElementCollection convRet = SelectionItemPatternHelper.GetListItems(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage("Items: " + convRet.Count));
            return convRet.Count;
        }

        private static int NativeGetItemCount(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.Tab)
                return ProdTabNative.GetTabCount((IntPtr)control.UIAElement.Current.NativeWindowHandle);
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                ProdComboBoxNative.GetItemCountNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return ProdListBoxNative.GetItemCountNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        /// <summary>
        /// Gets the selected index ex.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns></returns>
        internal static int GetSelectedIndexBridge(this ISingleSelectList extension, BaseProdControl control)
        {
            try
            {
                return UiaSelectedIndex(control);
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
                return NativeSelectedIndex(control);
            }
        }

        private static int UiaSelectedIndex(BaseProdControl control)
        {
            AutomationElement[] element = SelectionPatternHelper.GetSelection(control.UIAElement);
            int retVal = SelectionItemPatternHelper.FindIndexByItem(control.UIAElement, element[0].Current.Name);

            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }

        private static int NativeSelectedIndex(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                return ProdComboBoxNative.GetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return ProdListBoxNative.GetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        /// <summary>
        /// Gets the selected list item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The selected List element
        /// </returns>
        internal static AutomationElement GetSelectedItemBridge(this ISingleSelectList extension, BaseProdControl control)
        {
            try
            {
                return UiaGetSelectedItem(control);
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
                return NativeGetSelectedItem(control);
            }
        }

        private static AutomationElement UiaGetSelectedItem(BaseProdControl control)
        {
            AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage("Item " + retVal[0]));
            return retVal[0];
        }

        private static AutomationElement NativeGetSelectedItem(BaseProdControl control)
        {
            ProdListBoxNative.GetSelectedItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
            //Note: This can not return an AutomationElement...
            return control.UIAElement;
        }

        /// <summary>
        /// Sets the selected list item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        internal static void SetSelectedIndexBridge(this ISingleSelectList extension, BaseProdControl control, int index)
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
        /// Sets the selected list item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="itemText">The text of the item to select.</param>
        internal static void SetSelectedItemBridge(this ISingleSelectList extension, BaseProdControl control, string itemText)
        {
            try
            {
                UiaSetSelectedItem(control, itemText);
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
                NativeSetSelectedItem(control, itemText);
            }
        }

        private static void UiaSetSelectedItem(BaseProdControl control, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Selecting " + itemText));

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            AutomationElement element = SelectionItemPatternHelper.FindItemByText(control.UIAElement, itemText);
            SelectionItemPatternHelper.SelectItem(element);
        }

        private static void NativeSetSelectedItem(BaseProdControl control, string itemText)
        {
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
                ProdComboBoxNative.SelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);

            ProdListBoxNative.SelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
        }

        internal static bool IsItemSelectedBridge(this ISingleSelectList extension, BaseProdControl control, int index)
        {
            try
            {
                return UiaIsItemSelected(control, index);
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
                return NativeIsItemSelected(control, index);
            }
        }

        private static bool NativeIsItemSelected(BaseProdControl control, int index)
        {
            int selectedIndex;

            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
            {
                selectedIndex = ProdComboBoxNative.GetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
            }
            else
            {
                selectedIndex = ProdTabNative.GetSelectedTab((IntPtr)control.UIAElement.Current.NativeWindowHandle);
            }

            return selectedIndex == index;
        }

        private static bool UiaIsItemSelected(BaseProdControl control, int index)
        {
            AutomationElement element = SelectionItemPatternHelper.FindItemByIndex(control.UIAElement, index);
            bool retVal = SelectionItemPatternHelper.IsItemSelected(element);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        internal static bool IsItemSelectedBridge(this ISingleSelectList extension, BaseProdControl control, string text)
        {
            try
            {
                return UiaIsItemSelected(control, text);
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
                //TODO: No IsItemSelectedBridge native
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        /// Gets selection status of the item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static bool UiaIsItemSelected(BaseProdControl control, string text)
        {
            AutomationElement element = SelectionItemPatternHelper.FindItemByText(control.UIAElement, text);
            bool retVal = SelectionItemPatternHelper.IsItemSelected(element);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }
    }
}