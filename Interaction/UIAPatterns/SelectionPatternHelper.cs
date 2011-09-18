// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using ProdUI.Exceptions;

[assembly: InternalsVisibleTo("ProdUITests")]

namespace ProdUI.Interaction.UIAPatterns
{
    internal static class SelectionPatternHelper
    {
        #region Search Conditions

        /// <summary>
        ///     Determines if element is a content element
        /// </summary>
        private static readonly PropertyCondition ConditionContent = new PropertyCondition(AutomationElement.IsContentElementProperty, true);

        /// <summary>
        ///     Used to determine items that are NOT selected
        /// </summary>
        private static readonly PropertyCondition ConditionNotSelected = new PropertyCondition(SelectionItemPattern.IsSelectedProperty, false);

        /// <summary>
        ///     Used to determine selected items
        /// </summary>
        private static readonly PropertyCondition ConditionIsSelected = new PropertyCondition(SelectionItemPattern.IsSelectedProperty, true);

        #endregion

        #region ISelectionProvider implementation

        /// <summary>
        ///     Determines whether this instance can select multiple items
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     <c>true</c> if this instance can select multiple items; otherwise, <c>false</c>.
        /// </returns>
        internal static bool CanSelectMultiple(AutomationElement control)
        {
            SelectionPattern pat = (SelectionPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pat.Current.CanSelectMultiple;
        }

        /// <summary>
        ///     Gets the selected items.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns></returns>
        internal static AutomationElement[] GetSelection(AutomationElement control)
        {
            SelectionPattern pat = (SelectionPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pat.Current.GetSelection();
        }

        /// <summary>
        ///     Determines whether a selection is required for the specified control.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     <c>true</c> if selection is required; otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsSelectionRequired(AutomationElement control)
        {
            SelectionPattern pat = (SelectionPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pat.Current.IsSelectionRequired;
        }

        #endregion

        #region ISelectionItemProvider

        /// <summary>
        ///     Adds to selection in a multi-select list.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <param name = "index">The index.</param>
        internal static void AddToSelection(AutomationElement control, int index)
        {
            SelectionItemPattern sip = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            sip.AddToSelection();
        }

        internal static void AddToSelection(AutomationElement control, string itemText)
        {
            SelectionItemPattern pat = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);

            AutomationElement container = pat.Current.SelectionContainer;
            if (container == null)
            {
                throw new ProdOperationException(new ElementNotAvailableException());
            }
            pat.AddToSelection();
        }

        /// <summary>
        ///     Determines whether the specified item is selected.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///     <c>true</c> if the specified control is selected; otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsSelected(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            return pat.Current.IsSelected;
        }

        /// <summary>
        ///     Removes from item from selection in a multi-select list.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        internal static void RemoveFromSelection(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            pat.RemoveFromSelection();
        }

        /// <summary>
        ///     Selects the specified Item.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        internal static void Select(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            pat.Select();
        }

        internal static AutomationElement SelectionContainer(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            return pat.Current.SelectionContainer;
        }

        #endregion

        /// <summary>
        ///     Gets the selection items.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns></returns>
        internal static AutomationElementCollection GetSelectionItems(AutomationElement control)
        {
            AutomationElementCollection aec = GetListCollectionUtility(control);
            return aec;
        }

        /// <summary>
        ///     Gets the number of items in a list.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     The item count
        /// </returns>
        internal static int GetItemCount(AutomationElement control)
        {
            AutomationElementCollection aec = GetListCollectionUtility(control);
            return aec.Count;
        }

        /// <summary>
        ///     Utility to get all of the items in a List control
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     An AutomationElementCollection containing all list items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElementCollection GetListCollectionUtility(AutomationElement control)
        {
            /* Everything, selector or not */
            OrCondition orCon = new OrCondition(ConditionIsSelected, ConditionNotSelected);

            /* If we don't filter that with a IsContent condition, we get some weird stuff back */
            AndCondition con = new AndCondition(ConditionContent, orCon);

            return control.FindAll(TreeScope.Children, con);
        }

        /// <summary>
        ///     Finds the index by item.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "matchString">The match string.</param>
        /// <returns>
        ///     The zero-based index of the supplied item
        /// </returns>
        internal static int FindIndexByItem(AutomationElement control, string matchString)
        {
            AutomationElementCollection aec = GetListCollectionUtility(control);

            for (int i = 0; i < aec.Count; i++)
            {
                if (matchString == aec[i].Current.Name)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Finds the item by zero-based index.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "index">The zero-based index of the item to select.</param>
        /// <returns>
        ///     The item at the specified index
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElement FindItemByIndex(AutomationElement control, int index)
        {
            AutomationElementCollection aec = GetListCollectionUtility(control);
            return aec[index];
        }

        /// <summary>
        ///     Finds the item by its text.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <param name = "itemText">The item text.</param>
        /// <returns>
        ///     The element that matches the supplied text
        /// </returns>
        internal static AutomationElement FindItemByText(AutomationElement control, string itemText)
        {
            Condition propertyCondition = new PropertyCondition(AutomationElement.NameProperty, itemText, PropertyConditionFlags.IgnoreCase);

            AutomationElement firstMatch = control.FindFirst(TreeScope.Descendants, propertyCondition);
            if (firstMatch == null)
            {
                throw new ProdOperationException("Item: " + itemText + " could not be found");
            }
            return firstMatch;
        }

        /// <summary>
        ///     Gets the list items.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     An <see cref = "AutomationElementCollection" /> of list items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElementCollection GetListItems(AutomationElement control)
        {
            AutomationElementCollection aec = GetListCollectionUtility(control);
            return aec;
        }
    }
}