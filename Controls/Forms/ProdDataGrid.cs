/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Controls
{
    internal sealed class ProdDataGrid : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdDataGrid(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdDataGrid(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdDataGrid(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        #region GridPattern

        /// <summary>
        ///   Gets the total number of columns in the ProdDataGrid
        /// </summary>
        /// <returns>The number of columns</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetColumnCount()
        {
            try
            {
                if (CheckPatternSupport(GridPattern.Pattern, UIAElement))
                {
                    int retVal = GridPatternHelper.GetColumnCount(UIAElement);

                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support GridPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return -1;
            }
        }

        /// <summary>
        ///   Gets the total number of rows in the ProdDataGrid
        /// </summary>
        /// <returns>The number of rows</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetRowCount()
        {
            try
            {
                if (CheckPatternSupport(GridPattern.Pattern, UIAElement))
                {
                    int retVal = GridPatternHelper.GetRowCount(UIAElement);

                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support GridPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return -1;
            }
        }

        /// <summary>
        ///   Gets the desired item from a ProdDataGrid.
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        /// <returns>The desired ProdDataGrid item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetItem(int row, int column)
        {
            try
            {
                if (CheckPatternSupport(GridPattern.Pattern, UIAElement))
                {
                    AutomationElement retVal = GridPatternHelper.GetItem(UIAElement, row, column);

                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support GridPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return null;
            }
        }

        /// <summary>
        ///   Gets the column span of the passed in item.
        /// </summary>
        /// <param name = "dataItem">The data item.</param>
        /// <returns>Number of columns spanned by a cell or item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemColumnSpan(AutomationElement dataItem)
        {
            try
            {
                if (CheckPatternSupport(GridItemPattern.Pattern, dataItem))
                {
                    int retVal = GridPatternHelper.GetColumnSpan(dataItem);

                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support GridItemPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return -1;
            }
        }

        /// <summary>
        ///   Gets the row span of the passed in item.
        /// </summary>
        /// <param name = "dataItem">The data item.</param>
        /// <returns>Number of rows spanned by a cell or item</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemRowSpan(AutomationElement dataItem)
        {
            try
            {
                if (CheckPatternSupport(GridItemPattern.Pattern, dataItem))
                {
                    int retVal = GridPatternHelper.GetRowSpan(dataItem);

                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support GridItemPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return -1;
            }
        }

        #endregion

        #region SelectionProvider

        /// <summary>
        ///   Selects an item in a DataGrid.
        /// </summary>
        /// <param name = "dataItem">The data item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectItem(AutomationElement dataItem)
        { 
            Logmessage = "Item: " + dataItem.Current.AutomationId;

            try
            {
                if (CheckPatternSupport(SelectionItemPattern.Pattern, UIAElement))
                {
                    SubscribeToEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                    SelectionPatternHelper.Select(dataItem);
                   
                    CreateMessage();
                }
                throw new ProdOperationException("This control does not support GridPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Selects an item in a DataGrid
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectItem(int row, int column)
        {

            try
            {
                if (CheckPatternSupport(SelectionItemPattern.Pattern, UIAElement))
                {
                    AutomationElement dataItem = GetItem(row, column);

                    Logmessage = "Item: " + dataItem.Current.AutomationId;
                    SubscribeToEvent(SelectionItemPattern.ElementAddedToSelectionEvent);

                    SelectionPatternHelper.Select(dataItem);          
                }
                throw new ProdOperationException("This control does not support GridPattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Gets Whether the control supports multiple selection of items
        /// </summary>
        /// <returns>True if it supports multiple selection, false otherwise</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool CanSelectMultiple()
        {
            try
            {
                bool retVal = SelectionPatternHelper.CanSelectMultiple(UIAElement);

                Logmessage = retVal.ToString(CultureInfo.CurrentCulture);
                CreateMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   DeSelect an item in the DataGrid control
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///   Only valid for multiple selection list controls
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

                Logmessage = "Item: " + dataItem.Current.AutomationId;
                SubscribeToEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);

                SelectionPatternHelper.RemoveFromSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   DeSelect an item in the DataGrid control
        /// </summary>
        /// <param name = "dataItem">The data item to deselect.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///   Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(AutomationElement dataItem)
        {
            Logmessage = "Item: " + dataItem.Current.AutomationId;
            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent);
                SelectionPatternHelper.RemoveFromSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Selects an item in a multi-select DataGrid control without deselecting other items
        /// </summary>
        /// <param name = "row">The zero-based row of the desired item.</param>
        /// <param name = "column">The zero-based column of the desired item.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///   Only valid for multiple selection DataGrid controls
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

                Logmessage = "Item: " + dataItem.Current.AutomationId;
                SubscribeToEvent(SelectionItemPattern.ElementAddedToSelectionEvent);

                //SelectionPatternHelper.AddToSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Selects an item in a multi-select DataGrid control without deselecting other items
        /// </summary>
        /// <param name = "dataItem">The data item to select.</param>
        /// <exception cref = "ProdVerificationException"></exception>
        /// <remarks>
        ///   Only valid for multiple selection controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(AutomationElement dataItem)
        {
            Logmessage = "Item: " + dataItem.Current.AutomationId;
            try
            {
                if (!CanSelectMultiple())
                {
                    return;
                }


                SubscribeToEvent(SelectionItemPattern.ElementAddedToSelectionEvent);
                //SelectionPatternHelper.AddToSelection(dataItem);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        #endregion

        #region TablePattern

        /// <summary>
        ///   Gets a collection of UI Automation providers that represents all the column headers in a DataGrid
        /// </summary>
        /// <returns>An array of header items</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElement[] GetColumnHeaders()
        {
            try
            {
                if (CheckPatternSupport(TablePattern.Pattern, UIAElement))
                {
                    AutomationElement[] retVal = TablePatternHelper.GetColumnHeaders(UIAElement);
                    List<object> retList = new List<object>();
                    foreach (AutomationElement item in retVal)
                    {
                        retList.Add(item);
                    }
                    Logmessage = "Column Headers";
                    VerboseInformation = retList;
                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support TablePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return null;
            }
        }

        /// <summary>
        ///   Gets a collection of UI Automation providers that represents all the row headers in a DataGrid
        /// </summary>
        /// <returns>An array of header items</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElement[] GetRowHeaders()
        {
            try
            {
                if (CheckPatternSupport(TablePattern.Pattern, UIAElement))
                {
                    AutomationElement[] retVal = TablePatternHelper.GetRowHeaders(UIAElement);
                    List<object> retList = new List<object>(retVal);

                    Logmessage = "Row Headers";
                    VerboseInformation = retList;
                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support TablePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return null;
            }
        }

        /// <summary>
        ///   Retrieves the primary direction of traversal for the table
        /// </summary>
        /// <returns>The primary direction of traversal. </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public RowOrColumnMajor GetRowOrColumnMajor()
        {
            try
            {
                if (CheckPatternSupport(TablePattern.Pattern, UIAElement))
                {
                    RowOrColumnMajor retVal = TablePatternHelper.GetRowOrColumnMajor(UIAElement);

                    Logmessage = "Row Or Column Major: " + retVal;
                    CreateMessage();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support TablePattern");
            }
            catch (InvalidOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

    }
}