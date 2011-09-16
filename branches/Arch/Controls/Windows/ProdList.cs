/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Interaction.UIAPatterns;

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
    ///   Methods to work with ListBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdList : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdList(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdList(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdList(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion


        /// <summary>Gets the items in a List control.</summary>
        /// <returns>an ArrayList containing the items in a List control</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetItems()
        {
            try
            {
                AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(UIAElement);

                List<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);

                LogText = "Items:";
                VerboseInformation = retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the number of items in the List control
        /// </summary>
        /// <returns>The number of items in the list</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception> 
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public int GetItemCount()
        {
            try
            {
                AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(UIAElement);
                return convRet.Count;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
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
            try
            {
                bool retVal = SelectionPatternHelper.CanSelectMultiple(UIAElement);

                LogText = "Value " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        #region single select specific


        /// <summary>Gets the index of the selected item.</summary>
        /// <returns>The zero based index of the selected item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedIndex()
        {
            try
            {
                if (!CanSelectMultiple())
                {
                    AutomationElement[] element = SelectionPatternHelper.GetSelection(UIAElement);
                    int retVal = SelectionPatternHelper.FindIndexByItem(UIAElement, element[0].Current.Name);
                    LogText = retVal.ToString(CultureInfo.CurrentCulture);
                    LogMessage();
                    return retVal;
                }
                throw new ProdOperationException("Does not support single selection");
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>Gets the selected list item.</summary>
        /// <returns>The selected List element</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetSelectedItem()
        {
            try
            {
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(UIAElement);
                LogText = "Item " + retVal[0];
                LogMessage();

                return retVal[0];
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        /// <summary>Sets the selected list item.</summary>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedIndex(int index)
        {
            LogText = "Index " + index;

            try
            {
                RegisterEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(UIAElement, index);
                SelectionPatternHelper.Select(indexedItem);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        /// <summary>Sets the selected list item.</summary>
        /// <param name="itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            LogText = "Item " + itemText;
            try
            {
                RegisterEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement control = SelectionPatternHelper.FindItemByText(UIAElement, itemText);
                SelectionPatternHelper.Select(control);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        #endregion

        #region Multi Select specific

        /// <summary>Adds the selected list item to the current selection.</summary>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(int index)
        {
            if (!CanSelectMultiple())
            {
                return;
            }


            LogText = "Index " + index;

            try
            {
                RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
               // AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(UIAElement, index);
                SelectionPatternHelper.AddToSelection(UIAElement, index);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Adds the selected list item to the current selection.</summary>
        /// <param name="itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(string itemText)
        {
            if (!CanSelectMultiple())
            {
                return;
            }


            LogText = "Item " + itemText;

            try
            {
                RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                //AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(UIAElement, itemText);
                SelectionPatternHelper.AddToSelection(UIAElement, itemText);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Gets the selected indexes.</summary>
        /// <returns>An ArrayList of all the indexes of currently selected list items.</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetSelectedIndexes()
        {
            if (!CanSelectMultiple())
            {
                return null;
            }


            try
            {
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(UIAElement);
                List<object> retList = new List<object>{(selectedItems)};

                LogText = "Index";
                VerboseInformation = retList;
                LogMessage();

                return retList;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Gets the selected items.</summary>
        /// <returns>An ArrayList of all currently selected list items</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetSelectedItems()
        {
            if (!CanSelectMultiple())
            {
                throw new ProdOperationException("Does not allow multiple selection");
            }

            try
            {
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(UIAElement);
                List<object> retList = new List<object> {selectedItems};

                LogText = "Items: ";
                VerboseInformation = retList;
                LogMessage();

                return retList;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Gets the selected item count.</summary>
        /// <returns>The count of selected items</returns>
        public int GetSelectedItemCount()
        {
            if (!CanSelectMultiple())
            {
                return -1;
            }

            try
            {
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(UIAElement);

                LogText = "Count: " + selectedItems.Length;
                LogMessage();

                return selectedItems.Length;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>Removes the selected list item from the current selection.</summary>
        /// <param name="index">The index of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(int index)
        {
            if (!CanSelectMultiple())
            {
                return;
            }

            try
            {
                RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(UIAElement, index);
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);

                LogText = "Index: " + index;
                LogMessage();
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Removes the selected list item from the current selection.</summary>
        /// <param name="itemText">The text of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(string itemText)
        {
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }


                RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(UIAElement, itemText);
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);

                LogText = "Item: " + itemText;
                LogMessage();
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Selects all items in a ListBox.</summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectAll()
        {
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }

                LogText = "Select All";
                LogMessage();

                foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(UIAElement))
                {
                    AddToSelection(item.Current.Name);
                }
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }


        /// <summary>Sets the select indexes from a supplied list.</summary>
        /// <param name="indexes">The indexes to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SetSelectIndexes(Collection<int> indexes)
        {
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }


                foreach (int index in indexes)
                {
                    AddToSelection(index);
                }

                List<object> retList = new List<object> {indexes};

                LogText = "Indexes";
                VerboseInformation = retList;
                LogMessage();
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Sets the selected items from a supplied list.</summary>
        /// <param name="items">The text of the items to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SetSelectedItems(Collection<string> items)
        {
            try
            {
                foreach (string item in items)
                {
                    AddToSelection(item);
                }

                List<object> retList = new List<object>(items);
                LogText = "Items";
                VerboseInformation = retList;
                LogMessage();
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        #endregion

    }
}