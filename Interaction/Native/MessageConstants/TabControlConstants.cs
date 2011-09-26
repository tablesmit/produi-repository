// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do

namespace ProdUI.Interaction.Native
{
    internal enum TabControlMessage
    {
        TCMFIRST = 0X1300,

        /// <summary>
        ///     Retrieves the number of tabs in the tab control
        ///     wParam - Must be zero.
        ///     lParam - Must be zero.
        /// </summary>
        TCMGETITEMCOUNT = TCMFIRST + 4,

        /// <summary>
        ///     Determines the currently selected tab in a tab control.
        ///     wParam - Must be zero.
        ///     lParam - Must be zero.
        /// </summary>
        TCMGETCURSEL = TCMFIRST + 11,

        /// <summary>
        ///     Selects a tab in a tab control
        ///     wParam - Index of the tab to select.
        ///     lParam - Must be zero.
        /// </summary>
        TCMSETCURSEL = TCMFIRST + 12,

        /// <summary>
        ///     Sets the focus to a specified tab in a tab control
        ///     wParam - Index of the tab that gets the focus.
        ///     lParam - Must be zero.
        /// </summary>
        TCMSETCURFOCUS = TCMFIRST + 48
    }
}