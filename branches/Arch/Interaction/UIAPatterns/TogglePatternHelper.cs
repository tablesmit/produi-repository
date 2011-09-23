// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Runtime.CompilerServices;
using System.Windows.Automation;

[assembly: InternalsVisibleTo("ProdUITests")]

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the TogglePattern control pattern. implements IToggleProvider
    /// </summary>
    internal static class TogglePatternHelper
    {
        #region IToggleProvider Implementation

        /// <summary>
        ///     Cycles through the toggle states of an AutomationElement.
        /// </summary>
        /// <param name = "control">Toggle element to cycle</param>
        /// <remarks>
        ///     A control will cycle through its ToggleState in this order: On, Off and, if supported, Indeterminate.
        /// </remarks>
        internal static void Toggle(AutomationElement control)
        {
            TogglePattern pattern = (TogglePattern) CommonUIAPatternHelpers.CheckPatternSupport(TogglePattern.Pattern, control);
            pattern.Toggle();
        }

        /// <summary>
        ///     Retrieves the ToggleState of specified control
        /// </summary>
        /// <param name = "control">The control to be manipulated</param>
        /// <returns>
        ///     The current <see cref = "System.Windows.Automation.ToggleState" />ToggleState or null if there is a recoverable error
        /// </returns>
        internal static ToggleState GetToggleState(AutomationElement control)
        {
            TogglePattern pattern = (TogglePattern) CommonUIAPatternHelpers.CheckPatternSupport(TogglePattern.Pattern, control);
            return pattern.Current.ToggleState;
        }

        #endregion

        #region Custom functions

        /// <summary>
        ///     Sets state of toggle control
        /// </summary>
        /// <param name = "control">The control to be manipulated</param>
        /// <param name = "toggleState">The current <see cref = "System.Windows.Automation.ToggleState" />ToggleState</param>
        internal static void SetToggleState(AutomationElement control, ToggleState toggleState)
        {
            /* Only need to change it if it needs-a-changin' */
            if (GetToggleState(control) != toggleState)
            {
                TogglePattern pattern = (TogglePattern) control.GetCurrentPattern(TogglePattern.Pattern);
                pattern.Toggle();
            }

            VerifyCheckState(control, toggleState);
        }

        /// <summary>
        ///     Verifies the toggle state.
        /// </summary>
        /// <param name = "control">The control to verify.</param>
        /// <param name = "toggleState">Desired toggleState</param>
        /// <returns>
        ///     <c>true</c> if verified, <c>false</c> if failure
        /// </returns>
        private static bool VerifyCheckState(AutomationElement control, ToggleState toggleState)
        {
            /* now verify toggle */
            if (GetToggleState(control) == toggleState)
                return true;
            return false;
        }

        #endregion
    }
}