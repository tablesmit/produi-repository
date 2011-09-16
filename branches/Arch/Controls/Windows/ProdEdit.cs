/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Controls.Windows;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Controls;

/* 
 * Supported Patterns: 
 * IValueProvider 
 * ITextProvider 
 * 
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///   Provides mechanisms to work with Edit (or TextBox) controls
    /// </summary>
    public sealed class ProdEdit : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        public ProdEdit(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdEdit(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdTextBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdEdit(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        ///   Appends text to a text input control
        /// </summary>
        /// <param name = "newText">Text To Append</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AppendText(string newText)
        {
            LogText = "Appended: " + newText;

            try
            {
                RegisterEvent(ValuePattern.ValueProperty);
                if (CommonUIAPatternHelpers.ReadOnly(UIAElement))
                {
                    throw new ProdOperationException("TextBox is Read Only");
                }

                int ret = ValuePatternHelper.AppendValue(UIAElement, newText);

                if (ret == -1 && Handle != IntPtr.Zero)
                {
                    if (NativeTextProds.AppendTextNative(Handle, newText))
                    {
                        return;
                    }
                    else
                        /* If it doesn't have one, send keys, then */
                        ValuePatternHelper.SendKeysAppendText(UIAElement, newText); 
                }

            

            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>
        ///   Set text area value to an empty string
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Clear()
        {
            LogText = "Cleared";

            try
            {
                RegisterEvent(ValuePattern.ValueProperty);
                if (CommonUIAPatternHelpers.ReadOnly(UIAElement))
                {
                    throw new ProdOperationException("TextBox is Read Only");
                }

                if (ValuePatternHelper.SetValue(UIAElement, "") == 0)
                {
                    return;
                }


                if (Handle != IntPtr.Zero)
                {
                    NativeTextProds.ClearTextNative(Handle);
                    return;
                }

                /* If it doesn't have one, send keys, then */
                ValuePatternHelper.SendKeysSetText(UIAElement, "");              
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>Copies any text in the control to the Clipboard.</summary>
        public void CopyToClipBoard()
        {
            string text = GetText();
            if (text.Length > 0)
            { 
                Clipboard.SetText(text); 
            }
            
        }

        /// <summary>
        ///   Gets the number of characters in textbox
        /// </summary>
        /// <returns>The number of characters in the ProdTextBox</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///   Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetLength()
        {
            try
            {
                string txt = GetText();
                if (txt != null && Handle != IntPtr.Zero)
                {
                    txt = NativeTextProds.GetTextNative(Handle);
                }

                int retVal = txt.Length;
                LogText = "Length: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        ///   Gets or sets the text contained in the current TextBox
        /// </summary>
        /// <returns>The text currently in the ProdTextBox</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            string ret = ValuePatternHelper.GetValue(UIAElement);

            if (ret == null && Handle != IntPtr.Zero)
            {
                ret = NativeTextProds.GetTextNative(Handle);
            }

            LogText = "Text: " + ret;
            LogMessage();

            return ret;
        }

        /// <summary>
        ///   Appends the supplied string to the existing textBox text
        /// </summary>
        /// <param name = "newText">Text to append to TextBox value</param>
        /// <param name = "insertIndex">Zero based index of string to insert text into</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void InsertText(string newText, int insertIndex)
        {
            try
            {
                RegisterEvent(ValuePattern.ValueProperty);

                if (CommonUIAPatternHelpers.ReadOnly(UIAElement))
                {
                    throw new ProdOperationException("TextBox is Read Only");
                }


                if (ValuePatternHelper.InsertValue(UIAElement, newText, insertIndex) == 0)
                {
                    return;
                }


                if (Handle != IntPtr.Zero)
                {
                    NativeTextProds.InsertTextNative(Handle, newText, insertIndex);
                }
                else
                {
                    throw new ProdOperationException("Could not InsertText");
                }
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

        /// <summary>Pastes text (if available) from the Clipboard into the control.</summary>
        public void PasteFromClipboard()
        {
            if (!Clipboard.ContainsText())
            {
                return;
            }


            string contents = Clipboard.GetText();
            SetText(contents);

        }

        /// <summary>
        ///   Gets or sets the text contained in the current TextBox
        /// </summary>
        /// <param name = "text">The text to place into the ProdTextBox.</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            try
            {
                RegisterEvent(ValuePattern.ValueProperty);

                if (CommonUIAPatternHelpers.ReadOnly(UIAElement))
                {
                    throw new ProdOperationException("TextBox is Read Only");
                }

                if (ValuePatternHelper.SetValue(UIAElement, text) == 0)
                {
                    return;
                }


                /* If control has a handle, use native method */
                if (Handle != IntPtr.Zero)
                {
                    if (NativeTextProds.SetTextNative(Handle, text))
                    {
                        return;
                    }

                }

                /* If it doesn't have one, send keys, then */
                ValuePatternHelper.SendKeysSetText(UIAElement, text);

            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }

    }
}