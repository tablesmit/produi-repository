using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    class MultipleViewPatternHelper
    {
        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        /// <param name="viewId">The control-specific view identifier.</param>
        /// <returns>The control-specific view name</returns>
        internal static string GetViewName(AutomationElement control, int viewId)
        {
            MultipleViewPattern pattern = (MultipleViewPattern)CommonUIAPatternHelpers.CheckPatternSupport(MultipleViewPattern.Pattern, control);
            return pattern.GetViewName(viewId);
        }

        /// <summary>
        /// Gets the current view ID.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>The current view identifier</returns>
        internal int GetCurrentViewID(AutomationElement control)
        {
            MultipleViewPattern pattern = (MultipleViewPattern)CommonUIAPatternHelpers.CheckPatternSupport(MultipleViewPattern.Pattern, control);
            return (int)control.GetCurrentPropertyValue(MultipleViewPattern.CurrentViewProperty);
        }

        /// <summary>
        /// Gets the supported view ids.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>The current views available</returns>
        internal int[] GetSupportedViewIds(AutomationElement control)
        {
            MultipleViewPattern pattern = (MultipleViewPattern)CommonUIAPatternHelpers.CheckPatternSupport(MultipleViewPattern.Pattern, control);
            return (int[])control.GetCurrentPropertyValue(MultipleViewPattern.SupportedViewsProperty);
        }

        /// <summary>
        /// Sets the current view.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="viewId">A control-specific view identifier.</param>
        internal void SetCurrentView(AutomationElement control, int viewId)
        {
            MultipleViewPattern pattern = (MultipleViewPattern)CommonUIAPatternHelpers.CheckPatternSupport(MultipleViewPattern.Pattern, control);
            pattern.SetCurrentView(viewId);
        }

    }
}
