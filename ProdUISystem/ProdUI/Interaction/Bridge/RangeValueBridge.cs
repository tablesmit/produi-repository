// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class RangeValueBridge
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="theValue">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// Current value of the control
        /// </returns>
        public static double GetValueBridge(this IRangeValue theValue, BaseProdControl control)
        {
            try
            {
                return UiaGetValue(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetValue(control);
            }
        }

        private static double NativeGetValue(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.Spinner)
                return ProdSliderNative.GetValueNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return ProdSliderNative.GetValueNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static double UiaGetValue(BaseProdControl control)
        {
            double retVal = RangeValuePatternHelper.GetValue(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));

            return retVal;
        }

        /// <summary>
        /// Sets the value of the specified control.
        /// </summary>
        /// <param name="theValue">The extension interface</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <param name="value">The value to set control to.</param>
        public static void SetValueBridge(this IRangeValue theValue, BaseProdControl control, double value)
        {
            try
            {
                UiaSetValue(control, value);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                NativeSetValue(control, value);
            }
        }

        private static void NativeSetValue(BaseProdControl control, double value)
        {
            if (control.UIAElement.Current.ControlType == ControlType.Spinner)
                ProdSpinnerNative.SetValueNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, value);

            ProdSliderNative.SetValueNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, value);
        }

        private static void UiaSetValue(BaseProdControl control, double value)
        {
            LogController.ReceiveLogMessage(new LogMessage(value.ToString()));

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, RangeValuePattern.ValueProperty));
            RangeValuePatternHelper.SetValue(control.UIAElement, value);
        }

        /// <summary>
        /// Gets the maximum value of the control.
        /// </summary>
        /// <param name="theValue">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// The maximum value of the control
        /// </returns>
        public static double GetMaxValueBridge(this IRangeValue theValue, BaseProdControl control)
        {
            try
            {
                return UiaGetMaxValue(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetMaxValue(control);
            }
        }

        private static double NativeGetMaxValue(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.Spinner)
                return ProdSpinnerNative.GetMaximumNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return (double)ProdSliderNative.GetSmallChangeNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static double UiaGetMaxValue(BaseProdControl control)
        {
            double retVal = RangeValuePatternHelper.GetMaximum(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Gets the minimum value of the control.
        /// </summary>
        /// <param name="theValue">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// The minimum value of the control.
        /// </returns>
        public static double GetMinValueBridge(this IRangeValue theValue, BaseProdControl control)
        {
            try
            {
                return UiaGetMinValue(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetMinValue(control);
            }
        }

        private static double NativeGetMinValue(BaseProdControl control)
        {
            if (control.UIAElement.Current.ControlType == ControlType.Spinner)
                return ProdSpinnerNative.GetMinimumNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);

            return ProdSliderNative.GetMinimumNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static double UiaGetMinValue(BaseProdControl control)
        {
            double retVal = RangeValuePatternHelper.GetMinimum(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Gets the large change value for the control.
        /// </summary>
        /// <param name="theValue">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// A number indicating the increment of a large change
        /// </returns>
        public static double GetLargeChangeBridge(this IRangeValue theValue, BaseProdControl control)
        {
            try
            {
                return UiaGetLargeChange(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetLargeChange(control);
            }
        }

        private static double NativeGetLargeChange(BaseProdControl control)
        {
            return (double)ProdSliderNative.GetLargeChangeNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static double UiaGetLargeChange(BaseProdControl control)
        {
            double retVal = RangeValuePatternHelper.GetLargeChange(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Gets the small change value for the control.
        /// </summary>
        /// <param name="theValue">The extension interface.</param>
        /// <param name="control">The base ProdUI control.</param>
        /// <returns>
        /// A number indicating the increment of a small change
        /// </returns>
        public static double GetSmallChangeBridge(this IRangeValue theValue, BaseProdControl control)
        {
            try
            {
                return UiaGetSmallChange(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                return NativeGetSmallChange(control);
            }
        }

        private static double NativeGetSmallChange(BaseProdControl control)
        {
            return (double)ProdSliderNative.GetSmallChangeNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static double UiaGetSmallChange(BaseProdControl control)
        {
            double retVal = RangeValuePatternHelper.GetSmallChange(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }
    }
}