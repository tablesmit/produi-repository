// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Utility
{
    [Flags]
    internal enum SpinnerMessages
    {
        WMUSER = 0x0400,
        /// <summary>
        /// This message sets the minimum and maximum positions, or the range, for a up-down control
        /// </summary>
        UDMSETRANGE = (WMUSER + 101),
        /// <summary>
        /// Retrieves the minimum and maximum positions (range) for an up-down control
        /// </summary>
        UDMGETRANGE = (WMUSER + 102),
        /// <summary>
        /// Sets the current position for an up-down control with 16-bit precision
        /// </summary>
        UDMSETPOS = (WMUSER + 103),
        /// <summary>
        /// Retrieves the current position of an up-down control with 16-bit precision
        /// </summary>
        UDMGETPOS = (WMUSER + 104),
        /// <summary>
        /// Sets the buddy window for an up-down control
        /// </summary>
        UDMSETBUDDY = (WMUSER + 105),
        /// <summary>
        /// Retrieves the handle to the current buddy window
        /// </summary>
        UDMGETBUDDY = (WMUSER + 106),
        /// <summary>
        /// Sets the acceleration for an up-down control.
        /// </summary>
        UDMSETACCEL = (WMUSER + 107),
        /// <summary>
        /// retrieves acceleration information for an up-down control
        /// </summary>
        UDMGETACCEL = (WMUSER + 108),
        /// <summary>
        /// Retrieves the current radix base (that is, either base 10 or 16) for an up-down control
        /// </summary>
        UDMSETBASE = (WMUSER + 109),
        /// <summary>
        /// retrieves the current radix base — that is, either base 10 or 16 — for an up-down control
        /// </summary>
        UDMGETBASE = (WMUSER + 110),
        /// <summary>
        /// This message sets the 32-bit range of an up-down control
        /// </summary>
        UDMSETRANGE32 = (WMUSER + 111),
        /// <summary>
        /// Retrieves the 32-bit range of an up-down control
        /// </summary>
        UDMGETRANGE32 = (WMUSER + 112),
        /// <summary>
        /// Sets the position of an up-down control with 32-bit precision
        /// </summary>
        UDMSETPOS32 = (WMUSER + 113),
        /// <summary>
        /// Returns the 32-bit position of an up-down control
        /// </summary>
        UDMGETPOS32 = (WMUSER + 114)
    }
}