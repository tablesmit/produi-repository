using System.Windows.Automation;

namespace ProdUI.Adapters
{
    public interface DockAdapter
    {
        /// <summary>
        /// Gets or sets the dock position within a docking container.
        /// </summary>
        /// <value>
        /// The dock position.
        /// </value>
        DockPosition DockPosition { get; set; }

    }
}
