/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Interaction.Native;


namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///   Methods to work with Slider (or Track Bar) controls using the UI Automation framework
    /// </summary>
    public sealed class ProdSlider : BaseProdControl
    {

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdSlider(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdSlider(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdSlider(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion


        /// <summary>
        ///   Sets the value.
        /// </summary>
        /// <param name = "value">The value.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetValue(double value)
        {
            LogText = "Value: " + value;
            try
            {
                RegisterEvent(RangeValuePattern.ValueProperty);
                int ret = RangeValuePatternHelper.SetValue(UIAElement, value);

                if (ret == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdSliderNative.SetValueNative(NativeWindowHandle, value);
                }
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the value.
        /// </summary>
        /// <returns></returns>
         [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetValue()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetValue(UIAElement);

                if (retVal == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                   retVal = ProdSliderNative.GetMaximumNative(NativeWindowHandle);
                }

                LogText = "Value: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the large change.
        /// </summary>
        /// <returns></returns>
         [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetLargeChange()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetLargeChange(UIAElement);

                LogText = "Value: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the max value.
        /// </summary>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetMaxValue()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetMaximum(UIAElement);

                if (retVal == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdSliderNative.GetMaximumNative(NativeWindowHandle);
                }

                LogText = "Value: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the min value.
        /// </summary>
        /// <returns></returns>
         [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetMinValue()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetMinimum(UIAElement);

                if (retVal == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdSliderNative.GetMinimumNative(NativeWindowHandle);
                }

                LogText = "Value: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the small change.
        /// </summary>
        /// <returns></returns>
         [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetSmallChange()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetSmallChange(UIAElement);

                LogText = "Value: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }
    }
}