using System;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Bridge
{
    internal static class TableItemBridge
    {
        #region Required

        /// <summary>
        /// Gets a collection of UI Automation providers that represents all the column headers in a DataGrid
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// An array of header items
        /// </returns>
        public static AutomationElement[] GetColumnHeadersHook(this TableItemAdapter extension, BaseProdControl control)
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
            Collection<object> retList = new Collection<object>();
            foreach (AutomationElement item in retVal)
            {
                retList.Add(item);
            }

            LogController.ReceiveLogMessage(new LogMessage("Headers", retList));

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
        public static AutomationElement[] GetRowHeadersHook(this TableItemAdapter extension, BaseProdControl control)
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
            AutomationElement[] retVal = TableItemPatternHelper.GetRowHeaderItems(control.UIAElement);
            Collection<object> retList = new Collection<object>(retVal);

            LogController.ReceiveLogMessage(new LogMessage("Headers", retList));

            return retVal;
        }

        /// <summary>
        /// Gets a UI Automation element that supports the GridPattern control pattern and represents the table cell or item container.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The TableItem Element.</param>
        /// <returns>A UI Automation element that supports the GridPattern control pattern and represents the table cell or item container</returns>
        public static AutomationElement GetContainingGridHook(this TableItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return TableItemPatternHelper.GetContainingGrid(control.UIAElement);
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

        #endregion Required

        /// <summary>
        /// Gets the ordinal number of the column that contains the cell or item
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <returns>
        /// A zero-based ordinal number that identifies the column containing the cell or item
        /// </returns>
        public static int GetColumnIndexHook(this TableItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetColumnIndex(control);
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

        private static int UiaGetColumnIndex(BaseProdControl control)
        {
            int retVal = TableItemPatternHelper.GetColumnIndex(control.UIAElement);

            LogController.ReceiveLogMessage(new LogMessage("Column Index: " + retVal));

            return retVal;
        }

        /// <summary>
        /// Gets the number of columns spanned by a cell or item.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The TableItem element.</param>
        /// <returns>
        /// The number of columns spanned
        /// </returns>
        public static int GetColumnSpanHook(this TableItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetColumnSpan(control);
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

        private static int UiaGetColumnSpan(BaseProdControl control)
        {
            int retVal = TableItemPatternHelper.GetColumnSpan(control.UIAElement);

            LogController.ReceiveLogMessage(new LogMessage("Column Span: " + retVal));

            return retVal;
        }

        /// <summary>
        /// Gets the ordinal number of the row that contains the cell or item.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The TableItem element.</param>
        /// <returns>
        /// A zero-based ordinal number that identifies the row containing the cell or item
        /// </returns>
        public static int GetRowIndexHook(this TableItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetRowIndex(control);
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

        private static int UiaGetRowIndex(BaseProdControl control)
        {
            int retVal = TableItemPatternHelper.GetRowIndex(control.UIAElement);

            LogController.ReceiveLogMessage(new LogMessage("Row Index: " + retVal));

            return retVal;
        }

        /// <summary>
        /// Gets the number of rows spanned by a cell or item.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The TableItem Element.</param>
        /// <returns>
        /// The number of rows spanned
        /// </returns>
        public static int GetRowSpanHook(this TableItemAdapter extension, BaseProdControl control)
        {
            try
            {
                return UiaGetRowSpan(control);
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

        private static int UiaGetRowSpan(BaseProdControl control)
        {
            int retVal = TableItemPatternHelper.GetRowSpan(control.UIAElement);

            LogController.ReceiveLogMessage(new LogMessage("Row Span: " + retVal));

            return retVal;
        }
    }
}