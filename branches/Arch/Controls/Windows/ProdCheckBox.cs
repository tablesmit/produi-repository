// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with CheckBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdCheckBox : BaseProdControl, IToggle
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdCheckBox(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdCheckBox(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdCheckBox(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Gets the current ToggleState
        /// </summary>
        /// <returns>
        /// The state of the checkbox.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public ToggleState GetCheckState()
        {
            return this.GetCheckStateBridge(this);
        }

        /// <summary>
        /// Sets the current CheckBoxes state.
        /// </summary>
        /// <param name="checkstate">The ProdCheckState.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetCheckState(ToggleState checkstate)
        {
            this.SetCheckStateBridge(this, checkstate);
        }

        /// <summary>
        /// Changes the CheckState of checkbox to next valid CheckState
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void ToggleCheckState()
        {
            this.ToggleCheckStateBridge(this);
        }
    }
}