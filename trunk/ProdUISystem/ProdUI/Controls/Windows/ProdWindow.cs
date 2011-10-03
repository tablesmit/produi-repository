// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    /// Provides mechanisms to work with container windows
    /// </summary>
    public sealed class ProdWindow : IWindow
    {
        internal IntPtr NativeHandle;
        internal AutomationElement UIAElement;
        internal string WindowTitle;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls.ProdWindow Class from the specified handle
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        public ProdWindow(IntPtr windowHandle)
        {
            try
            {
                UIAElement = AutomationElement.FromHandle(windowHandle);
                NativeHandle = windowHandle;
                WindowTitle = UIAElement.Current.Name;

                /* gotta check to make sure its a window */
                if (!(bool)UIAElement.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
                {
                    throw new ProdOperationException("Control does not support WindowPattern");
                }
            }
            catch (ArgumentException err)
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

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls.ProdWindow Class from the specified partial title
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <remarks>
        /// If window cannot be found, an error will be thrown
        /// </remarks>
        public ProdWindow(string partialTitle)
        {
            try
            {
                IntPtr handle = InternalUtilities.FindWindowPartial(partialTitle);
                UIAElement = AutomationElement.FromHandle(handle);
                NativeHandle = handle;
                WindowTitle = UIAElement.Current.Name;

                /* Check to make sure its a window */
                if (!(bool)UIAElement.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
                {
                    throw new ProdOperationException("Control does not support WindowPattern");
                }
            }
            catch (ArgumentException err)
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

        #endregion Constructors

        /// <summary>
        /// Register to make a window the active window.
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Activate()
        {
            this.ActivateWindowBridge(this);
        }

        /// <summary>
        /// Closes the current window
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Close()
        {
            this.CloseWindowBridge(this);
        }

        /// <summary>
        /// Gets whether the current window is modal or not
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetIsModal()
        {
            return this.GetIsModalBridge(this);
        }

        /// <summary>
        /// Gets the specified windows title
        /// </summary>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetTitle()
        {
            return this.GetTitleBridge(this);
        }

        /// <summary>
        /// Gets a value whether a window is set to be topmost in the z-order
        /// </summary>
        /// <returns>
        ///   <c>true</c> if topmost; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetIsTopmost()
        {
            return this.GetIsTopmostBridge(this);
        }

        /// <summary>
        /// Gets the WindowVisualState of the current window
        /// </summary>
        /// <returns>
        /// The visual state of the window.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public WindowVisualState GetWindowVisualState()
        {
            return this.GetWindowVisualStateBridge(this);
        }

        /// <summary>
        /// Gets the state of the current window.
        /// </summary>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public WindowInteractionState GetWinState()
        {
            return this.GetWindowStateBridge(this);
        }

        /// <summary>
        /// Sets the specified windows title
        /// </summary>
        /// <param name="newTitle">The new title.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetTitle(string newTitle)
        {
            this.SetTitleBridge(this, newTitle);
        }

        /// <summary>
        /// Minimizes the current window
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Minimize()
        {
            this.MinimizeWindowBridge(this);
        }

        /// <summary>
        /// Maximizes the current window
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Maximize()
        {
            this.MaximizeWindowBridge(this);
        }

        /// <summary>
        /// Restores current window to its original dimensions
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Restore()
        {
            this.RestoreWindowBridge(this);
        }

        /// <summary>
        /// Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first
        /// </summary>
        /// <param name="delay">Time, in milliseconds to wait for an idle state. If no value is provided, it will wait forever</param>
        /// <returns>
        ///   <c>true</c> if the window has entered the idle state. <c>false</c> if the timeout occurred
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool WaitForInputIdle(int delay = -1)
        {
            return this.WaitForInputIdleBridge(this, delay);
        }

        /// <summary>
        /// Resize the window
        /// </summary>
        /// <param name="width">The new width of the window, in pixels</param>
        /// <param name="height">The new height of the window, in pixels</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Resize(double width, double height)
        {
            this.ResizeWindowBridge(this, width, height);
        }

        /// <summary>
        /// Moves the window to the specified location
        /// </summary>
        /// <param name="x">Absolute screen coordinates of the left side of the window</param>
        /// <param name="y">Absolute screen coordinates of the top of the window</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Move(double x, double y)
        {
            this.MoveWindowBridge(this, x, y);
        }

        /// <summary>
        /// Rotates the window
        /// </summary>
        /// <param name="degrees">The number of degrees to rotate the element. A positive number rotates clockwise;
        /// a negative number rotates counterclockwise</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void Rotate(double degrees)
        {
            this.RotateWindowBridge(this, degrees);
        }
    }
}