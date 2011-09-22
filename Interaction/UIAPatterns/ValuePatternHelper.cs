// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the ValuePattern control pattern. implements IValueProvider
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
        internal static string GetValue(AutomationElement control)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            return pattern.Current.Value;
        }

        /// <summary>
        /// Sets the TextBox value to the supplied value, overwriting any existing text
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">Text to set Textbox value to</param>
        internal static void SetValue(AutomationElement control, string text)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            pattern.SetValue(text);

            VerifyText(control, text);
        }

        #endregion


        /// <summary>
        /// Appends the supplied string to the existing textBox text
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">Text to append to TextBox value</param>
        internal static void AppendValue(AutomationElement control, string text)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);

            string appText = pattern.Current.Value + text;
            pattern.SetValue(appText);

            VerifyText(control, appText);
        }

        /// <summary>
        /// Inserts supplied text into existing string beginning at the specified index
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">Text to insert into to TextBox value</param>
        /// <param name="index">Index into string where to begin insertion</param>
        internal static void InsertValue(AutomationElement control, string text, int index)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            string baseText = pattern.Current.Value;

            /* If index is out of range, defer to ProdErrorManager */
            if (baseText != null)
            {
                string insString = baseText.Insert(index, text);
                SetValue(control, insString);
            }

            /* Time to verify */
            VerifyText(control, GetValue(control));
        }

        /// <summary>
        /// Verifies that supplied text matches what is currently in the control
        /// </summary>
        /// <param name="control">control to verify</param>
        /// <param name="text">the text to verify</param>
        /// <returns>
        /// 0 if match, anything else otherwise
        /// </returns>
        private static int VerifyText(AutomationElement control, string text)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            string currentText = pattern.Current.Value;

            if (text.Length == 0 || currentText.Length == 0)
            {
                return 0;
            }
            return String.Compare(text, currentText, StringComparison.Ordinal);
        }
    }
}