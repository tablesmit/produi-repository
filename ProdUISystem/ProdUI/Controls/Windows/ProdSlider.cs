// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with Slider (or Track Bar) controls using the UI Automation framework
    /// </summary>
    public sealed class ProdSlider : BaseProdControl, IRangeValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdSlider(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdSlider(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdSlider(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The current value of the slider</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetValue()
        {
            return this.GetValueBridge(this);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetValue(double value)
        {
            this.SetValueBridge(this, value);
        }

        /// <summary>
        /// Gets the maximum value of the control
        /// </summary>
        /// <returns>
        /// The maximum value of the control
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetMaxValue()
        {
            return this.GetMaxValueBridge(this);
        }

        /// <summary>
        /// Gets the minimum value of the control
        /// </summary>
        /// <returns>
        /// The minimum value of the control
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetMinValue()
        {
            return this.GetMinValueBridge(this);
        }

        /// <summary>
        /// Gets the large change value for the control.
        /// </summary>
        /// <returns>
        /// A number indicating the increment of a large change.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetLargeChange()
        {
            return this.GetLargeChangeBridge(this);
        }

        /// <summary>
        /// Gets the small change value for the control.
        /// </summary>
        /// <returns>
        /// A number indicating the increment of a small change.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double GetSmallChange()
        {
            return this.GetSmallChangeBridge(this);
        }
    }
}