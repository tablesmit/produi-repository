// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    /// Methods to work with CheckBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdCheckBox : BaseProdControl, IToggle
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation element</param>
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
        /// Gets or sets the check state of the CheckBox.
        /// </summary>
        /// <value>
        /// The check state of the CheckBox.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public ToggleState CheckState
        {
            get
            {
                return this.GetCheckStateBridge(this);
            }
            set
            {
                this.SetCheckStateBridge(this, value);
            }
        }

        /// <summary>
        /// Changes the CheckState of checkbox to next valid CheckState
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Toggle()
        {
            this.ToggleCheckStateBridge(this);
        }
    }
}