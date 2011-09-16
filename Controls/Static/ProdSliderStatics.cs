/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Session;
using ProdUI.Utility;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Interaction.Native;
using ProdUI.Controls.Windows;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        /// Set value of control
        /// </summary>
        /// <param name="controlHandle">Handle to the target control</param>
        /// <param name="value">The value to set the slider to.</param>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        public static void SliderSetValue(IntPtr controlHandle, double value)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);

            int ret = RangeValuePatternHelper.SetValue(control, value);
            if (ret == -1)
            {
                ProdSliderNative.SetValueNative(controlHandle, value);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value to set: " + value;
            ProdStaticSession.Log(logmessage);
        }

        /// <summary>
        /// Set value of control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <param name="value">The value to set the slider to.</param>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        public static void SliderSetValue(ProdWindow prodwindow, string automationId, double value)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);

            int ret = RangeValuePatternHelper.SetValue(control, value);
            if (ret == -1 && control.Current.NativeWindowHandle != 0)
            {
                RangeValuePatternHelper.SetValue(control, value);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value to set: " + value;
            ProdStaticSession.Log(logmessage);
        }

        /// <summary>
        /// Gets the value of the current slider control
        /// </summary>
        /// <param name="controlHandle">Handle to the target control</param>
        /// <returns>
        /// Value of the control
        /// </returns>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        public static double SliderGetValue(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);
            double retVal = RangeValuePatternHelper.GetValue(control);

            if (retVal == -1)
            {
                ProdSliderNative.GetValueNative(controlHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the value of the current slider control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <returns>
        /// Value of the control
        /// </returns>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        public static double SliderGetValue(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetValue(control);

            if (retVal == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSliderNative.GetValueNative((IntPtr)control.Current.NativeWindowHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The large-change value or null if the element does not support LargeChange
        /// </returns>
        public static double SliderGetLargeChange(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);

            double retVal = RangeValuePatternHelper.GetLargeChange(control);
            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);
            return retVal;
        }

        /// <summary>
        /// Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The large-change value or null if the element does not support LargeChange
        /// </returns>
        public static double SliderGetLargeChange(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetLargeChange(control);

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the control-specific small-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The small-change value or null if the element does not support SmallChange
        /// </returns>
        public static double SliderGetSmallChange(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            double retVal = RangeValuePatternHelper.GetSmallChange(control);

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the control-specific small-change value which is added to or subtracted from the Value property.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The small-change value or null if the element does not support SmallChange
        /// </returns>
        public static double SliderGetSmallChange(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetSmallChange(control);

            string logmessage = "Control Text: " + control.Current.Name + " Value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the maximum range value supported.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The maximum value supported by the UI Automation element or null if the element does not support Maximum
        /// </returns>
        public static double SliderGetMaxValue(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            double retVal = RangeValuePatternHelper.GetMaximum(control);

            if (retVal == -1)
            {
                ProdSliderNative.GetMaximumNative(controlHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the maximum range value supported
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The maximum value supported by the UI Automation element or null if the element does not support Maximum
        /// </returns>
        public static double SliderGetMaxValue(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetMaximum(control);

            if (retVal == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSliderNative.GetMaximumNative((IntPtr)control.Current.NativeWindowHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the minimum range value supported.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The minimum value supported by the UI Automation element or null if the element does not support Minimum
        /// </returns>
        public static double SliderGetMinValue(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
            double retVal = RangeValuePatternHelper.GetMinimum(control);

            if (retVal == -1)
            {
                ProdSliderNative.GetMinimumNative(controlHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }

        /// <summary>
        /// Gets the minimum range value supported
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The minimum value supported by the UI Automation element or null if the element does not support Minimum
        /// </returns>
        public static double SliderGetMinValue(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            double retVal = RangeValuePatternHelper.GetMinimum(control);

            if (retVal == -1 && control.Current.NativeWindowHandle != 0)
            {
                ProdSliderNative.GetMinimumNative((IntPtr)control.Current.NativeWindowHandle);
            }

            string logmessage = "Control Text: " + control.Current.Name + " value: " + retVal;
            ProdStaticSession.Log(logmessage);

            return retVal;
        }
    }
}