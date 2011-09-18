// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;

namespace ProdUI.Interaction.Native
{
    [Flags]
    internal enum TrackBarMessages
    {
        /// <summary>
        ///     Retrieves the current logical position of the slider in a TrackBar. The logical positions are the integer
        ///     values in the TrackBar's range of minimum to maximum slider positions.
        ///     wParam - Redraw flag. If this parameter is TRUE, the message redraws the control with the slider at the position given by lParam.
        ///     If this parameter is FALSE, the message does not redraw the slider at the new position.
        ///     lParam - New logical position of the slider. Valid logical positions are the integer values in the TrackBar's range of minimum to maximum slider positions
        /// </summary>
        TbmGetpos = 0x0400,
        /// <summary>
        ///     Sets the current logical position of the slider in a TrackBar
        /// </summary>
        TbmSetpos = 0x0405,
        /// <summary>
        ///     Retrieves the maximum position for the slider in a TrackBar
        /// </summary>
        TbmGetrangemax = 0x0402,
        /// <summary>
        ///     Retrieves the minimum position for the slider in a TrackBar
        /// </summary>
        TbmGetrangemin = 0x0401
    }
}