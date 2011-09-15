/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Used for controls that support the Table and TableItem control patterns. implements ITableProvider, ITableItemProvider
    /// </summary>
    internal static class TablePatternHelper
    {
        #region ITableProvider Implentation

        /// <summary>
        ///   Gets the column headers.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>An array of Column Header elements</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElement[] GetColumnHeaders(AutomationElement control)
        {
            try
            {
                TablePattern pat = (TablePattern)CommonPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
                return pat.Current.GetColumnHeaders();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Gets the row headers.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>An array of Row Header elements</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElement[] GetRowHeaders(AutomationElement control)
        {
            try
            {
                TablePattern pat = (TablePattern)CommonPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
                return pat.Current.GetRowHeaders();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Gets the number of columns
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>The number of columns</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int GetColumnCount(AutomationElement control)
        {
            try
            {
                TablePattern pat = (TablePattern)CommonPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
                return pat.Current.ColumnCount;
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

        /// <summary>
        ///   Gets the item at the specified cell.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "row">The row of the item to retrieve.</param>
        /// <param name = "column">The column of the item to retrieve.</param>
        /// <returns>
        ///   The Automation Element at the supplied row/column intersection
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElement GetItem(AutomationElement control, int row, int column)
        {
            try
            {
                TablePattern pat = (TablePattern)CommonPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
                return pat.GetItem(row, column);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Gets the number of rows
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>The number of rows</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int GetRowCount(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TablePattern pat = (TablePattern)CommonPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
                return pat.Current.RowCount;
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

        internal static RowOrColumnMajor GetRowOrColumnMajor(AutomationElement control)
        {
            try
            {
                TablePattern pat = (TablePattern)CommonPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
                return pat.Current.RowOrColumnMajor;
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

        #endregion

        #region ITableItemProvider Implementation

        /// <summary>
        ///   Retrieves a collection of UI Automation providers representing all the column headers associated with a table item or cell.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>A collection of UI Automation providers</returns>
        public static object[] GetColumnHeaderItems(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.GetColumnHeaderItems();
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

        /// <summary>
        ///   Retrieves a collection of UI Automation providers representing all the row headers associated with a table item or cell
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>A collection of UI Automation providers</returns>
        public static object[] GetRowHeaderItems(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.GetRowHeaderItems();
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

        /// <summary>
        ///   Gets the ordinal number of the column that contains the cell or item
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>A zero-based ordinal number that identifies the column containing the cell or item</returns>
        public static int  GetColumn(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.Column;
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

        /// <summary>
        ///   Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>The number of columns spanned</returns>
        public static int GetColumnSpan(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.ColumnSpan;
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

        /// <summary>
        ///   Gets a UI Automation provider that implements IGridProvider and represents the container of the cell or item
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>A UI Automation provider that implements the GridPattern and represents the cell or item container</returns>
        public static AutomationElement GetContainingGrid(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.ContainingGrid;
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

        /// <summary>
        ///   Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>A zero-based ordinal number that identifies the row containing the cell or item</returns>
        public static int GetRow(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.Row;
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

        /// <summary>Gets the number of rows spanned by a cell or item.</summary>
        /// <param name="control">The control.</param>
        /// <returns>The number of rows spanned</returns>
        public static int GetRowSpan(AutomationElement control)
        {
            try
            {
                /* move to next state */
                TableItemPattern pat = (TableItemPattern)CommonPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
                return pat.Current.RowSpan;
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

        #endregion
    }
}