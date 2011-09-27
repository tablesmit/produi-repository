// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    internal sealed class ProdDataGrid : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdDataGrid(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdDataGrid(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdDataGrid(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        #region GridPattern

        /// <summary>
        ///     Gets the total number of columns in the ProdDataGrid
        /// </summary>
        /// <returns>The number of columns</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetColumnCount()
        {
            try
            {
                int retVal = GridPatternHelper.GetColumnCount(UIAElement);

                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the total number of rows in the ProdDataGrid
        /// </summary>
        /// <returns>The number of rows</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetRowCount()
        {
            try
            {
                int retVal = GridPatternHelper.GetRowCount(UIAElement);

                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the desired item from a ProdDataGrid.
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        /// <returns>The desired ProdDataGrid item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetItem(int row, int column)
        {
            try
            {
                AutomationElement retVal = GridPatternHelper.GetItem(UIAElement, row, column);

                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the column span of the passed in item.
        /// </summary>
        /// <param name = "dataItem">The data item.</param>
        /// <returns>Number of columns spanned by a cell or item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemColumnSpan(AutomationElement dataItem)
        {
            try
            {
                int retVal = GridPatternHelper.GetColumnSpan(dataItem);

                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the row span of the passed in item.
        /// </summary>
        /// <param name = "dataItem">The data item.</param>
        /// <returns>Number of rows spanned by a cell or item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemRowSpan(AutomationElement dataItem)
        {
            try
            {
                int retVal = GridPatternHelper.GetRowSpan(dataItem);

                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        #endregion

        #region SelectionProvider

        /// <summary>
        ///     Selects an item in a DataGrid.
        /// </summary>
        /// <param name = "dataItem">The data item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectItem(AutomationElement dataItem)
        {
            LogText = "Item: " + dataItem.Current.AutomationId;

            try
            {
                RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                SelectionPatternHelper.Select(dataItem);

                LogMessage();
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Selects an item in a DataGrid
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectItem(int row, int column)
        {
            try
            {
                AutomationElement dataItem = GetItem(row, column);

                LogText = "Item: " + dataItem.Current.AutomationId;
                RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);

                SelectionPatternHelper.Select(dataItem);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets Whether the control supports multiple selection of items
        /// </summary>
        /// <returns>True if it supports multiple selection, false otherwise</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool CanSelectMultiple()
        {
            try
            {
                bool retVal = SelectionPatternHelper.CanSelectMultiple(UIAElement);

                LogText = retVal.ToString(CultureInfo.CurrentCulture);
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     DeSelect an item in the DataGrid control
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(int row, int column)
        {
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }


                AutomationElement dataItem = GetItem(row, column);

                LogText = "Item: " + dataItem.Current.AutomationId;
                RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);

                SelectionPatternHelper.RemoveFromSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     DeSelect an item in the DataGrid control
        /// </summary>
        /// <param name = "dataItem">The data item to deselect.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(AutomationElement dataItem)
        {
            LogText = "Item: " + dataItem.Current.AutomationId;
            try
            {
                RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
                SelectionPatternHelper.RemoveFromSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Selects an item in a multi-select DataGrid control without deselecting other items
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///     Only valid for multiple selection DataGrid controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(int row, int column)
        {
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }


                AutomationElement dataItem = GetItem(row, column);

                LogText = "Item: " + dataItem.Current.AutomationId;
                RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);

                //SelectionPatternHelper.AddToSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Selects an item in a multi-select DataGrid control without deselecting other items
        /// </summary>
        /// <param name = "dataItem">The data item to select.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///     Only valid for multiple selection controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(AutomationElement dataItem)
        {
            LogText = "Item: " + dataItem.Current.AutomationId;
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }


                RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                //SelectionPatternHelper.AddToSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        #endregion

        #region TablePattern

        /// <summary>
        ///     Gets a collection of UI Automation providers that represents all the column headers in a DataGrid
        /// </summary>
        /// <returns>An array of header items</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElement[] GetColumnHeaders()
        {
            try
            {
                AutomationElement[] retVal = TablePatternHelper.GetColumnHeaders(UIAElement);
                List<object> retList = new List<object>();
                foreach (AutomationElement item in retVal)
                {
                    retList.Add(item);
                }
                LogText = "Column Headers";
                VerboseInformation = retList;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets a collection of UI Automation providers that represents all the row headers in a DataGrid
        /// </summary>
        /// <returns>An array of header items</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElement[] GetRowHeaders()
        {
            try
            {
                AutomationElement[] retVal = TablePatternHelper.GetRowHeaders(UIAElement);
                List<object> retList = new List<object>(retVal);

                LogText = "Row Headers";
                VerboseInformation = retList;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Retrieves the primary direction of traversal for the table
        /// </summary>
        /// <returns>The primary direction of traversal. </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public RowOrColumnMajor GetRowOrColumnMajor()
        {
            try
            {
                RowOrColumnMajor retVal = TablePatternHelper.GetRowOrColumnMajor(UIAElement);

                LogText = "Row Or Column Major: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw;
            }
            catch (ElementNotAvailableException err)
            {
                throw;
            }
        }

        #endregion
    }
}