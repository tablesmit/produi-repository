using System;

namespace ProdUI.Interaction.Native
{
    internal enum ComboBoxMessage
    {
        /// <summary>
        ///     Adds a string to the list box of a combo box. If the combo box does not have the CBS_SORT style,
        ///     the string is added to the end of the list. Otherwise, the string is inserted into the list, and the list is sorted
        /// </summary>
        /// wParam  This parameter is not used
        /// lParam string to be added
        /// Return Value - zero-based index to the string in the list box of the combo box. If an error occurs, the return value is CB_ERR. If insufficient space is available to store the new string, it is CB_ERRSPACE
        CBADDSTRING = 0x0143,
        /// <summary>
        ///     Deletes a string in the list box of a combo box.
        /// </summary>
        /// wParam-The zero-based index of the string to delete
        /// lParam-This parameter is not used
        /// Return Value-count of the strings remaining in the list. If the wParam parameter specifies an index greater than the number of items in the list, the return value is CB_ERR.
        CBDELETESTRING = 0x0144,

        /// <summary>
        ///     Searches the list box of a combo box for an item beginning with the characters in a specified string
        /// </summary>
        /// wParam-The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list box,
        /// it continues from the top of the list box back to the item specified by the wParam parameter.
        /// If wParam is –1, the entire list box is searched from the beginning
        /// lParam- string that contains the characters for which to search. The search is not case sensitive
        /// Return Value- The return value is the zero-based index of the matching item. If the search is unsuccessful, it is CB_ERR
        CBFINDSTRING = 0x014C,
        /// <summary>
        ///     Finds the first list box string in a combo box that matches the string specified in the lParam parameter
        ///     wParam-The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list box,
        ///     it continues from the top of the list box back to the item specified by the wParam parameter.
        ///     If wParam is –1, the entire list box is searched from the beginning
        ///     lParam- string that contains the characters for which to search. The search is not case sensitive
        ///     Return Value- The return value is the zero-based index of the matching item. If the search is unsuccessful, it is CB_ERR
        /// </summary>
        CBFINDSTRINGEXACT = 0x0158,

        /// <summary>
        ///     Gets the starting and ending character positions of the current selection in the edit control of a combo box
        /// </summary>
        CBGETEDITSEL = 0x0140,
        /// <summary>
        ///     Gets the number of items in the list box of a combo box.
        /// </summary>
        CBGETCOUNT = 0x0146,
        /// <summary>
        ///     retrieve the index of the currently selected item, if any, in the list box of a combo box.
        /// </summary>
        CBGETCURSEL = 0x0147,
        /// <summary>
        ///     Gets a string from the list of a combo box.
        /// </summary>
        CBGETLBTEXT = 0x0148,
        /// <summary>
        ///     Gets the length, in characters, of a string in the list of a combo box
        /// </summary>
        CBGETLBTEXTLEN = 0x0149,
        /// <summary>
        ///     Determines whether the list box of a combo box is dropped down
        /// </summary>
        CBGETDROPPEDSTATE = 0X0157,
        CBGETTOPINDEX = 0X015B,
        CBGETITEMDATA = 0X0150,
        CBINSERTSTRING = 0X014A,
        CBLIMITTEXT = 0X0141,
        CBRESETCONTENT = 0X014B,
        CBSELECTSTRING = 0X014D,
        CBSETCURSEL = 0X014E,
        CBSETEDITSEL = 0X0142,
        CBSETITEMDATA = 0X0151,
        CBSETITEMHEIGHT = 0X0153,
        CBSETEXTENDEDUI = 0X0155,
        /// <summary>
        ///     An application sends a CB_SHOWDROPDOWN message to show or hide the list box of a combo box
        /// </summary>
        /// wParam-A BOOL that specifies whether the drop-down list box is to be shown or hidden. A value of TRUE shows the list box; a value of FALSE hides it
        /// lParam- Not used
        /// Return Value- Always TRUE
        CBSHOWDROPDOWN = 0X014F,
        CBINITSTORAGE = 0X0161,
        CBMULTIPLEADDSTRING = 0X0163
    }
}