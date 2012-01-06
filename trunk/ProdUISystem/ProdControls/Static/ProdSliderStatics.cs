// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdControls.Static
{
    public static partial class Prod
    {
        /// <summary>
        /// Set value of control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <param name="value">The value to set the slider to.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        public static void SliderSetValue(IntPtr controlHandle, double value)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);

                RangeValuePatternHelper.SetValue(control, value);
                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
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
        /// Set value of control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <param name="value">The value to set the slider to.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        public static void SliderSetValue(ProdWindow prodwindow, string automationId, double value)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            RangeValueBridge.SetValueBridge(null, control, value);
        }

        /// <summary>
        /// Gets the value of the current slider control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <returns>
        /// Value of the control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        public static double SliderGetValue(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(RangeValuePattern.ValueProperty, control);
                double retVal = RangeValuePatternHelper.GetValue(control);

                if (retVal == -1)
                {
                    ProdSliderNative.GetValueNative(controlHandle);
                }

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));
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
        /// Gets the value of the current slider control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <returns>
        /// Value of the control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        public static double SliderGetValue(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetValueBridge(null, control);
        }

        /// <summary>
        /// Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The large-change value or null if the element does not support LargeChange
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetLargeChange(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);

                double retVal = RangeValuePatternHelper.GetLargeChange(control);
                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));
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
        /// Gets the control-specific large-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The large-change value or null if the element does not support LargeChange
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetLargeChange(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetLargeChangeBridge(null, control);
        }

        /// <summary>
        /// Gets the control-specific small-change value which is added to or subtracted from the Value property
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The small-change value or null if the element does not support SmallChange
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetSmallChange(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
                double retVal = RangeValuePatternHelper.GetSmallChange(control);

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));

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
        /// Gets the control-specific small-change value which is added to or subtracted from the Value property.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The small-change value or null if the element does not support SmallChange
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetSmallChange(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetSmallChangeBridge(null, control);
        }

        /// <summary>
        /// Gets the maximum range value supported.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The maximum value supported by the UI Automation element or null if the element does not support Maximum
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetMaxValue(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
                double retVal = RangeValuePatternHelper.GetMaximum(control);

                if (retVal == -1)
                {
                    ProdSliderNative.GetMaximumNative(controlHandle);
                }

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));

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
        /// Gets the maximum range value supported
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The maximum value supported by the UI Automation element or null if the element does not support Maximum
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetMaxValue(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetMaxValueBridge(null, control);
        }

        /// <summary>
        /// Gets the minimum range value supported.
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <returns>
        /// The minimum value supported by the UI Automation element or null if the element does not support Minimum
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetMinValue(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(RangeValuePattern.Pattern, controlHandle);
                double retVal = RangeValuePatternHelper.GetMinimum(control);

                if (retVal == -1)
                {
                    ProdSliderNative.GetMinimumNative(controlHandle);
                }

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name + " Value: " + retVal));

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
        /// Gets the minimum range value supported
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The minimum value supported by the UI Automation element or null if the element does not support Minimum
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static double SliderGetMinValue(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return RangeValueBridge.GetMinValueBridge(null, control);
        }
    }
}