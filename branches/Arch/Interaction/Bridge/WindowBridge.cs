using System;
using System.Collections.Generic;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Interaction.Bridge
{
    internal static class WindowBridge
    {

        /// <summary>
        /// Gets the window visual state of the window.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The ProdWindow.</param>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static WindowVisualState GetWindowVisualStateBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                return UiaGetWindowVisualState(BaseControl);
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
                return NativeGetWindowVisualState(BaseControl);
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
        /// <param name="BaseControl">The ProdWindow.</param>
        /// <returns>
        ///   <c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static bool GetIsModalBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                return UiaGetIsModal(BaseControl);
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
        /// <param name="BaseControl">The ProdWindow.</param>
        /// <returns>
        ///   <c>true</c> if topmost; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static bool GetIsTopmostBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                return UiaGetIsTopmost(BaseControl);
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
                return NativeGetIsTopmost(BaseControl);
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
        /// <param name="BaseControl">The base control.</param>
        /// <returns>
        /// The WindowState
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static WindowInteractionState GetWindowStateBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                return UiaGetWindowState(BaseControl);
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

        private static WindowInteractionState UiaGetWindowState(ProdWindow BaseControl)
        {
            WindowInteractionState state = WindowPatternHelper.GetInteractionState(BaseControl.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(state.ToString()));
            return state;
        }




        /// <summary>
        /// Gets the specified windows title
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static string GetTitleBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                return UiaGetTitle(BaseControl);
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
                return NativeGetTitle(BaseControl);
            }
        }

        private static string UiaGetTitle(ProdWindow BaseControl)
        {
            string retVal = BaseControl.WindowTitle;
            LogController.ReceiveLogMessage(new LogMessage(retVal));
            return retVal;
        }

        private static string NativeGetTitle(ProdWindow BaseControl)
        {
            return ProdWindowNative.GetWindowTitleNative(BaseControl.NativeHandle);
        }




        /// <summary>
        /// Sets the specified windows title
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <param name="title">The title.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SetTitleBridge(this IWindow theInterface, ProdWindow BaseControl, string title)
        {
            try
            {
                NativeSetTitle(BaseControl, title);
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

        private static void NativeSetTitle(ProdWindow BaseControl, string title)
        {
            ProdWindowNative.SetWindowTitleNative(BaseControl.NativeHandle, title);
        }




        /// <summary>
        /// Minimizes the current window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void MinimizeWindowBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                UiaMinimizeWindow(BaseControl);
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
                NativeMinimizeWindow(BaseControl);
            }

        }

        private static void NativeMinimizeWindow(ProdWindow BaseControl)
        {
            ProdWindowNative.MinimizeWindowNative(BaseControl.NativeHandle);
        }

        private static int UiaMinimizeWindow(ProdWindow BaseControl)
        {
            int retVal = WindowPatternHelper.SetVisualState(BaseControl.UIAElement, WindowVisualState.Minimized);
            LogController.ReceiveLogMessage(new LogMessage("minimized"));
            return retVal;
        }



        /// <summary>
        /// Maximizes the window bridge.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void MaximizeWindowBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                UiaMaximizeWindow(BaseControl);
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
                NativeMaximizeWindow(BaseControl);
            }

        }

        private static void NativeMaximizeWindow(ProdWindow BaseControl)
        {
            ProdWindowNative.MaximizeWindowNative(BaseControl.NativeHandle);
        }

        private static int UiaMaximizeWindow(ProdWindow BaseControl)
        {
            int retVal = WindowPatternHelper.SetVisualState(BaseControl.UIAElement, WindowVisualState.Maximized);
            LogController.ReceiveLogMessage(new LogMessage("maximized"));
            return retVal;
        }



        /// <summary>
        /// Restores the window bridge.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void RestoreWindowBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                UiaRestoreWindow(BaseControl);
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
                NativeRestoreWindow(BaseControl);
            }

        }

        private static void NativeRestoreWindow(ProdWindow BaseControl)
        {
            ProdWindowNative.ShowWindowNative(BaseControl.NativeHandle);
        }

        private static int UiaRestoreWindow(ProdWindow BaseControl)
        {
            int retVal = WindowPatternHelper.SetVisualState(BaseControl.UIAElement, WindowVisualState.Normal);
            LogController.ReceiveLogMessage(new LogMessage("restored"));
            return retVal;
        }



        /// <summary>
        /// Closes the current window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void CloseWindowBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                UiaCloseWindow(BaseControl);
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
                NativeCloseWindow(BaseControl);
            }
        }

        private static void NativeCloseWindow(ProdWindow BaseControl)
        {
            ProdWindowNative.CloseWindowNative(BaseControl.NativeHandle);
        }

        private static void UiaCloseWindow(ProdWindow BaseControl)
        {
            LogController.ReceiveLogMessage(new LogMessage("closing"));
            WindowPatternHelper.CloseWindow(BaseControl.UIAElement);
        }



        /// <summary>
        /// Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <param name="delay">Time, in milliseconds to wait for an idle state</param>
        /// <returns>
        ///   <c>true</c> if the window has entered the idle state. <c>false</c> if the timeout occurred
        /// </returns>
        internal static bool WaitForInputIdleBridge(this IWindow theInterface, ProdWindow BaseControl, int delay)
        {
            try
            {
                return UiaWaitForInputIdle(BaseControl, delay);
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

        private static bool UiaWaitForInputIdle(ProdWindow BaseControl, int delay)
        {
            bool retVal = WindowPatternHelper.WaitForInputIdle(BaseControl.UIAElement, delay);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }




        /// <summary>
        /// Resize the window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <param name="width">The new width of the window, in pixels</param>
        /// <param name="height">The new height of the window, in pixels</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void ResizeWindowBridge(this IWindow theInterface, ProdWindow BaseControl, double width, double height)
        {
            try
            {
                UiaResizeWindow(BaseControl, width, height);
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
                NativeResizeWindow(BaseControl, width, height);
            }

        }

        private static void NativeResizeWindow(ProdWindow BaseControl, double width, double height)
        {
            double x = BaseControl.UIAElement.Current.BoundingRectangle.X;
            double y = BaseControl.UIAElement.Current.BoundingRectangle.Y;
            ProdWindowNative.MoveWindowNative(BaseControl.NativeHandle, x, y, width, height);
        }

        private static void UiaResizeWindow(ProdWindow BaseControl, double width, double height)
        {
            List<object> VerboseInformation = new List<object>();
            VerboseInformation.Add("Width = " + width);
            VerboseInformation.Add("Height = " + height);
            LogController.ReceiveLogMessage(new LogMessage("resize", VerboseInformation));

            TransformPatternHelper.Resize(BaseControl.UIAElement, width, height);
        }




        /// <summary>
        /// Moves the window to the specified location
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <param name="x">Absolute screen coordinates of the left side of the window</param>
        /// <param name="y">Absolute screen coordinates of the top of the window</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void MoveWindowBridge(this IWindow theInterface, ProdWindow BaseControl, double x, double y)
        {
            try
            {
                UiaMoveWindow(BaseControl, x, y);
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
                NativeMoveWindow(BaseControl, x, y);
            }
        }

        private static void NativeMoveWindow(ProdWindow BaseControl, double x, double y)
        {
            double width = BaseControl.UIAElement.Current.BoundingRectangle.Width;
            double height = BaseControl.UIAElement.Current.BoundingRectangle.Height;
            ProdWindowNative.MoveWindowNative(BaseControl.NativeHandle, x, y, width, height);
        }

        private static void UiaMoveWindow(ProdWindow BaseControl, double x, double y)
        {
            List<object> VerboseInformation = new List<object>();
            VerboseInformation.Add("Y = " + y);
            VerboseInformation.Add("X = " + x);
            LogController.ReceiveLogMessage(new LogMessage("move", VerboseInformation));

            TransformPatternHelper.Move(BaseControl.UIAElement, x, y);
        }



        /// <summary>
        /// Rotates the window
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="BaseControl">The base control.</param>
        /// <param name="degrees">The number of degrees to rotate the element. A positive number rotates clockwise;
        /// a negative number rotates counterclockwise</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static void RotateWindowBridge(this IWindow theInterface, ProdWindow BaseControl, double degrees)
        {
            try
            {
                UiaRotateWindow(BaseControl, degrees);
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

        private static void UiaRotateWindow(ProdWindow BaseControl, double degrees)
        {
            List<object> VerboseInformation = new List<object>();
            VerboseInformation.Add("degrees = " + degrees);
            LogController.ReceiveLogMessage(new LogMessage("Rotated", VerboseInformation));
            TransformPatternHelper.Rotate(BaseControl.UIAElement, degrees);
        }




        /// <summary>
        ///     Register to make a window the active window.
        /// </summary>
        /// <exception cref = "InvalidOperationException">The exception that is thrown when a method call is invalid for the object's current state</exception>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <exception cref = "Win32Exception">Throws an exception for a Win32 error code</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void ActivateWindowBridge(this IWindow theInterface, ProdWindow BaseControl)
        {
            try
            {
                NativeMethods.ShowWindowAsync(BaseControl.NativeHandle, (int)ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync(BaseControl.NativeHandle, (int)ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow(BaseControl.NativeHandle);
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
