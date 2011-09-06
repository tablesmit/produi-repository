/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ProdSpy.Core
{
    internal static class NativeMethods
    {
        #region Enums and Structs

        #region ExtendedWindowStyles enum

        /// <summary>
        /// Values used with CreateWindowEx	
        /// </summary>
        public enum ExtendedWindowStyle : uint
        {
            /// <summary>
            ///   The window has a double border
            /// </summary>
            WS_EX_DLGMODALFRAME = 0x00000001,
            /// <summary>
            ///   The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window
            ///   when it is created or destroyed
            /// </summary>
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            /// <summary>
            ///   The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated
            /// </summary>
            WS_EX_TOPMOST = 0x00000008,
            /// <summary>
            ///   The window accepts drag-drop files
            /// </summary>
            WS_EX_ACCEPTFILES = 0x00000010,
            /// <summary>
            ///   The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted
            /// </summary>
            WS_EX_TRANSPARENT = 0x00000020,
            /// <summary>
            ///   The window is a MDI child window
            /// </summary>
            WS_EX_MDICHILD = 0x00000040,
            /// <summary>
            ///   The window is intended to be used as a floating toolbar
            /// </summary>
            WS_EX_TOOLWINDOW = 0x00000080,
            /// <summary>
            ///   The window has a border with a raised edge
            /// </summary>
            WS_EX_WINDOWEDGE = 0x00000100,
            /// <summary>
            ///   The window has a border with a sunken edge
            /// </summary>
            WS_EX_CLIENTEDGE = 0x00000200,
            /// <summary>
            ///   The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes
            ///   to a question mark with a pointer
            /// </summary>
            WS_EX_CONTEXTHELP = 0x00000400,
            /// <summary>
            ///   The window has generic "right-aligned" properties. This depends on the window class.
            /// </summary>
            WS_EX_RIGHT = 0x00001000,
            /// <summary>
            ///   The window has generic left-aligned properties
            /// </summary>
            WS_EX_LEFT = 0x00000000,
            /// <summary>
            ///   If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment,
            ///   the window text is displayed using right-to-left reading-order properties
            /// </summary>
            WS_EX_RTLREADING = 0x00002000,
            /// <summary>
            ///   The window text is displayed using left-to-right reading-order properties
            /// </summary>
            WS_EX_LTRREADING = 0x00000000,
            /// <summary>
            ///   If the shell language is Hebrew, Arabic, or another language that supports
            ///   reading order alignment, the vertical scroll bar (if present) is to the left of the client area
            /// </summary>
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            /// <summary>
            ///   The vertical scroll bar (if present) is to the right of the client area
            /// </summary>
            WS_EX_RIGHTSCROLLBAR = 0x00000000,
            /// <summary>
            ///   The window itself contains child windows that should take part in dialog box navigation
            /// </summary>
            WS_EX_CONTROLPARENT = 0x00010000,
            /// <summary>
            ///   The window has a three-dimensional border style intended to be used for items that do not accept user input
            /// </summary>
            WS_EX_STATICEDGE = 0x00020000,
            /// <summary>
            ///   Forces a top-level window onto the taskbar when the window is visible
            /// </summary>
            WS_EX_APPWINDOW = 0x00040000
        }

        #endregion

        #region WindowStyles enum

        /// <summary>
        /// Values used with CreateWindow	
        /// </summary>
        public enum WindowStyle : uint
        {
            /// <summary>
            ///   The windows is a pop-up window
            /// </summary>
            WS_POPUP = 0x80000000,
            /// <summary>
            ///   The window is a child window. A window with this style cannot have a menu bar
            /// </summary>
            WS_CHILD = 0x40000000,
            /// <summary>
            ///   The window is initially minimized
            /// </summary>
            WS_MINIMIZE = 0x20000000,
            /// <summary>
            ///   The window is initially visible
            /// </summary>
            WS_VISIBLE = 0x10000000,
            /// <summary>
            ///   The window is initially disabled. A disabled window cannot receive input from the user
            /// </summary>
            WS_DISABLED = 0x08000000,
            /// <summary>
            ///   Clips child windows relative to each other
            /// </summary>
            WS_CLIPSIBLINGS = 0x04000000,
            /// <summary>
            ///   Excludes the area occupied by child windows when drawing occurs within the parent window.
            ///   This style is used when creating the parent window
            /// </summary>
            WS_CLIPCHILDREN = 0x02000000,
            /// <summary>
            ///   The window is initially maximized.
            /// </summary>
            WS_MAXIMIZE = 0x01000000,
            /// <summary>
            ///   The window has a title bar
            /// </summary>
            WS_CAPTION = 0x00C00000,
            /// <summary>
            ///   The window has a thin-line border
            /// </summary>
            WS_BORDER = 0x00800000,
            /// <summary>
            ///   The window has a border of a style typically used with dialog boxes
            /// </summary>
            WS_DLGFRAME = 0x00400000,
            /// <summary>
            ///   The window has a vertical scroll bar
            /// </summary>
            WS_VSCROLL = 0x00200000,
            /// <summary>
            ///   The window has a horizontal scroll bar
            /// </summary>
            WS_HSCROLL = 0x00100000,
            /// <summary>
            ///   The window has a window menu on its title bar. The WS_CAPTION style must also be specified
            /// </summary>
            WS_SYSMENU = 0x00080000,
            /// <summary>
            ///   The window has a sizing border
            /// </summary>
            WS_THICKFRAME = 0x00040000,
            /// <summary>
            ///   The window is the first control of a group of controls.
            /// </summary>
            WS_GROUP = 0x00020000,
            /// <summary>
            ///   The window is a control that can receive the keyboard focus when the user presses the TAB key
            /// </summary>
            WS_TABSTOP = 0x00010000,
        }

        #endregion

        #region Nested type: POINT

        /// <summary>
        ///  Native version of managed Point	
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            /// <summary>
            /// 	
            /// </summary>
            /// <remarks></remarks>
            public int X;
            /// <summary>
            /// 	
            /// </summary>
            /// <remarks></remarks>
            public int Y;

            /// <summary>
            /// Initializes a new instance of the <see cref="POINT" /> struct.	
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            /// <remarks></remarks>
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }

            /// <summary>
            /// Implements the operator ==.	
            /// </summary>
            /// <param name="p1">The p1.</param>
            /// <param name="p2">The p2.</param>
            /// <returns>The result of the operator.</returns>
            /// <remarks></remarks>
            public static bool operator ==(POINT p1, POINT p2)
            {
                return p1.X == p2.X && p1.Y == p2.Y;
            }

            /// <summary>
            /// Implements the operator !=.	
            /// </summary>
            /// <param name="p1">The p1.</param>
            /// <param name="p2">The p2.</param>
            /// <returns>The result of the operator.</returns>
            /// <remarks></remarks>
            public static bool operator !=(POINT p1, POINT p2)
            {
                return p1.X != p2.X || p1.Y != p2.Y;
            }

            /// <summary>
            /// Equalses the specified other.	
            /// </summary>
            /// <param name="other">The other.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            public bool Equals(POINT other)
            {
                return other.X == X && other.Y == Y;
            }

            /// <summary>
            /// Equalses the specified obj.	
            /// </summary>
            /// <param name="obj">The obj.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }

                if (obj.GetType() != typeof (POINT))
                {
                    return false;
                }

                return Equals((POINT) obj);
            }

            /// <summary>
            /// Gets the hash code.	
            /// </summary>
            /// <returns></returns>
            /// <remarks></remarks>
            public override int GetHashCode()
            {
                unchecked
                {
                    return (X*397) ^ Y;
                }
            }
        }

        #endregion

        #region Nested type: RECT

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }

            public override bool Equals(Object obj)
            {
                throw new NotImplementedException();
            }

            public static bool operator ==(RECT x, RECT y)
            {
                throw new NotImplementedException();
            }

            public static bool operator !=(RECT x, RECT y)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: WINDOWINFO

        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWINFO
        {
            public uint CbSize;
            public RECT RCWindow;
            public RECT RCClient;
            public uint DWStyle;
            public uint DWEXStyle;
            public uint DWWindowStatus;
            public uint CXWindowBorders;
            public uint CYWindowBorders;
            public ushort AtomWindowType;
            public ushort WCreatorVersion;

            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }

            public override bool Equals(Object obj)
            {
                throw new NotImplementedException();
            }

            public static bool operator ==(WINDOWINFO x, WINDOWINFO y)
            {
                throw new NotImplementedException();
            }

            public static bool operator !=(WINDOWINFO x, WINDOWINFO y)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #endregion

        #region Cursor Functions

        /// <summary>
        /// Destroys an icon and frees any memory the icon occupied
        /// </summary>
        /// <param name="handle">A handle to the icon to be destroyed. The icon must not be in use</param>
        /// <returns>If the function succeeds, the return value is nonzero</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyIcon(IntPtr handle);

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates
        /// </summary>
        /// <param name="lpPoint">A pointer to a POINT structure that receives the screen coordinates of the cursor</param>
        /// <returns>Returns nonzero if successful or zero otherwise</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out POINT lpPoint);

        #endregion

        #region Windows and Drawing

        /// <summary>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose ancestor is to be retrieved. If this parameter is the desktop window, the function returns NULL.</param>
        /// <param name="gaFlags">GA_PARENT    1  Retrieves the parent window. This does not include the owner, as it does with the GetParent function.
        /// GA_ROOT      2  Retrieves the root window by walking the chain of parent windows.
        /// GA_ROOTOWNER 3  Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetAncestor(IntPtr hwnd, int gaFlags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);


        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, [MarshalAs(UnmanagedType.Bool)] bool bErase);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SendMessage(IntPtr hwnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr hwnd, uint msg, int wParam, string lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr hwnd, uint msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr WindowFromPoint(POINT point);

        /// <summary>
        ///   Determines which, if any, of the child windows belonging to a parent window contains the specified point
        /// </summary>
        /// <param name = "hWnd">handle to the parent window</param>
        /// <param name = "point">A structure that defines the client coordinates, relative to hWnd, of the point to be checked</param>
        /// <returns>handle to the child window that contains the point, even if the child window is hidden or disabled. If the point lies outside the parent window, the return value is NULL</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr ChildWindowFromPoint(IntPtr hWnd, POINT point);

        #endregion

        #region Processes

        /// <summary>
        /// Retrieves the fully-qualified path for the file containing the specified module.
        /// </summary>
        /// <param name="hProcess">A handle to the process that contains the module.</param>
        /// <param name="hModule">A handle to the module. If this parameter is NULL, GetModuleFileNameEx returns the path of the executable file of the process specified in hProcess</param>
        /// <param name="lpBaseName">A pointer to a buffer that receives the fully-qualified path to the module</param>
        /// <param name="nSize">The size of the lpFilename buffer, in characters.</param>
        /// <returns>If the function succeeds, the return value specifies the length of the string copied to the buffer</returns>
        [DllImport("psapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In] int nSize);

        /// <summary>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpdwProcessId">A pointer to a variable that receives the process identifier. If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; otherwise, it does not.</param>
        /// <returns>The identifier of the thread that created the window</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        #endregion

        /// <summary>
        ///   Retrieves a string that specifies the window type.
        /// </summary>
        /// <param name = "windowHandle">A handle to the window whose type will be retrieved</param>
        /// <param name = "pszType">A pointer to a string that receives the window type</param>
        /// <param name = "cchType">The length, in characters, of the buffer pointed to by the pszType parameter</param>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true, ThrowOnUnmappableChar = true)]
        internal static extern void RealGetWindowClass(IntPtr windowHandle, StringBuilder pszType, uint cchType);

        /// <summary>
        ///   Retrieves a handle to the child window at the specified point.
        /// </summary>
        /// <param name = "hwndParent">A handle to the window whose child is to be retrieved.</param>
        /// <param name = "ptParentClientCoords">A POINT structure that defines the client coordinates of the point to be checked</param>
        /// <returns>Handle to the child window that contains the specified point</returns>
        /// <remarks>
        ///   The search is restricted to immediate child windows; grandchildren and deeper descendant windows are not searched.
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr RealChildWindowFromPoint(IntPtr hwndParent, POINT ptParentClientCoords);

        /// <summary>
        /// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code
        /// </summary>
        /// <returns>The return value is the calling thread's last-error code</returns>
        [DllImport("Kernel32.dll", SetLastError = true)]
        internal static extern int GetLastError();
    }
}