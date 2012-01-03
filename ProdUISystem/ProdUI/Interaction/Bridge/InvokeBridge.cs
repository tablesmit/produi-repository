// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class InvokeBridge
    {
        private const string CLICK_MSG = @"Performing Click";

        /// <summary>
        /// Handles The extended interface. event
        /// </summary>
        /// <param name="extension">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        internal static void ClickBridge(this InvokeAdapter extension, BaseProdControl control)
        {
            try
            {
                /* Try UIA First */
                UiaInvoke(control);
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
                /* now try a native SendMessage */
                NativeInvoke(control);
            }
        }

        /// <summary>
        /// Handles the UIA version of The extended interface. event
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        private static void UiaInvoke(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(CLICK_MSG + control.UIAElement.Current.Name));

            InvokePatternHelper.Invoke(control.UIAElement);
        }

        /// <summary>
        /// Send the BM_Click message to a button control
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        private static void NativeInvoke(BaseProdControl control)
        {
            int hWnd = control.UIAElement.Current.NativeWindowHandle;

            if (control.UIAElement.Current.ControlType != ControlType.Button) return;

            /* should throw with no handle */
            NativeInvokeHelper.Invoke(control);
        }
    }
}