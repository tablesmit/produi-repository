/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///   Used for controls that support the WindowPattern control pattern. implements IWindowProvider
    /// </summary>
    internal static class WindowPatternHelper
    {
        #region IWindowProvider Implentation

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        /// <returns>
        /// 0 if no problems, -1 if InvalidOperationException
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int CloseWindow(AutomationElement control)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                pat.Close();
                return 0;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the interaction state of the window
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The current <see cref="WindowInteractionState"/>
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static WindowInteractionState GetInteractionState(AutomationElement control)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                return false == pat.WaitForInputIdle(10000) ? WindowInteractionState.NotResponding : pat.Current.WindowInteractionState;
            }
            catch (InvalidOperationException)
            {
                return WindowInteractionState.NotResponding;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (Exception error)
            {
                throw new ProdOperationException(error.Message, error);
            }
        }

        /// <summary>
        /// Gets whether the window is modal or not
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// <c>true</c> if modal, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static bool? GetIsModal(AutomationElement control)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                if (false == pat.WaitForInputIdle(10000))
                {
                    throw new ProdOperationException("Window Not Responding");
                }
                return pat.Current.IsModal;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets whether the window is topmost.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// <c>true</c> if Topmost, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static bool? GetIsTopmost(AutomationElement control)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                if (false == pat.WaitForInputIdle(10000))
                {
                    throw new ProdOperationException("Window Not Responding");
                }
                return pat.Current.IsTopmost;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Sets the visual state of the window
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="state">The <see cref="WindowVisualState"/> of the current window</param>
        /// <returns>
        /// -1 if in error
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int SetVisualState(AutomationElement control, WindowVisualState state)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                if (pat.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction)
                {
                    SetState(state, pat);
                    return VerifyState(pat, state);
                }
                return -1;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the visual state of the current window
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The <see cref="WindowVisualState"/> of the current window
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static WindowVisualState GetVisualState(AutomationElement control)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                if (false == pat.WaitForInputIdle(10000))
                {
                    throw new ProdOperationException("Window Not Responding");
                }
                return pat.Current.WindowVisualState;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending, or until the time-out interval has elapsed
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="delay">The time-out interval, in milliseconds</param>
        /// <returns>
        ///   <c>true</c> if the window has entered the idle state; <c>false</c> if the timeout occurred
        /// </returns>
        internal static bool? WaitForInputIdle(AutomationElement control, int delay)
        {
            try
            {
                WindowPattern pat = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
                return pat.WaitForInputIdle(delay);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        #region Custom Functions

        /// <summary>
        /// Sets the state of the window
        /// </summary>
        /// <param name="state">The <see cref="WindowVisualState"/> of the current window</param>
        /// <param name="wp">The WindowPattern of the target window.</param>
        private static void SetState(WindowVisualState state, WindowPattern wp)
        {
            switch (state)
            {
                case WindowVisualState.Maximized:
                    // Confirm that the element can be maximized
                    if ((wp.Current.CanMaximize) && !(wp.Current.IsModal))
                    {
                        wp.SetWindowVisualState(WindowVisualState.Maximized);
                    }
                    break;
                case WindowVisualState.Minimized:
                    // Confirm that the element can be minimized
                    if ((wp.Current.CanMinimize) && !(wp.Current.IsModal))
                    {
                        wp.SetWindowVisualState(WindowVisualState.Minimized);
                    }
                    break;
                case WindowVisualState.Normal:
                    wp.SetWindowVisualState(WindowVisualState.Normal);
                    break;
                default:
                    wp.SetWindowVisualState(WindowVisualState.Normal);
                    break;
            }
        }

        /// <summary>
        /// Verifies the window is closed.
        /// </summary>
        /// <param name="pattern">The WindowPattern of the current control</param>
        /// <param name="state">The desired <see cref="WindowVisualState"/></param>
        /// <returns>
        /// 0 if ok, -1 if error
        /// </returns>
        private static int VerifyState(WindowPattern pattern, WindowVisualState state)
        {
            try
            {
                if (false == pattern.WaitForInputIdle(10000))
                {
                    throw new ProdOperationException("Window Not Responding");
                }

                if (pattern.Current.WindowVisualState != state)
                {
                    return -1;
                }
                return 0;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion
    }
}