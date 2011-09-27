// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

/* Notes
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
 * SupportsMultipleSelection
 * SelectMultipleItems
 * GetAllSelectedItems -object and index
 * AddToSelection
 * RemoveFromSelection
 * ClearItems
 *
 * ListBoxes can support non-text items
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with ListBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdList : BaseProdControl, ISingleSelectList, IMultipleSelectionList
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdList(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdList(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdList(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        /// <summary>
        ///     Gets the items in a List control.
        /// </summary>
        /// <returns>
        ///     an ArrayList containing the items in a List control
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetItems()
        {
            return this.GetItemsBridge(this);
        }

        /// <summary>
        ///     Gets the number of items in the List control
        /// </summary>
        /// <returns>
        ///     The number of items in the list
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemCount()
        {
            return this.GetItemCountBridge(this);
        }

        #region single select specific

        /// <summary>
        /// Gets the index of the selected item.
        /// </summary>
        /// <returns>
        /// The zero based index of the selected item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedIndex()
        {
            return this.GetSelectedIndexBridge(this);
        }

        /// <summary>
        ///     Gets the selected list item.
        /// </summary>
        /// <returns>
        ///     The selected List element
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetSelectedItem()
        {
            return this.GetSelectedItemBridge(this);
        }

        /// <summary>
        ///     Sets the selected list item.
        /// </summary>
        /// <param name = "index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedIndex(int index)
        {
            this.SetSelectedIndexBridge(this, index);
        }

        /// <summary>
        ///     Sets the selected list item.
        /// </summary>
        /// <param name = "itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            this.SetSelectedItemBridge(this, itemText);
        }

        #endregion single select specific

        #region Multi Select specific

        /// <summary>
        /// Adds the selected list item to the current selection.
        /// </summary>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(int index)
        {
            this.AddToSelectionBridge(this, index);
        }

        /// <summary>
        ///     Adds the selected list item to the current selection.
        /// </summary>
        /// <param name = "itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(string itemText)
        {
            this.AddToSelectionBridge(this, itemText);
        }

        /// <summary>
        ///     Gets the selected indexes.
        /// </summary>
        /// <returns>
        ///     A List of all the indexes of currently selected list items.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<int> GetSelectedIndexes()
        {
            return this.GetSelectedIndexesBridge((this));
        }

        /// <summary>
        ///     Gets the selected items.
        /// </summary>
        /// <returns>
        ///     A List of all currently selected list items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetSelectedItems()
        {
            return this.GetSelectedItemsBridge(this);
        }

        /// <summary>
        /// Gets the selected item count.
        /// </summary>
        /// <returns>
        /// The count of selected items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedItemCount()
        {
            return this.GetSelectedItemCountBridge(this);
        }

        /// <summary>
        /// Removes the selected list item from the current selection.
        /// </summary>
        /// <param name="index">The index of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(int index)
        {
            this.RemoveFromSelectionBridge(this, index);
        }

        /// <summary>
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "itemText">The text of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(string itemText)
        {
            this.RemoveFromSelectionBridge(this, itemText);
        }

        /// <summary>
        /// Selects all items in a ListBox.
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectAll()
        {
            this.SelectAllBridge(this);
        }

        /// <summary>
        /// Sets the select indexes from a supplied list.
        /// </summary>
        /// <param name="indexes">The indexes to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SetSelectIndexes(List<int> indexes)
        {
            this.SetSelectedIndexesBridge(this, indexes);
        }

        /// <summary>
        /// Sets the selected items from a supplied list.
        /// </summary>
        /// <param name="items">The text of the items to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SetSelectedItems(Collection<string> items)
        {
            this.SetSelectedItemsBridge(this, items);
        }

        #endregion Multi Select specific
    }
}