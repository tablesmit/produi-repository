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
            /* Try UIA First */
            UiaInvoke(control);

            /* now try a native SendMessage */
            NativeInvoke(control);
        }

        private static void UiaInvoke(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, InvokePattern.InvokedEvent));
            InvokePatternHelper.Invoke(control.UIAElement);
        }

        private static void NativeInvoke(BaseProdControl control)
        {
            AutomationElement element = control.UIAElement;

            int hWnd = element.Current.NativeWindowHandle;
            if (hWnd == 0) throw new ProdOperationException("Unable to use native method");

            if (element.Current.ControlType == ControlType.Button)
            {
                ProdButtonNative.Click((IntPtr)hWnd);
            }
        }
    }
}