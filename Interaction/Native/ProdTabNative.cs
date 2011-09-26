// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Logging;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///     Methods to work with Button controls using the UI Automation framework
    /// </summary>
    internal sealed class ProdTabNative
    {
        /// <summary>
        ///     Gets the tab count.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <returns>
        ///     The number of tabs within the tabControl
        /// </returns>
        internal static int GetTabCount(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int) NativeMethods.SendMessage(windowHandle, (int) TabControlMessage.TCMGETITEMCOUNT, 0, 0);
        }

        /// <summary>
        ///     Gets the selected tab.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <returns>
        ///     The zero based index of the selected TabItem
        /// </returns>
        internal static int GetSelectedTab(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int) NativeMethods.SendMessage(windowHandle, (int) TabControlMessage.TCMGETCURSEL, 0, 0);
        }

        /// <summary>
        ///     Sets the selected tab.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "index">The index.</param>
        internal static void SetSelectedTab(IntPtr windowHandle, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int) TabControlMessage.TCMSETCURSEL, index, 0);
        }
    }
}