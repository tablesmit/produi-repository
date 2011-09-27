// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;

/* Notes
 * Supported Patterns:
 * ExpandCollapsePattern
 * DockPattern
 * TransformPattern
 *
 * Proposed funtionality:
 *
 */

//TODO: Not Implemented

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Identifies a toolbar, such as the control that contains a set of command buttons in an application window
    /// </summary>
    public sealed class ProdToolBar : BaseProdControl
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
        public ProdToolBar(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdToolBar(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdToolBar(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors
    }
}