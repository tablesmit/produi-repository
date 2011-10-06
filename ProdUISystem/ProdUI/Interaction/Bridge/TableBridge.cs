﻿using System;
using System.Collections.Generic;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Interaction.Bridge
{
    internal static class TableBridge
    {

        /// <summary>
        /// Gets a collection of UI Automation providers that represents all the column headers in a DataGrid
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An array of header items
        /// </returns>
        internal static AutomationElement[] GetColumnHeadersBridge(this ITable extension, BaseProdControl control)
        {
            try
            {
                return UiaGetColumnHeaders(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
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

        private static AutomationElement[] UiaGetColumnHeaders(BaseProdControl control)
        {
            AutomationElement[] retVal = TablePatternHelper.GetColumnHeaders(control.UIAElement);
            List<object> retList = new List<object>();
            foreach (AutomationElement item in retVal)
            {
                retList.Add(item);
            }

            LogController.ReceiveLogMessage(new LogMessage("Headers",retList));

            return retVal;
        }


        /// <summary>
        /// Gets a collection of UI Automation providers that represents all the row headers in a DataGrid
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An array of header items
        /// </returns>
        internal static AutomationElement[] GetRowHeadersBridge(this ITable extension, BaseProdControl control)
        {
            try
            {
                return UiaGetRowHeaders(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
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

        private static AutomationElement[] UiaGetRowHeaders(BaseProdControl control)
        {
            AutomationElement[] retVal = TablePatternHelper.GetRowHeaders(control.UIAElement);
            List<object> retList = new List<object>(retVal);

            LogController.ReceiveLogMessage(new LogMessage("Headers", retList));

            return retVal;
        }


        /// <summary>
        /// Retrieves the primary direction of traversal for the table
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The primary direction of traversal.
        /// </returns>
        internal static RowOrColumnMajor GetRowOrColumnMajorBridge(this ITable extension, BaseProdControl control)
        {
            try
            {
                return UiaGetRowOrColumnMajor(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
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

        private static RowOrColumnMajor UiaGetRowOrColumnMajor(BaseProdControl control)
        {
            RowOrColumnMajor retVal = TablePatternHelper.GetRowOrColumnMajor(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }
    }
}
