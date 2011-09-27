// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Windows.Automation;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

/* Notes
 * --ListBox Portion--
 * Supported Patterns:
 * ISelectionProvider
 * IExpandCollapseProvider
 *
 * Proposed functionality:
 * SetSelectedItem - index and text
 * GetSelectedItem - index and text
 * Item count
 * Get all items
 * additem
 *
 * --Textbox portion--
 * Supported Pattern:
 * IValueProvider
 *
 * Proposed functionality:
 * is editing supported
 * gettext
 * settext
 * appendtext
 * cleartext
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with ComboBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdComboBox : BaseProdControl, ISingleSelectList, IValue
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdComboBox(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdComboBox(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdComboBox(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        #region List Instance Methods

        /// <summary>
        /// Gets the number of items in the List control
        /// </summary>
        /// <returns>
        /// The number of items in the list
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemCount()
        {
            return this.GetItemCountBridge(this);
        }

        /// <summary>
        /// Gets the selected item
        /// </summary>
        /// <returns>
        /// The currently selected item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetSelectedItem()
        {
            return this.GetSelectedItemBridge(this);
        }

        /// <summary>
        /// Gets the zero-based index of the currently selected item
        /// </summary>
        /// <returns>
        /// The zero based index of the selected item in the list
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedIndex()
        {
            return this.GetSelectedIndexBridge(this);
        }

        /// <summary>
        ///     Selects the item by its index.
        /// </summary>
        /// <param name = "index">The index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedIndex(int index)
        {
            this.SetSelectedIndexBridge(this, index);
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="itemText">The item text.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            this.SetSelectedItemBridge(this, itemText);
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

        /// <summary>
        /// Get all items contained in the list control
        /// </summary>
        /// <returns>
        /// List containing text of all items in the list control
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetItems()
        {
            return this.GetItemsBridge(this);
        }

        #endregion List Instance Methods

        #region Textbox Instance Methods

        /// <summary>
        /// Gets the number of characters in textbox
        /// </summary>
        /// <returns>
        /// The length of the string in the TextBox (if supported)
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int Length()
        {
            return this.GetLengthBridge(this);
        }

        /// <summary>
        /// Gets the text contained in the current TextBox
        /// </summary>
        /// <returns>
        /// The string in the Textbox (if supported)
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            return this.GetTextBridge(this);
        }

        /// <summary>
        /// Sets the text contained in the current TextBox
        /// </summary>
        /// <param name="text">The text to set the TextBox to (if supported)</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            this.SetTextBridge(this, text);
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