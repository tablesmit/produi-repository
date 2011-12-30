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
        /// Gets the number of items in a list.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The item count
        /// </returns>
        internal static int ItemCount(AutomationElement control)
        {
            return Items(control).Count;
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

        /// <summary>
        /// Gets the number of selected items in a list.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The selected item count
        /// </returns>
        internal static int SelectedItemCount(AutomationElement control)
        {
            return SelectedItems(control).Length;
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