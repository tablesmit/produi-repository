// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.ComponentModel;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        #region Static Methods

        /// <summary>
        ///     Register to make a window the active window.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <exception cref = "InvalidOperationException">The exception that is thrown when a method call is invalid for the object's current state</exception>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <exception cref = "Win32Exception">Throws an exception for a Win32 error code</exception>
        [ProdLogging(LoggingLevels.Warn, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void WindowActivate(IntPtr windowHandle)
        {
            try
            {
                NativeMethods.ShowWindowAsync(windowHandle, (int) ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync(windowHandle, (int) ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow(windowHandle);
            }
            catch (InvalidOperationException ierr)
            {
                throw new ProdOperationException(ierr.Message, ierr);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (Win32Exception werr)
            {
                throw new ProdOperationException(werr.Message, werr);
            }
        }

        /// <summary>
        ///     Closes the specified window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowClose(IntPtr windowHandle)
        {
            int ret = WindowPatternHelper.CloseWindow(AutomationElement.FromHandle(windowHandle));
            if (ret == -1)
            {
                ProdWindowNative.CloseWindow(windowHandle);
            }
        }

        /// <summary>
        ///     Minimizes the current window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowMinimize(IntPtr windowHandle)
        {
            int ret = WindowPatternHelper.SetVisualState(AutomationElement.FromHandle(windowHandle), WindowVisualState.Minimized);
            if (ret == -1)
            {
                ProdWindowNative.MinimizeWindow(windowHandle);
            }
        }

        /// <summary>
        ///     Maximizes the current window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowMaximize(IntPtr windowHandle)
        {
            int ret = WindowPatternHelper.SetVisualState(AutomationElement.FromHandle(windowHandle), WindowVisualState.Maximized);
            if (ret == -1)
            {
                ProdWindowNative.MaximizeWindow(windowHandle);
            }
        }

        /// <summary>
        ///     Restores current window to its original dimensions
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowRestore(IntPtr windowHandle)
        {
            int ret = WindowPatternHelper.SetVisualState(AutomationElement.FromHandle(windowHandle), WindowVisualState.Normal);
            if (ret == -1)
            {
                ProdWindowNative.ShowWindow(windowHandle);
            }
        }

        /// <summary>
        ///     Gets whether the current window is modal or not
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <returns>
        ///     True if window is modal, false otherwise
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool WindowGetModal(IntPtr windowHandle)
        {
            try
            {
                return WindowPatternHelper.GetIsModal(AutomationElement.FromHandle(windowHandle));
            }
            catch (InvalidOperationException ex)
            {
                throw new ProdOperationException(ex);
            }
        }

        /// <summary>
        ///     Gets a value whether a window is set to be topmost in the z-order
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <returns>
        ///     True if window is topmost, false otherwise
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool WindowIsTopmost(IntPtr windowHandle)
        {
            try
            {
                return WindowPatternHelper.GetIsTopmost(AutomationElement.FromHandle(windowHandle));
            }
            catch (InvalidOperationException ex)
            {
                throw new ProdOperationException(ex);
            }
        }

        /// <summary>
        ///     Gets the WindowVisualState of the current window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <returns>
        ///     The <see cref = "WindowVisualState" />
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static WindowVisualState WindowGetVisualState(IntPtr windowHandle)
        {
            return WindowPatternHelper.GetVisualState(AutomationElement.FromHandle(windowHandle));
        }

        /// <summary>
        ///     gets the current ready-state of the window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <returns>
        ///     The current <see cref = "WindowState" />
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static WindowState WindowGetWindowState(IntPtr windowHandle)
        {
            WindowInteractionState state = WindowPatternHelper.GetInteractionState(AutomationElement.FromHandle(windowHandle));
            return ConvertFromInteractionState(state);
        }

        /// <summary>
        ///     Gets the specified windows title
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to target window</param>
        /// <returns>
        ///     The specified Windows Title
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static string WindowGetTitle(IntPtr windowHandle)
        {
            return ProdWindowNative.GetWindowTitle(windowHandle);
        }

        /// <summary>
        ///     Sets the specified windows title
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <param name = "newText">The text to set the title to</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowSetTitle(IntPtr windowHandle, string newText)
        {
            ProdWindowNative.SetWindowTitle(windowHandle, newText);
        }

        /// <summary>
        ///     Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <param name = "delay">Time, in milliseconds to wait for an idle state</param>
        /// <returns>
        ///     true if the window has entered the idle state; false if the timeout occurred
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static bool WindowWaitForIdle(IntPtr windowHandle, int delay)
        {
            try
            {
                bool retVal = WindowPatternHelper.WaitForInputIdle(AutomationElement.FromHandle(windowHandle), delay);
                return retVal;
            }
            catch (InvalidOperationException ex)
            {
                throw new ProdOperationException(ex);
            }
        }

        /// <summary>
        ///     Moves window to specified location
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <param name = "x">Absolute screen coordinates of the left side of the window</param>
        /// <param name = "y">Absolute screen coordinates of the top of the window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowMove(IntPtr windowHandle, double x, double y)
        {
            int ret = TransformPatternHelper.Move(AutomationElement.FromHandle(windowHandle), x, y);

            if (ret != -1)
            {
                return;
            }

            double width = AutomationElement.FromHandle(windowHandle).Current.BoundingRectangle.Width;
            double height = AutomationElement.FromHandle(windowHandle).Current.BoundingRectangle.Height;
            ProdWindowNative.MoveWindowNative(windowHandle, x, y, width, height);
        }

        /// <summary>
        ///     Moves the window a specified offset of its current location
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <param name = "xOffset">how far, in pixels, to move the windows left side</param>
        /// <param name = "yOffset">how far, in pixels, to move the windows top</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowMoveFromCurrent(IntPtr windowHandle, double xOffset, double yOffset)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Rotates the window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <param name = "degrees">The number of degrees to rotate the element. A positive number rotates clockwise; a negative number rotates counterclockwise</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowRotate(IntPtr windowHandle, double degrees)
        {
            TransformPatternHelper.Rotate(AutomationElement.FromHandle(windowHandle), degrees);
        }

        /// <summary>
        ///     Resizes the window
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to window</param>
        /// <param name = "width">The new width of the window, in pixels</param>
        /// <param name = "height">The new height of the window, in pixels</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static void WindowResize(IntPtr windowHandle, double width, double height)
        {
            int ret = TransformPatternHelper.Resize(AutomationElement.FromHandle(windowHandle), width, height);

            if (ret != -1)
            {
                return;
            }

            double x = AutomationElement.FromHandle(windowHandle).Current.BoundingRectangle.X;
            double y = AutomationElement.FromHandle(windowHandle).Current.BoundingRectangle.Y;
            ProdWindowNative.MoveWindowNative(windowHandle, x, y, width, height);
        }

        /* Private */

        /// <summary>
        ///     Converts a WindowInteractionState enum to a WindowState value.
        /// </summary>
        /// <param name = "state">The WindowInteractionState to convert from</param>
        /// <returns>
        ///     the corresponding WindowState
        /// </returns>
        internal static WindowState ConvertFromInteractionState(WindowInteractionState state)
        {
            switch (state)
            {
                case WindowInteractionState.Running:
                    return WindowState.Running;
                case WindowInteractionState.Closing:
                    return WindowState.NotResponding;
                case WindowInteractionState.ReadyForUserInteraction:
                    return WindowState.Ready;
                case WindowInteractionState.BlockedByModalWindow:
                    return WindowState.Blocked;
                case WindowInteractionState.NotResponding:
                    return WindowState.NotResponding;
                default:
                    return WindowState.Running;
            }
        }

        /// <summary>
        ///     Gets the handle to a window.
        /// </summary>
        /// <param name = "partialTitle">The partial title.</param>
        /// <returns>The window handle</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public static IntPtr WindowGetHandle(string partialTitle)
        {
            return InternalUtilities.FindWindowPartial(partialTitle);
        }

        #endregion
    }
}