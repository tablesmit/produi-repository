/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Session;
using ProdUI.Utility;
using ProdUI.Controls.Windows;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        /// Sets the value of the spinner control.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <param name="value">The desired value.</param>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SpinnerSetValue(IntPtr controlHandle, double value)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);

            int ret = RangeValuePatternHelper.SetValue(control, value);
            if (ret == -1)
            {
                ProdSpinnerNative.SetValueNative(controlHandle, value);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value to set: " + value;
            ProdStaticSession.Log(logmessage);
        }

        /// <summary>
        /// Sets the value of the spinner control.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="value">The desired value.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SpinnerSetValue(ProdWindow prodwindow, string automationId, double value)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);

            int ret = RangeValuePatternHelper.SetValue(control, value);
            if (ret == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSpinnerNative.SetValueNative((IntPtr)control.Current.NativeWindowHandle, value);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value to set: " + value;
            ProdStaticSession.Log(logmessage);
        }

        /// <summary>
        /// Gets the value of the spinner control.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The current value of the spinner
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetValue(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);
            double retVal = RangeValuePatternHelper.GetValue(control);

            if (retVal == -1)
            {
                ProdSpinnerNative.GetValueNative(controlHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the value of the spinner control.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The current value of the target spinner
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetValue(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetValue(control);

            if (retVal == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSpinnerNative.GetValueNative((IntPtr)control.Current.NativeWindowHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the max value the spinner can have.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// Max value the spinner can have
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetMaxValue(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            double retVal = RangeValuePatternHelper.GetMaximum(control);

            if (retVal == -1)
            {
                ProdSpinnerNative.GetMaximumNative(controlHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the max value the spinner can have.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// Max value the spinner can have
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetMaxValue(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetMaximum(control);

            if (retVal == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSpinnerNative.GetMaximumNative((IntPtr)control.Current.NativeWindowHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the minimum value the spinner can have.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// Minimum value the spinner can have
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetMinValue(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            double retVal = RangeValuePatternHelper.GetMinimum(control);

            if (retVal == -1)
            {
                ProdSpinnerNative.GetMinimumNative(controlHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the minimum value the spinner can have.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// Minimumvalue the spinner can have
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetMinValue(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetMinimum(control);

            if (retVal == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSpinnerNative.GetMinimumNative((IntPtr)control.Current.NativeWindowHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }
    }
}