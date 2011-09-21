// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
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

    internal static class InvokeBridge
    {
        private const string CLICK_MSG = @"Performing Click on ";
        private const string NATIVE_CLICK_MSG = @"Performing Click with SendMessage";

        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void ClickBridge(this IInvoke theInvoke, BaseProdControl control)
        {
            try
            {
                /* Try UIA First */
                UiaInvoke(control);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeInvoke(control.UIAElement);
            }
        }

        private static void UiaInvoke(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            LogController.ReceiveLogMessage(new LogMessage(CLICK_MSG + control.UIAElement.Current.Name));
            
            InvokePatternHelper.Invoke(control.UIAElement);
        }

        private static void NativeInvoke(AutomationElement control)
        {
            int hWnd = control.Current.NativeWindowHandle;

            if (control.Current.ControlType == ControlType.Button)
            {
                LogController.ReceiveLogMessage(new LogMessage(NATIVE_CLICK_MSG));
                /* should throw with no handle */
                ProdButtonNative.Click((IntPtr)hWnd);
            }
        }
    }
}