// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the RangeValuePattern pattern. implements IRangeValueProvider
    /// </summary>
    internal static class RangeValuePatternHelper
    {
        #region IRangeValueProvider Implementation

        /// <summary>
        ///     Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     The increment of a Large Change
        /// </returns>
        internal static double GetLargeChange(AutomationElement control)
        {
            RangeValuePattern pat = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            if (pat == null)
            {
                return -1;
            }

            return pat.Current.LargeChange;
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
            RangeValuePattern pat = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            if (pat == null)
            {
                return -1;
            }

            return pat.Current.Maximum;
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
            RangeValuePattern pat = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            if (pat == null)
            {
                return -1;
            }

            return pat.Current.Minimum;
        }

        /// <summary>
        ///     Sets the current value of the UI Automation element
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <param name = "value">The value to set the control to.</param>
        /// <returns>
        ///     0 if successful, -1 otherwise
        /// </returns>
        internal static int SetValue(AutomationElement control, double value)
        {
            RangeValuePattern pat = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            if (pat == null)
            {
                return -1;
            }

            pat.SetValue(value);
            return 0;
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
            RangeValuePattern pat = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            if (pat == null)
            {
                return -1;
            }

            return pat.Current.SmallChange;
        }

        /// <summary>
        ///     Gets the current value of the UI Automation element
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <returns>
        ///     The control-specific value
        /// </returns>
        internal static double GetValue(AutomationElement control)
        {
            RangeValuePattern pat = (RangeValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
            if (pat == null)
            {
                return -1;
            }

            return pat.Current.Value;
        }

        #endregion
    }
}