// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdUI.Exceptions;
using ProdUI.Interaction.Base;
using ProdUI.Interaction.UIAPatterns;

namespace ProdUI.Interaction.Bridge
{
    internal static class ValueBridge
    {
        #region IValueProvider Implementation

        /// <summary>
        ///     Gets the current string value in the supplied TextBox
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     String value in TextBox, or <c>null</c> if InvalidOperationException is raised
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static string GetValueBridge(this ISingleSelectList theInterface, AutomationElement control)
        {
            try
            {
                ValuePattern pat = (ValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                return pat.Current.Value;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Sets the TextBox value to the supplied value, overwriting any existing text
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "newText">Text to set Textbox value to</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int SetValueBridge(this ISingleSelectList theInterface, AutomationElement control, string newText)
        {
            try
            {
                ValuePattern pat = (ValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                pat.SetValue(newText);

                return ValuePatternHelper.VerifyText(control, newText); //Note: Verify text
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        #region Custom Functions

        /// <summary>
        ///     Appends the supplied string to the existing textBox text
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "newText">Text to append to TextBox value</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int AppendValueBridge(this ISingleSelectList theInterface, AutomationElement control, string newText)
        {
            try
            {
                ValuePattern pat = (ValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);

                string appText = pat.Current.Value + newText;
                pat.SetValue(appText);

                return ValuePatternHelper.VerifyText(control, appText); //Note: Verify text
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Inserts supplied text into existing string beginning at the specified index
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "newText">Text to insert into to TextBox value</param>
        /// <param name = "index">Index into string where to begin insertion</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int InsertValueBridge(this ISingleSelectList theInterface, AutomationElement control, string newText, int index)
        {
            try
            {
                ValuePattern pat = (ValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                string baseText = pat.Current.Value;

                /* If index is out of range, defer to ProdErrorManager */
                if (baseText != null)
                {
                    string insString = baseText.Insert(index, newText);
                    ValuePatternHelper.SetValue(control, insString);
                }

                /* Time to verify */
                return ValuePatternHelper.VerifyText(control, ValuePatternHelper.GetValue(control));
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Verifies that supplied text matches what is currently in the control
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">control to verify</param>
        /// <param name = "text">the text to verify</param>
        /// <returns>
        ///     <c>true</c> if text matches, <c>null</c> if InvalidOperationException is raised
        /// </returns>
        /// <exception cref = "ProdVerificationException">Thrown if element value does not match</exception>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int VerifyTextBridge(this ISingleSelectList theInterface, AutomationElement control, string text)
        {
            try
            {
                ValuePattern pat = (ValuePattern) CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                string currentText = pat.Current.Value;

                if (text.Length == 0 || currentText.Length == 0)
                {
                    return 0;
                }
                if (String.Compare(text, currentText, StringComparison.Ordinal) == 0)
                    return 0;
                throw new ProdVerificationException(control);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        /// <summary>
        ///     Uses SendKeys to set the text (clobbering).
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control to set.</param>
        /// <param name = "text">The text to place in the control.</param>
        internal static void SendKeysSetTextBridge(this ISingleSelectList theInterface, AutomationElement control, string text)
        {
            control.SetFocus();
            Thread.Sleep(100);
            SendKeys.SendWait("^{HOME}");
            SendKeys.SendWait("^+{END}");
            SendKeys.SendWait("{DEL}");
            SendKeys.SendWait(text);
        }

        /// <summary>
        ///     Uses SendKeys to append text.
        /// </summary>
        /// <param name = "theInterface">The interface.</param>
        /// <param name = "control">The control to set.</param>
        /// <param name = "text">The text to append.</param>
        internal static void SendKeysAppendTextBridge(this ISingleSelectList theInterface, AutomationElement control, string text)
        {
            control.SetFocus();
            Thread.Sleep(100);
            SendKeys.SendWait("^{END}");
            SendKeys.SendWait(text);
        }
    }
}