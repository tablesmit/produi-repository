// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using ProdUI.Utility;
using ProdUI.Logging;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    /// Methods to work with Button controls using the UI Automation framework
    /// </summary>
    /// <remarks>
    /// Uses InvokeBridge
    /// </remarks>
    internal sealed class ProdButtonNative
    {
        /// <summary>
        ///     Uses SendMessage to click the button
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to the button to send message to</param>
        internal static void Click(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)ButtonMessage.BMCLICK, 0, 0); 
        }
    }
}