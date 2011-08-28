using System;

namespace ProdUI.Enums
{
    [Flags]
    internal enum TrackBarMessages
    {
        /// <summary>
        ///   Retrieves the current logical position of the slider in a TrackBar. The logical positions are the integer
        ///   values in the TrackBar's range of minimum to maximum slider positions.
        ///   wParam - Redraw flag. If this parameter is TRUE, the message redraws the control with the slider at the position given by lParam.
        ///   If this parameter is FALSE, the message does not redraw the slider at the new position.
        ///   lParam - New logical position of the slider. Valid logical positions are the integer values in the TrackBar's range of minimum to maximum slider positions
        /// </summary>
        TBM_GETPOS = 0x0400,
        /// <summary>
        ///   Sets the current logical position of the slider in a TrackBar
        /// </summary>
        TBM_SETPOS = 0x0405,
        /// <summary>
        ///   Retrieves the maximum position for the slider in a TrackBar
        /// </summary>
        TBM_GETRANGEMAX = 0x0402,
        /// <summary>
        ///   Retrieves the minimum position for the slider in a TrackBar
        /// </summary>
        TBM_GETRANGEMIN = 0x0401
    }
}