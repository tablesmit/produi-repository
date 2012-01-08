// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Bridge
{
    /// <summary>
    /// Provides access to controls that support the TogglePattern
    /// </summary>
    public static class ToggleBridge
    {
        /// <summary>
        /// Gets the current <see cref="ToggleState"/>.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>The current <see cref="ToggleState"/></returns>
        public static ToggleState GetToggleStateHook(this ToggleAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetToggleState(control);
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
                return NativeGetToggleState(control);
            }
        }

        private static ToggleState UiaGetToggleState(BaseProdControl control)
        {
            ToggleState ret = TogglePatternHelper.GetToggleState(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(ret.ToString()));
            return ret;
        }

        internal static ToggleState NativeGetToggleState(BaseProdControl control)
        {
            return ProdCheckBoxNative.GetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        /// <summary>
        /// Sets the <see cref="ToggleState"/>.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="checkstate">The <see cref="ToggleState"/>.</param>
        public static void SetToggleStateHook(this ToggleAdapter extension, BaseProdControl control, ToggleState checkstate)
        {
            try
            {
                UiaSetToggleState(control, checkstate);
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
                NativeSetToggleState(control, checkstate);
            }
        }

        private static void UiaSetToggleState(BaseProdControl control, ToggleState checkstate)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, TogglePatternIdentifiers.ToggleStateProperty));
            LogController.ReceiveLogMessage(new LogMessage(checkstate.ToString()));
            TogglePatternHelper.SetToggleState(control.UIAElement, checkstate);
        }

        private static void NativeSetToggleState(BaseProdControl control, ToggleState checkstate)
        {
            //note ProdCheckBoxNative.SetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, checkstate);
        }

        /// <summary>
        /// Toggles the check state.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <remarks>
        /// A control will cycle through its ToggleState in this order: On, Off and, if supported, Indeterminate.
        /// </remarks>
        public static void ToggleStateHook(this ToggleAdapter extension, BaseProdControl control)
        {
            try
            {
                UiaToggleState(control);
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
                NativeToggleState(control);
            }
        }

        private static void UiaToggleState(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, TogglePatternIdentifiers.ToggleStateProperty));
            LogController.ReceiveLogMessage(new LogMessage("Toggle"));
            TogglePatternHelper.Toggle(control.UIAElement);
        }

        internal static void NativeToggleState(BaseProdControl control)
        {
            ProdCheckBoxNative.ToggleCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }
    }
}