// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Bridge;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Static
{
    /// <summary>
    /// Provides access to controls using static methods
    /// </summary>
    public static partial class Prod
    {
        /// <summary>
        /// Determines whether the list control supports multiple selection of items
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to th target list control</param>
        /// <returns>
        ///   <c>true</c> if this instance can have multiple items selected, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        /// Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool CanSelectMultiple(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
                return SelectionPatternHelper.CanSelectMultiple(control);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Determines whether the list control supports multiple selection of items
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <returns>
        ///   <c>true</c> if this instance can have multiple items selected, otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool CanSelectMultiple(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                return SelectionPatternHelper.CanSelectMultiple(control);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Get all items contained in the list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        /// List containing text of all items in the list control
        /// </returns>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static Collection<object> GetItems(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection convRet = SelectionItemPatternHelper.GetListItems(control);

                Collection<object> ret = InternalUtilities.AutomationCollToObjectList(convRet);

                if (ret == null)
                {
                    ProdListBoxNative.GetItemsNative(controlHandle);
                }

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name, ret));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Get all items contained in the list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// List containing text of all items in the list control
        /// </returns>
        /// <remarks>
        /// Only valid for multiple selection list controls.
        /// </remarks>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static Collection<object> GetItems(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetItemsBridge(null, control);
        }

        /// <summary>
        /// Gets the number of items in the list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        /// The number of items contained in the list control
        /// </returns>
        /// <remarks>
        /// Invalid on WPF controls
        /// </remarks>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetItemCount(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                int ret = SelectionItemPatternHelper.GetListItemCount(control);

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

                LogController.ReceiveLogMessage(new LogMessage(ret.ToString(CultureInfo.InvariantCulture)));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the number of items in the list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The number of items contained in the list control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetItemCount(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetItemCountBridge(null, control);
        }

        #region Single Select specific

        /// <summary>
        /// Gets the zero based index of the currently selected item in a list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        /// Index of selected item
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetSelectedIndex(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement[] element = SelectionPatternHelper.GetSelection(control);
                int ret = SelectionItemPatternHelper.FindIndexByItem(control, element[0].Current.Name);
                if (ret == -1)
                {
                    /* Call native function */
                    ret = ProdListBoxNative.GetSelectedIndexNative(controlHandle);
                }
                LogController.ReceiveLogMessage(new LogMessage(ret.ToString(CultureInfo.InvariantCulture)));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the zero based index of the currently selected item in a list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// Index of selected item
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid only for single-selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int GetSelectedIndex(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetSelectedIndexBridge(null, control);
        }

        /// <summary>
        /// Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the window containing the target control</param>
        /// <returns>
        /// collection containing text of all selected items
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static AutomationElement GetSelectedItem(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(control);

                AutomationElement ret = retVal[0];
                if (ret == null)
                {
                    throw new ProdOperationException("Unable to select Item");
                }

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// collection containing text of all selected items
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static object GetSelectedItem(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return SingleSelectListBridge.GetSelectedItemBridge(null, control);
        }

        /// <summary>
        /// Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to list control</param>
        /// <param name="index">The zero-based index of the item to select</param>
        ///<exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

                AutomationElement indexedItem = SelectionItemPatternHelper.FindItemByIndex(control, index);
                SelectionItemPatternHelper.SelectItem(indexedItem);

                LogController.ReceiveLogMessage(new LogMessage(index.ToString(CultureInfo.InvariantCulture)));
            }
            catch (InvalidOperationException)
            {
                ProdListBoxNative.SelectItemNative(controlHandle, index);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="itemText">Text of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

                AutomationElement indexedItem = SelectionItemPatternHelper.FindItemByText(control, itemText);
                SelectionItemPatternHelper.SelectItem(indexedItem);

                LogController.ReceiveLogMessage(new LogMessage(itemText));
            }
            catch (InvalidOperationException)
            {
                ProdListBoxNative.SelectItemNative(controlHandle, itemText);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="index">The zero-based index of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedIndex(ProdWindow prodwindow, string automationId, int index)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            SingleSelectListBridge.SetSelectedIndexBridge(null, control, index);
        }

        /// <summary>
        /// Select an item in the list control, deselecting all other items
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="itemText">Text of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetSelectedItem(ProdWindow prodwindow, string automationId, string itemText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            SingleSelectListBridge.SetSelectedItemBridge(null, control, itemText);
        }

        #endregion Single Select specific

        #region Multi Select specific

        /// <summary>
        /// Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="index">The zero-based index of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent, control);
                SelectionItemPatternHelper.AddToSelection(control, index);

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.AddSelectedItemNative(controlHandle, index);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="itemText">Text of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementAddedToSelectionEvent, control);
                SelectionItemPatternHelper.AddToSelection(control, itemText);

                LogController.ReceiveLogMessage(new LogMessage("List Item selected: " + itemText));
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.AddSelectedItemNative(controlHandle, itemText);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="index">The zero-based index of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(ProdWindow prodwindow, string automationId, int index)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            MultipleSelectListBridge.AddToSelectionBridge(null, control, index);
        }

        /// <summary>
        /// Selects an item in a multi-select list control without deselecting other items
        /// </summary>
        /// <param name="prodwindow">The ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="itemText">Text of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void AddToSelection(ProdWindow prodwindow, string automationId, string itemText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            MultipleSelectListBridge.AddToSelectionBridge(null, control, itemText);
        }

        /// <summary>
        /// Deselect an item in the list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="index">The zero-based index of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(IntPtr controlHandle, int index)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement itemToSelect = SelectionItemPatternHelper.FindItemByIndex(control, index);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent, control);
                SelectionItemPatternHelper.RemoveFromSelection(itemToSelect);

                LogController.ReceiveLogMessage(new LogMessage("List Item deselected: " + index));
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.DeSelectItemNative(controlHandle, index);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Deselect an item in the list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="itemText">Text of the item to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(IntPtr controlHandle, string itemText)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElement itemToSelect = SelectionItemPatternHelper.FindItemByText(control, itemText);

                StaticEvents.RegisterEvent(SelectionItemPattern.ElementRemovedFromSelectionEvent, control);
                SelectionItemPatternHelper.RemoveFromSelection(itemToSelect);

                LogController.ReceiveLogMessage(new LogMessage("List Item deselected: " + itemText));
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdListBoxNative.DeSelectItemNative(controlHandle, itemText);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Deselect an item in the list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="index">The zero-based index of the item to select.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(ProdWindow prodwindow, string automationId, int index)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            MultipleSelectListBridge.RemoveFromSelectionBridge(null, control, index);
        }

        /// <summary>
        /// Deselect an item in the list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="itemText">Text of the item to select.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void DeselectItem(ProdWindow prodwindow, string automationId, string itemText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            MultipleSelectListBridge.RemoveFromSelectionBridge(null, control, itemText);
        }

        /// <summary>
        /// Gets the number of selected items in the list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target window containing the control</param>
        /// <returns>
        /// The number of selected items in the list control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int SelectedItemCount(IntPtr controlHandle)
        {
            try
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

                if (selectedItems == null)
                {
                    return -1;
                }
                LogController.ReceiveLogMessage(new LogMessage("List selection count: " + selectedItems.Length));
                return selectedItems.Length;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the number of selected items in the list control.
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// The number of selected items in the list control
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static int SelectedItemCount(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return MultipleSelectListBridge.GetSelectedItemCountBridge(null, control);
        }

        /// <summary>
        /// Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target window containing the control</param>
        /// <returns>
        /// collection containing text of all selected items
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static Collection<object> GetSelectedItems(IntPtr controlHandle)
        {
            if (!CanSelectMultiple(controlHandle))
            {
                return null;
            }

            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                AutomationElementCollection convRet = SelectionItemPatternHelper.GetSelectedItems(control);

                Collection<object> ret = InternalUtilities.AutomationCollToObjectList(convRet);
                LogController.ReceiveLogMessage(new LogMessage("List selected items: ", ret));

                return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets a list of selected indexes in a list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <returns>
        /// List of selected indexes
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. Invalid on WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static Collection<object> GetSelectedIndexes(IntPtr controlHandle)
        {
            if (!CanSelectMultiple(controlHandle))
            {
                return null;
            }

            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);

                AutomationElement[] selectedItems = SelectionPatternHelper.GetSelection(control);
                Collection<object> retList = new Collection<object>(selectedItems);

                LogController.ReceiveLogMessage(new LogMessage("List selected items: ", retList));

                return retList;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets a collection of all selected items in a list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// collection containing text of all selected items
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static Collection<string> GetSelectedItems(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return MultipleSelectListBridge.GetSelectedItemsBridge(null, control);
        }

        /// <summary>
        /// Gets a list of selected indexes in a list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// List of selected indexes
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls. This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static Collection<int> GetSelectedIndexes(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return MultipleSelectListBridge.GetSelectedIndexesBridge(null, control);
        }

        /// <summary>
        /// Sets selected items in a multi-select list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="items">The text of all the items to select</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
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
                List<object> itemList = new List<object>(items);
                Collection<object> retList = new Collection<object>(itemList);
                LogController.ReceiveLogMessage(new LogMessage("List items Selected: ", retList));
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                foreach (string item in items)
                {
                    ProdListBoxNative.AddSelectedItemNative(controlHandle, item);
                }
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Sets a list of selected items by index in a multi-select list control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target list control</param>
        /// <param name="indexes">A list of integers representing the zero-based indexes to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls
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
                if (!CanSelectMultiple((IntPtr)control.Current.NativeWindowHandle))
                {
                    return;
                }

                foreach (int index in indexes)
                {
                    AddToSelection(controlHandle, index);
                }

                Collection<object> retList = new Collection<object> {
                                                            indexes
                                                        };
                LogController.ReceiveLogMessage(new LogMessage("List items Selected: ", retList));
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                foreach (int item in indexes)
                {
                    ProdListBoxNative.AddSelectedItemNative(controlHandle, item);
                }
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Sets selected items in a multi-select list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <param name="items">The text of all the items to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static void SetSelectedItems(ProdWindow prodwindow, string automationId, Collection<string> items)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            MultipleSelectListBridge.SetSelectedItemsBridge(null, control, items);
        }

        /// <summary>
        /// Sets a list of selected items by index in a multi-select list control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption)</param>
        /// <param name="indexes">A list of integers representing the zero-based indexes to select</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Only valid for multiple selection list controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public static void SetSelectedIndexes(ProdWindow prodwindow, string automationId, Collection<int> indexes)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            MultipleSelectListBridge.SetSelectedIndexesBridge(null, control, indexes);
        }

        #endregion Multi Select specific
    }
}