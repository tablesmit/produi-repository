// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;


namespace ProdUI.Adapters
{
    /// <summary>
    /// Supports controls that act as containers for a collection of child elements. 
    /// The children of this element must implement GridItemAdapter and be organized in a two-dimensional logical coordinate system that can be traversed by row and column
    /// </summary>
    public interface GridAdapter
    {
        /// <summary>
        /// Gets the total number of rows in a grid.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// Gets the total number of columns in a grid.
        /// </summary>
        int ColumnCount { get; }

        /// <summary>
        /// Gets the item for the specified cell.
        /// </summary>
        /// <param name="row">The ordinal number of the row of interest.</param>
        /// <param name="column">The ordinal number of the column of interest.</param>
        /// <returns>The AutomationElement for the specified cell</returns>
        AutomationElement GetItem(int row, int column);

    }
}