// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    internal static class ValueBridge
    {

        /// <summary>
        /// Appends text to a text input control
        /// </summary>
        /// <param name="theValue">The invoke.</param>
        /// <param name="control">The control.</param>
        /// <param name="newText">Text To Append</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void AppendTextBridge(this IValue theValue, BaseProdControl control, string newText)
        {
            try
            {
                if (GetReadOnly(control.UIAElement)) throw new ProdOperationException("Control is Read Only");
             
                AutomationEventVerifier.Register(new EventRegistrationMessage(control, ValuePattern.ValueProperty));

                LogController.ReceiveLogMessage(new LogMessage("Appending: " + newText));
                ValuePatternHelper.AppendValue(control.UIAElement, newText);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeAppendText(control.UIAElement, newText);
            }
        }

        private static void UiaAppendText(AutomationElement element, string newText)
        {
            ValuePatternHelper.AppendValue(element, newText);
        }

        private static void NativeAppendText(AutomationElement element, string newText)
        {
            int hwnd = element.Current.NativeWindowHandle;
            if (hwnd == 0)
                /* If it doesn't have one, send keys, then */
                InternalUtilities.SendKeysAppendText(element, newText);

            ProdEditNative.AppendTextNative((IntPtr)element.Current.NativeWindowHandle, newText);
        }






        /// <summary>
        ///     Set text area value to an empty string
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void ClearTextBridge(this IValue theValue, BaseProdControl control)
        {
            try
            {
                if (GetReadOnly(control.UIAElement)) throw new ProdOperationException("Control is Read Only");

                UiaClearText(control.UIAElement);

            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeClearText(control.UIAElement);
            }
        }

        private static void UiaClearText(AutomationElement element)
        {
            //currently the verification is done in pattern helper
            ValuePatternHelper.SetValue(element, "");
        }

        private static void NativeClearText(AutomationElement element)
        {
            int hwnd = element.Current.NativeWindowHandle;
            if (hwnd != 0) { ProdEditNative.ClearTextNative((IntPtr)hwnd); }

            /* If it doesn't have one, send keys, then */
            InternalUtilities.SendKeysSetText(element, "^a");
            InternalUtilities.SendKeysSetText(element, "{Backspace}");
        }







        /// <summary>
        ///     Copies any text in the control to the Clipboard.
        /// </summary>
        public void CopyToClipBoard()
        {
            string text = GetText();
            if (text.Length > 0)
            {
                Clipboard.SetText(text);
            }
        }

        /// <summary>
        ///     Gets the number of characters in textbox
        /// </summary>
        /// <returns>The number of characters in the ProdTextBox</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetLength()
        {
            try
            {
                string txt = GetText();
                if (txt != null && NativeWindowHandle != IntPtr.Zero)
                {
                    txt = NativeTextProds.GetTextNative(NativeWindowHandle);
                }

                int retVal = txt.Length;
                LogText = "Length: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets or sets the text contained in the current TextBox
        /// </summary>
        /// <returns>The text currently in the ProdTextBox</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            string ret = ValuePatternHelper.GetValue(UIAElement);

            if (ret == null && NativeWindowHandle != IntPtr.Zero)
            {
                ret = NativeTextProds.GetTextNative(NativeWindowHandle);
            }

            LogText = "Text: " + ret;
            LogMessage();

            return ret;
        }

        /// <summary>
        ///     Appends the supplied string to the existing textBox text
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

                if ((bool)UIAElement.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty))
                {
                    throw new ProdOperationException("TextBox is Read Only");
                }

                //TODO: convert
                //if (ValuePatternHelper.InsertValue(UIAElement, newText, insertIndex) == 0)
                //{
                //    return;
                //}


                if (NativeWindowHandle != IntPtr.Zero)
                {
                    NativeTextProds.InsertTextNative(NativeWindowHandle, newText, insertIndex);
                }
                else
                {
                    throw new ProdOperationException("Could not InsertText");
                }
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Pastes text (if available) from the Clipboard into the control.
        /// </summary>
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
        ///     Gets or sets the text contained in the current TextBox
        /// </summary>
        /// <param name = "text">The text to place into the ProdTextBox.</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            try
            {
                RegisterEvent(ValuePattern.ValueProperty);

                if ((bool)UIAElement.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty))
                {
                    throw new ProdOperationException("TextBox is Read Only");
                }

                if (ValuePatternHelper.SetValue(UIAElement, text) == 0)
                {
                    return;
                }


                /* If control has a handle, use native method */
                if (NativeWindowHandle != IntPtr.Zero)
                {
                    if (NativeTextProds.SetTextNative(NativeWindowHandle, text))
                    {
                        return;
                    }
                }

                /* If it doesn't have one, send keys, then */
                //TODO: convert ValuePatternHelper.SendKeysSetText(UIAElement, text);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        private static bool GetReadOnly(AutomationElement control)
        {
            return (bool)control.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty);
        }


    }
}