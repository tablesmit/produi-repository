using System;
using System.Runtime.InteropServices;
using ProdUI.Utility;

namespace ProdUI.Bridge.NativePatterns
{
    //ReSharper disable InconsistentNaming

    /// <summary>
    /// Messages for the win32  Date and Time Picker Control
    /// </summary>
    internal enum DtPickerMessages
    {
        DTM_FIRST = 0x1000,

        /// <summary>
        /// Closes a date and time picker (DTP) control. Send this message explicitly or by using the DateTime_CloseMonthCal macro.
        /// wParam: Must be zero.
        /// lParam:Must be zero.
        /// Returns zero.
        /// </summary>
        /// <remarks>
        /// Destroys the control and sends a DTN_CLOSEUP notification that the control is closing
        /// </remarks>
        DTM_CLOSEMONTHCAL = DTM_FIRST + 13,

        /// <summary>
        /// Gets information on a date and time picker (DTP) control.
        /// wParam: Must be zero.
        /// lParam: A pointer to DATETIMEPICKERINFO to receive the information. The caller is responsible for allocating the memory for this structure.
        /// Set the cbSize member of the structure to sizeof(DATETIMEPICKERINFO) before sending this message.
        /// </summary>
        DTM_GETDATETIMEPICKERINFO = DTM_FIRST + 14,

        DTM_GETIDEALSIZE = DTM_FIRST + 15,
        DTM_GETMCCOLOR = DTM_FIRST + 7,
        DTM_GETMCFONT = DTM_FIRST + 10,
        DTM_GETMCSTYLE = DTM_FIRST + 12,

        /// <summary>
        /// Gets the handle to a date and time picker's (DTP) child month calendar control. You can send this message explicitly or use the DateTime_GetMonthCal macro.
        /// wParam: Must be zero.
        /// lParam:Must be zero.
        /// Returns the handle to a DTP control's child month calendar control if successful, or NULL otherwise.
        /// </summary>
        /// <remarks>
        /// DTP controls create a child month calendar control when the user clicks the drop-down arrow (DTN_DROPDOWN notification).
        /// When the month calendar is no longer needed, it is destroyed (a DTN_CLOSEUP notification is sent on destruction).
        /// So your application must not rely on a static handle to the DTP control's child month calendar.
        /// </remarks>
        DTM_GETMONTHCAL = DTM_FIRST + 8,
        DTM_GETRANGE = DTM_FIRST + 3,
        DTM_GETSYSTEMTIME = DTM_FIRST + 1,
        DTM_SETFORMAT = DTM_FIRST + 50,
        DTM_SETMCCOLOR = DTM_FIRST + 6,
        DTM_SETMCFONT = DTM_FIRST + 9,
        DTM_SETMCSTYLE = DTM_FIRST + 11,
        DTM_SETRANGE = DTM_FIRST + 4,
        DTM_SETSYSTEMTIME = DTM_FIRST + 2
    }

    /// <summary>
    /// Contains information about a date and time picker (DTP) control.
    /// </summary>
    internal struct DATETIMEPICKERINFO
    {
        /// <summary>
        /// Set to sizeof(DATETIMEPICKERINFO). This member must be set before sending a pointer to this structure with the DTM_GETDATETIMEPICKERINFO message
        /// </summary>
        [MarshalAs(UnmanagedType.SysInt)]
        internal int cbSize;
        /// <summary>
        /// A RECT structure describing location of checkbox. If a checkbox is displayed and checked, an edit control should be available to update the selected date-time value
        /// </summary>
        internal RECT rcCheck;
        /// <summary>
        /// The state of rcCheck—one of the Object State Constants, such as STATE_SYSTEM_CHECKED or STATE_SYSTEM_INVISIBLE
        /// </summary>
        [MarshalAs(UnmanagedType.SysInt)]
        internal int stateCheck;
        /// <summary>
        /// A RECT structure describing the location of a drop-down grid or up/down control.
        /// </summary>
        internal RECT rcButton;
        /// <summary>
        /// The state of rcButton— one or a bitwise combination of the Object State Constants. If the up/down control is in use, the state of the button is STATE_SYSTEM_INVISIBLE.
        /// </summary>
        [MarshalAs(UnmanagedType.SysInt)]
        internal int stateButton;
        /// <summary>
        /// A handle to the edit control.
        /// </summary>
        internal IntPtr hwndEdit;
        /// <summary>
        /// A handle to the up/down control—an alternative to using the drop-down grid (looks like month calendar control).
        /// </summary>
        internal IntPtr hwndUD;
        /// <summary>
        /// A handle to the drop-down grid.
        /// </summary>
        internal IntPtr hwndDropDown;
    }

    // ReSharper restore InconsistentNaming
}