// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Bridge;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Utility;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        /// Gets the ReadOnly status of the Textbox
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the  control</param>
        /// <returns>
        ///   <c>true</c> if control is ReadOnly, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This overload is invalid for WPF controls
        /// </remarks>
        public static bool GetReadOnly(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = AutomationElement.FromHandle(controlHandle);
                return (bool)control.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty);
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
        /// Gets the ReadOnly status of the Textbox
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        ///   <c>true</c> if control is ReadOnly, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static bool GetReadOnly(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                return (bool)control.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty);
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
        /// Set text area value to an empty string
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void ClearText(IntPtr controlHandle)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }

            try
            {
                ValuePatternHelper.SetValue(AutomationElement.FromHandle(controlHandle), string.Empty);
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
        /// Set text area value to an empty string
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void ClearText(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            ValueBridge.ClearTextBridge(null, control);
        }

        /// <summary>
        /// Gets the text currently contained in a text area
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <returns>
        /// Text contained in text area
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This overload is invalid for WPF controls
        /// </remarks>
        public static string GetText(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = AutomationElement.FromHandle(controlHandle);
                control.GetCurrentPattern(ValuePattern.Pattern);
                string ret = ValuePatternHelper.GetValue(control);
                return ret ?? NativeTextProds.GetTextNative(controlHandle);
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
        /// Gets the text currently contained in a text area
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// Text contained in text area
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static string GetText(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return ValueBridge.GetTextBridge(null, control);
        }

        /// <summary>
        /// Set text area value
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <param name="newText">Desired text</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void SetText(IntPtr controlHandle, string newText)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }

            try
            {
                ValuePatternHelper.SetValue(AutomationElement.FromHandle(controlHandle), newText);
            }
            catch (InvalidOperationException)
            {
                NativeTextProds.SetTextNative(controlHandle, newText);
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
        /// Set text area value
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="newText">Desired text</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void SetText(ProdWindow prodwindow, string automationId, string newText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            ValueBridge.AppendTextBridge(null, control, newText);
        }

        /// <summary>
        /// Appends text to a .Net text input control
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <param name="newText">Text To Append</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void AppendText(IntPtr controlHandle, string newText)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }

            try
            {
            NativeTextProds.AppendTextNative(controlHandle, newText);
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
        /// Appends text to a .Net text input control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="newText">Text To Append</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void AppendText(ProdWindow prodwindow, string automationId, string newText)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            ValueBridge.AppendTextBridge(null, control, newText);
        }

        /// <summary>
        /// Inserts the supplied string into the existing textBox text
        /// </summary>
        /// <param name="controlHandle">The control to be worked with</param>
        /// <param name="newText">Text to append to TextBox value</param>
        /// <param name="insertIndex">Zero based index of string to insert text into</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void InsertText(IntPtr controlHandle, string newText, int insertIndex)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }

            try
            {
            NativeTextProds.InsertTextNative(controlHandle, newText, insertIndex);
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
        /// Inserts the supplied string into the existing textBox text
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="newText">Text to append to TextBox value</param>
        /// <param name="insertIndex">Zero based index of string to insert text into</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        public static void InsertText(ProdWindow prodwindow, string automationId, string newText, int insertIndex)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            ValueBridge.InsertTextBridge(null, control, newText, insertIndex);
        }
    }
}