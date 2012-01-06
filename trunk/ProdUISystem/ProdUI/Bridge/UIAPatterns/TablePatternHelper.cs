// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Bridge.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the Table and TableItem control patterns.
    /// </summary>
    internal static class TablePatternHelper
    {
        /// <summary>
        /// Gets the column headers.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An array of Column Header elements
        /// </returns>
        internal static AutomationElement[] GetColumnHeaders(AutomationElement control)
        {
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.Current.GetColumnHeaders();
        }

        /// <summary>
        /// Gets the row headers.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An array of Row Header elements
        /// </returns>
        internal static AutomationElement[] GetRowHeaders(AutomationElement control)
        {
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.Current.GetRowHeaders();
        }

        /// <summary>
        ///     Gets the number of columns
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>The number of columns</returns>
        internal static int GetColumnCount(AutomationElement control)
        {
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.Current.ColumnCount;
        }

        /// <summary>
        /// Gets the number of rows
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The number of rows
        /// </returns>
        internal static int GetRowCount(AutomationElement control)
        {
            /* move to next state */
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.Current.RowCount;
        }

        /// <summary>
        /// Gets the item at the specified cell.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="row">The row of the item to retrieve.</param>
        /// <param name="column">The column of the item to retrieve.</param>
        /// <returns>
        /// The Automation Element at the supplied row/column intersection
        /// </returns>
        internal static AutomationElement GetItem(AutomationElement control, int row, int column)
        {
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.GetItem(row, column);
        }

        /// <summary>
        /// Gets the primary direction of traversal.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        /// <returns></returns>
        internal static RowOrColumnMajor GetRowOrColumnMajor(AutomationElement control)
        {
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.Current.RowOrColumnMajor;
        }

    }
}