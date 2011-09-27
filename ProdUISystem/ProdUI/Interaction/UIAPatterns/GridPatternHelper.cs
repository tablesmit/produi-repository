// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the GridPattern and/or GridItemcontrol patterns. implements IGridProvider,IGridItemProvider
    /// </summary>
    internal static class GridPatternHelper
    {
        /// <summary>
        ///     Determines if the control supports the GridItemPattern
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///     The pattern, if valid
        /// </returns>
        private static GridItemPattern GetGridItemPattern(AutomationElement control)
        {
            object pat;
            control.TryGetCurrentPattern(GridItemPattern.Pattern, out pat);
            return (GridItemPattern)pat;
        }

        #region IGridProvider Implementation

        /// <summary>
        ///     Gets the total number of columns in a grid.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///     Total number of columns in a grid
        /// </returns>
        internal static int GetColumnCount(AutomationElement control)
        {
            GridPattern pat = (GridPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
            return pat.Current.ColumnCount;
        }

        /// <summary>
        ///     Retrieves the UI Automation provider for the specified cell
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <param name = "row">The ordinal number of the row of interest</param>
        /// <param name = "column">The ordinal number of the column of interest.</param>
        /// <returns>
        ///     An object representing the item at the specified location
        /// </returns>
        internal static AutomationElement GetItem(AutomationElement control, int row, int column)
        {
            GridPattern pat = (GridPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
            return pat.GetItem(row, column);
        }

        /// <summary>
        ///     Gets the total number of rows in a grid.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     Total number of rows in a grid
        /// </returns>
        internal static int GetRowCount(AutomationElement control)
        {
            GridPattern pat = (GridPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
            return pat.Current.RowCount;
        }

        #endregion IGridProvider Implementation

        #region IGridItemProvider Implementation

        /// <summary>
        ///     Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///     The ordinal number of the column that contains the cell or item
        /// </returns>
        internal static int GetColumn(AutomationElement control)
        {
            GridItemPattern pat = GetGridItemPattern(control);
            return pat.Current.Column;
        }

        /// <summary>
        ///     Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///     The number of columns spanned by a cell or item
        /// </returns>
        internal static int GetColumnSpan(AutomationElement control)
        {
            GridItemPattern pat = GetGridItemPattern(control);
            return pat.Current.ColumnSpan;
        }

        /// <summary>
        ///     Gets a UI Automation provider that implements IGridProvider and represents the container of the cell or item
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     returns an object, stored as an internal variable that represents the grid container
        /// </returns>
        internal static object GetContainingGrid(AutomationElement control)
        {
            GridItemPattern pat = GetGridItemPattern(control);
            return pat.Current.ContainingGrid;
        }

        /// <summary>
        ///     Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     The row that contains the cell or item.
        /// </returns>
        internal static int Row(AutomationElement control)
        {
            GridItemPattern pat = GetGridItemPattern(control);
            return pat.Current.Row;
        }

        /// <summary>
        ///     Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     The number of rows spanned by a cell or item
        /// </returns>
        internal static int GetRowSpan(AutomationElement control)
        {
            GridItemPattern pat = GetGridItemPattern(control);
            return pat.Current.RowSpan;
        }

        #endregion IGridItemProvider Implementation
    }
}