using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    class TableItemPatternHelper
    {

        /// <summary>
        /// Retrieves a collection of UI Automation providers representing all the column headers associated with a table item or cell.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// A collection of UI Automation providers
        /// </returns>
        public static AutomationElement[] GetColumnHeaderItems(AutomationElement control)
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
        public static AutomationElement[] GetRowHeaderItems(AutomationElement control)
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

    }
}
