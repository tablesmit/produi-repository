// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Logging;

namespace ProdControls
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
        /// <param name="automationId">The UI Automation element</param>
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value of the control.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double Value
        {
            get { return this.GetValueBridge(this); }
            set { this.SetValueBridge(this, value); }
        }


        /// <summary>
        /// Gets the maximum value of the control
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double MaxValue
        {
            get { return this.GetMaxValueBridge(this); }
        }

        /// <summary>
        /// Gets the minimum value of the control
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double MinValue
        {
            get { return this.GetMinValueBridge(this); }
        }

        /// <summary>
        /// Gets the large change value for the control.
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double LargeChange
        {
            get { return this.GetLargeChangeBridge(this); }
        }

        /// <summary>
        /// Gets the small change value for the control.
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public double SmallChange
        {
            get { return this.GetSmallChangeBridge(this); }
        }
    }
}