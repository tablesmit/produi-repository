// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Logging;

namespace ProdControls
{
    internal sealed class ProdDataGrid : BaseProdControl, IGrid, IGridItem, ISingleSelectList, IMultipleSelectionList, ITable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation element</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdDataGrid(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdDataGrid(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdDataGrid class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdDataGrid(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        #region GridPattern

        /// <summary>
        /// Gets the total number of columns in the ProdDataGrid
        /// </summary>
        /// <returns>
        /// The number of columns
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetColumnCount()
        {
            return this.GetColumnCountBridge(this);
        }

        /// <summary>
        /// Gets the total number of rows in the ProdDataGrid
        /// </summary>
        /// <returns>
        /// The number of rows
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetRowCount()
        {
            return this.GetColumnCountBridge(this);
        }

        /// <summary>
        /// Retrieves the UI Automation provider for the specified cell
        /// </summary>
        /// <param name="row">The zero-based row of the desired item.</param>
        /// <param name="column">The zero-based column of the desired item.</param>
        /// <returns>
        /// The desired ProdDataGrid item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetItem(int row, int column)
        {
            return this.GetItemBridge(this, row, column);
        }

        #endregion GridPattern

        #region Grid Item

        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="dataItem">The data item.</param>
        /// <returns>
        /// Number of columns spanned by a cell or item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemColumnSpan(AutomationElement dataItem)
        {
            return this.GetItemColumnSpanBridge(this, dataItem);
        }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="dataItem">The data item.</param>
        /// <returns>
        /// Number of rows spanned by a cell or item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemRowSpan(AutomationElement dataItem)
        {
            return this.GetItemRowSpanBridge(this, dataItem);
        }

        /// <summary>
        /// Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name="dataItem">The data item.</param>
        /// <returns>
        /// Number of rows spanned by a cell or item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetRowIndex(AutomationElement dataItem)
        {
            return this.GetRowBridge(this, dataItem);
        }

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <param name="dataItem">The data item.</param>
        /// <returns>
        /// Number of column spanned by a cell or item
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetColumnIndex(AutomationElement dataItem)
        {
            return this.GetColumnBridge(this, dataItem);
        }

        #endregion Grid Item

        #region Selection Pattern

        /// <summary>
        /// Selects an item in a DataGrid.
        /// </summary>
        /// <param name="dataItem">The data item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectItem(AutomationElement dataItem)
        {
            this.SetSelectedItemBridge(this, dataItem.Current.Name);
        }

        /// <summary>
        /// Selects an item in a DataGrid
        /// </summary>
        /// <param name="row">The zero-based row of the desired item.</param>
        /// <param name="column">The zero-based column of the desired item.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectItem(int row, int column)
        {
            AutomationElement dataItem = GetItem(row, column);
            this.SetSelectedItemBridge(this, dataItem.Current.Name);
        }

        /// <summary>
        /// Gets Whether the control supports multiple selection of items
        /// </summary>
        /// <returns>
        /// True if it supports multiple selection, false otherwise
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool CanSelectMultiple()
        {
            return this.CanSelectMultipleBridge(this);
        }

        /// <summary>
        /// Deselect an item in the DataGrid control
        /// </summary>
        /// <param name="row">The zero-based row of the desired item.</param>
        /// <param name="column">The zero-based column of the desired item.</param>
        /// <remarks>
        /// Only valid for multiple selection controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(int row, int column)
        {
            AutomationElement dataItem = this.GetItemBridge(this, row, column);
            this.RemoveFromSelectionBridge(this, dataItem.Current.Name);
        }

        /// <summary>
        /// Deselect an item in the DataGrid control
        /// </summary>
        /// <param name="dataItem">The data item to deselect.</param>
        /// <remarks>
        /// Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(AutomationElement dataItem)
        {
            this.RemoveFromSelectionBridge(this, dataItem.Current.Name);
        }

        /// <summary>
        /// Selects an item in a multi-select DataGrid control without deselecting other items
        /// </summary>
        /// <param name="row">The zero-based row of the desired item.</param>
        /// <param name="column">The zero-based column of the desired item.</param>
        /// <remarks>
        /// Only valid for multiple selection DataGrid controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(int row, int column)
        {
            AutomationElement dataItem = this.GetItemBridge(this, row, column);
            this.AddToSelectionBridge(this, dataItem.Current.Name);
        }

        /// <summary>
        /// Selects an item in a multi-select DataGrid control without deselecting other items
        /// </summary>
        /// <param name="dataItem">The data item to select.</param>
        /// <remarks>
        /// Only valid for multiple selection controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(AutomationElement dataItem)
        {
            this.AddToSelectionBridge(this, dataItem.Current.Name);
        }

        #endregion Selection Pattern

        #region Table pattern

        /// <summary>
        /// Gets a collection of UI Automation providers that represents all the column headers in a DataGrid
        /// </summary>
        /// <returns>
        /// An array of header items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElement[] GetColumnHeaders()
        {
            return this.GetColumnHeadersBridge(this);
        }

        /// <summary>
        /// Gets a collection of UI Automation providers that represents all the row headers in a DataGrid
        /// </summary>
        /// <returns>
        /// An array of header items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElement[] GetRowHeaders()
        {
            return this.GetRowHeadersBridge(this);
        }

        /// <summary>
        /// Retrieves the primary direction of traversal for the table
        /// </summary>
        /// <returns>
        /// The primary direction of traversal.
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public RowOrColumnMajor GetRowOrColumnMajor()
        {
            return this.GetRowOrColumnMajorBridge(this);
        }

        #endregion Table pattern
    }
}