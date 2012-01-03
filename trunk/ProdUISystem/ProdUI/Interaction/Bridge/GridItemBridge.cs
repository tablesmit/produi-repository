// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Adapters;
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
        internal static int GetItemColumnSpanBridge(this GridAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
            int retVal = GridItemPatternHelper.GetColumnSpan(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="dataItem">The data item.</param>
        /// <returns></returns>
        internal static int GetItemRowSpanBridge(this GridAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
            int retVal = GridItemPatternHelper.GetRowSpan(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <returns></returns>
        internal static int GetColumnBridge(this GridAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
            int retVal = GridItemPatternHelper.GetColumn(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="dataItem">The data item.</param>
        /// <returns></returns>
        internal static int GetRowBridge(this GridAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
            int retVal = GridItemPatternHelper.GetRow(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }


        internal static AutomationElement GetContainingGrid(this GridAdapter extension, BaseProdControl control, AutomationElement dataItem)
        {
            try
            {
                return UiaGetContainingGrid(dataItem);
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

        private static AutomationElement UiaGetContainingGrid(AutomationElement dataItem)
        {
            AutomationElement retVal = GridItemPatternHelper.GetContainingGrid(dataItem);
            LogController.ReceiveLogMessage(new LogMessage(retVal.Current.AutomationId.ToString(CultureInfo.CurrentCulture)));
            return retVal;
        }
    }
}