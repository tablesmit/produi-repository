/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Used for controls that support the RangeValuePattern pattern. implements IRangeValueProvider
    /// </summary>
    internal static class RangeValuePatternHelper
    {

        #region IRangeValueProvider Implementation

        /// <summary>
        ///   Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>The increment of a Large Change</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static double GetLargeChange(AutomationElement control)
        {
            try
            {
                RangeValuePattern pat = (RangeValuePattern)CommonPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                return pat.Current.LargeChange;
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
        ///   Gets the specified controls maximum range.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>Maximum Range value</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static double GetMaximum(AutomationElement control)
        {
            try
            {
                RangeValuePattern pat = (RangeValuePattern)CommonPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                return pat.Current.Maximum;
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
        ///   Gets the minimum range value supported by the UI Automation element.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>Minimum Range value</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static double GetMinimum(AutomationElement control)
        {
            try
            {
                RangeValuePattern pat = (RangeValuePattern)CommonPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                return pat.Current.Minimum;
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
        ///   Sets the current value of the UI Automation element
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <param name = "value">The value to set the control to.</param>
        /// <returns>0 if successful, -1 otherwise</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int SetValue(AutomationElement control, double value)
        {
            try
            {
                RangeValuePattern pat = (RangeValuePattern)CommonPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                pat.SetValue(value);
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
        ///   Gets the small-change value, unique to the UI Automation element, which is added to or subtracted from the elements Value property.
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <returns>The small-change value</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static double GetSmallChange(AutomationElement control)
        {
            try
            {
                RangeValuePattern pat = (RangeValuePattern)CommonPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                return pat.Current.SmallChange;
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
        ///   Gets the current value of the UI Automation element
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <returns>The control-specific value</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static double GetValue(AutomationElement control)
        {
            try
            {
                RangeValuePattern pat = (RangeValuePattern)CommonPatternHelpers.CheckPatternSupport(RangeValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                return pat.Current.Value;
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