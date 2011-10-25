// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Static
{
    /// <summary>
    /// Functions that are available to most UI Elements
    /// </summary>
    public static partial class Prod
    {
        /// <summary>
        /// Register to make a window the active window by passing partial title.
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Warn, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void ActivateWindow(string partialTitle)
        {
            try
            {
                IntPtr windowHandle = InternalUtilities.FindWindowPartial(partialTitle);
                NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow(windowHandle);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Brings the specified window to the foreground and activates it
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to the target window</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Warn, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void ActivateWindow(IntPtr windowHandle)
        {
            try
            {
                if ((int)windowHandle == 0)
                {
                    throw new ProdOperationException("NativeWindowHandle not found.", new ElementNotEnabledException());
                }

                NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOWDEFAULT);
                NativeMethods.ShowWindowAsync(windowHandle, (int)ShowWindowCommand.SW_SHOW);
                NativeMethods.SetForegroundWindow(windowHandle);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Copies an object in the specified format to the windows Clipboard.
        /// </summary>
        /// <param name="format">The <see cref="System.Windows.Forms.DataFormats"/></param>
        /// <param name="item">The object to place on the Clipboard buffer.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void CopyToClipboard(DataFormats format, object item)
        {
            try
            {
                Clipboard.SetData(format.ToString(), item);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Waits a specified amount of time for the specified control to be ready for interaction.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="delay">Time, in seconds, to wait for window to exist. -1 to wait forever</param>
        /// <returns>
        ///   <c>true</c> if ready, <c>false</c> if not ready within time limit
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static bool ControlWaitReady(BaseProdControl control, int delay)
        {
            int tryCounter = 0;
            try
            {
                while (tryCounter != delay || delay == -1)
                {
                    if (control.UIAElement.Current.IsEnabled)
                    {
                        return true;
                    }
                    Thread.Sleep(1000);
                    tryCounter++;
                }

                return false;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets control caption
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the button</param>
        /// <returns>
        /// The caption of the current control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static string GetCaption(IntPtr controlHandle)
        {
            try
            {
                AutomationElement ae = AutomationElement.FromHandle(controlHandle);
                string retVal = ae.GetCachedPropertyValue(AutomationElement.NameProperty, false).ToString();
                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets current controls handle
        /// </summary>
        /// <param name="parentHandle">NativeWindowHandle to the parent window</param>
        /// <param name="controlId">Resource Id of the control</param>
        /// <returns>
        /// NativeWindowHandle to the current control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Info, VerbositySupport = LoggingVerbosity.Minimum)]
        public static IntPtr GetControlHandle(IntPtr parentHandle, int controlId)
        {
            try
            {
                IntPtr ret = InternalUtilities.GetChildHandle(parentHandle, controlId);
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets current controls handle
        /// </summary>
        /// <param name="parentHandle">NativeWindowHandle to the parent window.</param>
        /// <param name="controlText">The control text to match.</param>
        /// <returns>
        /// NativeWindowHandle to the current control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Info, VerbositySupport = LoggingVerbosity.Minimum)]
        public static IntPtr GetControlHandle(IntPtr parentHandle, string controlText)
        {
            try
            {
                IntPtr ret = InternalUtilities.GetChildHandle(parentHandle, controlText);
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the handle from controls position in the forms UI control tree.
        /// </summary>
        /// <param name="windowHandle">The applications window handle.</param>
        /// <param name="position">The position of the control.</param>
        /// <returns>
        /// The window handle to the selected control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// The position of the control tree can be found through the use of ProdSpy. This function is especially useful for those controls that have no name, label, or resourceID
        /// However, WPF controls do NOT have a handle, so this will return a 0
        /// </remarks>
        public static IntPtr GetHandleFromTree(IntPtr windowHandle, int position)
        {
            try
            {
                ControlTree tree = new ControlTree(windowHandle);

                return (IntPtr)tree.Find(position);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Register to return a handle to the window with a partial title matching the string provided.
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <returns>
        /// NativeWindowHandle to the window if successful. IntPtr.Zero if not found
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static IntPtr GetWindowHandle(string partialTitle)
        {
            try
            {
                IntPtr retVal = InternalUtilities.FindWindowPartial(partialTitle);
                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Determines if control is able to accept input
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the control to investigate</param>
        /// <returns>
        ///   <c>true</c> if enabled, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool IsEnabled(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = AutomationElement.FromHandle(controlHandle);
                bool retVal = (bool)control.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty);
                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Determines if control is able to accept input
        /// </summary>
        /// <param name="control">The <see cref="System.Windows.Automation.AutomationElement"/> to investigate</param>
        /// <returns>
        ///   <c>true</c> if enabled, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool IsEnabled(AutomationElement control)
        {
            try
            {
                bool retVal = (bool)control.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty);
                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Moves the mouse to control.
        /// </summary>
        /// <param name="controlHandle">The control handle of the element to snap to.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void MoveMouseToControl(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = AutomationElement.FromHandle(controlHandle);
                control.SetFocus();
                Point p = new Point((int)control.GetClickablePoint().X, (int)control.GetClickablePoint().Y);
                InternalUtilities.MoveMouseToPoint(p);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Moves the mouse to control.
        /// </summary>
        /// <param name="control">The UI Automation element to snap the mouse to</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void MoveMouseToControl(AutomationElement control)
        {
            try
            {
                Point p = new Point((int)control.GetClickablePoint().X, (int)control.GetClickablePoint().Y);
                control.SetFocus();
                InternalUtilities.MoveMouseToPoint(p);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Used to send a set of keys to a focused window or control
        /// </summary>
        /// <param name="partialTitle">Title of window to focus upon, then send keys to</param>
        /// <param name="theKeys">The keys to send. <seealso cref="System.Windows.Forms.SendKeys.Send"/></param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SendKeysTo(string partialTitle, string theKeys)
        {
            try
            {
                ActivateWindow(partialTitle);
                SendKeys.SendWait(theKeys);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Used to send a set of keys to a focused window or control
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to the window to focus upon, then send keys to</param>
        /// <param name="theKeys">The keys to send. <seealso cref="System.Windows.Forms.SendKeys.Send"/></param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SendKeysTo(IntPtr windowHandle, string theKeys)
        {
            try
            {
                ActivateWindow(windowHandle);
                SendKeys.SendWait(theKeys);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Moves the mouse to a control and sends the specified mouse click.
        /// </summary>
        /// <param name="control">The UI Automation element to click</param>
        /// <param name="clickType">Type of the click. <see cref="MouseClick"/></param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void SendMouseClick(AutomationElement control, MouseClick clickType)
        {
            try
            {
                Point p = new Point((int)control.GetClickablePoint().X, (int)control.GetClickablePoint().Y);
                control.SetFocus();
                InternalUtilities.MoveMouseToPoint(p);

                switch (clickType)
                {
                    case MouseClick.Left:
                        InternalUtilities.SendMouseInput(p.X, p.Y, 0, MOUSEEVENTF.MOUSEEVENTFLEFTDOWN | MOUSEEVENTF.MOUSEEVENTFABSOLUTE);
                        InternalUtilities.SendMouseInput(p.X, p.Y, 0, MOUSEEVENTF.MOUSEEVENTFLEFTUP | MOUSEEVENTF.MOUSEEVENTFABSOLUTE);
                        break;
                    case MouseClick.Right:
                        InternalUtilities.SendMouseInput(p.X, p.Y, 0, MOUSEEVENTF.MOUSEEVENTFRIGHTDOWN | MOUSEEVENTF.MOUSEEVENTFABSOLUTE);
                        InternalUtilities.SendMouseInput(p.X, p.Y, 0, MOUSEEVENTF.MOUSEEVENTFRIGHTUP | MOUSEEVENTF.MOUSEEVENTFABSOLUTE);
                        break;
                    case MouseClick.Middle:
                        InternalUtilities.SendMouseInput(p.X, p.Y, 0, MOUSEEVENTF.MOUSEEVENTFMIDDLEDOWN | MOUSEEVENTF.MOUSEEVENTFABSOLUTE);
                        InternalUtilities.SendMouseInput(p.X, p.Y, 0, MOUSEEVENTF.MOUSEEVENTFMIDDLEUP | MOUSEEVENTF.MOUSEEVENTFABSOLUTE);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("clickType");
                }
            }
            catch (NoClickablePointException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Sets input focus to control
        /// </summary>
        /// <param name="control">The <see cref="System.Windows.Automation.AutomationElement"/> to investigate</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void SetFocus(AutomationElement control)
        {
            try
            {
                if (control.Current.IsEnabled && (bool)control.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty, true))
                {
                    control.SetFocus();
                }
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Sets input focus to control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the control to investigate</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void SetFocus(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = AutomationElement.FromHandle(controlHandle);
                if (control.Current.IsEnabled && (bool)control.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty, true))
                {
                    control.SetFocus();
                }
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Provides a delay in processing
        /// </summary>
        /// <param name="seconds">The number of seconds to spin.</param>
        public static void TimeDelay(double seconds)
        {
            double wait = seconds * 1000;
            Thread.Sleep((int)wait);
        }

        /// <summary>
        /// Determines if the target window exists
        /// </summary>
        /// <param name="partialTitle">Part of the target windows title</param>
        /// <returns>
        ///   <c>true</c> if enabled, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool WindowExists(string partialTitle)
        {
            try
            {
                bool doesWinExist = InternalUtilities.FindWindowPartial(partialTitle) != IntPtr.Zero;

                return doesWinExist;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Waits a specified amount of time, checking for a windows existence
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <param name="delay">Time, in seconds, to wait for window to exist. -1 to wait forever</param>
        /// <returns>
        ///   <c>true</c> if window was verified closed, <c>false</c> otherwise
        /// </returns>
        public static bool WinWaitClose(string partialTitle, int delay)
        {
            int tryCounter = 0;
            while (tryCounter != delay || delay == -1)
            {
                try
                {
                    InternalUtilities.FindWindowPartial(partialTitle);
                }
                catch (Exception)
                {
                    return true;
                }
                Thread.Sleep(1000);
                tryCounter++;
            }

            return false;
        }

        /// <summary>
        /// Waits a specified amount of time for the specified window to exist
        /// </summary>
        /// <param name="partialTitle">The title of the window to search for (partial names are acceptable, though less accurate)</param>
        /// <param name="delay">Time, in seconds, to wait for window to exist. -1 to wait forever</param>
        /// <returns>
        /// NativeWindowHandle to window if found, zero if not found
        /// </returns>
        public static IntPtr WinWaitExists(string partialTitle, int delay)
        {
            int tryCounter = 0;

            while (tryCounter != delay || delay == -1)
            {
                IntPtr ret = InternalUtilities.WinWaitSearch(partialTitle);
                if (ret != IntPtr.Zero)
                {
                    return ret;
                }

                Thread.Sleep(1000);
                tryCounter++;
            }

            return IntPtr.Zero;
        }
    }
}