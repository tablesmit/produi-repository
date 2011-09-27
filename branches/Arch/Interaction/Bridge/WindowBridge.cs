using System;
using System.Collections.Generic;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Interaction.Bridge
{
    internal static class WindowBridge
    {
        /// <summary>
        /// Gets the window visual state of the window.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The ProdWindow.</param>
        /// <returns></returns>

        internal static WindowVisualState GetWindowVisualStateBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                return UiaGetWindowVisualState(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetWindowVisualState(baseControl);
            }
        }

        private static WindowVisualState UiaGetWindowVisualState(ProdWindow control)
        {
            WindowVisualState retVal = WindowPatternHelper.GetVisualState(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        private static WindowVisualState NativeGetWindowVisualState(ProdWindow control)
        {
            return ProdWindowNative.GetVisualStateNative(control.NativeHandle);
        }

        /// <summary>
        /// Gets whether the current window is modal or not
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The ProdWindow.</param>
        /// <returns>
        ///   <c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </returns>
        internal static bool GetIsModalBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                return UiaGetIsModal(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static bool UiaGetIsModal(ProdWindow control)
        {
            bool retVal = WindowPatternHelper.GetIsModal(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Gets a value whether a window is set to be topmost in the z-order
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The ProdWindow.</param>
        /// <returns>
        ///   <c>true</c> if topmost; otherwise, <c>false</c>.
        /// </returns>
        internal static bool GetIsTopmostBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                return UiaGetIsTopmost(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetIsTopmost(baseControl);
            }
        }

        private static bool UiaGetIsTopmost(ProdWindow control)
        {
            bool retVal = WindowPatternHelper.GetIsTopmost(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        private static bool NativeGetIsTopmost(ProdWindow control)
        {
            return ProdWindowNative.GetIsTopmostNative(control.NativeHandle);
        }

        /// <summary>
        /// Gets the state of the current window.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <returns>
        /// The WindowState
        /// </returns>
        internal static WindowInteractionState GetWindowStateBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                return UiaGetWindowState(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static WindowInteractionState UiaGetWindowState(ProdWindow baseControl)
        {
            WindowInteractionState state = WindowPatternHelper.GetInteractionState(baseControl.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(state.ToString()));
            return state;
        }

        /// <summary>
        /// Gets the specified windows title
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <returns></returns>
        internal static string GetTitleBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                return UiaGetTitle(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetTitle(baseControl);
            }
        }

        private static string UiaGetTitle(ProdWindow baseControl)
        {
            string retVal = baseControl.WindowTitle;
            LogController.ReceiveLogMessage(new LogMessage(retVal));
            return retVal;
        }

        private static string NativeGetTitle(ProdWindow baseControl)
        {
            return ProdWindowNative.GetWindowTitleNative(baseControl.NativeHandle);
        }

        /// <summary>
        /// Sets the specified windows title
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <param name="title">The title.</param>
        internal static void SetTitleBridge(this IWindow theInterface, ProdWindow baseControl, string title)
        {
            try
            {
                NativeSetTitle(baseControl, title);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static void NativeSetTitle(ProdWindow baseControl, string title)
        {
            ProdWindowNative.SetWindowTitleNative(baseControl.NativeHandle, title);
        }

        /// <summary>
        /// Minimizes the current window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static void MinimizeWindowBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                UiaMinimizeWindow(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeMinimizeWindow(baseControl);
            }
        }

        private static void NativeMinimizeWindow(ProdWindow baseControl)
        {
            ProdWindowNative.MinimizeWindowNative(baseControl.NativeHandle);
        }

        private static void UiaMinimizeWindow(ProdWindow baseControl)
        {
            WindowPatternHelper.SetVisualState(baseControl.UIAElement, WindowVisualState.Minimized);
            LogController.ReceiveLogMessage(new LogMessage("minimized"));
        }

        /// <summary>
        /// Maximizes the window bridge.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static void MaximizeWindowBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                UiaMaximizeWindow(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeMaximizeWindow(baseControl);
            }
        }

        private static void NativeMaximizeWindow(ProdWindow baseControl)
        {
            ProdWindowNative.MaximizeWindowNative(baseControl.NativeHandle);
        }

        private static void UiaMaximizeWindow(ProdWindow baseControl)
        {
            WindowPatternHelper.SetVisualState(baseControl.UIAElement, WindowVisualState.Maximized);
            LogController.ReceiveLogMessage(new LogMessage("maximized"));
        }

        /// <summary>
        /// Restores the window bridge.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void RestoreWindowBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                UiaRestoreWindow(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeRestoreWindow(baseControl);
            }
        }

        private static void NativeRestoreWindow(ProdWindow baseControl)
        {
            ProdWindowNative.ShowWindowNative(baseControl.NativeHandle);
        }

        private static void UiaRestoreWindow(ProdWindow baseControl)
        {
            WindowPatternHelper.SetVisualState(baseControl.UIAElement, WindowVisualState.Normal);
            LogController.ReceiveLogMessage(new LogMessage("restored"));
        }

        /// <summary>
        /// Closes the current window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void CloseWindowBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                UiaCloseWindow(baseControl);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeCloseWindow(baseControl);
            }
        }

        private static void NativeCloseWindow(ProdWindow baseControl)
        {
            ProdWindowNative.CloseWindowNative(baseControl.NativeHandle);
        }

        private static void UiaCloseWindow(ProdWindow baseControl)
        {
            LogController.ReceiveLogMessage(new LogMessage("closing"));
            WindowPatternHelper.CloseWindow(baseControl.UIAElement);
        }

        /// <summary>
        /// Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <param name="delay">Time, in milliseconds to wait for an idle state</param>
        /// <returns>
        ///   <c>true</c> if the window has entered the idle state. <c>false</c> if the timeout occurred
        /// </returns>
        internal static bool WaitForInputIdleBridge(this IWindow theInterface, ProdWindow baseControl, int delay)
        {
            try
            {
                return UiaWaitForInputIdle(baseControl, delay);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static bool UiaWaitForInputIdle(ProdWindow baseControl, int delay)
        {
            bool retVal = WindowPatternHelper.WaitForInputIdle(baseControl.UIAElement, delay);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Resize the window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <param name="width">The new width of the window, in pixels</param>
        /// <param name="height">The new height of the window, in pixels</param>
        internal static void ResizeWindowBridge(this IWindow theInterface, ProdWindow baseControl, double width, double height)
        {
            try
            {
                UiaResizeWindow(baseControl, width, height);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeResizeWindow(baseControl, width, height);
            }
        }

        private static void NativeResizeWindow(ProdWindow baseControl, double width, double height)
        {
            double x = baseControl.UIAElement.Current.BoundingRectangle.X;
            double y = baseControl.UIAElement.Current.BoundingRectangle.Y;
            ProdWindowNative.MoveWindowNative(baseControl.NativeHandle, x, y, width, height);
        }

        private static void UiaResizeWindow(ProdWindow baseControl, double width, double height)
        {
            List<object> verboseInformation = new List<object> {
                                                                   "Width = " + width,
                                                                   "Height = " + height
                                                               };
            LogController.ReceiveLogMessage(new LogMessage("resize", verboseInformation));

            TransformPatternHelper.Resize(baseControl.UIAElement, width, height);
        }

        /// <summary>
        /// Moves the window to the specified location
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <param name="x">Absolute screen coordinates of the left side of the window</param>
        /// <param name="y">Absolute screen coordinates of the top of the window</param>
        internal static void MoveWindowBridge(this IWindow theInterface, ProdWindow baseControl, double x, double y)
        {
            try
            {
                UiaMoveWindow(baseControl, x, y);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeMoveWindow(baseControl, x, y);
            }
        }

        private static void NativeMoveWindow(ProdWindow baseControl, double x, double y)
        {
            double width = baseControl.UIAElement.Current.BoundingRectangle.Width;
            double height = baseControl.UIAElement.Current.BoundingRectangle.Height;
            ProdWindowNative.MoveWindowNative(baseControl.NativeHandle, x, y, width, height);
        }

        private static void UiaMoveWindow(ProdWindow baseControl, double x, double y)
        {
            List<object> verboseInformation = new List<object> {
                                                                   "Y = " + y,
                                                                   "X = " + x
                                                               };
            LogController.ReceiveLogMessage(new LogMessage("move", verboseInformation));

            TransformPatternHelper.Move(baseControl.UIAElement, x, y);
        }

        /// <summary>
        /// Rotates the window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        /// <param name="degrees">The number of degrees to rotate the element. A positive number rotates clockwise;
        /// a negative number rotates counterclockwise</param>
        internal static void RotateWindowBridge(this IWindow theInterface, ProdWindow baseControl, double degrees)
        {
            try
            {
                UiaRotateWindow(baseControl, degrees);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        private static void UiaRotateWindow(ProdWindow baseControl, double degrees)
        {
            List<object> verboseInformation = new List<object> {
                                                                   "degrees = " + degrees
                                                               };
            LogController.ReceiveLogMessage(new LogMessage("Rotated", verboseInformation));
            TransformPatternHelper.Rotate(baseControl.UIAElement, degrees);
        }

        /// <summary>
        /// Register to make a window the active window.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="baseControl">The base control.</param>
        internal static void ActivateWindowBridge(this IWindow theInterface, ProdWindow baseControl)
        {
            try
            {
                NativeMethods.ShowWindowAsync(baseControl.NativeHandle, (int)ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync(baseControl.NativeHandle, (int)ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow(baseControl.NativeHandle);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }
    }
}