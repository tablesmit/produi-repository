/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ProdUI.Utility
{
    internal static partial class NativeMethods
    {
        #region Callbacks

        /// <summary>
        ///   this represents the callback used for the enumwin function
        /// </summary>
        /// <param name = "windowHandle"></param>
        /// <param name = "lParam"></param>
        /// <returns></returns>
        public delegate bool EnumWindowsCallBack(IntPtr windowHandle, int lParam);

        #endregion

        /// <summary>
        ///   Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search
        /// </summary>
        /// <param name = "lpClassName">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter</param>
        /// <param name = "lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match</param>
        /// <returns>
        ///   If the function succeeds, the return value is a handle to the window that has the specified class name and window name. If the function fails, the return value is NULL
        /// </returns>
        [DllImport("user32.dll", SetLastError = true,CharSet = CharSet.Unicode, BestFitMapping = true)]
        internal static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        /// <summary>
        ///   Retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows, beginning with the one following the specified child window.
        /// </summary>
        /// <param name = "hwndParent">A handle to the parent window whose child windows are to be searched.If hwndParent is NULL, the function uses the desktop window as the parent window</param>
        /// <param name = "hwndChildAfter">A handle to a child window. If hwndChildAfter is NULL, the search begins with the first child window of hwndParent</param>
        /// <param name = "lpszClass">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function</param>
        /// <param name = "lpszWindow">The window name (the window's title). If this parameter is NULL, all window names match</param>
        /// <returns>
        ///   If the function succeeds, the return value is a handle to the window that has the specified class and window names.If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        internal static extern IntPtr FindWindowEX(IntPtr hwndParent, IntPtr hwndChildAfter, String lpszClass, String lpszWindow);

        /// <summary>
        ///   Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages
        ///   to the window to deactivate it and remove the keyboard focus from it
        /// </summary>
        /// <param name = "windowHandle">A handle to the window to be destroyed</param>
        /// <returns>If the function succeeds, the return value is nonzero</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyWindow(IntPtr windowHandle);

        /// <summary>
        ///   Enumerates the child windows that belong to the specified parent window by passing the handle
        ///   to each child window, in turn, to an application-defined callback function. EnumChildWindows
        ///   continues until the last child window is enumerated or the callback function returns FALSE
        /// </summary>
        /// <param name = "windowHandleParent">A Handle to the window containing the control whose child windows are to be enumerated.
        ///   If this parameter is NULL, this function is equivalent to EnumWindows</param>
        /// <param name = "lpEnumFunc">A pointer to an application-defined callback function</param>
        /// <param name = "lParam">An application-defined value to be passed to the callback function</param>
        /// <returns>The return value is not used.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumChildWindows(IntPtr windowHandleParent, EnumWindowsCallBack lpEnumFunc, IntPtr lParam);

        /// <summary>
        ///   Enumerates all top-level windows associated with the specified desktop
        /// </summary>
        /// <param name = "hDesktop">Enumerates all top-level windows associated with the specified desktop</param>
        /// <param name = "lpfn">A pointer to an application-defined EnumWindowsProc callback function</param>
        /// <param name = "lParam">An application-defined value to be passed to the callback function</param>
        /// <returns>
        ///   If the function fails or is unable to perform the enumeration, the return value is zero
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsCallBack lpfn, IntPtr lParam);


        /// <summary>
        ///   Retrieves a handle to a control in the specified dialog box
        /// </summary>
        /// <param name = "hDlg">A handle to the dialog box that contains the control.</param>
        /// <param name = "nIDDlgItem">The identifier of the control to be retrieved.</param>
        /// <returns>
        ///   If the function succeeds, the return value is the window handle of the specified control
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        /// <summary>
        ///   Retrieves a handle to the specified window's parent or owner
        /// </summary>
        /// <param name = "windowHandle">A handle to the window whose parent window handle is to be retrieved</param>
        /// <returns>
        ///   If the window is a child window, the return value is a Handle to the window containing the control.
        ///   If the window is a top-level window with the WS_POPUP style, the return value is a handle to
        ///   the owner window
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetParent(IntPtr windowHandle);


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

        /// <summary>
        ///   Brings the thread that created the specified window into the foreground and activates the window.
        ///   Keyboard input is directed to the window, and various visual cues are changed for the user
        /// </summary>
        /// <param name = "windowHandle">A handle to the window that should be activated and brought to the foreground</param>
        /// <returns>
        ///   If the window was brought to the foreground, the return value is nonzero
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr windowHandle);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true, ThrowOnUnmappableChar = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowText(IntPtr windowHandle, string lp);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ShowWindowAsync(IntPtr windowHandle, int nCmdShow);


        /// <summary>
        ///   Determines whether the specified window handle identifies an existing window
        /// </summary>
        /// <param name = "hWnd">A handle to the window to be tested</param>
        /// <returns>
        ///   If the window handle identifies an existing window, the return value is nonzero
        /// </returns>
        /// <remarks>
        ///   Handle Recycling: http://blogs.msdn.com/b/oldnewthing/archive/2007/07/17/3903614.aspx
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindow(IntPtr hWnd);


        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetSystemMetrics(int nIndex);


        /// <summary>
        ///   Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name = "nInputs">TThe number of structures in the pInputs array.</param>
        /// <param name = "pInputs">An array of INPUT structures. Each structure represents an event to be inserted into the keyboard or mouse input stream</param>
        /// <param name = "cbSize">The size, in bytes, of an INPUT structure. If cbSize is not the size of an INPUT structure, the function fails.</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendInput(uint nInputs, ref NPUT pInputs, int cbSize);

        /// <summary>
        ///   Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name = "hWnd">A handle to the window and, indirectly, the class to which the window belongs</param>
        /// <param name = "nIndex">The zero-based offset to the value to be retrieved</param>
        /// <returns>
        ///   If the function succeeds, the return value is the requested value, otherwise zero
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);


        /// <summary>
        ///   Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area
        /// </summary>
        /// <param name = "hWnd">A handle to the window</param>
        /// <param name = "x">The new position of the left side of the window.</param>
        /// <param name = "y">The new position of the top of the window</param>
        /// <param name = "nWidth">The new width of the window</param>
        /// <param name = "nHeight">The new height of the window.</param>
        /// <param name = "bRepaint">Indicates whether the window is to be repainted.</param>
        /// <returns>
        ///   If the function succeeds, the return value is nonzero.otherwise zero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

    }
}