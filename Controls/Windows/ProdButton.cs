// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.Bridge;

/* Notes
 * Supported Patterns: 
 * IInvokeProvider 
 * (IToggleProvider) -> ToggleButton
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    /// Methods to work with Button controls using the UI Automation framework
    /// </summary>
    public sealed class ProdButton : BaseProdControl, IInvoke
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdButton(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdButton(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdButton(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        /// Performs a "Click" on the current ProdButton
        /// </summary>
        public void Click()
        {
            this.ClickBridge(this);
        }
    }
}