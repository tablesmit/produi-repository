// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;
using ProdUI.Verification;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the WindowPattern control pattern.
    /// </summary>
    internal static class WindowPatternHelper
    {
        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        internal static void CloseWindow(AutomationElement control)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            pattern.Close();
        }

        /// <summary>
        /// Gets the interaction state of the window
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The current <see cref="WindowInteractionState"/>
        /// </returns>
        internal static WindowInteractionState GetInteractionState(AutomationElement control)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            return false == pattern.WaitForInputIdle(10000)
                       ? WindowInteractionState.NotResponding
                       : pattern.Current.WindowInteractionState;
        }

        /// <summary>
        /// Gets whether the window is modal or not
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        ///   <c>true</c> if modal, <c>false</c> otherwise
        /// </returns>
        internal static bool GetIsModal(AutomationElement control)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            return pattern.Current.IsModal;
        }

        /// <summary>
        /// Gets whether the window is topmost.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        ///   <c>true</c> if Topmost, <c>false</c> otherwise
        /// </returns>
        internal static bool GetIsTopmost(AutomationElement control)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            return pattern.Current.IsTopmost;
        }

        /// <summary>
        /// Sets the visual state of the window
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="state">The <see cref="WindowVisualState"/> of the current window</param>
        internal static void SetVisualState(AutomationElement control, WindowVisualState state)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            if (pattern.Current.WindowInteractionState != WindowInteractionState.ReadyForUserInteraction) return;
            SetState(state, pattern);
            ValueVerifier<WindowVisualState, WindowVisualState>.Verify(state, GetVisualState(control));
        }

        /// <summary>
        /// Gets the visual state of the current window
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The <see cref="WindowVisualState"/> of the current window
        /// </returns>
        internal static WindowVisualState GetVisualState(AutomationElement control)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            return pattern.Current.WindowVisualState;
        }

        /// <summary>
        /// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending, or until the time-out interval has elapsed
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="delay">The time-out interval, in milliseconds</param>
        /// <returns>
        ///   <c>true</c> if the window has entered the idle state; <c>false</c> if the timeout occurred
        /// </returns>
        internal static bool WaitForInputIdle(AutomationElement control, int delay)
        {
            WindowPattern pattern = (WindowPattern)CommonUIAPatternHelpers.CheckPatternSupport(WindowPattern.Pattern, control);
            return pattern.WaitForInputIdle(delay);
        }

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
    }
}