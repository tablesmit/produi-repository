using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    class ScrollItemPatternHelper
    {

        /// <summary>
        ///     Scrolls the content area of a container object in order to display the control within the visible region (viewport) of the container.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <remarks>
        ///     This method does not provide the ability to specify the position of the control within the visible region (viewport) of the container
        /// </remarks>
        internal static void ScrollIntoView(AutomationElement control)
        {
            ScrollItemPattern pat = (ScrollItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(ScrollItemPattern.Pattern, control);
            pat.ScrollIntoView();
        }

    }
}
