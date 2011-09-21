// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.Bridge;

/* 
 * Supported Patterns: 
 * IValueProvider 
 * ITextProvider 
 * 
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Provides mechanisms to work with Edit (or TextBox) controls
    /// </summary>
    public sealed class ProdEdit : BaseProdControl, IValue
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        public ProdEdit(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdEdit(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdEdit(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        /// Appends text to a text input control
        /// </summary>
        /// <param name="newText">Text To Append</param>
        public void AppendText(string newText)
        {
            this.AppendTextBridge(this, newText);
        }

        public void Clear()
        {
            this.ClearTextBridge(this);
        }
    }
}