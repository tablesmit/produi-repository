// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
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
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="newText">Text To Append</param>
        internal static void AppendTextBridge(this IValue extension, BaseProdControl control, string newText)
        {
            try
            {
                UiaAppendText(control, newText);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeAppendText(control, newText);
            }
        }

        private static void UiaAppendText(BaseProdControl control, string newText)
        {
            if (GetReadOnly(control.UIAElement)) throw new ProdOperationException("Control is Read Only");

            AutomationEventVerifier.Register(new EventRegistrationMessage(control, ValuePattern.ValueProperty));

            LogController.ReceiveLogMessage(new LogMessage("Appending: " + newText));
            ValuePatternHelper.AppendValue(control.UIAElement, newText);
        }

        private static void NativeAppendText(BaseProdControl control, string newText)
        {
            int hwnd = control.UIAElement.Current.NativeWindowHandle;
            if (hwnd == 0)
                /* If it doesn't have one, send keys, then */
                InternalUtilities.SendKeysAppendText(control.UIAElement, newText);

            ProdEditNative.AppendTextNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, newText);
        }

        /// <summary>
        /// Set text area value to an empty string
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        internal static void ClearTextBridge(this IValue extension, BaseProdControl control)
        {
            try
            {
                UiaClearText(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeClearText(control);
            }
        }

        private static void UiaClearText(BaseProdControl control)
        {
            if (GetReadOnly(control.UIAElement)) throw new ProdOperationException("Control is Read Only");
            //currently the verification is done in pattern helper
            ValuePatternHelper.SetValue(control.UIAElement, "");
            LogController.ReceiveLogMessage(new LogMessage("Clear Text"));
        }

        private static void NativeClearText(BaseProdControl control)
        {
            int hwnd = control.UIAElement.Current.NativeWindowHandle;
            if (hwnd != 0)
            {
                ProdEditNative.ClearTextNative((IntPtr)hwnd);
            }

            /* If it doesn't have one, send keys, then */
            InternalUtilities.SendKeysSetText(control.UIAElement, "^a");
            InternalUtilities.SendKeysSetText(control.UIAElement, "{Backspace}");
        }

        /// <summary>
        /// Gets the number of characters in textbox
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The number of characters in the ProdTextBox
        /// </returns>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        internal static int GetLengthBridge(this IValue extension, BaseProdControl control)
        {
            try
            {
                return UiaGetLength(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                return NativeGetLength(control);
            }
        }

        private static int UiaGetLength(BaseProdControl control)
        {
            string txt = ValuePatternHelper.GetValue(control.UIAElement);
            int retVal = txt.Length;
            LogController.ReceiveLogMessage(new LogMessage("Length: " + retVal));
            return retVal;
        }

        private static int NativeGetLength(BaseProdControl control)
        {
            string txt = NativeTextProds.GetTextNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
            return txt.Length;
        }

        /// <summary>
        /// Gets or sets the text contained in the current TextBox
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// The text currently in the ProdTextBox
        /// </returns>
        internal static string GetTextBridge(this IValue extension, BaseProdControl control)
        {
            try
            {
                return UiaGetText(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                return NativeGetText(control);
            }
        }

        private static string UiaGetText(BaseProdControl control)
        {
            string ret = ValuePatternHelper.GetValue(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage("String: " + ret));
            return ret;
        }

        private static string NativeGetText(BaseProdControl control)
        {
            return NativeTextProds.GetTextNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        /// <summary>
        /// inserts the supplied string to the existing textBox text
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="newText">Text to append to TextBox value</param>
        /// <param name="index">Zero based index of string to insert text into</param>
        internal static void InsertTextBridge(this IValue extension, BaseProdControl control, string newText, int index)
        {
            if ((bool)control.UIAElement.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty)) throw new ProdOperationException("TextBox is Read Only");

            try
            {
                UiaInsertText(control, newText, index);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeInsertText(control, newText, index);
            }
        }

        private static void UiaInsertText(BaseProdControl control, string newText, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("inserting " + newText));
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, ValuePattern.ValueProperty));
            ValuePatternHelper.InsertValue(control.UIAElement, newText, index);
        }

        private static void NativeInsertText(BaseProdControl control, string newText, int index)
        {
            NativeTextProds.InsertTextNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, newText, index);
        }

        /// <summary>
        /// Sets the text contained in the current TextBox
        /// </summary>
        /// <param name="extension">The extended interface.</param>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">The text to place into the ProdTextBox.</param>
        internal static void SetTextBridge(this IValue extension, BaseProdControl control, string text)
        {
            if ((bool)control.UIAElement.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty)) throw new ProdOperationException("TextBox is Read Only");
            try
            {
                UiaSetText(control, text);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeSetText(control, text);
            }
        }

        private static void UiaSetText(BaseProdControl control, string text)
        {
            LogController.ReceiveLogMessage(new LogMessage(text));
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, ValuePattern.ValueProperty));
            ValuePatternHelper.SetValue(control.UIAElement, text);
        }

        private static void NativeSetText(BaseProdControl control, string text)
        {
            NativeTextProds.SetTextNative((IntPtr)control.UIAElement.Current.NativeWindowHandle, text);
        }

        private static bool GetReadOnly(AutomationElement control)
        {
            return (bool)control.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty);
        }
    }
}