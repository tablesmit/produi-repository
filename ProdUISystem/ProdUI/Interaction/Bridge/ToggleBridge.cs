// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Native;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class ToggleBridge
    {
        /// <summary>
        /// Gets the check state.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>The current <see cref="ToggleState"/></returns>
        internal static ToggleState GetCheckStateBridge(this IToggle extension, BaseProdControl control)
        {
            try
            {
                return UiaGetCheckState(control);
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
                return NativeGetCheckState(control);
            }
        }

        internal static ToggleState UiaGetCheckState(BaseProdControl control)
        {
            ToggleState ret = TogglePatternHelper.GetToggleState(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(ret.ToString()));
            return ret;
        }

        internal static ToggleState NativeGetCheckState(BaseProdControl control)
        {
            return ProdCheckBoxNative.GetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        /// <summary>
        /// Sets the check state.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="checkstate">The <see cref="ToggleState"/>.</param>
        internal static void SetCheckStateBridge(this IToggle extension, BaseProdControl control, ToggleState checkstate)
        {
            try
            {
                UiaSetCheckState(control, checkstate);
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
                NativeSetCheckState(control, checkstate);
            }
        }

        private static void UiaSetCheckState(BaseProdControl control, ToggleState checkstate)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, TogglePatternIdentifiers.ToggleStateProperty));
            LogController.ReceiveLogMessage(new LogMessage(checkstate.ToString()));
            TogglePatternHelper.SetToggleState(control.UIAElement, checkstate);
        }

        private static void NativeSetCheckState(BaseProdControl control, ToggleState checkstate)
        {
            ProdCheckBoxNative.SetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, checkstate);
        }

        /// <summary>
        /// Toggles the check state.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        internal static void ToggleCheckStateBridge(this IToggle extension, BaseProdControl control)
        {
            try
            {
                UiaToggleCheckState(control);
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
                NativeToggleCheckState(control);
            }
        }

        internal static void UiaToggleCheckState(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, TogglePatternIdentifiers.ToggleStateProperty));
            LogController.ReceiveLogMessage(new LogMessage("Toggle"));
            TogglePatternHelper.Toggle(control.UIAElement);
        }

        internal static void NativeToggleCheckState(BaseProdControl control)
        {
            ProdCheckBoxNative.ToggleCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }
    }
}