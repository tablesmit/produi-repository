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

namespace ProdUI.Controls
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
        ///   Will attempt to match AutomationId, then Name
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
        ///   Gets the number of items in the List control
        /// </summary>
        /// <returns>The number of items in the list</returns>
        /// <example>
        ///   <code>
        ///     ProdSession session = new ProdSession();
        ///     ProdWindow window = new ProdWindow("App Window Name", session);
        ///     ProdComboBox control = new ProdComboBox(window, "CboName");
        ///     int retVal = control.GetItemCount();
        ///   </code>
        /// </example>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetItemCount()
        {
            try
            {
                AutomationElementCollection aec = SelectionPatternHelper.GetListCollectionUtility(ThisElement);
                int retVal = aec.Count;
                if (retVal == -1 && Handle != IntPtr.Zero)
                {
                    ProdComboBoxNative.GetItemCountNative(Handle);
                }
                Logmessage = "Count: " + retVal;
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
        ///   Gets the selected item
        /// </summary>
        /// <returns>The currently selected item</returns>
        /// <example>
        ///   <code>
        ///     ProdSession session = new ProdSession();
        ///     ProdWindow window = new ProdWindow("App Window Name", session);
        ///     ProdComboBox control = new ProdComboBox(window, "CboName");
        ///     Object retVal = control.GetSelectedItem();
        ///   </code>
        /// </example>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetSelectedItem()
        {
            try
            {
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(ThisElement);

                Logmessage = "Count: " + retVal[0].Current.AutomationId;
                LogEntry();

                return retVal[0];

            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return null;
            }
        }

        /// <summary>
        ///   Gets the zero-based index of the currently selected item
        /// </summary>
        /// <returns>The zero based index of the selected item in the list</returns>
        /// <example>
        ///   <code>
        ///     ProdSession session = new ProdSession();
        ///     ProdWindow window = new ProdWindow("App Window Name", session);
        ///     ProdComboBox control = new ProdComboBox(window, "CboName");
        ///     int retVal = ProdComboBox.GetSelectedIndex();
        ///   </code>
        /// </example>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedIndex()
        {
            try
            {
                AutomationElement[] element = SelectionPatternHelper.GetSelection(ThisElement);
                int retVal = SelectionPatternHelper.FindIndexByItem(element[0]);
                Logmessage = "Index " + retVal;
                LogEntry();
                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return -1;
            }
        }

        /// <summary>
        ///   Selects the item.
        /// </summary>
        /// <param name = "index">The index of the item to select.</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(int index)
        {
            try
            {
                Logmessage = "Index " + index;
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(ThisElement, index);
                SelectionPatternHelper.Select(indexedItem);               
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdComboBoxNative.SelectItemNative(Handle, index);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Selects the item.
        /// </summary>
        /// <param name = "itemText">The item text.</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetSelectedItem(string itemText)
        {
            try
            {
                Logmessage = "Item " + itemText;
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement control = SelectionPatternHelper.FindItemByText(ThisElement, itemText);
                SelectionPatternHelper.Select(control);
            }
            catch (InvalidOperationException)
            {
                /* Call native function */
                ProdComboBoxNative.SelectItemNative(Handle, itemText);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Determines whether the specified index is selected.
        /// </summary>
        /// <param name = "index">The index.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public bool IsSelected(int index)
        {
            try
            {
                bool retVal = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByIndex(ThisElement, index));

                Logmessage = retVal.ToString(CultureInfo.CurrentCulture);
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return false;
            }
        }

        /// <summary>
        ///   Determines whether the specified item text is selected.
        /// </summary>
        /// <param name = "itemText">The item text.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        public bool IsSelected(string itemText)
        {
            try
            {
                bool retVal = SelectionPatternHelper.IsSelected(SelectionPatternHelper.FindItemByText(ThisElement, itemText));

                Logmessage = retVal.ToString(CultureInfo.CurrentCulture);
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return false;
            }
        }

        /// <summary>
        ///   Get all items contained in the list control
        /// </summary>
        /// <returns>List containing text of all items in the list control</returns>
        /// <example>
        ///   <code><![CDATA[
        /// ProdSession session = new ProdSession();
        /// ProdWindow window = new ProdWindow("App Window Name", session);
        /// ProdComboBox control = new ProdComboBox(window, "CboName");
        /// collection;ltObject;gt retVal = control.GetItems();
        /// ]]></code>
        /// </example>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public ArrayList GetItems()
        {
            try
            {
                AutomationElementCollection retVal = SelectionPatternHelper.GetListItems(ThisElement);

                if (retVal == null && Handle != IntPtr.Zero)
                {
                    return ProdComboBoxNative.GetItemsNative(Handle);
                }

                ArrayList retArr = InternalUtilities.AutomationCollToArrayList(retVal);
                Logmessage = "Items: ";
                VerboseInformation = retArr;
                LogEntry();

                return retArr;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return null;
            }
        }

        #endregion

        #region Textbox Instance Methods

        /// <summary>
        ///   Gets the number of characters in textbox
        /// </summary>
        /// <returns>The length of the string in the TextBox (if supported)</returns>
        /// <exception cref = "ProdOperationException">
        ///   Thrown if element is no longer available
        ///   Thrown if ComboBox doesn't support the value pattern
        /// </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int Length()
        {
            try
            {
                if (CheckPatternSupport(ValuePattern.Pattern, ThisElement))
                {
                    string retVal = ValuePatternHelper.GetValue(ThisElement);

                    if (retVal == null && Handle != IntPtr.Zero)
                    {
                        retVal = NativeTextProds.GetTextNative(Handle);
                    }
                    if (retVal != null)
                    {
                        int len = retVal.Length;

                        Logmessage = "Length: " + len;
                        LogEntry();

                        return len;
                    }
                }
                throw new ProdOperationException("This control does not support ValuePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return -1;
            }
        }

        /// <summary>
        ///   Gets the text contained in the current TextBox
        /// </summary>
        /// <returns>The string in the Textbox (if supported)</returns>
        /// <exception cref = "ProdOperationException">
        ///   Thrown if element is no longer available
        ///   Thrown if ComboBox doesn't support the value pattern
        /// </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            try
            {
                if (CheckPatternSupport(ValuePattern.Pattern, ThisElement))
                {
                    string retVal = ValuePatternHelper.GetValue(ThisElement);

                    if (retVal == null && Handle != IntPtr.Zero)
                    {
                        return NativeTextProds.GetTextNative(Handle);
                    }

                    Logmessage = "Control Text: " + retVal;
                    LogEntry();

                    return retVal;
                }
                throw new ProdOperationException("This control does not support ValuePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                return string.Empty;
            }
        }

        /// <summary>
        ///   Sets the text contained in the current TextBox
        /// </summary>
        /// <param name = "text">The text to set the TextBox to (if supported)</param>
        /// <exception cref = "ProdOperationException">
        ///   Thrown if element is no longer available
        ///   Thrown if ComboBox doesn't support the value pattern
        /// </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            try
            {
                if (CheckPatternSupport(ValuePattern.Pattern, ThisElement))
                {
                    Logmessage = "Text: " + text;
                    SubscribeToEvent(ValuePattern.ValueProperty);
                    int ret = ValuePatternHelper.SetValue(ThisElement, text);

                    if (ret == -1 && Handle != IntPtr.Zero)
                    {
                        NativeTextProds.SetTextNative(Handle, text);
                    }
                }
                throw new ProdOperationException("This control does not support ValuePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Set text area value to an empty string
        /// </summary>
        /// <exception cref = "ProdOperationException">
        ///   Thrown if element is no longer available
        ///   Thrown if ComboBox doesn't support the value pattern
        /// </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Clear()
        {
            try
            {
                if (CheckPatternSupport(ValuePattern.Pattern, ThisElement))
                {
                    SubscribeToEvent(ValuePattern.ValueProperty);
                    int ret = ValuePatternHelper.SetValue(ThisElement, string.Empty);

                    if (ret == -1 && Handle != IntPtr.Zero)
                    {
                        NativeTextProds.SetTextNative(Handle, String.Empty);
                    }
                }
                throw new ProdOperationException("This control does not support ValuePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Appends text to a text input control
        /// </summary>
        /// <param name = "newText">Text To Append</param>
        /// <exception cref = "ProdOperationException">
        ///   Thrown if element is no longer available
        ///   Thrown if ComboBox doesn't support the value pattern
        /// </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AppendText(string newText)
        {
            try
            {
                SubscribeToEvent(ValuePattern.ValueProperty);
                if (CheckPatternSupport(ValuePattern.Pattern, ThisElement))
                {
                    int ret = ValuePatternHelper.AppendValue(ThisElement, newText);

                    if (ret == -1 && Handle != IntPtr.Zero)
                    {
                        NativeTextProds.AppendTextNative(Handle, newText);
                    }

                    Logmessage = "Appended: " + newText;
                    LogEntry();
                }
                throw new ProdOperationException("This control does not support ValuePattern");
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        #endregion

    }
}