/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Runtime.InteropServices;

namespace ProdUI.Utility
{
    /// <summary>
    ///   Mouse event flags from From winuser.h
    /// </summary>
    [Flags]
    internal enum MOUSEEVENTF
    {
        /// <summary>
        ///   mouse move
        /// </summary>
        MouseeventfMove = 0x0001,
        /// <summary>
        ///   left button down
        /// </summary>
        MouseeventfLeftdown = 0x0002,
        /// <summary>
        ///   left button up
        /// </summary>
        MouseeventfLeftup = 0x0004,
        /// <summary>
        ///   right button down
        /// </summary>
        MouseeventfRightdown = 0x0008,
        /// <summary>
        ///   right button up
        /// </summary>
        MouseeventfRightup = 0x0010,
        /// <summary>
        ///   middle button down
        /// </summary>
        MouseeventfMiddledown = 0x0020,
        /// <summary>
        ///   middle button up
        /// </summary>
        MouseeventfMiddleup = 0x0040,
        /// <summary>
        ///   x button down
        /// </summary>
        MouseeventfXdown = 0x0080,
        /// <summary>
        ///   x button down
        /// </summary>
        MouseeventfXup = 0x0100,
        /// <summary>
        ///   wheel button rolled
        /// </summary>
        MouseeventfWheel = 0x0800,
        /// <summary>
        ///   absolute move
        /// </summary>
        MouseeventfAbsolute = 0x8000,
        /// <summary>
        ///   map to entire virtual desktop
        /// </summary>
        MouseeventfVirtualdesk = 0x4000
    }

    /// <summary>
    ///   Used for the nIndex parameter in the GetSystemMetrics call. this is only a partial list. http://msdn.microsoft.com/en-us/library/ms724385(VS.85).aspx
    /// </summary>
    internal enum SystemMetric
    {
        /// <summary>
        ///   Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
        /// </summary>
        SMSwapbutton = 23,
        /// <summary>
        ///   The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
        /// </summary>
        SMCxmaxtrack = 59,
        /// <summary>
        ///   The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
        /// </summary>
        SMCymaxtrack = 60,
        /// <summary>
        ///   The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMXvirtualscreen = 76,
        /// <summary>
        ///   The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMYvirtualscreen = 77,
        /// <summary>
        ///   The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMCxvirtualscreen = 78,
        /// <summary>
        ///   The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMCyvirtualscreen = 79
    }

    #region Union Structs for SendInput Call

    /// <summary>
    ///   Contains information about a simulated mouse event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        /// <summary>
        ///   The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member.
        ///   Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved
        /// </summary>
        [MarshalAs(UnmanagedType.I4)] 
        public int DX;

        /// <summary>
        ///   The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member.
        ///   Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved
        /// </summary>
        [MarshalAs(UnmanagedType.I4)] 
        public int DY;

        /// <summary>
        ///   Depending of the dwFlags value, it contains different things. http://msdn.microsoft.com/en-us/library/ms646273(v=VS.85).aspx
        /// </summary>
        [MarshalAs(UnmanagedType.I4)] 
        public int MouseData;

        /// <summary>
        ///   <see cref="MOUSEEVENTF"/>
        /// </summary>
        [MarshalAs(UnmanagedType.I4)] 
        public int DWFlags;

        /// <summary>
        ///   The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp
        /// </summary>
        [MarshalAs(UnmanagedType.I4)] 
        public int Time;

        /// <summary>
        ///   An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information
        /// </summary>
        public IntPtr DWExtraInfo;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(MOUSEINPUT x, MOUSEINPUT y)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(MOUSEINPUT x, MOUSEINPUT y)
        {
            throw new NotImplementedException();
        }
    };

    /// <summary>
    ///   Contains information about a simulated keyboard event. Since this isn't used yet, its taking up space for the INPUT struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        /// <summary>
        ///   A virtual-key code. The code must be a value in the range 1 to 254. If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.
        /// </summary>
        public int WVK;

        /// <summary>
        ///   A hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.
        /// </summary>
        public int WScan;

        /// <summary>
        ///   Specifies various aspects of a keystroke. We don't use this (yet) so I havent created the enumeration for it
        /// </summary>
        public int DWFlags;

        /// <summary>
        ///   The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.
        /// </summary>
        public int Time;

        /// <summary>
        ///   An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information
        /// </summary>
        public IntPtr DWExtraInfo;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(KEYBDINPUT x, KEYBDINPUT y)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(KEYBDINPUT x, KEYBDINPUT y)
        {
            throw new NotImplementedException();
        }
    };

    /// <summary>
    ///   Contains information about a simulated message generated by an input device other than a keyboard or mouse.Since this isn't used yet, its taking up space for the INPUT struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        /// <summary>
        ///   The message generated by the input hardware
        /// </summary>
        public int UMsg;

        /// <summary>
        ///   The low-order word of the lParam parameter for uMsg
        /// </summary>
        public int WParamL;

        /// <summary>
        ///   The high-order word of the lParam parameter for uMsg
        /// </summary>
        public int WParamH;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(HARDWAREINPUT x, HARDWAREINPUT y)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(HARDWAREINPUT x, HARDWAREINPUT y)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    ///   contains the mi, ki and hi structs for the input struct.
    /// </summary>
    /// <remarks>
    ///   These are layed out per MSDN INPUT structure documentation in order to simulate a c union
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UNION
    {
        public MOUSEINPUT MouseInput;
        public KEYBDINPUT KeyboardInput;
        public HARDWAREINPUT HardwareInput;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(UNION x, UNION y)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(UNION x, UNION y)
        {
            throw new NotImplementedException();
        }
    };

    /// <summary>
    ///   Used by SendInput to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NPUT
    {
        /// <summary>
        ///   The type of the input event <see cref = "InputStructType" />
        /// </summary>
        public int Type;

        /// <summary>
        ///   Union of structs <see cref = "UNION" />
        /// </summary>
        public UNION Union;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(NPUT x, NPUT y)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(NPUT x, NPUT y)
        {
            throw new NotImplementedException();
        }
    } ;

    /// <summary>
    ///   Used for the INPUT structure
    /// </summary>
    internal enum InputStructType
    {
        /// <summary>
        ///   The event is a mouse event. Use the mi structure of the union.
        /// </summary>
        InputMouse,
        /// <summary>
        ///   The event is a keyboard event. Use the ki structure of the union.
        /// </summary>
        InputKeyboard,
        /// <summary>
        ///   The event is a hardware event. Use the hi structure of the union.
        /// </summary>
        InputHardware
    }

    #endregion

}