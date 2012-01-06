// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Bridge
{
    public static class GridItemBridge
    {
        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="dataItem">The data item.</param>
        /// <returns></returns>
        public static int GetColumnSpanHook(this GridItemAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
        public static int GetRowSpanHook(this GridItemAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
        public static int GetColumnHook(this GridItemAdapter extension, BaseProdControl control, AutomationElement dataItem)
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
        public static int GetRowHook(this GridItemAdapter extension, BaseProdControl control, AutomationElement dataItem)
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


        public static AutomationElement GetContainingGridHook(this GridItemAdapter extension, BaseProdControl control, AutomationElement dataItem)
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