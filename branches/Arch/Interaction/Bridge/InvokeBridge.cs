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
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class InvokeBridge
    {
        internal static void ClickBridge(this IInvoke theInvoke, BaseProdControl control)
        {
            try
            {
                AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
                InvokePatternHelper.Invoke(control.UIAElement);
            }
            catch (InvalidOperationException)
            {
                NativeInvoke(control.UIAElement);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        private static void NativeInvoke(AutomationElement control)
        {
            int hWnd = control.Current.NativeWindowHandle;

            if (hWnd == 0) throw new ProdOperationException("Unable to use native method");
            if (control.Current.ControlType == ControlType.Button)
            {
                ProdButtonNative.Click((IntPtr) hWnd);
            }
        }
    }
}