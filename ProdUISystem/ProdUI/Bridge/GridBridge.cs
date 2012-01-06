// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Bridge
{
    public static class GridBridge
    {
        /// <summary>
        /// Gets the total number of columns in a grid.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The total number of columns.
        /// </returns>
        public static int GetColumnCountHook(this GridAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetColumnCount(control);
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

        private static int UiaGetColumnCount(BaseProdControl control)
        {
            int retVal = GridPatternHelper.GetColumnCount(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Gets the total number of rows in a grid.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The total number of rows.
        /// </returns>
        public static int GetRowCountHook(this GridAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetRowCount(control);
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

        private static int UiaGetRowCount(BaseProdControl control)
        {
            int retVal = GridPatternHelper.GetRowCount(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Retrieves an AutomationElement that represents the specified cell.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="row">The ordinal number of the row of interest.</param>
        /// <param name="column">The ordinal number of the column of interest.</param>
        /// <returns>
        /// An AutomationElement that represents the retrieved cell
        /// </returns>
        public static AutomationElement GetItemHook(this GridAdapter extension, BaseProdControl control, int row, int column)
        {
            try
            {
                return UiaGetItem(control, row, column);
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

        private static AutomationElement UiaGetItem(BaseProdControl control, int row, int column)
        {
            AutomationElement retVal = GridPatternHelper.GetItem(control.UIAElement, row, column);
            LogController.ReceiveLogMessage(new LogMessage(retVal.Current.Name));
            return retVal;
        }
    }
}