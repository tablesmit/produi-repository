using System;

namespace ProdUI.Enums
{
    [Flags]
    internal enum SpinnerMessages
    {
        WM_USER = 0x0400,
        /// <summary>
        ///   This message sets the minimum and maximum positions, or the range, for a up-down control
        /// </summary>
        UDM_SETRANGE = (WM_USER + 101),
        /// <summary>
        ///   Retrieves the minimum and maximum positions (range) for an up-down control
        /// </summary>
        UDM_GETRANGE = (WM_USER + 102),
        /// <summary>
        ///   Sets the current position for an up-down control with 16-bit precision
        /// </summary>
        UDM_SETPOS = (WM_USER + 103),
        /// <summary>
        ///   Retrieves the current position of an up-down control with 16-bit precision
        /// </summary>
        UDM_GETPOS = (WM_USER + 104),
        /// <summary>
        ///   Sets the buddy window for an up-down control
        /// </summary>
        UDM_SETBUDDY = (WM_USER + 105),
        /// <summary>
        ///   Retrieves the handle to the current buddy window
        /// </summary>
        UDM_GETBUDDY = (WM_USER + 106),
        /// <summary>
        ///   Sets the acceleration for an up-down control.
        /// </summary>
        UDM_SETACCEL = (WM_USER + 107),
        /// <summary>
        ///   retrieves acceleration information for an up-down control
        /// </summary>
        UDM_GETACCEL = (WM_USER + 108),
        /// <summary>
        ///   Retrieves the current radix base (that is, either base 10 or 16) for an up-down control
        /// </summary>
        UDM_SETBASE = (WM_USER + 109),
        /// <summary>
        ///   retrieves the current radix base — that is, either base 10 or 16 — for an up-down control
        /// </summary>
        UDM_GETBASE = (WM_USER + 110),
        /// <summary>
        ///   This message sets the 32-bit range of an up-down control
        /// </summary>
        UDM_SETRANGE32 = (WM_USER + 111),
        /// <summary>
        ///   Retrieves the 32-bit range of an up-down control
        /// </summary>
        UDM_GETRANGE32 = (WM_USER + 112),
        /// <summary>
        ///   Sets the position of an up-down control with 32-bit precision
        /// </summary>
        UDM_SETPOS32 = (WM_USER + 113),
        /// <summary>
        ///   Returns the 32-bit position of an up-down control
        /// </summary>
        UDM_GETPOS32 = (WM_USER + 114)
    }
}