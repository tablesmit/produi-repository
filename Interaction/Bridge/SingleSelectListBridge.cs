using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class SingleSelectListBridge
    {
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static List<object> GetItemsBridge(this ISingleSelectList theInterface, BaseProdControl control)
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
            AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(control.UIAElement);

            List<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);
            LogController.ReceiveLogMessage(new LogMessage("List Items: ", retVal));
            return retVal;
        }

        private static List<object> NativeGetItems(BaseProdControl control)
        {
            return ProdListBoxNative.GetItemsNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }



        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static int GetItemCountBridge(this ISingleSelectList theInterface, BaseProdControl control)
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
            AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage("Items: " + convRet.Count));
            return convRet.Count;
        }

        private static int NativeGetItemCount(BaseProdControl control)
        {
            return ProdListBoxNative.GetItemCountNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }



        /// <summary>
        /// Gets the selected index ex.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static int GetSelectedIndexBridge(this ISingleSelectList theInterface, BaseProdControl control)
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
            int retVal = SelectionPatternHelper.FindIndexByItem(control.UIAElement, element[0].Current.Name);

            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }

        private static int NativeSelectedIndex(BaseProdControl control)
        {
            return ProdListBoxNative.GetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }



        /// <summary>
        /// Gets the selected list item.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <returns>
        /// The selected List element
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static AutomationElement GetSelectedItemBridge(this ISingleSelectList theInterface, BaseProdControl control)
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
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SetSelectedIndexBridge(this ISingleSelectList theInterface, BaseProdControl control, int index)
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
            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(control.UIAElement, index);
            SelectionPatternHelper.Select(indexedItem);
        }

        private static void NativeSetSelectedIndex(BaseProdControl control, int index)
        {
            ProdListBoxNative.SetSelectedIndexNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, index);
        }




        /// <summary>
        /// Sets the selected list item.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SetSelectedItemBridge(this ISingleSelectList theInterface, BaseProdControl control, string itemText)
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
            AutomationElement ae = SelectionPatternHelper.FindItemByText(control.UIAElement, itemText);
            SelectionPatternHelper.Select(ae);
        }

        private static void NativeSetSelectedItem(BaseProdControl control, string itemText)
        {
            ProdListBoxNative.SelectItemNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, itemText);
        }
    }
}