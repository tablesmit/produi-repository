// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.ObjectModel;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    /// Methods to work with ComboBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdComboBox : BaseProdControl, ISingleSelectList, IValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation element</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdComboBox(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdComboBox(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdComboBox(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        #region List properties and methods

        /// <summary>
        /// Gets the number of items in the List control
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int ItemCount
        {
            get { return this.GetItemCountBridge(this); }
        }

        /// <summary>
        /// Gets or sets the selected item by text
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string SelectedItem
        {
            get { return this.GetSelectedItemBridge(this).Current.Name; }
            set { this.SetSelectedItemBridge(this, value); }
        }

        /// <summary>
        /// Gets or sets the zero-based index of the currently selected item
        /// </summary>
        /// <value>
        /// The index of the selected item.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int SelectedIndex
        {
            get { return this.GetSelectedIndexBridge(this); }
            set { this.SetSelectedIndexBridge(this, value); }
        }

        /// <summary>
        /// Get all items contained in the list control
        /// </summary>
        /// <returns>
        /// List containing text of all items in the list control
        ///   </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public Collection<object> GetItems
        {
            get { return this.GetItemsBridge(this); }
        }


        /// <summary>
        /// Determines whether the specified index is selected.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool IsSelected(int index)
        {
            return this.IsItemSelectedBridge(this, index);
        }

        /// <summary>
        /// Determines whether the specified item text is selected.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool IsSelected(string text)
        {
            return this.IsItemSelectedBridge(this, text);
        }



        #endregion

        #region Textbox properties and methods

        /// <summary>
        /// Gets the number of characters in textbox
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int Length
        {
            get { return this.GetLengthBridge(this); }
        }

        /// <summary>
        /// Gets or sets the text contained in the current TextBox
        /// </summary>
        /// <value>
        /// The string in the Textbox (if supported)
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string Text
        {
            get { return this.GetTextBridge(this); }
            set { this.SetTextBridge(this, value); }
        }

        /// <summary>
        /// Set text area value to an empty string
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Clear()
        {
            this.ClearTextBridge(this);
        }

        /// <summary>
        /// Appends text to a text input control
        /// </summary>
        /// <param name="text">The text.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AppendText(string text)
        {
            this.AppendTextBridge(this, text);
        }

        #endregion Textbox Instance Methods
    }
}