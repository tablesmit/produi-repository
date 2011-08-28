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
using ProdUI.Session;

namespace ProdUI.Controls
{
    public static partial class Prod
    {
        /// <summary>Gets a collection of all items in the list control</summary>
        /// <param name="controlHandle">The control handle.</param>
        /// <returns>list containing all items</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static ArrayList TabsGet(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection aec = SelectionPatternHelper.GetListItems(control);
                return InternalUtilities.AutomationCollToArrayList(aec);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Gets a collection of all items in the list control</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>list containing all items</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static ArrayList TabsGet(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                AutomationElementCollection aec = SelectionPatternHelper.GetListItems(control);
                return InternalUtilities.AutomationCollToArrayList(aec);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Determines whether the specified index is selected.</summary>
        /// <param name="controlHandle">The control handle.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                bool ret = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByIndex(control, index));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }

        }

        /// <summary>Determines whether the specified item text is selected.</summary>
        /// <param name="controlHandle">The control handle.</param>
        /// <param name="itemText">The item text.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                bool ret = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByText(control, itemText));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Determines whether the specified index is selected.</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(ProdWindow prodwindow, string automationId, int index)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                bool ret = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByIndex(control, index));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Determines whether the specified item text is selected.</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="itemText">The item text.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static bool TabIsSelected(ProdWindow prodwindow, string automationId, string itemText)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                bool ret = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByText(control, itemText));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Gets the number of child tabs contained in the tab control</summary>
        /// <param name="controlHandle">The control handle.</param>
        /// <returns>The number of tabs</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static int TabGetCount(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(control);
                int retVal = aec.Count;

                if (retVal == -1)
                {
                    ProdTabNative.GetTabCount(controlHandle);
                }
                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Gets the number of child tabs contained in the tab control</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>The number of tabs</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static int TabGetCount(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(control);
                int retVal = aec.Count;

                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Retrieves the selected tab</summary>
        /// <param name="controlHandle">The control handle.</param>
        /// <returns>Selected TabItem</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static AutomationElement TabGetSelected(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control);
                return retVal[0];
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Retrieves the selected tab</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>Selected TabItem</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static object TabGetSelected(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control);
                return retVal[0];
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>
        ///   Select a TabItem within the TabControl
        /// </summary>
        /// <param name = "controlHandle">The control handle.</param>
        /// <param name = "index">The zero based index of the TabItem</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection aec = SelectionPatternHelper.GetListItems(control);

                /* When using the GetListItems() methods, item index 0 is the tab control itself, so add on to get to correct TabItem */
                int adjustedIndex = index + 1;
                string itemText = aec[adjustedIndex].Current.Name;

                StaticEvents.SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent, control);
                SelectionPatternHelper.Select(SelectionPatternHelper.FindItemByText(control, itemText));

                string logmessage = "Control Text: " + control.Current.Name + " Selection verified";
                ProdStaticSession.Log(logmessage);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdTabNative.SetSelectedTab(controlHandle, index);
            }
        }

        /// <summary>Select a TabItem within the TabControl</summary>
        /// <param name="controlHandle">The control handle.</param>
        /// <param name="itemText">The TabItem text</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);

                StaticEvents.SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent, control);
                SelectionPatternHelper.Select(SelectionPatternHelper.FindItemByText(control, itemText));

                string logmessage = "Control Text: " + control.Current.Name + " Selection verified";
                ProdStaticSession.Log(logmessage);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Select a TabItem within the TabControl</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="index">The zero based index of the TabItem</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(ProdWindow prodwindow, string automationId, int index)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                AutomationElementCollection aec = SelectionPatternHelper.GetListItems(control);

                /* When using the GetListItems() methods, item index 0 is the tab control itself, so add on to get to correct TabItem */
                int adjustedIndex = index + 1;
                string itemText = aec[adjustedIndex].Current.Name;

                StaticEvents.SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent, control);
                SelectionPatternHelper.Select(SelectionPatternHelper.FindItemByText(control, itemText));

                string logmessage = "Control Text: " + control.Current.Name + " Selection verified";
                ProdStaticSession.Log(logmessage);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }

        /// <summary>Select a TabItem within the TabControl</summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="itemText">The TabItem text</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void TabSelect(ProdWindow prodwindow, string automationId, string itemText)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);

                StaticEvents.SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent, control);
                SelectionPatternHelper.Select(SelectionPatternHelper.FindItemByText(control, itemText));

                string logmessage = "Control Text: " + control.Current.Name + " Selection verified";
                ProdStaticSession.Log(logmessage);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
        }
    }
}