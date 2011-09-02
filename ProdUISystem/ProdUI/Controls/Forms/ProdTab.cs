/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Controls.Native;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Utility;
using System.Globalization;
using System.Collections.Generic;

/* Notes
 * Supported Patterns: 
 * ISelectionProvider  
 * IScrollProvider 
 * 
 * Proposed functionality:
 * SelectTab by item/index
 * getSelectedTab
 * getnumberoftabs
 * determine if tab is selected (?) This might be useless....
 */

namespace ProdUI.Controls
{
    /// <summary>
    ///   Methods to work with Tab controls using the UI Automation framework
    ///   A tab control is analogous to the dividers in a notebook or the labels in a file cabinet. By using a tab control, an application can define multiple pages for the same area of a window or dialog box
    /// </summary>
    public sealed class ProdTab : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdTab class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then Name
        /// </remarks>
        public ProdTab(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdTab class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdTab(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdTab class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdTab(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>Gets the number of tabs in a TabControl.</summary>
        /// <returns>The number of tabs in a TabControl</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemCount()
        {
            try
            {
                AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(ThisElement);
                int retVal = aec.Count;
                
                Logmessage = "Length: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Gets a collection of all tabs in the TabControl
        /// </summary>
        /// <returns>list containing all items</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetItems()
        {
            try
            {
                AutomationElementCollection aec = SelectionPatternHelper.GetListItems(ThisElement);
                List<object> retList = InternalUtilities.AutomationCollToObjectList(aec);

                Logmessage = "Items: ";
                VerboseInformation = retList;
                LogEntry();

                return InternalUtilities.AutomationCollToObjectList(aec);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Determines whether the Tab with the specified index is selected.
        /// </summary>
        /// <param name = "index">The zero based index of the tab to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
              [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]  
        public bool IsSelected(int index)
        {
            try
            {
                bool ret = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByIndex(ThisElement, index));

                Logmessage = ret.ToString(CultureInfo.CurrentCulture);
                LogEntry();

                return ret;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Determines whether the Tab with the specified title is selected.
        /// </summary>
        /// <param name = "itemText">The item text of the tab to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public bool IsSelected(string itemText)
        {
            try
            {
                bool ret = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByText(ThisElement, itemText));

                Logmessage = ret.ToString(CultureInfo.CurrentCulture);
                LogEntry();

                return ret;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Gets the number of child tabs contained in the tab control
        /// </summary>
        /// <returns>The number of tabs</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int TabCount()
        {
            try
            {
                int retVal = GetItemCount();

                if (retVal == -1)
                {
                    retVal = ProdTabNative.GetTabCount(Handle);
                }

                Logmessage = retVal.ToString(CultureInfo.CurrentCulture);
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Retrieves the selected tab
        /// </summary>
        /// <returns>Selected TabItem</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement SelectedTab()
        {
            try
            {
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(ThisElement);

                Logmessage = "Tab: " + retVal[0].Current.AutomationId;
                LogEntry();

                return retVal[0];
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "index">The zero based index of the TabItem</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectTab(int index)
        {
            Logmessage = "Index: " + index;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElementCollection aec = SelectionPatternHelper.GetListItems(ThisElement);

                /* When using the GetListItems() methods, item index 0 is the tab control itself, so add on to get to correct tabitem */
                int adjustedIndex = index;// +1;

                string itemText = aec[adjustedIndex].Current.Name;
                SelectionPatternHelper.Select(SelectionPatternHelper.FindItemByText(ThisElement, itemText));
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "itemText">The TabItem text</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectTab(string itemText)
        {
            Logmessage = "Item: " + itemText;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                SelectionPatternHelper.Select(SelectionPatternHelper.FindItemByText(ThisElement, itemText));
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }
    }
}