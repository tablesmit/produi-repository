/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdUI.Exceptions;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Used for controls that support the ValuePattern control pattern. implements IValueProvider
    /// </summary>
    internal static class ValuePatternHelper
    {

        #region IValueProvider Implementation

        /// <summary>
        /// Gets the current string value in the supplied TextBox
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// String value in TextBox, or <c>null</c> if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static string GetValue(AutomationElement control)
        {
            try
            {
                ValuePattern pat = (ValuePattern)CommonPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                if (pat == null)
                {
                    return null;
                }
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
        /// Sets the TextBox value to the supplied value, overwriting any existing text
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="newText">Text to set Textbox value to</param>
        /// <returns>
        /// 0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int SetValue(AutomationElement control, string newText)
        {
            try
            {
                ValuePattern pat = (ValuePattern)CommonPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                pat.SetValue(newText);

                return VerifyText(control, newText);
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        #region Custom Functions

        /// <summary>
        /// Appends the supplied string to the existing textBox text
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="newText">Text to append to TextBox value</param>
        /// <returns>
        /// 0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int AppendValue(AutomationElement control, string newText)
        {
            try
            {
                ValuePattern pat = (ValuePattern)CommonPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);

                string appText = pat.Current.Value + newText;
                pat.SetValue(appText);

                return VerifyText(control, appText);
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Inserts supplied text into existing string beginning at the specified index
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="newText">Text to insert into to TextBox value</param>
        /// <param name="index">Index into string where to begin insertion</param>
        /// <returns>
        /// 0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int InsertValue(AutomationElement control, string newText, int index)
        {
            try
            {
                ValuePattern pat = (ValuePattern)CommonPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                string baseText = pat.Current.Value;

                /* If index is out of range, defer to ProdErrorManager */
                if (baseText != null)
                {
                    baseText.Insert(index, newText);
                }


                /* Time to verify */
                return VerifyText(control, baseText + newText);
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Verifies that supplied text matches what is currently in the control
        /// </summary>
        /// <param name="control">control to verify</param>
        /// <param name="text">the text to verify</param>
        /// <returns>
        ///   <c>true</c> if text matches, <c>null</c> if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdVerificationException">Thrown if element value does not match</exception>
        ///   
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int VerifyText(AutomationElement control, string text)
        {
            try
            {
                ValuePattern pat = (ValuePattern)CommonPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
                string currentText = pat.Current.Value;

                if (String.Compare(text, currentText, StringComparison.Ordinal) == 0)
                    return 0;
                throw new ProdVerificationException(control);
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        /// <summary>
        /// Uses SendKeys to set the text (clobbering).
        /// </summary>
        /// <param name="control">The control to set.</param>
        /// <param name="text">The text to place in the control.</param>
        internal static void SendKeysSetText(AutomationElement control, string text)
        {
            control.SetFocus();
            Thread.Sleep(100);
            SendKeys.SendWait("^{HOME}");
            SendKeys.SendWait("^+{END}");
            SendKeys.SendWait("{DEL}");
            SendKeys.SendWait(text);
        }

        /// <summary>
        /// Uses SendKeys to append text.
        /// </summary>
        /// <param name="control">The control to set.</param>
        /// <param name="text">The text to append.</param>
        internal static void SendKeysAppendText(AutomationElement control, string text)
        {
            control.SetFocus();
            Thread.Sleep(100);
            SendKeys.SendWait("^{END}");
            SendKeys.SendWait(text);
        }
    }
}