// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Adapters
{
    /// <summary>
    /// Supports individual child controls of containers that implement GridAdapter.
    /// </summary>
    public interface GridItemAdapter
    {
        /// <summary>
        /// Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        int Row { get; }

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        int Column { get; }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        int RowSpan { get; }

        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        int ColumnSpan { get; }

        /// <summary>
        /// Gets the containing grid of the cell or item.
        /// </summary>
        AutomationElement ContainingGrid { get; }

    }
}