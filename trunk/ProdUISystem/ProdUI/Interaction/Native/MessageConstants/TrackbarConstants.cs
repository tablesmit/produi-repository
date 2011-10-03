// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Interaction.Native
{
    [Flags]
    internal enum TrackBarMessages
    {
        /// <summary>
        /// Retrieves the current logical position of the slider in a TrackBar. The logical positions are the integer
        /// values in the TrackBar's range of minimum to maximum slider positions.
        /// wParam - Redraw flag. If this parameter is TRUE, the message redraws the control with the slider at the position given by lParam.
        /// If this parameter is FALSE, the message does not redraw the slider at the new position.
        /// lParam - New logical position of the slider. Valid logical positions are the integer values in the TrackBar's range of minimum to maximum slider positions
        /// </summary>
        TBMGETPOS = 0x0400,
        /// <summary>
        /// Sets the current logical position of the slider in a TrackBar
        /// </summary>
        TBMSETPOS = 0x0405,
        /// <summary>
        /// Retrieves the maximum position for the slider in a TrackBar
        /// </summary>
        TBMGETRANGEMAX = 0x0402,
        /// <summary>
        /// Retrieves the minimum position for the slider in a TrackBar
        /// </summary>
        TBMGETRANGEMIN = 0x0401,
        /// <summary>
        /// This message retrieves the size of the page for a TrackBar
        /// wParam Not used.
        /// lParam Not used
        /// Returns a 32-bit value that specifies the page size for the TrackBar
        /// </summary>
        TBMGETPAGESIZE = (TBMGETPOS + 22),
        /// <summary>
        /// This message retrieves the size of the line for a TrackBar
        /// wParam Not used.
        /// lParam Not used
        /// Returns a 32-bit value that specifies the line size for the TrackBar
        /// </summary>
        TBMGETLINESIZE = (TBMGETPOS + 24)
    }
}