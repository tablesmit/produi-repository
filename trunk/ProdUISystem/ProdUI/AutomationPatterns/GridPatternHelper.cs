/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Used for controls that support the GridPattern and/or GridItemcontrol patterns. implements IGridProvider,IGridItemProvider
    /// </summary>
    internal static class GridPatternHelper
    {
        /// <summary>
        ///   Determines if the control support the GridItemPattern
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>The pattern if valid</returns>
        private static GridItemPattern GetGridItemPattern(AutomationElement control)
        {
            object pat;
            try
            {
                control.TryGetCurrentPattern(GridItemPattern.Pattern, out pat);
                return (GridItemPattern)pat;
            }
            catch (Exception)
            {
                throw new ProdOperationException("Does not support GridItemPattern");
            }
        }

        #region IGridProvider Implementation

        /// <summary>
        ///   Gets the total number of columns in a grid.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>Total number of columns in a grid</returns>
        internal static int GetColumnCount(AutomationElement control)
        {
            try
            {
                GridPattern pat = (GridPattern)CommonPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
                return pat.Current.ColumnCount;
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
        ///   Retrieves the UI Automation provider for the specified cell
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "row">The ordinal number of the row of interest</param>
        /// <param name = "column">The ordinal number of the column of interest.</param>
        /// <returns>An object representing the item at the specified location</returns>
        internal static AutomationElement GetItem(AutomationElement control, int row, int column)
        {
            try
            {
                GridPattern pat = (GridPattern)CommonPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
                return pat.GetItem(row, column);
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
        ///   Gets the total number of rows in a grid.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>Total number of rows in a grid</returns>
        internal static int GetRowCount(AutomationElement control)
        {
            try
            {
                GridPattern pat = (GridPattern)CommonPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
                return pat.Current.RowCount;
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

        #region IGridItemProvider Implementation

        /// <summary>
        ///   Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>The ordinal number of the column that contains the cell or item</returns>
        internal static int GetColumn(AutomationElement control)
        {
            try
            {
                GridItemPattern pat = GetGridItemPattern(control);
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
        /// <returns>The number of columns spanned by a cell or item</returns>
        internal static int GetColumnSpan(AutomationElement control)
        {
            try
            {
                GridItemPattern pat = GetGridItemPattern(control);
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
        /// <returns>returns an object, stored as an internal variable that represents the grid container</returns>
        internal static object GetContainingGrid(AutomationElement control)
        {
            try
            {
                GridItemPattern pat = GetGridItemPattern(control);
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
        /// <returns>The row that contains the cell or item.</returns>
        internal static int Row(AutomationElement control)
        {
            try
            {
                GridItemPattern pat = GetGridItemPattern(control);
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

        /// <summary>
        ///   Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>The number of rows spanned by a cell or item</returns>
        internal static int GetRowSpan(AutomationElement control)
        {
            try
            {
                GridItemPattern pat = GetGridItemPattern(control);
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