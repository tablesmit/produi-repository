using System.Windows.Automation;

namespace ProdUI.Bridge.UIAPatterns
{
    internal static class GridItemPatternHelper
    {

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The ordinal number of the column that contains the cell or item
        /// </returns>
        internal static int GetColumn(AutomationElement control)
        {
            GridItemPattern pat = (GridItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridItemPattern.Pattern, control);
            return pat.Current.Column;
        }

        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The number of columns spanned by a cell or item
        /// </returns>
        internal static int GetColumnSpan(AutomationElement control)
        {
            GridItemPattern pat = (GridItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridItemPattern.Pattern, control);
            return pat.Current.ColumnSpan;
        }

        /// <summary>
        /// Gets a UI Automation provider that implements IGridProvider and represents the container of the cell or item
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// returns an object, stored as an internal variable that represents the grid container
        /// </returns>
        internal static AutomationElement GetContainingGrid(AutomationElement control)
        {
            GridItemPattern pat = (GridItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridItemPattern.Pattern, control);
            return pat.Current.ContainingGrid;
        }

        /// <summary>
        /// Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The row that contains the cell or item.
        /// </returns>
        internal static int GetRow(AutomationElement control)
        {
            GridItemPattern pat = (GridItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridItemPattern.Pattern, control);
            return pat.Current.Row;
        }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The number of rows spanned by a cell or item
        /// </returns>
        internal static int GetRowSpan(AutomationElement control)
        {
            GridItemPattern pat = (GridItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridItemPattern.Pattern, control);
            return pat.Current.RowSpan;
        }
    }
}
