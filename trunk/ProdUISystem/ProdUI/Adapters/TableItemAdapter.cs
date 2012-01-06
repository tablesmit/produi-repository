// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;
namespace ProdUI.Adapters
{
    internal interface TableItemAdapter
    {
        /// <summary>
        /// Retrieves all the column headers associated with a table item or cell.
        /// </summary>
        AutomationElement[] ColumnHeaderItems { get; }

        /// <summary>
        /// Retrieves all the row headers associated with a table item or cell.
        /// </summary>
        AutomationElement[] RowHeaderItems { get; }

        /// <summary>
        /// Gets a UI Automation element that supports the GridPattern control pattern and represents the table cell or item container
        /// </summary>
        AutomationElement ContainingGrid { get; }

    }
}