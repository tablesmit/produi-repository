/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.ComponentModel;
using ProdUI.Exceptions;
using ProdUI.Session;
using ProdUI.Utility;

namespace ProdUI.Controls.Native
{
    /// <summary>
    ///   Methods to work with Button controls using the UI Automation framework
    /// </summary>
    internal static class ProdButtonNative
    {
        /// <summary>
        ///   Uses SendMessage to click the button
        /// </summary>
        /// <param name = "windowHandle">Handle to the button to send message to</param>
        internal static void Click(IntPtr windowHandle)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) ButtonMessage.BMClick, 0, 0);

                const string logmessage = "Button clicked using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}