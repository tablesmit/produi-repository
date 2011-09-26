// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;
using ProdUI.Verification;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the RangeValuePattern pattern.
    /// </summary>
    internal static class RangeValuePatternHelper
    {
        /// <summary>
        ///     Gets the current value of the UI Automation element
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <returns>
        ///     The control-specific value
        /// </returns>
        internal static double GetValue(AutomationElement control)
        {
            RangeValuePattern pattern = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            return pattern.Current.Value;
        }

        /// <summary>
        ///     Sets the current value of the UI Automation element
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <param name = "value">The value to set the control to.</param>
        internal static void SetValue(AutomationElement control, double value)
        {
            RangeValuePattern pattern = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            pattern.SetValue(value);
            ValueVerifier<double, double>.Verify(value, GetValue(control));
        }

        /// <summary>
        ///     Gets the specified controls maximum range.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     Maximum Range value
        /// </returns>
        internal static double GetMaximum(AutomationElement control)
        {
            RangeValuePattern pattern = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            return pattern.Current.Maximum;
        }

        /// <summary>
        ///     Gets the minimum range value supported by the UI Automation element.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     Minimum Range value
        /// </returns>
        internal static double GetMinimum(AutomationElement control)
        {
            RangeValuePattern pattern = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            return pattern.Current.Minimum;
        }

        /// <summary>
        ///     Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     The increment of a Large Change
        /// </returns>
        internal static double GetLargeChange(AutomationElement control)
        {
            RangeValuePattern pattern = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            return pattern.Current.LargeChange;
        }

        /// <summary>
        ///     Gets the small-change value, unique to the UI Automation element, which is added to or subtracted from the elements Value property.
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <returns>
        ///     The small-change value
        /// </returns>
        internal static double GetSmallChange(AutomationElement control)
        {
            RangeValuePattern pattern = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            return pattern.Current.SmallChange;
        }
    }
}