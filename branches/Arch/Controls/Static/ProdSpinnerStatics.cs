// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Interaction.Bridge;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

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

            RangeValuePatternHelper.SetValue(control, value);

            LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + value));
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
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            RangeValueBridge.SetValueBridge(null, control, value);
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

            LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));

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
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetValueBridge(null, control);
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

            LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));

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
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetMaxValueBridge(null, control);
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

            LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));

            return retVal;
        }

        /// <summary>
        /// Gets the minimum value the spinner can have.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// Minimum value the spinner can have
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static double SpinnerGetMinValue(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetMinValueBridge(null, control);
        }
    }
}