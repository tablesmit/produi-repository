// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with RadioButton controls using the UI Automation framework
    /// </summary>
    public sealed class ProdRadioButton : BaseProdControl, ISelection
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdRadioButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdRadioButton(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdRadioButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdRadioButton(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdRadioButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdRadioButton(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        /// Gets a value indicating whether the control is checked
        /// </summary>
        /// <returns></returns>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetChecked()
        {
            return this.GetIsSelectedBridge(this);
        }

        /// <summary>
        /// Selects a radio button, deselecting others in its group
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Select()
        {
            this.SetIsSelectedBridge(this);
        }
    }
}