// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

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
        /// <param name="automationId">The UI Automation identifier (ID) for the element.</param>
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
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetValue(double value)
        {
            this.SetValueBridge(this, value);
        }

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
    }
}