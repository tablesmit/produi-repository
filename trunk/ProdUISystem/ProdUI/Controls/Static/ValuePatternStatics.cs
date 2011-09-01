/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Controls.Native;
using ProdUI.Exceptions;
using ProdUI.Utility;

namespace ProdUI.Controls
{
    public static partial class Prod
    {
        /// <summary>
        /// Gets the ReadOnly status of the Textbox
        /// </summary>
        /// <param name="controlHandle">Handle to the  control</param>
        /// <returns>
        /// <c>true</c> if control is ReadOnly, <c>false</c> otherwise
        /// </returns>
        /// <remarks>
        /// This overload is invalid for WPF controls
        /// </remarks>
        public static bool GetReadOnly(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = AutomationElement.FromHandle(controlHandle);
                return CommonPatternHelpers.ReadOnly(control);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException("Control doesn't support ValuePattern", err);
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
        public static bool GetReadOnly(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            return CommonPatternHelpers.ReadOnly(control);
        }

        /// <summary>
        /// Set text area value to an empty string
        /// </summary>
        /// <param name="controlHandle">Handle to the target control</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static void ClearText(IntPtr controlHandle)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            int ret = ValuePatternHelper.SetValue(AutomationElement.FromHandle(controlHandle), string.Empty);

            if (ret == -1)
            {
                NativeTextProds.ClearTextNative(controlHandle);
            }
        }

        /// <summary>
        /// Set text area value to an empty string
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        public static void ClearText(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (GetReadOnly(prodwindow, automationId))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }

            if (ValuePatternHelper.SetValue(control, string.Empty) == -1)
            {
                ValuePatternHelper.SendKeysSetText(control, string.Empty);
            }
        }

        /// <summary>
        /// Gets the text currently contained in a text area
        /// </summary>
        /// <param name="controlHandle">Handle to the target control</param>
        /// <returns>
        /// Text contained in text area
        /// </returns>
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
                throw new ProdOperationException("Control doesn't support ValuePattern", err);
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
        public static string GetText(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            string ret = ValuePatternHelper.GetValue(control);
            return ret;
        }

        /// <summary>
        /// Set text area value
        /// </summary>
        /// <param name="controlHandle">Handle to the target control</param>
        /// <param name="newText">Desired text</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static void SetText(IntPtr controlHandle, string newText)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            int ret = ValuePatternHelper.SetValue(AutomationElement.FromHandle(controlHandle), newText);

            if (ret != -1)
            {
                return;
            }

            if (NativeTextProds.SetTextNative(controlHandle, newText))
            {
                return;
            }

            ValuePatternHelper.SendKeysSetText(AutomationElement.FromHandle(controlHandle), newText);
        }

        /// <summary>
        /// Set text area value
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="newText">Desired text</param>
        public static void SetText(ProdWindow prodwindow, string automationId, string newText)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (GetReadOnly(prodwindow, automationId))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            if (ValuePatternHelper.SetValue(control, newText) == -1)
                ValuePatternHelper.SendKeysSetText(control, newText);
        }

        /// <summary>
        /// Appends text to a .Net text input control
        /// </summary>
        /// <param name="controlHandle">Handle to the target control</param>
        /// <param name="newText">Text To Append</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static void AppendText(IntPtr controlHandle, string newText)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            if (ValuePatternHelper.AppendValue(AutomationElement.FromHandle(controlHandle), newText) == 0)
            {
                return;
            }

            if (NativeTextProds.AppendTextNative(controlHandle, newText))
            {
                return;
            }

            ValuePatternHelper.SendKeysAppendText(AutomationElement.FromHandle(controlHandle), newText);
        }

        /// <summary>
        /// Appends text to a .Net text input control
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="newText">Text To Append</param>
        public static void AppendText(ProdWindow prodwindow, string automationId, string newText)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (GetReadOnly(prodwindow, automationId))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            if (ValuePatternHelper.AppendValue(control, newText) == 0)
            {
                return;
            }

            if (control.Current.NativeWindowHandle != 0)
            {
                if (NativeTextProds.AppendTextNative((IntPtr)control.Current.NativeWindowHandle, newText))
                {
                    return;
                }

            }
            ValuePatternHelper.SendKeysAppendText(control, newText);
        }

        /// <summary>
        /// Inserts the supplied string into the existing textBox text
        /// </summary>
        /// <param name="controlHandle">The control to be worked with</param>
        /// <param name="newText">Text to append to TextBox value</param>
        /// <param name="insertIndex">Zero based index of string to insert text into</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static void InsertText(IntPtr controlHandle, string newText, int insertIndex)
        {
            if (GetReadOnly(controlHandle))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            if (ValuePatternHelper.InsertValue(AutomationElement.FromHandle(controlHandle), newText, insertIndex) == 0)
            {
                return;
            }


            NativeTextProds.InsertTextNative(controlHandle, newText, insertIndex);
        }

        /// <summary>
        /// Inserts the supplied string into the existing textBox text
        /// </summary>
        /// <param name="prodwindow">The containing prodwindow.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="newText">Text to append to TextBox value</param>
        /// <param name="insertIndex">Zero based index of string to insert text into</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public static void InsertText(ProdWindow prodwindow, string automationId, string newText, int insertIndex)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            if (GetReadOnly(prodwindow, automationId))
            {
                throw new ProdOperationException("TextBox is Read Only");
            }


            if (ValuePatternHelper.InsertValue(control, newText, insertIndex) == 0)
            {
                return;
            }


            throw new ProdOperationException("Unable to InsertText");
        }
    }
}