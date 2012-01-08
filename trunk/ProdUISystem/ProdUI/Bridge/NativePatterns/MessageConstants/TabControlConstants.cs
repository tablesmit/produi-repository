// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdUI.Bridge.NativePatterns
{
    internal enum TabControlMessage
    {
        TCM_FIRST = 0X1300,

        /// <summary>
        /// Retrieves the number of tabs in the tab control
        /// wParam - Must be zero.
        /// lParam - Must be zero.
        /// </summary>
        TCM_GETITEMCOUNT = TCM_FIRST + 4,

        /// <summary>
        /// Determines the currently selected tab in a tab control.
        /// wParam - Must be zero.
        /// lParam - Must be zero.
        /// </summary>
        TCM_GETCURSEL = TCM_FIRST + 11,

        /// <summary>
        /// Selects a tab in a tab control
        /// wParam - Index of the tab to select.
        /// lParam - Must be zero.
        /// </summary>
        TCM_SETCURSEL = TCM_FIRST + 12,

        /// <summary>
        /// Sets the focus to a specified tab in a tab control
        /// wParam - Index of the tab that gets the focus.
        /// lParam - Must be zero.
        /// </summary>
        TCM_SETCURFOCUS = TCM_FIRST + 48
    }
}