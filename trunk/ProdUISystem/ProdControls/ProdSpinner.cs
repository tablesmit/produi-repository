// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Logging;

namespace ProdControls
{
    /// <summary>
    /// Methods to work with Spinner (or numeric up/down) controls using the UI Automation framework
    /// A Spinner control type consists of a set of buttons that enable a user to select from a set of items or set a numerical value from within a range
    /// </summary>
    public sealed class ProdSpinner : BaseProdControl, IRangeValue
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
        public ProdSpinner(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdSpinner(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdSlider class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdSpinner(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The desired value.
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
    }
}