using System.Windows.Automation;

namespace ProdUI.Bridge.UIAPatterns
{
    internal class TableItemPatternHelper
    {

        /// <summary>
        /// Retrieves all the column headers associated with a table item or cell.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// A collection of column header elements
        /// </returns>
        internal static AutomationElement[] GetColumnHeaderItems(AutomationElement control)
        {
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
        internal static AutomationElement[] GetRowHeaderItems(AutomationElement control)
        {
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, control);
            return pat.Current.GetRowHeaderItems();
        }

        /// <summary>
        /// Gets a UI Automation provider that implements IGridProvider and represents the container of the cell or item
        /// </summary>
        /// <param name="item">The UI Automation element</param>
        /// <returns>
        /// A UI Automation provider that implements the GridPattern and represents the cell or item container
        /// </returns>
        internal static AutomationElement GetContainingGrid(AutomationElement item)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, item);
            return pat.Current.ContainingGrid;
        }


        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item
        /// </summary>
        /// <param name="item">The UI Automation element</param>
        /// <returns>
        /// A zero-based ordinal number that identifies the column containing the cell or item
        /// </returns>
        internal static int GetColumnIndex(AutomationElement item)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, item);
            return pat.Current.Column;
        }

        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="item">The UI Automation element</param>
        /// <returns>
        /// The number of columns spanned
        /// </returns>
        internal static int GetColumnSpan(AutomationElement item)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, item);
            return pat.Current.ColumnSpan;
        }


        /// <summary>
        /// Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name="item">The UI Automation element.</param>
        /// <returns>
        /// A zero-based ordinal number that identifies the row containing the cell or item
        /// </returns>
        internal static int GetRowIndex(AutomationElement item)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, item);
            return pat.Current.Row;
        }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="item">The UI Automation element.</param>
        /// <returns>
        /// The number of rows spanned
        /// </returns>
        internal static int GetRowSpan(AutomationElement item)
        {
            /* move to next state */
            TableItemPattern pat = (TableItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(TableItemPattern.Pattern, item);
            return pat.Current.RowSpan;
        }

    }
}
