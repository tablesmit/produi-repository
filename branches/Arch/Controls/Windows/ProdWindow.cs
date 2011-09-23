// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Automation;
using ProdUI.Configuration;
using ProdUI.Controls.Static;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Provides mechanisms to work with container windows
    /// </summary>
    public sealed class ProdWindow
    {
        internal ProdSession AttachedSession;
        internal string LogText;
        internal IntPtr NativeHandle;
        internal AutomationElement UIAElement;
        internal List<object> VerboseInformation;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls.ProdWindow Class from the specified handle
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="session">The session.</param>
        public ProdWindow(IntPtr windowHandle, ProdSession session)
        {
            try
            {
                UIAElement = AutomationElement.FromHandle(windowHandle);
                NativeHandle = windowHandle;

                /* gotta check to make sure its a window */
                if (!(bool) UIAElement.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
                {
                    throw new ProdOperationException("Control does not support WindowPattern");
                }
                AttachedSession = session;
            }
            catch (ElementNotAvailableException ex)
            {
                throw new ProdOperationException(ex);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls.ProdWindow Class from the specified partial title
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <param name="session">The session.</param>
        /// <remarks>
        /// If window cannot be found, an error will be thrown
        /// </remarks>
        public ProdWindow(string partialTitle, ProdSession session)
        {
            try
            {
                IntPtr handle = InternalUtilities.FindWindowPartial(partialTitle);
                UIAElement = AutomationElement.FromHandle(handle);
                NativeHandle = handle;

                /* Check to make sure its a window */
                if (!(bool) UIAElement.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
                {
                    throw new ProdOperationException("Control does not support WindowPattern");
                }
            }
            catch (ElementNotAvailableException ex)
            {
                throw new ProdOperationException(ex);
            }
            AttachedSession = session;
        }

        #endregion

        /// <summary>
        ///     Gets the WindowVisualState of the current window
        /// </summary>
        /// <returns></returns>
        /// <value>
        ///     The visual state of the window.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public WindowVisualState GetWindowVisualState()
        {
            WindowVisualState retVal = WindowPatternHelper.GetVisualState(AutomationElement.FromHandle((IntPtr) UIAElement.Cached.NativeWindowHandle));

            LogText = "Visual State: " + retVal;
            LogMessage();

            return retVal;
        }

        /// <summary>
        ///     Gets whether the current window is modal or not
        /// </summary>
        /// <returns></returns>
        /// <value>
        ///     <c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetIsModal()
        {
            bool retVal = WindowPatternHelper.GetIsModal(UIAElement);

            LogText = "Is modal: " + retVal;
            LogMessage();

            return retVal;
        }

        /// <summary>
        ///     Gets a value whether a window is set to be topmost in the z-order
        /// </summary>
        /// <returns></returns>
        /// <value>
        ///     <c>true</c> if topmost; otherwise, <c>false</c>.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetIsTopmost()
        {
            bool retVal = WindowPatternHelper.GetIsTopmost(UIAElement);

            LogText = "Is topmost: " + retVal;
            LogMessage();

            return retVal;
        }

        /// <summary>
        ///     Gets the state of the current window.
        /// </summary>
        /// <returns>The WindowState</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public WindowState GetWinState()
        {
            WindowInteractionState state = WindowPatternHelper.GetInteractionState(UIAElement);

            LogText = "WindowState: " + state;
            LogMessage();

            return Prod.ConvertFromInteractionState(state);
        }

        /// <summary>
        ///     Gets the specified windows title
        /// </summary>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetTitle()
        {
            string retVal = Prod.WindowGetTitle((IntPtr) UIAElement.Cached.NativeWindowHandle);

            LogText = "Title: " + retVal;
            LogMessage();

            return retVal;
        }

        /// <summary>
        ///     Sets the specified windows title
        /// </summary>
        /// <param name = "newTitle">The new title.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetTitle(string newTitle)
        {
            Prod.WindowSetTitle((IntPtr) UIAElement.Cached.NativeWindowHandle, newTitle);

            LogText = "Title: " + newTitle;
            LogMessage();
        }

        /// <summary>
        ///     Minimizes the current window
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Minimize()
        {
            int ret = WindowPatternHelper.SetVisualState(UIAElement, WindowVisualState.Minimized);
            if (ret == -1)
            {
                ProdWindowNative.MinimizeWindow((IntPtr) UIAElement.Cached.NativeWindowHandle);
            }

            LogText = "Window minimized";
            LogMessage();
        }

        /// <summary>
        ///     Maximizes the current window
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Maximize()
        {
            int ret = WindowPatternHelper.SetVisualState(UIAElement, WindowVisualState.Maximized);
            if (ret == -1)
            {
                ProdWindowNative.MaximizeWindow((IntPtr) UIAElement.Cached.NativeWindowHandle);
            }

            LogText = "Window maximized";
            LogMessage();
        }

        /// <summary>
        ///     Restores current window to its original dimensions
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Restore()
        {
            int ret = WindowPatternHelper.SetVisualState(UIAElement, WindowVisualState.Normal);
            if (ret == -1)
            {
                ProdWindowNative.ShowWindow((IntPtr) UIAElement.Cached.NativeWindowHandle);
            }

            LogText = "Window restored";
            LogMessage();
        }

        /// <summary>
        ///     Closes the current window
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Close()
        {
            int ret = WindowPatternHelper.CloseWindow(UIAElement);
            if (ret == -1)
            {
                ProdWindowNative.CloseWindow((IntPtr) UIAElement.Cached.NativeWindowHandle);
            }

            LogText = "Window closed";
            LogMessage();
        }

        /// <summary>
        ///     Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first
        /// </summary>
        /// <param name = "delay">Time, in milliseconds to wait for an idle state</param>
        /// <returns>
        ///     <c>true</c> if the window has entered the idle state. <c>false</c> if the timeout occurred
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public bool WaitForInputIdle(int delay)
        {
            bool ret = WindowPatternHelper.WaitForInputIdle(UIAElement, delay);
            return ret;
        }

        /// <summary>
        ///     Resize the window
        /// </summary>
        /// <param name = "width">The new width of the window, in pixels</param>
        /// <param name = "height">The new height of the window, in pixels</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Resize(double width, double height)
        {
            int ret = TransformPatternHelper.Resize(UIAElement, width, height);

            if (ret == -1)
            {
                if (ret == -1)
                {
                    double x = UIAElement.Current.BoundingRectangle.X;
                    double y = UIAElement.Current.BoundingRectangle.Y;
                    ProdWindowNative.MoveWindowNative((IntPtr) UIAElement.Current.NativeWindowHandle, x, y, width, height);
                }
            }

            VerboseInformation.Clear();
            VerboseInformation.Add("Width = " + width);
            VerboseInformation.Add("Height = " + height);
            LogText = "New Dimensions";
            LogMessage();
        }

        /// <summary>
        ///     Moves the window to the specified location
        /// </summary>
        /// <param name = "x">Absolute screen coordinates of the left side of the window</param>
        /// <param name = "y">Absolute screen coordinates of the top of the window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Move(double x, double y)
        {
            int ret = TransformPatternHelper.Move(UIAElement, x, y);

            if (ret == -1)
            {
                double width = UIAElement.Current.BoundingRectangle.Width;
                double height = UIAElement.Current.BoundingRectangle.Height;
                ProdWindowNative.MoveWindowNative((IntPtr) UIAElement.Current.NativeWindowHandle, x, y, width, height);
            }

            VerboseInformation.Clear();
            VerboseInformation.Add("Y = " + y);
            VerboseInformation.Add("X = " + x);
            LogText = "New Location";
            LogMessage();
        }

        /// <summary>
        ///     Rotates the window
        /// </summary>
        /// <param name = "degrees">The number of degrees to rotate the element. A positive number rotates clockwise;
        ///     a negative number rotates counterclockwise</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Rotate(double degrees)
        {
            TransformPatternHelper.Rotate(UIAElement, degrees);

            VerboseInformation.Clear();
            VerboseInformation.Add("degrees = " + degrees);
            LogText = "Rotated";
            LogMessage();
        }

        /// <summary>
        ///     Register to make a window the active window.
        /// </summary>
        /// <exception cref = "InvalidOperationException">The exception that is thrown when a method call is invalid for the object's current state</exception>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <exception cref = "Win32Exception">Throws an exception for a Win32 error code</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Activate()
        {
                NativeMethods.ShowWindowAsync((IntPtr) UIAElement.Cached.NativeWindowHandle, (int) ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync((IntPtr) UIAElement.Cached.NativeWindowHandle, (int) ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow((IntPtr) UIAElement.Cached.NativeWindowHandle);
        }


        /// <summary>
        ///     Creates and sends the proper LogMessage.
        /// </summary>
        private void LogMessage()
        {
            //LogMessage message;
            //if (_verboseInformation.Count == 0)
            //{
            //    message = new LogMessage(LogText);
            //}
            //else
            //{
            //    _verboseInformation = new List<object>();
            //    message = new LogMessage(LogText, _verboseInformation);
            //}

            //sessionLoggers.ReceiveLogMessage(message);
        }
    }
}