/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Exceptions;
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

namespace ProdUI.Controls
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
        ///   Will attempt to match AutomationId, then Name
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
                AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(ThisElement);

                List<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);

                Logmessage = "Items:";
                VerboseInformation = retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(ThisElement);
                return convRet.Count;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                bool retVal = SelectionPatternHelper.CanSelectMultiple(ThisElement);

                Logmessage = "Value " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                    AutomationElement[] element = SelectionPatternHelper.GetSelection(ThisElement);
                    int retVal = SelectionPatternHelper.FindIndexByItem(element[0]);
                    Logmessage = retVal.ToString(CultureInfo.CurrentCulture);
                    LogEntry();
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
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(ThisElement);
                Logmessage = "Item " + retVal[0];
                LogEntry();

                return retVal[0];
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }


        /// <summary>Sets the selected list item.</summary>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedIndex(int index)
        {
            Logmessage = "Index " + index;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(ThisElement, index);
                SelectionPatternHelper.Select(indexedItem);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }


        /// <summary>Sets the selected list item.</summary>
        /// <param name="itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            Logmessage = "Item " + itemText;
            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement control = SelectionPatternHelper.FindItemByText(ThisElement, itemText);
                SelectionPatternHelper.Select(control);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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


            Logmessage = "Index " + index;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(ThisElement, index);
                SelectionPatternHelper.AddToSelection(itemToSelect);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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


            Logmessage = "Item " + itemText;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(ThisElement, itemText);
                SelectionPatternHelper.AddToSelection(itemToSelect);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(ThisElement);
                List<object> retList = new List<object>{(selectedItems)};

                Logmessage = "Index";
                VerboseInformation = retList;
                LogEntry();

                return retList;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                throw new ProdOperationException(Name + " does not allow multiple selection");
            }

            try
            {
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(ThisElement);
                List<object> retList = new List<object> {selectedItems};

                Logmessage = "Items: ";
                VerboseInformation = retList;
                LogEntry();

                return retList;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(ThisElement);

                Logmessage = "Count: " + selectedItems.Length;
                LogEntry();

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
                SubscribeToEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(ThisElement, index);
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);

                Logmessage = "Index: " + index;
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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


                SubscribeToEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(ThisElement, itemText);
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);

                Logmessage = "Item: " + itemText;
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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

                Logmessage = "Select All";
                LogEntry();

                foreach (AutomationElement item in SelectionPatternHelper.GetListCollectionUtility(ThisElement))
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

                Logmessage = "Indexes";
                VerboseInformation = retList;
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
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
                Logmessage = "Items";
                VerboseInformation = retList;
                LogEntry();
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }


        #endregion

    }
}