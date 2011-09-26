// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;
using ProdUI.Logging;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdWindowNative
    {
        /// <summary>
        /// Close the specified window using the supplied window handle
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        /// <returns>
        /// If the function succeeds, the return value is true, otherwise, false
        /// </returns>
        internal static bool CloseWindowNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            try
            {
                NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_CLOSE, 0, 0);
            }
            catch (Win32Exception)
            {
                return NativeMethods.DestroyWindow(windowHandle);
            }
            return false;
        }

        /// <summary>
        /// Maximizes specified window
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        internal static void MaximizeWindowNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            ShowWindowNative(windowHandle);
            NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOWMAXIMIZED);
            NativeMethods.SetForegroundWindow(windowHandle);
        }

        /// <summary>
        /// Minimizes specified window
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        internal static void MinimizeWindowNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOWMINNOACTIVE);
        }

        /// <summary>
        /// Shows a window in its "normal" state.
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        internal static void ShowWindowNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOWDEFAULT);
        }

        /// <summary>
        /// Retrieves the specified windows title
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        /// <returns>
        /// Title of the specified window, null if failure
        /// </returns>
        internal static string GetWindowTitleNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            StringBuilder sb = new StringBuilder();
            NativeMethods.GetWindowText(windowHandle, sb, sb.Capacity);
            return sb.ToString();
        }

        /// <summary>
        /// sets the title of the specified window
        /// </summary>
        /// <param name="windowHandle">Handle to the window</param>
        /// <param name="newTitle">Text to be used as the new title</param>
        internal static void SetWindowTitleNative(IntPtr windowHandle, string newTitle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SetWindowText(windowHandle, newTitle);

            /* verify it was changed */
            //if (GetWindowTitleNative(windowHandle).CompareTo(newTitle) != 0)
            //{
            //    throw new ProdOperationException("unable to verify title change");
            //}
        }

        /// <summary>
        /// Moves the window using MoveWindow native call.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        internal static void MoveWindowNative(IntPtr windowHandle, double x, double y, double width, double height)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.MoveWindow(windowHandle, (int)x, (int)y, (int)width, (int)height, true);
        }

        /// <summary>
        /// Gets the visual state of the window.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>
        ///   <see cref="WindowVisualState"/>
        /// </returns>
        internal static WindowVisualState GetVisualStateNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            WindowPlacement windowPlacement = new WindowPlacement();
            windowPlacement.Length = (uint)Marshal.SizeOf(windowPlacement);

            NativeMethods.GetWindowPlacement(windowHandle, windowPlacement);
            ShowCmdFlags flag = windowPlacement.ShowCmd;
            return StateConversion((uint)flag);
        }

        /// <summary>
        /// Determines if window the is topmost in the z-order.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>
        ///   <c>true</c> if window is topmost, <c>false</c> otherwise
        /// </returns>
        internal static bool GetIsTopmostNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            IntPtr topHandle = NativeMethods.GetTopWindow(IntPtr.Zero);
            return ((int)topHandle == (int)windowHandle);
        }


        /// <summary>
        /// conversion utility ShowCmdFlags -> WindowVisualState
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>corresponding WindowVisualState</returns>
        private static WindowVisualState StateConversion(uint state)
        {
            switch (state)
            {
                case 2:
                    return WindowVisualState.Minimized;
                case 3:
                    return WindowVisualState.Maximized;
                default:
                    return WindowVisualState.Normal;
            }
        }
    }
}