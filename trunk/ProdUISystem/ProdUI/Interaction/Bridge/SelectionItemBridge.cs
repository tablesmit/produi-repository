using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    class SelectionItemBridge
    {
        /// <summary>
        /// Gets a value indicating if a RadioButton is selected
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        ///   <c>true</c> if selected, <c>false</c> otherwise
        /// </returns>
        internal static bool GetIsSelectedBridge(this SelectionAdapter extension, BaseProdControl control)
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
            //catch (InvalidOperationException)
            //{
            //    if (control.UIAElement.Current.ControlType != ControlType.RadioButton) throw new ProdOperationException("This method only works with selectable RadioButtons");
            //    return NativeGetIsSelected(control);
            //}
        }

        //note Native
        //private static bool NativeGetIsSelected(BaseProdControl control)
        //{
        //    return ProdRadioButtonNative.GetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        //}

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
        internal static void SetIsSelectedBridge(this SelectionAdapter extension, BaseProdControl control)
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
            //catch (InvalidOperationException)
            //{
            //    if (control.UIAElement.Current.ControlType != ControlType.RadioButton) throw new ProdOperationException("This method only works with selectable RadioButtons");
            //    NativeSetSelected(control);
            //}
        }

        //note Native
        //private static void NativeSetSelected(BaseProdControl control)
        //{
        //    ProdRadioButtonNative.SetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        //}

        private static void UiaSetSelected(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            SelectionItemPatternHelper.SelectItem(control.UIAElement);
        }
    }
}
