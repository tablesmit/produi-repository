// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the DockPattern control pattern. implements IDockProvider
    /// </summary>
    internal static class DockPatternHelper
    {
        /// <summary>
        ///     Gets the current DockPosition of the control within a docking container.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///     <see cref = "DockPosition" />
        /// </returns>
        internal static DockPosition GetDockPosition(AutomationElement control)
        {
            DockPattern pat = (DockPattern)CommonUIAPatternHelpers.CheckPatternSupport(DockPattern.Pattern, control);
            return pat.Current.DockPosition;
        }

        /// <summary>
        ///     Docks the control within a docking container.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <param name = "dockPosition">The <see cref = "DockPosition" />.</param>
        internal static void SetDockPosition(AutomationElement control, DockPosition dockPosition)
        {
            DockPattern pat = (DockPattern)CommonUIAPatternHelpers.CheckPatternSupport(DockPattern.Pattern, control);
            pat.SetDockPosition(dockPosition);
        }
    }
}