// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the ExpandCollapseHelper control pattern. implements IExpandCollapseProvider
    /// </summary>
    internal static class ExpandCollapseHelper
    {
        /// <summary>
        ///     Collapses the specified control.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        internal static int Collapse(AutomationElement control)
        {
            ExpandCollapsePattern pat = (ExpandCollapsePattern) CommonUIAPatternHelpers.CheckPatternSupport(ExpandCollapsePattern.Pattern, control);
            pat.Collapse();
            return 0;
        }

        /// <summary>
        ///     Expands the specified control.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        internal static int Expand(AutomationElement control)
        {
            ExpandCollapsePattern pat = (ExpandCollapsePattern) CommonUIAPatternHelpers.CheckPatternSupport(ExpandCollapsePattern.Pattern, control);
            pat.Expand();
            return 0;
        }

        /// <summary>
        ///     Gets the current ExpandCollapseState of the supplied element
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     <see cref = "ExpandCollapseState" />
        /// </returns>
        internal static ExpandCollapseState ExpandCollapseState(AutomationElement control)
        {
            return (ExpandCollapseState) control.GetCurrentPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty);
        }
    }
}