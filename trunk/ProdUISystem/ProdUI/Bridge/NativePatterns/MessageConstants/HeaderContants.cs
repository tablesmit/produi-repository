namespace ProdUI.Bridge.NativePatterns
{
    internal enum HeaderMessages
    {
        HDM_FIRST = 0x1200,
        /// <summary>
        /// Clears the filter for a given header control
        /// wParam: A column value indicating which filter to clear.
        /// lParam: Must be zero.
        /// Returns an integer. The LRESULT is cast to an integer that indicates TRUE(1) or FALSE(0).
        /// </summary>
        /// <remarks>If the column value is specified as -1, all the filters are cleared, and the HDN_FILTERCHANGE notification is sent only once.</remarks>
        HDM_CLEARFILTER = HDM_FIRST + 24,

        /// <summary>
        /// Creates a semi-transparent version of an item's image for use as a dragging image.
        /// wParam: The zero-based index of the item within the header control. The image assigned to this item is the basis for the transparent image.
        /// lParam: Must be zero.
        /// Returns a handle to an image list that contains the new image as its only element
        /// </summary>
        HDM_CREATEDRAGIMAGE = HDM_FIRST + 16,

        /// <summary>
        /// Deletes an item from a header control.
        /// wParam: An index of the item to delete.
        /// lParam: A flag that specifies how to handle the user's editing changes. Use this flag to specify what to do if the user is in the process of editing the filter when the message is sent
        /// Returns an integer. The LRESULT is cast to an integer that indicates TRUE(1) or FALSE(0)
        /// </summary>
        /// <remarks>TRUE: Discard the changes made by the user.FALSE: Accept the changes made by the user.</remarks>
        HDM_DELETEITEM = HDM_FIRST + 2,

        /// <summary>
        /// Moves the input focus to the edit box when a filter button has the focus.
        /// wParam: A value specifying the column to edit.
        /// lParam: Must be zero.
        /// Returns TRUE if successful, or FALSE otherwise.
        /// </summary>
        HDM_EDITFILTER = HDM_FIRST + 23,

        HDM_GETBITMAPMARGIN = HDM_FIRST + 21,
        HDM_GETFOCUSEDITEM = HDM_FIRST + 27,
        HDM_GETIMAGELIST = HDM_FIRST + 9,
        HDM_GETITEM = HDM_FIRST + 11,
        HDM_GETITEMCOUNT = HDM_FIRST + 0,
        HDM_GETITEMDROPDOWNRECT = HDM_FIRST + 25,
        HDM_GETITEMRECT = HDM_FIRST + 7,
        HDM_GETORDERARRAY = HDM_FIRST + 17,
        HDM_GETOVERFLOWRECT = HDM_FIRST + 26,
        HDM_HITTEST = HDM_FIRST + 6,
        HDM_INSERTITEM = HDM_FIRST + 10,
        HDM_LAYOUT = HDM_FIRST + 5,
        HDM_ORDERTOINDEX = HDM_FIRST + 15,
        HDM_SETBITMAPMARGIN = HDM_FIRST + 20,
        HDM_SETFILTERCHANGETIMEOUT = HDM_FIRST + 22,
        HDM_SETFOCUSEDITEM = HDM_FIRST + 28,
        HDM_SETHOTDIVIDER = HDM_FIRST + 19,
        HDM_SETIMAGELIST = HDM_FIRST + 8,
        HDM_SETITEM = HDM_FIRST + 12,
        HDM_SETORDERARRAY = HDM_FIRST + 18
    }
}