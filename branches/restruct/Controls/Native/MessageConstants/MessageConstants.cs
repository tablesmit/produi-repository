/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;

namespace ProdUI.Interaction.Native
{
    internal enum ComboBoxMessage
    {
        /// <summary>
        ///   Adds a string to the list box of a combo box. If the combo box does not have the CBS_SORT style,
        ///   the string is added to the end of the list. Otherwise, the string is inserted into the list, and the list is sorted
        /// </summary>
        /// wParam  This parameter is not used
        /// lParam string to be added
        /// Return Value - zero-based index to the string in the list box of the combo box. If an error occurs, the return value is CB_ERR. If insufficient space is available to store the new string, it is CB_ERRSPACE
        CBAddstring = 0x0143,
        /// <summary>
        ///   Deletes a string in the list box of a combo box.
        /// </summary>
        /// wParam-The zero-based index of the string to delete
        /// lParam-This parameter is not used
        /// Return Value-count of the strings remaining in the list. If the wParam parameter specifies an index greater than the number of items in the list, the return value is CB_ERR.
        CBDeletestring = 0x0144,

        /// <summary>
        ///   Searches the list box of a combo box for an item beginning with the characters in a specified string
        /// </summary>
        /// wParam-The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list box,
        /// it continues from the top of the list box back to the item specified by the wParam parameter.
        /// If wParam is –1, the entire list box is searched from the beginning
        /// lParam- string that contains the characters for which to search. The search is not case sensitive
        /// Return Value- The return value is the zero-based index of the matching item. If the search is unsuccessful, it is CB_ERR
        CBFindstring = 0x014C,
        /// <summary>
        ///   Finds the first list box string in a combo box that matches the string specified in the lParam parameter
        ///   wParam-The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list box,
        ///   it continues from the top of the list box back to the item specified by the wParam parameter.
        ///   If wParam is –1, the entire list box is searched from the beginning
        ///   lParam- string that contains the characters for which to search. The search is not case sensitive
        ///   Return Value- The return value is the zero-based index of the matching item. If the search is unsuccessful, it is CB_ERR
        /// </summary>
        CBFindstringexact = 0x0158,

        /// <summary>
        ///   Gets the starting and ending character positions of the current selection in the edit control of a combo box
        /// </summary>
        CBGeteditsel = 0x0140,
        /// <summary>
        ///   Gets the number of items in the list box of a combo box.
        /// </summary>
        CBGetcount = 0x0146,
        /// <summary>
        ///   retrieve the index of the currently selected item, if any, in the list box of a combo box.
        /// </summary>
        CBGetcursel = 0x0147,
        /// <summary>
        ///   Gets a string from the list of a combo box.
        /// </summary>
        CBGetlbtext = 0x0148,
        /// <summary>
        ///   Gets the length, in characters, of a string in the list of a combo box
        /// </summary>
        CBGetlbtextlen = 0x0149,
        /// <summary>
        ///   Determines whether the list box of a combo box is dropped down
        /// </summary>
        CBGetdroppedstate = 0x0157,
        CBGettopindex = 0x015b,
        CBGetitemdata = 0x0150,
        CBInsertstring = 0x014A,
        CBLimittext = 0x0141,
        CBResetcontent = 0x014B,
        CBSelectstring = 0x014D,
        CBSetcursel = 0x014E,
        CBSeteditsel = 0x0142,
        CBSetitemdata = 0x0151,
        CBSetitemheight = 0x0153,
        CBSetextendedui = 0x0155,
        /// <summary>
        ///   An application sends a CB_SHOWDROPDOWN message to show or hide the list box of a combo box
        /// </summary>
        /// wParam-A BOOL that specifies whether the drop-down list box is to be shown or hidden. A value of TRUE shows the list box; a value of FALSE hides it
        /// lParam- Not used
        /// Return Value- Always TRUE
        CBShowdropdown = 0x014F,
        CBInitstorage = 0x0161,
        CBMultipleaddstring = 0x0163
    }

    /// <summary>
    ///   Win32 Button state constants
    /// </summary>
    [Flags]
    internal enum ButtonStates
    {
        /// <summary>
        ///   No special state. Equivalent to zero.
        /// </summary>
        BstUnchecked = 0x0000,
        /// <summary>
        ///   The button is checked.
        /// </summary>
        BstChecked = 0x0001,
        /// <summary>
        ///   The state of the button is indeterminate. Applies only if the button has the BS_3STATE or BS_AUTO3STATE style.
        /// </summary>
        BstIndeterminate = 0x0002,
        /// <summary>
        ///   The button is being shown in the pushed state.
        /// </summary>
        BstPushed = 0x0004,
        /// <summary>
        ///   The button has the keyboard focus.
        /// </summary>
        BstFocus = 0x0008,
        /// <summary>
        ///   Windows Vista. The button is in the drop-down state. Applies only if the button has the TBSTYLE_DROPDOWN style.
        /// </summary>
        BstDropdownpushed = 0x0400
    }


    /// <summary>
    ///   Win32 button message constants
    /// </summary>
    internal enum ButtonMessage
    {
        BMGetcheck = 0x00F0,
        /// <summary>
        ///   Sets the check state of a radio button or check box.
        /// </summary>
        BMSetcheck = 0x00F1,
        /// <summary>
        ///   Sends the button a WM_LBUTTONDOWN and a WM_LBUTTONUP message, and sends the parent window a BN_CLICKED notification code.
        /// </summary>
        BMClick = 0x00F5,
        /// <summary>
        ///   Returns the current check state, push state, and focus state of the button.
        /// </summary>
        BMGetstate = 0x00F2,
        /// <summary>
        ///   Sets the highlight state of a button. The highlight state indicates whether the button is highlighted as if the user had pushed it.
        /// </summary>
        BMSetstate = 0x00F3,
        /// <summary>
        ///   Retrieves a handle to the image (icon or bitmap) associated with the button.
        /// </summary>
        BMGetimage = 0x00F6
    }

    internal enum ListboxMessage
    {
        /* Multi-Select Only */
        /// <summary>
        ///   Selects an item in a multiple-selection list box and, if necessary, scrolls the item into view
        ///   wParam  Specifies how to set the selection. If this parameter is TRUE, the item is selected and highlighted; if it is FALSE, the highlight is removed and the item is no longer selected.
        ///   lParam Specifies the zero-based index of the item to set. If this parameter is –1, the selection is added to or removed from all items, depending on the value of wParam, and no scrolling occurs.
        ///   Return Value-If an error occurs, the return value is LB_ERR.
        ///   Remarks-Use this message only with multiple-selection list boxes.
        /// </summary>
        LBSetsel = 0x0185,

        /// <summary>
        ///   Fills a buffer with an array of integers that specify the item numbers of selected items in a multiple-selection list box
        ///   wParam- The maximum number of selected items whose item numbers are to be placed in the buffer.
        ///   lParam-A pointer to a buffer large enough for the number of integers specified by the wParam parameter.
        ///   Return-The return value is the number of items placed in the buffer. If the list box is a single-selection list box, the return value is LB_ERR.
        /// </summary>
        LBGetselitems = 0x0191,

        /// <summary>
        ///   Gets the total number of selected items in a multiple-selection list box
        ///   wParam and lParam-Not used; must be zero.
        ///   Return Value-The return value is the count of selected items in the list box. If the list box is a single-selection list box, the return value is LB_ERR.
        /// </summary>
        LBGetselcount = 0x0190,


        /* Single Select Only */
        /// <summary>
        ///   Gets the index of the currently selected item, if any, in a single-selection list box
        ///   wParam and lParam Not used; must be zero.
        ///   Return Value-In a single-selection list box, the return value is the zero-based index of the currently selected item. If there is no selection, the return value is LB_ERR.
        /// </summary>
        LBGetcursel = 0x0188,

        /// <summary>
        ///   wParam The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it continues from the top of the list box back to the item specified by the wParam parameter. If wParam is –1, the entire list box is searched from the beginning.
        ///   lParam A pointer to the null-terminated string that contains the prefix for which to search. The search is case independent
        ///   Return Value If the search is successful, the return value is the index of the selected item. If the search is unsuccessful,LB_ERR
        ///   Use this message only with single-selection list boxes. You cannot use it to set or remove a selection in a multiple-selection list box
        /// </summary>
        LBSelectstring = 0x018C,


        /* Either */
        /// <summary>
        ///   Selects a string and scrolls it into view, if necessary. When the new string is selected, the list box removes the highlight from the previously selected string.
        ///   wParam Specifies the zero-based index of the string that is selected. If this parameter is -1, the list box is set to have no selection.
        ///   lParam not used
        /// </summary>
        LBSetcursel = 0x0186,

        /// <summary>
        ///   Finds the first string in a list box that begins with the specified string
        ///   wParam The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it continues searching from the top of the list box back to the item specified by the wParam parameter. If wParam is –1, the entire list box is searched from the beginning.
        ///   lParam A pointer to the null-terminated string that contains the string for which to search. The search is case independent, so this string can contain any combination of uppercase and lowercase letters.
        ///   Return Value-The return value is the index of the matching item, or LB_ERR if the search was unsuccessful.
        /// </summary>
        LBFindstring = 0x018F,

        /// <summary>
        ///   Gets the number of items in a list box
        ///   wParam and lParam-zero
        ///   The return value is the number of items in the list box, or LB_ERR if an error occurs
        /// </summary>
        LBGetcount = 0x018B,

        /// <summary>
        ///   Gets the selection state of an item
        ///   wParam The zero-based index of the item
        ///   lParam This parameter is not used
        ///   Return Value-If an item is selected, the return value is greater than zero; otherwise, it is zero. If an error occurs, the return value is LB_ERR.
        /// </summary>
        LBGetsel = 0x0187,

        /// <summary>
        ///   Gets a string from a list box.
        ///   wParam The zero-based index of the string to retrieve.
        ///   lParam A pointer to the buffer that will receive the string; The buffer must have sufficient space for the string and a terminating null character.
        ///   Return Value length of the string, in TCHARs, excluding the terminating null character.
        /// </summary>
        LBGettext = 0x0189,

        /// <summary>
        ///   Removes all items from a list box
        /// </summary>
        LBResetcontent = 0x0184
    }

    internal enum TabControlMessage
    {
        TCMFirst = 0x1300,

        /// <summary>
        ///   Retrieves the number of tabs in the tab control
        ///   wParam - Must be zero.
        ///   lParam - Must be zero.
        /// </summary>
        TCMGetitemcount = TCMFirst + 4,

        /// <summary>
        ///   Determines the currently selected tab in a tab control.
        ///   wParam - Must be zero.
        ///   lParam - Must be zero.
        /// </summary>
        TCMGetcursel = TCMFirst + 11,

        /// <summary>
        ///   Selects a tab in a tab control
        ///   wParam - Index of the tab to select.
        ///   lParam - Must be zero.
        /// </summary>
        TCMSetcursel = TCMFirst + 12,

        /// <summary>
        ///   Sets the focus to a specified tab in a tab control
        ///   wParam - Index of the tab that gets the focus.
        ///   lParam - Must be zero.
        /// </summary>
        TCMSetcurfocus = TCMFirst + 48
    }
}