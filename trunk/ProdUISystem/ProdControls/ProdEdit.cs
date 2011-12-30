// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Interaction.Bridge;


namespace ProdUI.Controls.Windows
{
    /// <summary>
    /// Provides mechanisms to work with Edit (or TextBox) controls
    /// </summary>
    public sealed class ProdEdit : BaseProdControl, IValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation element</param>
        public ProdEdit(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdEdit(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdEdit(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        /// Appends text to a text input control
        /// </summary>
        /// <param name="text">Text To Append</param>
        public void AppendText(string text)
        {
            this.AppendTextBridge(this, text);
        }

        /// <summary>
        /// Clears the edit control of text.
        /// </summary>
        public void Clear()
        {
            this.ClearTextBridge(this);
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return this.GetTextBridge(this); }
            set { this.SetTextBridge(this, value); }
        }


        /// <summary>
        /// Gets the number of characters.
        /// </summary>
        public int Length
        {
            get
            {
                return this.GetLengthBridge(this);
            }
        }

        /// <summary>
        /// Inserts the text at the specified (zero-based) index.
        /// </summary>
        /// <param name="text">The text to insert.</param>
        /// <param name="index">The zero-based index.</param>
        public void InsertText(string text, int index)
        {
            this.InsertTextBridge(this, text, index);
        }
    }
}