using System;
using System.Windows.Automation;
using ProdUI.Logging;

namespace ProdUI.Interaction.Native
{
    internal static class NativeInvokeHelper
    {
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
            //if (type == ControlType.Button) NativeMethods.SendMessage(hWnd, (int)ButtonMessage.BMCLICK, 0, 0);
            //if (type == ControlType.HeaderItem)
            //    if (type == ControlType.Hyperlink)
            //        if(type == ControlType.ListItem)
            //            if(type == ControlType.MenuItem)
            //                if(type == ControlType.SplitButton)
            //                    if(type == ControlType.TreeItem)
        }
    }
}
