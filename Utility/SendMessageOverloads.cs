// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ProdUI.Utility
{
    internal static partial class NativeMethods
    {
        /// <summary>
        ///     Sends a message to the message window and waits until the WndProc method has processed the message
        /// </summary>
        /// <param name = "windowHandle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name = "msg">The message constant to pass.</param>
        /// <param name = "wParam">Additional message-specific information.</param>
        /// <param name = "lParam">Additional message-specific information.</param>
        /// <returns>
        ///     The return value specifies the result of the message processing; it depends on the message sent
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.I4)] int msg, [MarshalAs(UnmanagedType.I4)] int wParam, [MarshalAs(UnmanagedType.I4)] int lParam);

        /// <summary>
        ///     Sends a message to the message window and waits until the WndProc method has processed the message
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window to send message to</param>
        /// <param name = "msg">message to send: WM_SETTEXT</param>
        /// <param name = "wParam">null</param>
        /// <param name = "lParam">A pointer to a null-terminated string that is the window text</param>
        /// <returns>
        ///     The return value is TRUE if the text is set. It is FALSE (for an edit control), LB_ERRSPACE (for a list box), or CB_ERRSPACE (for a combo box) if insufficient space is available to set the text in the edit control
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern int SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.I4)] int msg, [MarshalAs(UnmanagedType.I4)] int wParam, string lParam);

        /// <summary>
        ///     WM_GETTEXT message to move text into a StringBuilder
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window to send message to</param>
        /// <param name = "msg">message to send</param>
        /// <param name = "wParam">The maximum number of characters to be copied, including the terminating null character</param>
        /// <param name = "lParam">A pointer to the buffer that is to receive the text. (StringBuilder)</param>
        /// <returns>
        ///     The return value is the number of characters copied, not including the terminating null character
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern int SendMessage(IntPtr windowHandle, int msg, [MarshalAs(UnmanagedType.I4)] int wParam, StringBuilder lParam);
    }
}