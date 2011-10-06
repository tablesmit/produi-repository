// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    /// <summary>
    /// Handles non-list related items that use the SelectionPatterns
    /// </summary>
    internal static class SelectionBridge
    {
        /// <summary>
        /// Gets a value indicating if a RadioButton is selected
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        ///   <c>true</c> if selected, <c>false</c> otherwise
        /// </returns>
        internal static bool GetIsSelectedBridge(this ISelection extension, BaseProdControl control)
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
        /// Selects a RadioButton
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        internal static void SetIsSelectedBridge(this ISelection extension, BaseProdControl control)
        {
            try
            {
                UiaSetSelected(control);
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
                NativeSetSelected(control);
            }
        }

        private static void NativeSetSelected(BaseProdControl control)
        {
            ProdRadioButtonNative.SetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static void UiaSetSelected(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            SelectionItemPatternHelper.SelectItem(control.UIAElement);
        }
    }
}