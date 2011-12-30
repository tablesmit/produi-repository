// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Controls.Native
{
    [Flags]
    internal enum TreeViewMessages
    {
        TVFIRST = 0x1100,
        /// <summary>
        /// Inserts a new item in a tree-view control.
        /// wParam = Must be zero.
        /// lParam = Pointer to a TVINSERTSTRUCT structure that specifies the attributes of the tree-view item.
        /// </summary>
        TVMINSERTITEM = TVFIRST + 50,
        /// <summary>
        /// Removes an item and all its children from a tree-view control.
        /// wParam = Must be zero.
        /// lParam = HTREEITEM handle to the item to delete. If lParam is set to TVI_ROOT or to NULL, all items are deleted.
        /// </summary>
        TVMDELETEITEM = TVFIRST + 1,
        /// <summary>
        /// The TVM_EXPAND message expands or collapses the list of child items associated with the specified parent item, if any
        /// wParam = Action flag "TreeViewExpandArgs"
        /// lParam = NativeWindowHandle to the parent item to expand or collapse
        /// </summary>
        TVMEXPAND = TVFIRST + 2,
        /// <summary>
        /// Retrieves a count of the items in a tree-view control
        /// wParam = Must be zero.
        /// lParam = Must be zero.
        /// </summary>
        TVMGETCOUNT = TVFIRST + 5,
        /// <summary>
        /// Begins in-place editing of the specified item's text, replacing the text of the item with a single-line edit control containing the text.
        /// This message implicitly selects and focuses the specified item
        /// wParam = Must be zero.
        /// lParam = NativeWindowHandle to the item to edit.
        /// </summary>
        TVMEDITLABEL = TVFIRST + 65,
        /// <summary>
        /// Selects the specified tree-view item, scrolls the item into view, or redraws the item in the style used to indicate the target of a drag-and-drop operation
        /// wParam = Action flag -&gt; TreeViewSelectArgs
        /// lParam = NativeWindowHandle to an item. If lParam is NULL, the control is set to have no selected item
        /// </summary>
        TVMSELECTITEM = TVFIRST + 11,
        /// <summary>
        /// Ensures that a tree-view item is visible, expanding the parent item or scrolling the tree-view control, if necessary.
        /// wParam = Must be zero
        /// lParam = NativeWindowHandle to the item
        /// </summary>
        TVMENSUREVISIBLE = TVFIRST + 20,
        /// <summary>
        /// Retrieves some or all of a tree-view item's attributes. http://msdn.microsoft.com/en-us/library/bb773459(v=VS.85).aspx
        /// wParam = Must be zero.
        /// lParam = Pointer to a TVITEMEX structure.
        /// </summary>
        TVMGETITEM = TVFIRST + 62
    }

    /// <summary>
    ///     Action flag used in conjunction with TVM_EXPAND Message
    /// </summary>
    internal enum TreeViewExpandArg
    {
        /// <summary>
        /// Collapses the list
        /// </summary>
        TVE_COLLAPSE = 0x0001,
        /// <summary>
        /// Expands the list
        /// </summary>
        TVE_EXPAND = 0x0002,
        /// <summary>
        /// Collapses the list if it is expanded or expands it if it is collapsed
        /// </summary>
        TVE_TOGGLE = 0x0003,
        /// <summary>
        /// Partially expands the list. In this state the child items are visible and the parent item's plus sign (+),
        /// indicating that it can be expanded, is displayed. This flag must be used in combination with the TVE_EXPAND flag
        /// </summary>
        TVE_EXPANDPARTIAL = 0x4000,
        /// <summary>
        /// Collapses the list and removes the child items. The TVIS_EXPANDEDONCE state flag is reset. This flag must be used with the TVE_COLLAPSE flag
        /// </summary>
        TVE_COLLAPSERESET = 0x8000
    }

    /// <summary>
    ///     Action flag used in conjunction with TVM_SELECTITEM Message
    /// </summary>
    internal enum TreeViewSelectArg
    {
        /// <summary>
        /// Ensures that the specified item is visible, and, if possible, displays it at the top of the control's window
        /// </summary>
        TVGN_FIRSTVISIBLE = 0x0005,
        /// <summary>
        /// Redraws the specified item in the style used to indicate the target of a drag-and-drop operation
        /// </summary>
        TVGN_DROPHILITE = 0x0008,
        /// <summary>
        /// Sets the selection to the specified item
        /// </summary>
        TVGN_CARET = 0x0009,
        /// <summary>
        /// Windows XP and later: When a single item is selected, ensures that the TreeView does not expand the children of that item.
        /// This is valid only if used with the TVGN_CARET flag.
        /// </summary>
        TVSI_NOSINGLEEXPAND = 0x8000
    }

    internal enum TreeViewStyle
    {
        TVS_HASBUTTONS = 0x0001,
        TVS_HASLINES = 0x0002,
        TVS_LINESATROOT = 0x0004,
        TVS_EDITLABELS = 0x0008,
        TVS_DISABLEDRAGDROP = 0x0010,
        TVS_SHOWSELALWAYS = 0x0020,
        TVS_NOTOOLTIPS = 0x0080,
        TVS_CHECKBOXES = 0x0100,
        TVS_TRACKSELECT = 0x0200,
        TVS_SINGLEEXPAND = 0x0400
    }
}