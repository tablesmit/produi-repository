// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the Table and TableItem control patterns.
    /// </summary>
    internal static class TablePatternHelper
    {
        #region ITableProvider Implementation

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

        internal static RowOrColumnMajor GetRowOrColumnMajor(AutomationElement control)
        {
            TablePattern pat = (TablePattern)CommonUIAPatternHelpers.CheckPatternSupport(TablePattern.Pattern, control);
            return pat.Current.RowOrColumnMajor;
        }

        #endregion ITableProvider Implementation

        #region ITableItemProvider Implementation

        /// <summary>
        /// Retrieves a collection of UI Automation providers representing all the column headers associated with a table item or cell.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// A collection of UI Automation providers
        /// </returns>
        public static object[] GetColumnHeaderItems(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.GetColumnHeaderItems();
        }

        /// <summary>
        /// Retrieves a collection of UI Automation providers representing all the row headers associated with a table item or cell
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// A collection of UI Automation providers
        /// </returns>
        public static object[] GetRowHeaderItems(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.GetRowHeaderItems();
        }

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// A zero-based ordinal number that identifies the column containing the cell or item
        /// </returns>
        public static int GetColumn(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.Column;
        }

        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The number of columns spanned
        /// </returns>
        public static int GetColumnSpan(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.ColumnSpan;
        }

        /// <summary>
        /// Gets a UI Automation provider that implements IGridProvider and represents the container of the cell or item
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// A UI Automation provider that implements the GridPattern and represents the cell or item container
        /// </returns>
        public static AutomationElement GetContainingGrid(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.ContainingGrid;
        }

        /// <summary>
        /// Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        /// <returns>
        /// A zero-based ordinal number that identifies the row containing the cell or item
        /// </returns>
        public static int GetRow(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.Row;
        }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        /// <returns>
        /// The number of rows spanned
        /// </returns>
        public static int GetRowSpan(AutomationElement control)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.RowSpan;
        }

        #endregion ITableItemProvider Implementation
    }
}