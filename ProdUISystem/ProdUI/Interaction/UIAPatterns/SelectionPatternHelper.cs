// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    internal static class SelectionPatternHelper
    {

        #region Search Conditions

        /// <summary>
        /// Determines if element is a content element
        /// </summary>
        private static readonly PropertyCondition ConditionContent = new PropertyCondition(AutomationElement.IsContentElementProperty, true);

        /// <summary>
        /// Used to determine items that are NOT selected
        /// </summary>
        private static readonly PropertyCondition ConditionNotSelected = new PropertyCondition(SelectionItemPattern.IsSelectedProperty, false);

        /// <summary>
        /// Used to determine selected items
        /// </summary>
        private static readonly PropertyCondition ConditionIsSelected = new PropertyCondition(SelectionItemPattern.IsSelectedProperty, true);

        #endregion Search Conditions


        /// <summary>
        /// Determines whether this instance can select multiple items
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        ///   <c>true</c> if this instance can select multiple items; otherwise, <c>false</c>.
        /// </returns>
        internal static bool CanSelectMultiple(AutomationElement control)
        {
            SelectionPattern pattern = (SelectionPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pattern.Current.CanSelectMultiple;
        }

        /// <summary>
        /// Determines whether a selection is required for the specified control.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        ///   <c>true</c> if selection is required; otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsSelectionRequired(AutomationElement control)
        {
            SelectionPattern pattern = (SelectionPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pattern.Current.IsSelectionRequired;
        }

        /// <summary>
        /// Utility to get all of the items in a List control
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An AutomationElementCollection containing all list items
        /// </returns>
        internal static AutomationElementCollection GetListItems(AutomationElement control)
        {
            /* Everything, selector or not */
            OrCondition orCon = new OrCondition(ConditionIsSelected, ConditionNotSelected);

            /* If we don't filter that with a IsContent condition, we get some weird stuff back */
            AndCondition con = new AndCondition(ConditionContent, orCon);

            return control.FindAll(TreeScope.Children, con);
        }

        /// <summary>
        /// Gets the selected items.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An AutomationElement array of all selected items
        /// </returns>
        internal static AutomationElement[] SelectedItems(AutomationElement control)
        {
            SelectionPattern pattern = (SelectionPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pattern.Current.GetSelection();
        }
    }
}