// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Bridge
{
    internal static class TableBridge
    {
        #region Required

        /// <summary>
        /// Retrieves the primary direction of traversal ( ColumnMajor, RowMajor, Indeterminate) for the table
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The primary direction of traversal.
        /// </returns>
        public static RowOrColumnMajor RowOrColumnMajorHook(this TableAdapter extension, BaseProdControl control)
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


        /// <summary>
        /// Retrieves a collection of AutomationElements representing all the column headers in a table.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        public static AutomationElement[] ColumnHeadersHook(this TableAdapter extension, BaseProdControl control)
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
        /// Retrieves a collection of AutomationElements representing all the row headers in a table.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        public static AutomationElement[] RowHeadersHook(this TableAdapter extension, BaseProdControl control)
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
            Collection<object> retList = new Collection<object>(retVal);

            LogController.ReceiveLogMessage(new LogMessage("Headers", retList));

            return retVal;
        }

        /// <summary>
        /// Retrieves an AutomationElement that represents the specified cell
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <param name="row">The ordinal number of the row of interest.</param>
        /// <param name="column">The ordinal number of the column of interest.</param>
        /// <returns>
        /// An AutomationElement that represents the retrieved cell
        /// </returns>
        public static AutomationElement GetItemHook(this TableAdapter extension, BaseProdControl control, int row, int column)
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
            AutomationElement retVal = TablePatternHelper.GetItem(control.UIAElement, row, column);

            LogController.ReceiveLogMessage(new LogMessage("Item:" + retVal.Current.Name));
            return retVal;
        }

        #endregion

        /// <summary>
        /// Gets the number of rows in the table.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <returns>
        /// The number of rows in the current table
        /// </returns>
        public static int GetRowCountHook(this TableAdapter extension, BaseProdControl control)
        {
            try
            {
                int retVal = TablePatternHelper.GetRowCount(control.UIAElement);

                LogController.ReceiveLogMessage(new LogMessage("Row Count:" + retVal));

                return retVal;
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

        /// <summary>
        /// Gets the number of columns in the table.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="control">The control.</param>
        /// <returns>
        /// The number of columns in the current table
        /// </returns>
        public static int GetColumnCountHook(this TableAdapter extension, BaseProdControl control)
        {
            try
            {
                int retVal = TablePatternHelper.GetColumnCount(control.UIAElement);

                LogController.ReceiveLogMessage(new LogMessage("Column Count:" + retVal));

                return retVal;
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
    }
}