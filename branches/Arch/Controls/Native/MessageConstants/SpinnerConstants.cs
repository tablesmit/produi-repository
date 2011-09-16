/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;

namespace ProdUI.Enums
{
    [Flags]
    internal enum SpinnerMessages
    {
        WMUser = 0x0400,
        /// <summary>
        ///   This message sets the minimum and maximum positions, or the range, for a up-down control
        /// </summary>
        UdmSetrange = (WMUser + 101),
        /// <summary>
        ///   Retrieves the minimum and maximum positions (range) for an up-down control
        /// </summary>
        UdmGetrange = (WMUser + 102),
        /// <summary>
        ///   Sets the current position for an up-down control with 16-bit precision
        /// </summary>
        UdmSetpos = (WMUser + 103),
        /// <summary>
        ///   Retrieves the current position of an up-down control with 16-bit precision
        /// </summary>
        UdmGetpos = (WMUser + 104),
        /// <summary>
        ///   Sets the buddy window for an up-down control
        /// </summary>
        UdmSetbuddy = (WMUser + 105),
        /// <summary>
        ///   Retrieves the handle to the current buddy window
        /// </summary>
        UdmGetbuddy = (WMUser + 106),
        /// <summary>
        ///   Sets the acceleration for an up-down control.
        /// </summary>
        UdmSetaccel = (WMUser + 107),
        /// <summary>
        ///   retrieves acceleration information for an up-down control
        /// </summary>
        UdmGetaccel = (WMUser + 108),
        /// <summary>
        ///   Retrieves the current radix base (that is, either base 10 or 16) for an up-down control
        /// </summary>
        UdmSetbase = (WMUser + 109),
        /// <summary>
        ///   retrieves the current radix base — that is, either base 10 or 16 — for an up-down control
        /// </summary>
        UdmGetbase = (WMUser + 110),
        /// <summary>
        ///   This message sets the 32-bit range of an up-down control
        /// </summary>
        UdmSetrangE32 = (WMUser + 111),
        /// <summary>
        ///   Retrieves the 32-bit range of an up-down control
        /// </summary>
        UdmGetrangE32 = (WMUser + 112),
        /// <summary>
        ///   Sets the position of an up-down control with 32-bit precision
        /// </summary>
        UdmSetpoS32 = (WMUser + 113),
        /// <summary>
        ///   Returns the 32-bit position of an up-down control
        /// </summary>
        UdmGetpoS32 = (WMUser + 114)
    }
}