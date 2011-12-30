// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Interaction.Bridge
{
    internal static class GridBridge
    {
        /// <summary>
        /// Gets the total number of columns in a grid.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>The total number of columns.</returns>
        internal static int GetColumnCountBridge(this IGrid extension, BaseProdControl control)
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
        /// <returns>The total number of rows.</returns>
        internal static int GetRowCountBridge(this IGrid extension, BaseProdControl control)
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
        /// Retrieves the UI Automation provider for the specified cell.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        internal static AutomationElement GetItemBridge(this IGrid extension, BaseProdControl control, int row, int column)
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