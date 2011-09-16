﻿/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Interaction.Native;

/* Notes
 * --ListBox Portion--
 * Supported Patterns: 
 * ISelectionProvider 
 * IExpandCollapseProvider 
 * 
 * Proposed functionality:
 * SetSelectedItem - index and text
 * GetSelectedItem - index and text
 * Item count
 * Get all items
 * additem
 * 
 * --Textbox portion--
 * Supported Pattern:
 * IValueProvider 
 * 
 * Proposed functionality:
 * is editing supported
 * gettext
 * settext
 * appendtext
 * cleartext
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///   Methods to work with ComboBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdComboBox : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdComboBox(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdComboBox(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdComboBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdComboBox(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        #region List Instance Methods

        /// <summary>
        /// Gets the number of items in the List control
        /// </summary>
        /// <returns>
        /// The number of items in the list
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemCount()
        {
            try
            {
                AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(UIAElement);
                int retVal = aec.Count;
                if (retVal == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdComboBoxNative.GetItemCountNative(NativeWindowHandle);
                }
                LogText = "Count: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the selected item
        /// </summary>
        /// <returns>
        /// The currently selected item
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetSelectedItem()
        {
            try
            {
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(UIAElement);

                LogText = "Count: " + retVal[0].Current.AutomationId;
                LogMessage();

                return retVal[0];

            }
            catch (ProdOperationException err)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the zero-based index of the currently selected item
        /// </summary>
        /// <returns>
        /// The zero based index of the selected item in the list
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedIndex()
        {
            try
            {
                AutomationElement[] element = SelectionPatternHelper.GetSelection(UIAElement);
                int retVal = SelectionPatternHelper.FindIndexByItem(UIAElement, element[0].Current.Name);
                LogText = "Index " + retVal;
                LogMessage();
                return retVal;
            }
            catch (ProdOperationException err)
            {
                return -1;
            }
        }

        /// <summary>
        /// Selects the item by its index.
        /// </summary>
        /// <param name="index">The index of the item to select.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedIndex(int index)
        {
            try
            {
                LogText = "Index " + index;
                RegisterEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(UIAElement, index);
                SelectionPatternHelper.Select(indexedItem);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdComboBoxNative.SelectItemNative(NativeWindowHandle, index);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="itemText">The item text.</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            try
            {
                LogText = "Item " + itemText;
                RegisterEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement control = SelectionPatternHelper.FindItemByText(UIAElement, itemText);
                SelectionPatternHelper.Select(control);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdComboBoxNative.SelectItemNative(NativeWindowHandle, itemText);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Determines whether the specified index is selected.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public bool IsSelected(int index)
        {
            try
            {
                bool retVal = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByIndex(UIAElement, index));

                LogText = retVal.ToString(CultureInfo.CurrentCulture);
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Determines whether the specified item text is selected.
        /// </summary>
        /// <param name="itemText">The item text.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public bool IsSelected(string itemText)
        {
            try
            {
                bool retVal = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByText(UIAElement, itemText));

                LogText = retVal.ToString(CultureInfo.CurrentCulture);
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all items contained in the list control
        /// </summary>
        /// <returns>
        /// List containing text of all items in the list control
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetItems()
        {
            try
            {
                AutomationElementCollection retVal = SelectionPatternHelper.GetListItems(UIAElement);

                if (retVal == null && NativeWindowHandle != IntPtr.Zero)
                {
                    return ProdComboBoxNative.GetItemsNative(NativeWindowHandle);
                }

                List<object> retArr = InternalUtilities.AutomationCollToObjectList(retVal);
                LogText = "Items: ";
                VerboseInformation = retArr;
                LogMessage();

                return retArr;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        #endregion

        #region Textbox Instance Methods

        /// <summary>
        /// Gets the number of characters in textbox
        /// </summary>
        /// <returns>
        /// The length of the string in the TextBox (if supported)
        /// </returns>
        /// <exception cref="ProdOperationException">
        /// Thrown if element is no longer available
        /// Thrown if ComboBox doesn't support the value pattern
        ///   </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int Length()
        {
            try
            {
                    string retVal = ValuePatternHelper.GetValue(UIAElement);

                    if (retVal == null && NativeWindowHandle != IntPtr.Zero)
                    {
                        retVal = NativeTextProds.GetTextNative(NativeWindowHandle);
                    }
                    if (retVal != null)
                    {
                        int len = retVal.Length;

                        LogText = "Length: " + len;
                        LogMessage();

                        return len;
                    }
                    return -1;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the text contained in the current TextBox
        /// </summary>
        /// <returns>
        /// The string in the Textbox (if supported)
        /// </returns>
        /// <exception cref="ProdOperationException">
        /// Thrown if element is no longer available
        /// Thrown if ComboBox doesn't support the value pattern
        ///   </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            try
            {
                    string retVal = ValuePatternHelper.GetValue(UIAElement);

                    if (retVal == null && NativeWindowHandle != IntPtr.Zero)
                    {
                        return NativeTextProds.GetTextNative(NativeWindowHandle);
                    }

                    LogText = "Control Text: " + retVal;
                    LogMessage();

                    return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Sets the text contained in the current TextBox
        /// </summary>
        /// <param name="text">The text to set the TextBox to (if supported)</param>
        /// <exception cref="ProdOperationException">
        /// Thrown if element is no longer available
        /// Thrown if ComboBox doesn't support the value pattern
        ///   </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            try
            {
                    LogText = "Text: " + text;
                    RegisterEvent(ValuePattern.ValueProperty);
                    int ret = ValuePatternHelper.SetValue(UIAElement, text);

                    if (ret == -1 && NativeWindowHandle != IntPtr.Zero)
                    {
                        NativeTextProds.SetTextNative(NativeWindowHandle, text);
                    }
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Set text area value to an empty string
        /// </summary>
        /// <exception cref="ProdOperationException">
        /// Thrown if element is no longer available
        /// Thrown if ComboBox doesn't support the value pattern
        ///   </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Clear()
        {
            try
            {
                    RegisterEvent(ValuePattern.ValueProperty);
                    int ret = ValuePatternHelper.SetValue(UIAElement, string.Empty);

                    if (ret == -1 && NativeWindowHandle != IntPtr.Zero)
                    {
                        NativeTextProds.SetTextNative(NativeWindowHandle, String.Empty);
                    }
                throw new ProdOperationException("This control does not support ValuePattern");
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        /// Appends text to a text input control
        /// </summary>
        /// <param name="newText">Text To Append</param>
        /// <exception cref="ProdOperationException">
        /// Thrown if element is no longer available
        /// Thrown if ComboBox doesn't support the value pattern
        ///   </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AppendText(string newText)
        {
            try
            {
                RegisterEvent(ValuePattern.ValueProperty);
                int ret = ValuePatternHelper.AppendValue(UIAElement, newText);

                if (ret == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    NativeTextProds.AppendTextNative(NativeWindowHandle, newText);
                }

                LogText = "Appended: " + newText;
                LogMessage();
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        #endregion

    }
}