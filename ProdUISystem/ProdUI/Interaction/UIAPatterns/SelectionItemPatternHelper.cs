// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    /// Represents selectable child items of container controls that support SelectionPattern
    /// </summary>
    internal static class SelectionItemPatternHelper
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
        /// Adds to selection in a multi-select list.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="index">The index.</param>
        internal static void AddToSelection(AutomationElement control)
        {
            SelectionItemPattern pattern = (SelectionItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            pattern.AddToSelection();
        }

        /// <summary>
        /// Removes from item from selection in a multi-select list.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        internal static void RemoveFromSelection(AutomationElement control)
        {
            SelectionItemPattern pattern = (SelectionItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            pattern.RemoveFromSelection();
        }

        /// <summary>
        /// Selects the specified Item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        internal static void SelectItem(AutomationElement control)
        {
            SelectionItemPattern pattern = (SelectionItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            pattern.Select();
        }

        /// <summary>
        /// Determines whether the specified item is selected.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        /// <returns>
        ///   <c>true</c> if the specified control is selected; otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsItemSelected(AutomationElement control)
        {
            SelectionItemPattern pattern = (SelectionItemPattern)CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            return pattern.Current.IsSelected;
        }

    }
}