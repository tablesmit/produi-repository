﻿// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class SingleSelectListBridge
    {
        /// <summary>
        ///     Gets the selected index ex.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns></returns>
        internal static int GetSelectedIndexBridge(this ISingleSelectList theInterface, BaseProdControl control)
        {
            if (!CanSelectMultiple(control))
            {
                AutomationElement[] element = SelectionPatternHelper.GetSelection(control.UIAElement);
                int retVal = SelectionPatternHelper.FindIndexByItem(control.UIAElement, element[0].Current.Name);
                return retVal;
            }
            throw new ProdOperationException("Does not support single selection");
        }

        /// <summary>
        ///     Gets the selected list item.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     The selected List element
        /// </returns>
        internal static AutomationElement GetSelectedItemBridge(this ISingleSelectList theInterface, BaseProdControl control)
        {
            AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control.UIAElement);
            return retVal[0];
        }


        /// <summary>
        /// Sets the selected list item.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        internal static void SetSelectedIndexBridge(this ISingleSelectList theInterface, BaseProdControl control, int index)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));

            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(control.UIAElement, index);
            SelectionPatternHelper.Select(indexedItem);
        }


        /// <summary>
        /// Sets the selected list item.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        internal static void SetSelectedItemBridge(this ISingleSelectList theInterface, BaseProdControl control, string itemText)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            AutomationElement ae = SelectionPatternHelper.FindItemByText(control.UIAElement, itemText);
            SelectionPatternHelper.Select(ae);
        }


        private static bool CanSelectMultiple(BaseProdControl control)
        {
            return SelectionPatternHelper.CanSelectMultiple(control.UIAElement);
        }
    }
}