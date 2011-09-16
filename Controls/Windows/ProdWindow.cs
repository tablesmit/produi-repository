/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///   Provides mechanisms to work with container windows
    /// </summary>
    public sealed class ProdWindow
    {
        private readonly CacheRequest _cacheRequest;
        private LogMessage _currentMessage;
        private string _logmessage = string.Empty;
        private readonly List<object> _verboseInformation;

        internal AutomationElement Window;

        /// <summary>
        ///   Gets or sets the attached logger.
        /// </summary>
        /// <value>The attached logger.</value>
        internal List<ProdLogger> AttachedLoggers;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls.ProdWindow Class from the specified handle
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="loggers">The loggers.</param>
        public ProdWindow(IntPtr windowHandle, List<ProdLogger> loggers)
        {
            try
            {
                AttachedLoggers = loggers;
                Window = AutomationElement.FromHandle(windowHandle);
                _cacheRequest = new CacheRequest();
                _cacheRequest.Add(AutomationElement.NativeWindowHandleProperty);

                /* gotta check to make sure its a window */
                if (!(bool)Window.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
                {
                    ProdOperationException err = new ProdOperationException("Control does not support WindowPattern");
                    ProdLogger.LogException(err, AttachedLoggers);
                    throw new ProdOperationException(err);
                }
                _verboseInformation = new List<object>();
            }
            catch (ElementNotAvailableException ex)
            {
                ProdOperationException err = new ProdOperationException(ex);
                ProdLogger.LogException(err, AttachedLoggers);
                throw new ProdOperationException(err);                 
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls.ProdWindow Class from the specified partial title
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <param name="loggers">The loggers.</param>
        /// <remarks>If window cannot be found, an error will be thrown</remarks>
        public ProdWindow(string partialTitle, List<ProdLogger> loggers)
        {
            try
            {
                AttachedLoggers = loggers;
                IntPtr handle = InternalUtilities.FindWindowPartial(partialTitle);
                Window = AutomationElement.FromHandle(handle);

                /* Check to make sure its a window */
                if (!(bool) Window.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
                {
                    ProdOperationException err = new ProdOperationException("Control does not support WindowPattern");
                    ProdLogger.LogException(err, AttachedLoggers);
                    throw new ProdOperationException(err);
                }
            }
            catch (ElementNotAvailableException ex)
            {
                ProdOperationException err = new ProdOperationException(ex);
                ProdLogger.LogException(err, AttachedLoggers);
                throw new ProdOperationException(err); 
            }
            _verboseInformation = new List<object>();
        }

        #endregion




        /// <summary>
        ///   Gets the WindowVisualState of the current window
        /// </summary>
        /// <returns></returns>
        /// <value>
        ///   The visual state of the window.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public WindowVisualState GetWindowVisualState()
        {
            try
            {
                WindowVisualState retVal = WindowPatternHelper.GetVisualState(AutomationElement.FromHandle((IntPtr) Window.Cached.NativeWindowHandle));

               _logmessage = "Visual State: " + retVal;
               LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw; 
            }
        }

        /// <summary>
        ///   Gets whether the current window is modal or not
        /// </summary>
        /// <returns></returns>
        /// <value>
        ///   <c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetIsModal()
        {
            try
            {
                bool retVal = (bool) WindowPatternHelper.GetIsModal(Window);

                _logmessage = "Is modal: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Gets a value whether a window is set to be topmost in the z-order
        /// </summary>
        /// <returns></returns>
        /// <value>
        ///   <c>true</c> if topmost; otherwise, <c>false</c>.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetIsTopmost()
        {
            try
            {
                bool retVal = (bool) WindowPatternHelper.GetIsTopmost(Window);

                _logmessage = "Is topmost: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Gets the state of the current window.
        /// </summary>
        /// <returns>The WindowState</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public WindowState GetWinState()
        {
            try
            {
                WindowInteractionState state = WindowPatternHelper.GetInteractionState(Window);

                _logmessage = "WindowState: " + state;
                LogEntry();

                return Prod.ConvertFromInteractionState(state);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Gets the specified windows title
        /// </summary>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetTitle()
        {
            try
            {
                string retVal = Prod.WindowGetTitle((IntPtr) Window.Cached.NativeWindowHandle);

                _logmessage = "Title: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Sets the specified windows title
        /// </summary>
        /// <param name = "newTitle">The new title.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetTitle(string newTitle)
        {
            try
            {
                Prod.WindowSetTitle((IntPtr) Window.Cached.NativeWindowHandle, newTitle);

                _logmessage = "Title: " + newTitle;
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Minimizes the current window
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Minimize()
        {
            try
            {
                int ret = WindowPatternHelper.SetVisualState(Window, WindowVisualState.Minimized);
                if (ret == -1)
                {
                    ProdWindowNative.MinimizeWindow((IntPtr) Window.Cached.NativeWindowHandle);
                }

                _logmessage = "Window minimized";
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Maximizes the current window
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Maximize()
        {
            try
            {
                int ret = WindowPatternHelper.SetVisualState(Window, WindowVisualState.Maximized);
                if (ret == -1)
                {
                    ProdWindowNative.MaximizeWindow((IntPtr) Window.Cached.NativeWindowHandle);
                }

                _logmessage = "Window maximized";
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Restores current window to its original dimensions
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Restore()
        {
            try
            {
                int ret = WindowPatternHelper.SetVisualState(Window, WindowVisualState.Normal);
                if (ret == -1)
                {
                    ProdWindowNative.ShowWindow((IntPtr) Window.Cached.NativeWindowHandle);
                }

                _logmessage = "Window restored";
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Closes the current window
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Close()
        {
            try
            {
                int ret = WindowPatternHelper.CloseWindow(Window);
                if (ret == -1)
                {
                    ProdWindowNative.CloseWindow((IntPtr) Window.Cached.NativeWindowHandle);
                }

                _logmessage = "Window closed";
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first
        /// </summary>
        /// <param name = "delay">Time, in milliseconds to wait for an idle state</param>
        /// <returns>
        ///   <c>true</c> if the window has entered the idle state. <c>false</c> if the timeout occurred
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public bool WaitForInputIdle(int delay)
        {
            try
            {
                bool? ret = WindowPatternHelper.WaitForInputIdle(Window, delay);
                if (ret == null)
                {
                    ProdOperationException err = new ProdOperationException(new InvalidOperationException());
                    ProdLogger.LogException(err, AttachedLoggers);
                    throw new ProdOperationException(err);
                }
                return (bool) ret;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Resize the window
        /// </summary>
        /// <param name = "width">The new width of the window, in pixels</param>
        /// <param name = "height">The new height of the window, in pixels</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Resize(double width, double height)
        {
            try
            {
                int ret = TransformPatternHelper.Resize(Window, width, height);

                if (ret == -1)
                {
                    if (ret == -1)
                    {
                        double x = Window.Current.BoundingRectangle.X;
                        double y = Window.Current.BoundingRectangle.Y;
                        ProdWindowNative.MoveWindowNative((IntPtr) Window.Current.NativeWindowHandle, x, y, width, height);
                    }
                }

                _verboseInformation.Clear();
                _verboseInformation.Add("Width = " + width);
                _verboseInformation.Add("Height = " + height);
                _logmessage = "New Dimensions";
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Moves the window to the specified location
        /// </summary>
        /// <param name = "x">Absolute screen coordinates of the left side of the window</param>
        /// <param name = "y">Absolute screen coordinates of the top of the window</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Move(double x, double y)
        {
            int ret = TransformPatternHelper.Move(Window, x, y);

            if (ret == -1)
            {
                double width = Window.Current.BoundingRectangle.Width;
                double height = Window.Current.BoundingRectangle.Height;
                ProdWindowNative.MoveWindowNative((IntPtr) Window.Current.NativeWindowHandle, x, y, width, height);
            }

            _verboseInformation.Clear();
            _verboseInformation.Add("Y = " + y);
            _verboseInformation.Add("X = " + x);
            _logmessage = "New Location";
            LogEntry();
        }

        /// <summary>
        ///   Rotates the window
        /// </summary>
        /// <param name = "degrees">The number of degrees to rotate the element. A positive number rotates clockwise;
        ///   a negative number rotates counterclockwise</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Rotate(double degrees)
        {
            TransformPatternHelper.Rotate(Window, degrees);

            _verboseInformation.Clear();
            _verboseInformation.Add("degrees = " + degrees);
            _logmessage = "Rotated";
            LogEntry();
        }

        /// <summary>
        ///   Register to make a window the active window.
        /// </summary>
        /// <exception cref = "InvalidOperationException">The exception that is thrown when a method call is invalid for the object's current state</exception>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <exception cref = "Win32Exception">Throws an exception for a Win32 error code</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Activate()
        {
            try
            {
                NativeMethods.ShowWindowAsync((IntPtr) Window.Cached.NativeWindowHandle, (int) ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync((IntPtr) Window.Cached.NativeWindowHandle, (int) ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow((IntPtr) Window.Cached.NativeWindowHandle);
            }
            catch (InvalidOperationException ex)
            {
                ProdOperationException err = new ProdOperationException(ex);
                ProdLogger.LogException(err, AttachedLoggers);
                throw; 
            }
            catch (ElementNotAvailableException ex)
            {
                ProdOperationException err = new ProdOperationException(ex);
                ProdLogger.LogException(err, AttachedLoggers);
                throw; 
            }
            catch (Win32Exception ex)
            {
                ProdOperationException err = new ProdOperationException(ex);
                ProdLogger.LogException(err, AttachedLoggers);
                throw; 
            }
        }


        private void CreateMessage()
        {
            if (_verboseInformation.Count == 0)
            {
                _currentMessage = new LogMessage(_logmessage);
            }
            else
            {
                _currentMessage = new LogMessage(_logmessage, _verboseInformation);
            }
        }

        private void LogEntry()
        {
            if (_currentMessage == null)
            {
                CreateMessage();
            }

            ProdLogger.Log(_currentMessage, AttachedLoggers);
        }

    }
}