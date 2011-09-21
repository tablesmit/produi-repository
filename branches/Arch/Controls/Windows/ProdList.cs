// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.Bridge;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

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
        public ProdList(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdList(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdList(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        ///     Gets the items in a List control.
        /// </summary>
        /// <returns>
        ///     an ArrayList containing the items in a List control
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetItems()
        {
            AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(UIAElement);

            List<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);

            LogText = "Items:";
            VerboseInformation = retVal;
            LogMessage();

            return retVal;
        }

        /// <summary>
        ///     Gets the number of items in the List control
        /// </summary>
        /// <returns>
        ///     The number of items in the list
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public int GetItemCount()
        {
            AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(UIAElement);
            return convRet.Count;
        }

        /// <summary>
        /// Determines whether this instance can select multiple item selection.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can select multiple; otherwise, <c>false</c>.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool CanSelectMultiple()
        {
            bool retVal = SelectionPatternHelper.CanSelectMultiple(UIAElement);

            LogText = "Value " + retVal;
            LogMessage();

            return retVal;
        }

        #region single select specific

        /// <summary>
        ///     Gets the index of the selected item.
        /// </summary>
        /// <returns>
        ///     The zero based index of the selected item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedIndex()
        {
            int retVal = this.GetSelectedIndexBridge(this);
            LogText = retVal.ToString(CultureInfo.CurrentCulture);
            LogMessage();
            return retVal;
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
            AutomationElement retVal = this.GetSelectedItemBridge(this);
            LogText = "Item " + retVal;
            LogMessage();

            return retVal;
        }


        /// <summary>
        ///     Sets the selected list item.
        /// </summary>
        /// <param name = "index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedIndex(int index)
        {
            LogText = "Index " + index;

            this.SetSelectedIndexBridge(this, index);
        }


        /// <summary>
        ///     Sets the selected list item.
        /// </summary>
        /// <param name = "itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            LogText = "Item " + itemText;

            this.SetSelectedItemBridge(this, itemText);
        }

        #endregion

        #region Multi Select specific

        /// <summary>
        ///     Adds the selected list item to the current selection.
        /// </summary>
        /// <param name = "index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(int index)
        {
            LogText = "Index " + index;

            RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
            this.AddToSelectionBridge(this, index);
        }

        /// <summary>
        ///     Adds the selected list item to the current selection.
        /// </summary>
        /// <param name = "itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(string itemText)
        {
            LogText = "Item " + itemText;

            RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
            this.AddToSelectionBridge(this, itemText);
        }

        /// <summary>
        ///     Gets the selected indexes.
        /// </summary>
        /// <returns>
        ///     An ArrayList of all the indexes of currently selected list items.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetSelectedIndexes()
        {
            List<object> retList = this.GetSelectedIndexesBridge((this));

            LogText = "Index";
            VerboseInformation = retList;
            LogMessage();

            return retList;
        }

        /// <summary>
        ///     Gets the selected items.
        /// </summary>
        /// <returns>
        ///     An ArrayList of all currently selected list items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetSelectedItems()
        {
            List<object> retList = this.GetSelectedItemsBridge(this);

            LogText = "Items: ";
            VerboseInformation = retList;
            LogMessage();

            return retList;
        }

        /// <summary>
        ///     Gets the selected item count.
        /// </summary>
        /// <returns>
        ///     The count of selected items
        /// </returns>
        public int GetSelectedItemCount()
        {
            int retVal = this.GetSelectedItemCountBridge(this);

            LogText = "Count: " + retVal;
            LogMessage();

            return retVal;
        }

        /// <summary>
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "index">The index of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(int index)
        {
            RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
            this.RemoveFromSelectionBridge(this, index);

            LogText = "Index: " + index;
            LogMessage();
        }

        /// <summary>
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "itemText">The text of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(string itemText)
        {
            RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
            this.RemoveFromSelectionBridge(this, itemText);

            LogText = "Item: " + itemText;
            LogMessage();
        }

        /// <summary>
        ///     Selects all items in a ListBox.
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectAll()
        {
            LogText = "Select All";
            LogMessage();

            foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(UIAElement))
            {
                this.AddToSelectionBridge(this, item.Current.Name);
            }
        }


        /// <summary>
        ///     Sets the select indexes from a supplied list.
        /// </summary>
        /// <param name = "indexes">The indexes to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SetSelectIndexes(Collection<int> indexes)
        {
            foreach (int index in indexes)
            {
                this.AddToSelectionBridge(this, index);
            }

            List<object> retList = new List<object> {
                                                        indexes
                                                    };

            LogText = "Indexes";
            VerboseInformation = retList;
            LogMessage();
        }

        /// <summary>
        ///     Sets the selected items from a supplied list.
        /// </summary>
        /// <param name = "items">The text of the items to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SetSelectedItems(Collection<string> items)
        {
            foreach (string item in items)
            {
                this.AddToSelectionBridge(this, item);
            }

            List<object> retList = new List<object>(items);
            LogText = "Items";
            VerboseInformation = retList;
            LogMessage();
        }

        #endregion
    }
}