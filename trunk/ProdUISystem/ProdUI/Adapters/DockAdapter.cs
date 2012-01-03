using System.Windows.Automation;

namespace ProdUI.Adapters
{
    public interface DockAdapter
    {
        /// <summary>
        /// Gets the dock position.
        /// </summary>
        DockPosition DockPosition { get; }

        /// <summary>
        /// Docks the control within a docking container.
        /// </summary>
        /// <param name="dockPosition">The dock position.</param>
        void SetDockPosition(DockPosition dockPosition);
    }
}
