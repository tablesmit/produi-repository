// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Configuration;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Static
{
    /// <summary>
    ///     Provides access to controls using static methods
    /// </summary>
    public static partial class Prod
    {
        /// <summary>
        ///     Determines whether the list control supports multiple selection of items
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to th target list control</param>
        /// <returns>
        ///     <c>true</c> if this instance can have multiple items selected, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool CanSelectMultiple(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            return SelectionPatternHelper.CanSelectMultiple(control);
        }

        /// <summary>
        ///     Determines whether the list control supports multiple selection of items
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption)</param>
        /// <returns>
        ///     <c>true</c> if this instance can have multiple items selected, otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        ///     This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool CanSelectMultiple(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            return SelectionPatternHelper.CanSelectMultiple(control);
        }

        /// <summary>
        ///     Get all items contained in the list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        ///     List containing text of all items in the list control
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static List<object> GetItems(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(control);

            List<object> ret = InternalUtilities.AutomationCollToObjectList(convRet);

            if (ret == null)
            {
                ProdListBoxNative.GetItemsNative(controlHandle);
            }

            ProdStaticSession.Log("List items: ", ret);
            return ret;
        }

        /// <summary>
        ///     Get all items contained in the list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     List containing text of all items in the list control
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls.
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static List<object> GetItems(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElementCollection convRet = SelectionPatternHelper.GetListItems(control);

            List<object> ret = InternalUtilities.AutomationCollToObjectList(convRet);

            ProdStaticSession.Log("List items: ", ret);
            return ret;
        }

        /// <summary>
        ///     Gets the number of items in the list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        ///     The number of items contained in the list control
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetItemCount(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(control);
            int ret = aec.Count;

            if (ret == -1)
            {
                if (control.Current.ControlType == ControlType.ComboBox)
                {
                    ProdComboBoxNative.GetItemCountNative(controlHandle);
                }
                else
                {
                    ProdListBoxNative.GetItemCountNative(controlHandle);
                }
            }

            ProdStaticSession.Log("List item count: " + ret);
            return ret;
        }

        /// <summary>
        ///     Gets the number of items in the list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     The number of items contained in the list control
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetItemCount(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(control);
            int ret = aec.Count;

            ProdStaticSession.Log("List item count: " + ret);
            return ret;
        }

        #region Single Select specific

        /// <summary>
        ///     Gets the zero based index of the currently selected item in a list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        ///     Index of selected item
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetSelectedIndex(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            AutomationElement[] element = SelectionPatternHelper.GetSelection(control);
            int ret = SelectionPatternHelper.FindIndexByItem(control, element[0].Current.Name);
            if (ret == -1)
            {
                /* Call native function */
                ret = ProdListBoxNative.GetSelectedIndexNative(controlHandle);
            }
            ProdStaticSession.Log("Selected List item index: " + ret);
            return ret;
        }

        /// <summary>
        ///     Gets the zero based index of the currently selected item in a list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     Index of selected item
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid only for single-selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetSelectedIndex(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement[] element = SelectionPatternHelper.GetSelection(control);
            int ret = SelectionPatternHelper.FindIndexByItem(control, element[0].Current.Name);

            ProdStaticSession.Log("Selected List item index: " + ret);
            return ret;
        }

        /// <summary>
        ///     Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the window containing the target control</param>
        /// <returns>
        ///     collection containing text of all selected items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static AutomationElement GetSelectedItem(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control);

            AutomationElement ret = retVal[0];
            if (ret == null)
            {
                throw new ProdOperationException("Unable to select Item");
            }

            ProdStaticSession.Log("Selected List item: " + ret);
            return ret;
        }

        /// <summary>
        ///     Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     collection containing text of all selected items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static object GetSelectedItem(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control);

            AutomationElement ret = retVal[0];
            if (ret == null)
            {
                throw new ProdOperationException("Unable to select Item");
            }

            ProdStaticSession.Log("Selected List item: " + ret);
            return ret;
        }

        /// <summary>
        ///     Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to list control</param>
        /// <param name = "index">The zero-based index of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(control, index);
                SelectionPatternHelper.Select(indexedItem);

                ProdStaticSession.Log("List item Selected: " + index);
            }
            catch (InvalidOperationException)
            {
                ProdListBoxNative.SelectItemNative(controlHandle, index);
            }
        }

        /// <summary>
        ///     Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "itemText">Text of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

                AutomationElement indexedItem = SelectionPatternHelper.FindItemByText(control, itemText);
                SelectionPatternHelper.Select(indexedItem);

                ProdStaticSession.Log("List item Selected: " + itemText);
            }
            catch (InvalidOperationException)
            {
                ProdListBoxNative.SelectItemNative(controlHandle, itemText);
            }
        }

        /// <summary>
        ///     Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "index">The zero-based index of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(ProdWindow prodwindow, string automationId, int index)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

            AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(control, index);
            SelectionPatternHelper.Select(indexedItem);

            ProdStaticSession.Log("List item Selected: " + index);
        }

        /// <summary>
        ///     Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "itemText">Text of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(ProdWindow prodwindow, string automationId, string itemText)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

            AutomationElement indexedItem = SelectionPatternHelper.FindItemByText(control, itemText);
            SelectionPatternHelper.Select(indexedItem);

            ProdStaticSession.Log("List item Selected: " + itemText);
        }

        #endregion

        #region Multi Select specific

        /// <summary>
        ///     Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "index">The zero-based index of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control, index);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent, control);
                SelectionPatternHelper.AddToSelection(control, index);

                ProdStaticSession.Log("List Item selected: " + index);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.AddSelectedItemNative(controlHandle, index);
            }
        }

        /// <summary>
        ///     Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "itemText">Text of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control, itemText);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent, control);
                SelectionPatternHelper.AddToSelection(control, itemText);

                ProdStaticSession.Log("List Item selected: " + itemText);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.AddSelectedItemNative(controlHandle, itemText);
            }
        }

        /// <summary>
        ///     Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "index">The zero-based index of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(ProdWindow prodwindow, string automationId, int index)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control, index);

            StaticEvents.RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent, control);
            SelectionPatternHelper.AddToSelection(control, index);

            ProdStaticSession.Log("List Item selected: " + index);
        }

        /// <summary>
        ///     Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name = "prodwindow">The prodwindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "itemText">Text of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(ProdWindow prodwindow, string automationId, string itemText)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control, itemText);

            StaticEvents.RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent, control);
            SelectionPatternHelper.AddToSelection(control, itemText);

            ProdStaticSession.Log("List Item selected: " + itemText);
        }

        /// <summary>
        ///     Deselect an item in the list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "index">The zero-based index of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control, index);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent, control);
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);

                ProdStaticSession.Log("List Item deselected: " + index);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.DeSelectItemNative(controlHandle, index);
            }
        }

        /// <summary>
        ///     Deselect an item in the list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "itemText">Text of the item to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control, itemText);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent, control);
                SelectionPatternHelper.RemoveFromSelection(itemToSelect);

                ProdStaticSession.Log("List Item deselected: " + itemText);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.DeSelectItemNative(controlHandle, itemText);
            }
        }

        /// <summary>
        ///     Deselect an item in the list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "index">The zero-based index of the item to select.</param>
        /// <remarks>
        ///     Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(ProdWindow prodwindow, string automationId, int index)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByIndex(control, index);

            StaticEvents.RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent, control);
            SelectionPatternHelper.RemoveFromSelection(itemToSelect);

            ProdStaticSession.Log("List Item deselected: " + index);
        }

        /// <summary>
        ///     Deselect an item in the list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <param name = "itemText">Text of the item to select.</param>
        /// <remarks>
        ///     Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(ProdWindow prodwindow, string automationId, string itemText)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement itemToSelect = SelectionPatternHelper.FindItemByText(control, itemText);

            StaticEvents.RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent, control);
            SelectionPatternHelper.RemoveFromSelection(itemToSelect);

            ProdStaticSession.Log("List Item deselected: " + itemText);
        }

        /// <summary>
        ///     Gets the number of selected items in the list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target window containing the control</param>
        /// <returns>
        ///     The number of selected items in the list control
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int SelectedItemCount(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            if (!SelectionPatternHelper.CanSelectMultiple(control))
            {
                return -1;
            }


            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control);

            if (selectedItems == null)
            {
                if (CanSelectMultiple(controlHandle))
                {
                    /* Call native function */
                    return ProdListBoxNative.GetSelectedItemCountNative(controlHandle);
                }
            }

            ProdStaticSession.Log("List selection count: " + selectedItems.Length);
            return selectedItems.Length;
        }

        /// <summary>
        ///     Gets the number of selected items in the list control.
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     The number of selected items in the list control
        /// </returns>
        /// <remarks>
        ///     Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int SelectedItemCount(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control);

            ProdStaticSession.Log("List selection count: " + selectedItems.Length);
            return selectedItems.Length;
        }

        /// <summary>
        ///     Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target window containing the control</param>
        /// <returns>
        ///     collection containing text of all selected items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static List<object> GetSelectedItems(IntPtr controlHandle)
        {
            if (!CanSelectMultiple(controlHandle))
            {
                return null;
            }

            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            AutomationElementCollection convRet = SelectionPatternHelper.GetSelectedItems(control);

            List<object> ret = InternalUtilities.AutomationCollToObjectList(convRet);
            ProdStaticSession.Log("List selected items: ", ret);

            return ret;
        }

        /// <summary>
        ///     Gets a list of selected indexes in a list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        ///     List of selected indexes
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static List<object> GetSelectedIndexes(IntPtr controlHandle)
        {
            if (!CanSelectMultiple(controlHandle))
            {
                return null;
            }

            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);

            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control);
            List<object> retList = new List<object>(selectedItems);

            ProdStaticSession.Log("List selected items: ", retList);

            return retList;
        }


        /// <summary>
        ///     Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     collection containing text of all selected items
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static List<object> GetSelectedItems(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (!CanSelectMultiple((IntPtr) control.Current.NativeWindowHandle))
            {
                return null;
            }


            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control);
            List<object> retList = new List<object>(selectedItems);

            ProdStaticSession.Log("List selected items: ", retList);

            return retList;
        }

        /// <summary>
        ///     Gets a list of selected indexes in a list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     List of selected indexes
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static List<object> GetSelectedIndexes(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (!CanSelectMultiple((IntPtr) control.Current.NativeWindowHandle))
            {
                return null;
            }


            AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control);
            List<object> retList = new List<object>(selectedItems);

            ProdStaticSession.Log("List selected items: ", retList);
            return retList;
        }

        /// <summary>
        ///     Sets selected items in a multi-select list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "items">The text of all the items to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static void SetSelectedItems(IntPtr controlHandle, Collection<string> items)
        {
            try
            {
                CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                if (!CanSelectMultiple(controlHandle))
                {
                    return;
                }


                foreach (string item in items)
                {
                    AddToSelection(controlHandle, item);
                }

                List<object> retList = new List<object>(items);
                ProdStaticSession.Log("List items Selected: ", retList);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                foreach (string item in items)
                {
                    ProdListBoxNative.AddSelectedItemNative(controlHandle, item);
                }
            }
        }

        /// <summary>
        ///     Sets a list of selected items by index in a multi-select list control
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name = "indexes">A list of integers representing the zero-based indexes to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static void SetSelectedIndexes(IntPtr controlHandle, Collection<int> indexes)
        {
            if (!CanSelectMultiple(controlHandle))
            {
                return;
            }


            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                if (!CanSelectMultiple((IntPtr) control.Current.NativeWindowHandle))
                {
                    return;
                }


                foreach (int index in indexes)
                {
                    AddToSelection(controlHandle, index);
                }

                List<object> retList = new List<object> {
                                                            indexes
                                                        };
                ProdStaticSession.Log("List items Selected: ", retList);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                foreach (int item in indexes)
                {
                    ProdListBoxNative.AddSelectedItemNative(controlHandle, item);
                }
            }
        }

        /// <summary>
        ///     Sets selected items in a multi-select list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption)</param>
        /// <param name = "items">The text of all the items to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static void SetSelectedItems(ProdWindow prodwindow, string automationId, Collection<string> items)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (!CanSelectMultiple((IntPtr) control.Current.NativeWindowHandle))
            {
                return;
            }


            foreach (string item in items)
            {
                AddToSelection(prodwindow, automationId, item);
            }

            List<object> retList = new List<object>(items);
            ProdStaticSession.Log("List items Selected: ", retList);
        }

        /// <summary>
        ///     Sets a list of selected items by index in a multi-select list control
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption)</param>
        /// <param name = "indexes">A list of integers representing the zero-based indexes to select</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static void SetSelectedIndexes(ProdWindow prodwindow, string automationId, Collection<int> indexes)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (!CanSelectMultiple((IntPtr) control.Current.NativeWindowHandle))
            {
                return;
            }


            foreach (int index in indexes)
            {
                AddToSelection(prodwindow, automationId, index);
            }

            List<object> retList = new List<object> {
                                                        indexes
                                                    };
            ProdStaticSession.Log("List items Selected: ", retList);
        }

        #endregion
    }
}