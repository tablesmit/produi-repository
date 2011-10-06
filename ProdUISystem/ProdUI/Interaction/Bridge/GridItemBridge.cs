using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;



namespace ProdUI.Interaction.Bridge
{
    internal static class GridItemBridge
    {
        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="dataItem">The data item.</param>
        /// <returns></returns>
        internal static int GetItemColumnSpanBridge(this IGrid extension, BaseProdControl control, AutomationElement dataItem)
        {
            try
            {
                return UiaGetItemColumnSpan(dataItem);
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

        private static int UiaGetItemColumnSpan(AutomationElement dataItem)
        {
            int retVal = GridPatternHelper.GetColumnSpan(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }


        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="dataItem">The data item.</param>
        /// <returns></returns>
        internal static int GetItemRowSpanBridge(this IGrid extension, BaseProdControl control, AutomationElement dataItem)
        {
            try
            {
                return UiaGetItemRowSpan(dataItem);
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

        private static int UiaGetItemRowSpan(AutomationElement dataItem)
        {
            int retVal = GridPatternHelper.GetRowSpan(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <returns></returns>
        internal static int GetColumnBridge(this IGrid extension, BaseProdControl control, AutomationElement dataItem)
        {
            try
            {
                return UiaGetColumn(dataItem);
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

        private static int UiaGetColumn(AutomationElement dataItem)
        {
            int retVal = GridPatternHelper.GetColumn(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }


        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="dataItem">The data item.</param>
        /// <returns></returns>
        internal static int GetRowBridge(this IGrid extension, BaseProdControl control, AutomationElement dataItem)
        {
            try
            {
                return UiaGetRow(dataItem);
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

        private static int UiaGetRow(AutomationElement dataItem)
        {
            int retVal = GridPatternHelper.GetRow(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }
    }
}
