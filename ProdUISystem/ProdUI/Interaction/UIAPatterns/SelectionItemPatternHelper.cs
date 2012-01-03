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

        /* Extended methods */

        /// <summary>
        /// Finds the index by item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="matchString">The match string.</param>
        /// <returns>
        /// The zero-based index of the supplied item, or -1 if item is not found
        /// </returns>
        internal static int FindIndexByItem(AutomationElement control, string matchString)
        {
            AutomationElementCollection elementCollection = GetListItems(control);

            for (int i = 0; i < elementCollection.Count; i++)
            {
                if (matchString == elementCollection[i].Current.Name)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Finds the item by zero-based index.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        /// <returns>
        /// The item at the specified index
        /// </returns>
        internal static AutomationElement FindItemByIndex(AutomationElement control, int index)
        {
            AutomationElementCollection elementCollection = GetListItems(control);
            return elementCollection[index];
        }

        /// <summary>
        /// Finds the item by its text.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="itemText">The item text.</param>
        /// <returns>
        /// The element that matches the supplied text or null if item not found
        /// </returns>
        internal static AutomationElement FindItemByText(AutomationElement control, string itemText)
        {
            Condition propertyCondition = new PropertyCondition(AutomationElement.NameProperty, itemText, PropertyConditionFlags.IgnoreCase);

            AutomationElement firstMatch = control.FindFirst(TreeScope.Descendants, propertyCondition);

            return firstMatch;
        }

    }
}