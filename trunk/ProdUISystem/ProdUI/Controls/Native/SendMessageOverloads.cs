// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ProdUI.Controls.Native
{
    internal static partial class NativeMethods
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
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.SysInt)] int msg, [MarshalAs(UnmanagedType.SysInt)] int wParam, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        /// <summary>
        /// Sends a message to the message window and waits until the WndProc method has processed the message
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to window to send message to</param>
        /// <param name="msg">message to send: WM_SETTEXT</param>
        /// <param name="wParam">null</param>
        /// <param name="lParam">A pointer to a null-terminated string that is the window text</param>
        /// <returns>
        /// The return value is TRUE if the text is set. It is FALSE (for an edit control), LB_ERRSPACE (for a list box), or CB_ERRSPACE (for a combo box) if insufficient space is available to set the text in the edit control
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern int SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.SysInt)] int msg, [MarshalAs(UnmanagedType.SysInt)] int wParam, string lParam);

        /// <summary>
        /// LB_SETCURSEL message to move selected indexes into array
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to window to send message to</param>
        /// <param name="msg">message to send</param>
        /// <param name="wParam">The maximum number of selected items whose item numbers are to be placed in the buffer.</param>
        /// <param name="lParam">A pointer to a buffer large enough for the number of integers specified by the wParam parameter</param>
        /// <returns>
        /// The return value is the length of the string
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern int SendMessage(IntPtr windowHandle, int msg, [MarshalAs(UnmanagedType.SysInt)] int wParam, int[] lParam);

        /// <summary>
        /// LB_GETTEXT message
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to window to send message to</param>
        /// <param name="msg">message to send</param>
        /// <param name="wParam">The zero-based index of the string to retrieve</param>
        /// <param name="lParam">A pointer to the buffer that will receive the string</param>
        /// <returns>
        /// The return value is the number of items placed in the buffer. If the list box is a single-selection list box, the return value is LB_ERR
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern int SendMessage(IntPtr windowHandle, int msg, [MarshalAs(UnmanagedType.SysInt)] int wParam, StringBuilder lParam);
    }
}