// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdUI.Interaction.Native
{
    internal enum ListboxMessage
    {
        /* Multi-Select Only */
        /// <summary>
        ///     Selects an item in a multiple-selection list box and, if necessary, scrolls the item into view
        ///     wParam  Specifies how to set the selection. If this parameter is TRUE, the item is selected and highlighted; if it is FALSE, the highlight is removed and the item is no longer selected.
        ///     lParam Specifies the zero-based index of the item to set. If this parameter is –1, the selection is added to or removed from all items, depending on the value of wParam, and no scrolling occurs.
        ///     Return Value-If an error occurs, the return value is LB_ERR.
        ///     Remarks-Use this message only with multiple-selection list boxes.
        /// </summary>
        LBSETSEL = 0x0185,

        /// <summary>
        ///     Fills a buffer with an array of integers that specify the item numbers of selected items in a multiple-selection list box
        ///     wParam- The maximum number of selected items whose item numbers are to be placed in the buffer.
        ///     lParam-A pointer to a buffer large enough for the number of integers specified by the wParam parameter.
        ///     Return-The return value is the number of items placed in the buffer. If the list box is a single-selection list box, the return value is LB_ERR.
        /// </summary>
        LBGETSELITEMS = 0x0191,

        /// <summary>
        ///     Gets the total number of selected items in a multiple-selection list box
        ///     wParam and lParam-Not used; must be zero.
        ///     Return Value-The return value is the count of selected items in the list box. If the list box is a single-selection list box, the return value is LB_ERR.
        /// </summary>
        LBGETSELCOUNT = 0x0190,

        /* Single Select Only */
        /// <summary>
        ///     Gets the index of the currently selected item, if any, in a single-selection list box
        ///     wParam and lParam Not used; must be zero.
        ///     Return Value-In a single-selection list box, the return value is the zero-based index of the currently selected item. If there is no selection, the return value is LB_ERR.
        /// </summary>
        LBGETCURSEL = 0x0188,

        /// <summary>
        ///     wParam The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it continues from the top of the list box back to the item specified by the wParam parameter. If wParam is –1, the entire list box is searched from the beginning.
        ///     lParam A pointer to the null-terminated string that contains the prefix for which to search. The search is case independent
        ///     Return Value If the search is successful, the return value is the index of the selected item. If the search is unsuccessful,LB_ERR
        ///     Use this message only with single-selection list boxes. You cannot use it to set or remove a selection in a multiple-selection list box
        /// </summary>
        LBSELECTSTRING = 0x018C,

        /* Either */
        /// <summary>
        ///     Selects a string and scrolls it into view, if necessary. When the new string is selected, the list box removes the highlight from the previously selected string.
        ///     wParam Specifies the zero-based index of the string that is selected. If this parameter is -1, the list box is set to have no selection.
        ///     lParam not used
        /// </summary>
        LBSETCURSEL = 0x0186,

        /// <summary>
        ///     Finds the first string in a list box that begins with the specified string
        ///     wParam The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it continues searching from the top of the list box back to the item specified by the wParam parameter. If wParam is –1, the entire list box is searched from the beginning.
        ///     lParam A pointer to the null-terminated string that contains the string for which to search. The search is case independent, so this string can contain any combination of uppercase and lowercase letters.
        ///     Return Value-The return value is the index of the matching item, or LB_ERR if the search was unsuccessful.
        /// </summary>
        LBFINDSTRING = 0x018F,

        /// <summary>
        ///     Gets the number of items in a list box
        ///     wParam and lParam-zero
        ///     The return value is the number of items in the list box, or LB_ERR if an error occurs
        /// </summary>
        LBGETCOUNT = 0x018B,

        /// <summary>
        ///     Gets the selection state of an item
        ///     wParam The zero-based index of the item
        ///     lParam This parameter is not used
        ///     Return Value-If an item is selected, the return value is greater than zero; otherwise, it is zero. If an error occurs, the return value is LB_ERR.
        /// </summary>
        LBGETSEL = 0x0187,

        /// <summary>
        ///     Gets a string from a list box.
        ///     wParam The zero-based index of the string to retrieve.
        ///     lParam A pointer to the buffer that will receive the string; The buffer must have sufficient space for the string and a terminating null character.
        ///     Return Value length of the string, in TCHARs, excluding the terminating null character.
        /// </summary>
        LBGETTEXT = 0x0189,

        /// <summary>
        ///     Removes all items from a list box
        /// </summary>
        LBRESETCONTENT = 0x0184,

        /// <summary>
        ///     Gets the application-defined value associated with the specified list box item.
        ///     wParam The index of the item
        ///     lParam This parameter is not used
        /// </summary>
        LBGETITEMDATA = 0x0199
    }
}