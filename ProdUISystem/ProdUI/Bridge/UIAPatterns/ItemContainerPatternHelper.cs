using System;
using System.Windows.Automation;

namespace ProdUI.Bridge.UIAPatterns
{
    internal static class ItemContainerPatternHelper
    {
        /// <summary>
        /// Retrieves an element by the specified property value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="startAfter">The item in the container after which to begin the search.</param>
        /// <param name="property">The property that contains the value to retrieve.</param>
        /// <param name="value">The value to retrieve.</param>
        /// <returns>
        /// The first item that matches the search criterion; otherwise, null if no items match
        /// </returns>
        internal static AutomationElement FindItemByProperty(AutomationElement control, AutomationElement startAfter, AutomationProperty property, Object value)
        {
            ItemContainerPattern pattern = (ItemContainerPattern)CommonUIAPatternHelpers.CheckPatternSupport(ItemContainerPattern.Pattern, control);
            return pattern.FindItemByProperty(startAfter, property, value);
        }

    }
}
