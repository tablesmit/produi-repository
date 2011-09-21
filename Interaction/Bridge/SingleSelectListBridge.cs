using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class SingleSelectListBridge
    {
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        internal static List<object> GetItemsBridge(this ISingleSelectList theInterface, BaseProdControl control)
        {
            try
            {
                AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(control.UIAElement);

                List<object> retVal = InternalUtilities.AutomationCollToObjectList(convRet);
                LogController.ReceiveLogMessage(new LogMessage("List Items: ", retVal));
                return retVal;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static int GetItemCountBridge(this ISingleSelectList theInterface, BaseProdControl control)
        {
            try
            {
                AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(control.UIAElement);
                LogController.ReceiveLogMessage(new LogMessage("Items: " + convRet.Count));
                return convRet.Count;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }


        /// <summary>
        ///     Gets the selected index ex.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns></returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static int GetSelectedIndexBridge(this ISingleSelectList theInterface, BaseProdControl control)
        {
            try
            {
                if (!CanSelectMultiple(control)) throw new ProdOperationException("Does not support single selection");

                AutomationElement[] element = SelectionPatternHelper.GetSelection(control.UIAElement);
                int retVal = SelectionPatternHelper.FindIndexByItem(control.UIAElement, element[0].Current.Name);

                LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
                return retVal;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }

        }

        /// <summary>
        ///     Gets the selected list item.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control.</param>
        /// <returns>
        ///     The selected List element
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static AutomationElement GetSelectedItemBridge(this ISingleSelectList theInterface, BaseProdControl control)
        {
            try
            {
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control.UIAElement);
                LogController.ReceiveLogMessage(new LogMessage("Item " + retVal[0]));
                return retVal[0];
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }


        /// <summary>
        /// Sets the selected list item.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SetSelectedIndexBridge(this ISingleSelectList theInterface, BaseProdControl control, int index)
        {
            try
            {
                AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));

                LogController.ReceiveLogMessage(new LogMessage("Selecting " + index));
                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(control.UIAElement, index);
                SelectionPatternHelper.Select(indexedItem);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }


        /// <summary>
        /// Sets the selected list item.
        /// </summary>
        /// <param name="theInterface">The interface.</param>
        /// <param name="control">The control.</param>
        /// <param name="itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SetSelectedItemBridge(this ISingleSelectList theInterface, BaseProdControl control, string itemText)
        {
            try
            {
                AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));

                LogController.ReceiveLogMessage(new LogMessage("Selecting " + itemText));
                AutomationElement ae = SelectionPatternHelper.FindItemByText(control.UIAElement, itemText);
                SelectionPatternHelper.Select(ae);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }


        private static bool CanSelectMultiple(BaseProdControl control)
        {
            return SelectionPatternHelper.CanSelectMultiple(control.UIAElement);
        }
    }
}