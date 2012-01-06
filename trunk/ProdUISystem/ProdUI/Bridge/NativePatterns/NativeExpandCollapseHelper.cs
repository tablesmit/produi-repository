
using System;
using System.Windows.Automation;
using ProdUI.Adapters;
namespace ProdUI.Bridge.NativePatterns
{
    internal class NativeExpandCollapseHelper
    {
        const int TVFIRST = 0x1100;

        /// <summary>
        /// The TVM_EXPAND message expands or collapses the list of child items associated with the specified parent item, if any
        /// wParam = Action flag "TreeViewExpandArgs"
        /// lParam = NativeWindowHandle to the parent item to expand or collapse
        /// </summary>
        int TVMEXPAND = TVFIRST + 2;

        /// <summary>
        ///wParam - Handle to the item. 
        ///lParam - Mask used to specify the states to query for. It is equivalent to the stateMask member of TVITEMEX.
        /// </summary>
        int TVMGETITEMSTATE = TVFIRST + 39;



        /// <summary>
        /// Expands the specified h WND.
        /// </summary>
        /// <param name="hWnd">The handle to the parent window.</param>
        /// <param name="itemHandle">The item handle.</param>
        internal void Expand(BaseProdControl control)
        {
            NativeMethods.SendMessage(control.,TVMEXPAND,(int)TreeViewExpandArg.TVE_EXPAND,(int)itemHandle);
        }

        internal bool Collapse(IntPtr hWnd)
        {
            NativeMethods.SendMessage(hWnd,TVMEXPAND,(int)TreeViewExpandArg.TVE_COLLAPSE,(int)itemHandle);
        }

        internal ExpandCollapseState ExaPandCollapseState(IntPtr hWnd)
        {
        }

    }

     /// <summary>
    ///     Action flag used in conjunction with TVM_EXPAND Message
    /// </summary>
    private enum TreeViewExpandArg
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

    [Flags]
    private enum TreeViewItemStates
    {
        TVIS_EXPANDED      =     0x0020,
        TVIS_EXPANDEDONCE    =  0x0040,
        TVIS_EXPANDPARTIAL   =   0x0080
    }
}


}
