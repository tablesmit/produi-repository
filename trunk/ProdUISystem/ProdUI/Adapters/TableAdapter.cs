// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do

using System.Windows.Automation;


namespace ProdUI.Adapters
{
    public interface TableAdapter
    {
        /// <summary>
        /// Retrieves a collection of AutomationElements representing all the column headers in a table.
        /// </summary>
        AutomationElement[] ColumnHeaders { get; }

        /// <summary>
        /// Retrieves a collection of AutomationElements representing all the row headers in a table.
        /// </summary>
        AutomationElement[] RowHeaders { get; }

        /// <summary>
        /// Retrieves the primary direction of traversal ( ColumnMajor, RowMajor, Indeterminate) for the table
        /// </summary>
        RowOrColumnMajor RowOrColumnMajor { get; }


        /// <summary>
        /// Retrieves an AutomationElement that represents the specified cell
        /// </summary>
        /// <param name="row">The ordinal number of the row of interest.</param>
        /// <param name="column">The ordinal number of the column of interest.</param>
        /// <returns>An AutomationElement that represents the retrieved cell</returns>
        AutomationElement GetItem(int row, int column);

    }
}