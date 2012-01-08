using System;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Logging;

namespace ProdUI.Bridge.NativePatterns
{
    internal static class NativeInvokeHelper
    {
        /// <summary>
        /// Sends a message to the message window and waits until the WndProc method has processed the message
        /// </summary>
        /// <param name="windowHandle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="msg">The message constant to pass.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>
        /// The return value specifies the result of the message processing; it depends on the message sent
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.SysInt)] int msg, [MarshalAs(UnmanagedType.SysInt)] int wParam, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        /// <summary>
        /// Invokes the specified control.
        /// </summary>
        /// <param name="control">The control to send a message to.</param>
        /// <remarks>Mimics controls that implement the IInvoke interface in UIA</remarks>
        internal static void Invoke(BaseProdControl control)
        {
            IntPtr hWnd = (IntPtr)control.UIAElement.Current.NativeWindowHandle;
            ControlType type = control.UIAElement.Current.ControlType;
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            if (type == ControlType.Button) SendMessage(hWnd, (int)ButtonMessages.BM_CLICK, 0, 0);
            //if (type == ControlType.HeaderItem)
            //    if (type == ControlType.Hyperlink)
            //        if(type == ControlType.ListItem)
            //            if(type == ControlType.MenuItem)
            //                if(type == ControlType.SplitButton)
            //                    if(type == ControlType.TreeItem)
        }
    }
}