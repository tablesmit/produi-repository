// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Runtime.CompilerServices;
using System.Windows.Automation;

[assembly: InternalsVisibleTo("ProdUITests")]

namespace ProdUI.Interaction.UIAPatterns
{
    internal static class SelectionPatternHelper
    {
        /// <summary>
        ///     Determines whether this instance can select multiple items
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        ///     <c>true</c> if this instance can select multiple items; otherwise, <c>false</c>.
        /// </returns>
        internal static bool CanSelectMultiple(AutomationElement control)
        {
            SelectionPattern pattern = (SelectionPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pattern.Current.CanSelectMultiple;
        }

        /// <summary>
        ///     Gets the selected items.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        /// <returns>An AutomationElement array of all selected items</returns>
        internal static AutomationElement[] GetSelection(AutomationElement control)
        {
            SelectionPattern pattern = (SelectionPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pattern.Current.GetSelection();
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
            SelectionPattern pattern = (SelectionPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionPattern.Pattern, control);
            return pattern.Current.IsSelectionRequired;
        }

        /// <summary>
        ///     Selects the specified Item.
        /// </summary>
        /// <param name = "control">The UI Automation identifier (ID) for the element</param>
        internal static void SelectItem(AutomationElement control)
        {
            SelectionItemPattern pattern = (SelectionItemPattern) CommonUIAPatternHelpers.CheckPatternSupport(SelectionItemPattern.Pattern, control);
            pattern.Select();
        }
    }
}