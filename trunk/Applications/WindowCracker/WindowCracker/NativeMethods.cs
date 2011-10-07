// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowCracker
{
    internal static class NativeMethods
    {
        /* native structures */

        /* callbacks */

        #region Delegates

        /// <summary>
        ///   this represents the callback used for the EnumDesktopWindows function
        /// </summary>
        /// <param name = "windowHandle"></param>
        /// <param name = "lParam"></param>
        /// <returns></returns>
        public delegate bool EnumWindowsCallBack(IntPtr windowHandle, int lParam);

        #endregion Delegates

        /* imports */

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumWindows(EnumWindowsCallBack lpfn, IntPtr lParam);

        /// <summary>
        ///   Copies the text of the specified window's title bar (if it has one) into a buffer
        /// </summary>
        /// <param name = "windowHandle">A handle to the window or control containing the text</param>
        /// <param name = "lp">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character</param>
        /// <param name = "nMaxCount">The maximum number of characters to copy to the buffer, including the null character</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true, ThrowOnUnmappableChar = true)]
        internal static extern int GetWindowText(IntPtr windowHandle, StringBuilder lp, int nMaxCount);

        /// <summary>
        ///   Determines the visibility state of the specified window
        /// </summary>
        /// <param name = "hWnd">A handle to the window to be tested</param>
        /// <returns>
        ///   If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        #region Nested type: ShowWindowCommand

        /// <summary>
        ///   Controls how the window is to be shown. Used for ShowWindow calls
        /// </summary>
        internal enum ShowWindowCommand
        {
            /// <summary>
            ///   Hides the window and activates another window.
            /// </summary>
            SW_HIDE,
            /// <summary>
            ///   Activates and displays a window. If the window is minimized or maximized, the system restores it
            ///   to its original size and position.
            /// </summary>
            SW_SHOWNORMAL,
            /// <summary>
            ///   Activates the window and displays it as a minimized window.
            /// </summary>
            SW_SHOWMINIMIZED,
            /// <summary>
            ///   Activates the window and displays it as a maximized window.
            /// </summary>
            SW_SHOWMAXIMIZED,
            /// <summary>
            ///   Displays a window in its most recent size and position.
            ///   This value is similar to SW_SHOWNORMAL, except that the window is not activated.
            /// </summary>
            SWShownoactivate,
            /// <summary>
            ///   Activates the window and displays it in its current size and position
            /// </summary>
            SW_SHOW,
            /// <summary>
            ///   Minimizes the specified window and activates the next top-level window in the Z order.
            /// </summary>
            SW_MINIMIZE,
            /// <summary>
            ///   Displays the window as a minimized window.
            ///   This value is similar to SW_SHOWMINIMIZED, except the window is not activated
            /// </summary>
            SW_SHOWMINNOACTIVE,
            /// <summary>
            ///   Displays the window in its current size and position.
            ///   This value is similar to SW_SHOW, except that the window is not activated.
            /// </summary>
            SW_SHOWNA,
            /// <summary>
            ///   Activates and displays the window
            /// </summary>
            SW_RESTORE,
            /// <summary>
            ///   Sets the show state based on the SW_ value specified in the STARTUPINFO
            ///   structure passed to the CreateProcess function by the program that started the application.
            /// </summary>
            SW_SHOWDEFAULT,
            /// <summary>
            ///   Minimizes a window, even if the thread that owns the window is not responding.
            ///   This flag should only be used when minimizing windows from a different thread.
            /// </summary>
            SW_FORCEMINIMIZE
        }

        #endregion Nested type: ShowWindowCommand
    }
}