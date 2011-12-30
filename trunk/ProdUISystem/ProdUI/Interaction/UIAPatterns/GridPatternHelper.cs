// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the GridPattern and/or GridItemcontrol patterns. implements IGridProvider,IGridItemProvider
    /// </summary>
    internal static class GridPatternHelper
    {

        /// <summary>
        /// Gets the total number of columns in a grid.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// Total number of columns in a grid
        /// </returns>
        internal static int GetColumnCount(AutomationElement control)
        {
            GridPattern pat = (GridPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
            return pat.Current.ColumnCount;
        }

        /// <summary>
        /// Retrieves the UI Automation provider for the specified cell
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="row">The ordinal number of the row of interest</param>
        /// <param name="column">The ordinal number of the column of interest.</param>
        /// <returns>
        /// An object representing the item at the specified location
        /// </returns>
        internal static AutomationElement GetItem(AutomationElement control, int row, int column)
        {
            GridPattern pat = (GridPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
            return pat.GetItem(row, column);
        }

        /// <summary>
        /// Gets the total number of rows in a grid.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// Total number of rows in a grid
        /// </returns>
        internal static int GetRowCount(AutomationElement control)
        {
            GridPattern pat = (GridPattern)CommonUIAPatternHelpers.CheckPatternSupport(GridPattern.Pattern, control);
            return pat.Current.RowCount;
        }

    }
}