// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;

/* Notes
 * Supported Patterns: 
 * ISelectionProvider  
 * IRangeValueProvider 
 * IValueProvider 
 * 
 * Proposed functionality:
 * Get/Set Value
 * GetMaxValue
 * GetMinValue
 * GetRadix (supports base 10 and 16)
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with Spinner (or numeric up/down) controls using the UI Automation framework
    ///     A Spinner control type consists of a set of buttons that enable a user to select from a set of items or set a numerical value from within a range
    /// </summary>
    public sealed class ProdSpinner : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdSpinner(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdSpinner(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdSpinner(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        ///     Sets the value.
        /// </summary>
        /// <param name = "value">The value.</param>
        public void SetValue(double value)
        {
            LogText = "Value: " + value;
            try
            {
                RegisterEvent(RangeValuePattern.ValueProperty);
                int ret = RangeValuePatternHelper.SetValue(UIAElement, value);

                if (ret == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdSpinnerNative.SetValueNative(NativeWindowHandle, value);
                }
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetValue(UIAElement);

                if (retVal == -1)
                {
                    ProdSliderNative.GetValueNative(NativeWindowHandle);
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
        ///     Gets the max value.
        /// </summary>
        /// <returns></returns>
        public double GetMaxValue()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetMaximum(UIAElement);

                if (retVal == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdSpinnerNative.GetMaximumNative(NativeWindowHandle);
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
        ///     Gets the min value.
        /// </summary>
        /// <returns></returns>
        public double GetMinValue()
        {
            try
            {
                double retVal = RangeValuePatternHelper.GetMinimum(UIAElement);

                if (retVal == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdSpinnerNative.GetMinimumNative(NativeWindowHandle);
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
    }
}