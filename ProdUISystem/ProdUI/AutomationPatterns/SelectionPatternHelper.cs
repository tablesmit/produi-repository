/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using ProdUI.Exceptions;

[assembly: InternalsVisibleTo("ProdUITests")] 
namespace ProdUI.AutomationPatterns
{
    internal static class SelectionPatternHelper
    {

        #region Search Conditions

        /// <summary>
        ///   Determines if element is a content element
        /// </summary>
        private static readonly PropertyCondition ConditionContent = new PropertyCondition(AutomationElement.IsContentElementProperty, true);

        /// <summary>
        ///   Used to determine items that are NOT selected
        /// </summary>
        private static readonly PropertyCondition ConditionNotSelected = new PropertyCondition(SelectionItemPattern.IsSelectedProperty, false);

        /// <summary>
        ///   Used to determine selected items
        /// </summary>
        private static readonly PropertyCondition ConditionIsSelected = new PropertyCondition(SelectionItemPattern.IsSelectedProperty, true);

        #endregion

        #region ISelectionProvider implementation

        internal static bool CanSelectMultiple(AutomationElement control)
        {
            try
            {
                SelectionPattern pat = (SelectionPattern)CommonPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
                return pat.Current.CanSelectMultiple;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        internal static AutomationElement[] GetSelection(AutomationElement control)
        {
            try
            {
                SelectionPattern pat = (SelectionPattern)CommonPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
                return pat.Current.GetSelection();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        internal static bool IsSelectionRequired(AutomationElement control)
        {
            try
            {
                SelectionPattern pat = (SelectionPattern)CommonPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
                return pat.Current.IsSelectionRequired;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        #region ISelectionItemProvider

        internal static void AddToSelection(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern)CommonPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            if (!CanSelectMultiple(control))
            {
                return;
            }


            AutomationElement container = pat.Current.SelectionContainer;
            if (container == null)
            {
                throw new ProdOperationException(new ElementNotAvailableException());
            }


            pat.AddToSelection();
        }

        internal static bool IsSelected(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern)CommonPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);

            return pat.Current.IsSelected;
        }

        internal static void RemoveFromSelection(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern)CommonPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);

            if (!CanSelectMultiple(control))
            {
                return;
            }

            pat.RemoveFromSelection();
        }

        internal static void Select(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern)CommonPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            ExpandCollapseHelper.Expand(control);
            pat.Select();
        }

        internal static AutomationElement SelectionContainer(AutomationElement control)
        {
            SelectionItemPattern pat = (SelectionItemPattern)CommonPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);

            return pat.Current.SelectionContainer;
        }

        #endregion

        internal static AutomationElementCollection GetSelectionItems(AutomationElement control)
        {
            try
            {
                AutomationElementCollection aec = GetListCollectionUtility(control);
                return aec;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        internal static int GetItemCount(AutomationElement control)
        {
            try
            {
                AutomationElementCollection aec = GetListCollectionUtility(control);
                return aec.Count;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Utility to get all of the items in a List control
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        /// An AutomationElementCollection containing all list items
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElementCollection GetListCollectionUtility(AutomationElement control)
        {
            /* Everything, selector or not */
            OrCondition orCon = new OrCondition(ConditionIsSelected, ConditionNotSelected);

            /* If we don't filter that with a IsContent condition, we get some weird stuff back */
            AndCondition con = new AndCondition(ConditionContent, orCon);

            try
            {
                return control.FindAll(TreeScope.Children, con);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Finds the index by item.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The zero-based index of the supplied item
        /// </returns>
        internal static int FindIndexByItem(AutomationElement control)
        {
            try
            {
                AutomationElementCollection aec = GetListCollectionUtility(control);

                for (int i = 0; i < aec.Count - 1; i++)
                {
                    if (control.Current.Name == aec[i].Current.Name)
                    {
                        return i;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                return -1;
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
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElement FindItemByIndex(AutomationElement control, int index)
        {
            try
            {
                AutomationElementCollection aec = GetListCollectionUtility(control);
                return aec[index];
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

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
        /// Gets the list items.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An <see cref="AutomationElementCollection"/> of list items
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static AutomationElementCollection GetListItems(AutomationElement control)
        {
            try
            {
                AutomationElementCollection aec = GetListCollectionUtility(control);
                return aec;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}
