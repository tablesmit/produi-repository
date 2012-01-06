// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;
using ProdUI.Verification;

namespace ProdUI.Bridge.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the ValuePattern control pattern. implements IValueProvider
    /// </summary>
    internal static class ValuePatternHelper
    {
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

            ValueVerifier<string, string>.Verify(text, GetValue(control));
        }

        /// <summary>
        /// Gets a value that specifies whether the value of a UI Automation element is read-only.
        /// </summary>
        /// <param name="control">The UI Automation element.</param>
        /// <returns>true if the value is read-only; false if it can be modified.</returns>
        internal static bool GetIsReadOnly(AutomationElement control)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            return pattern.Current.IsReadOnly;
        }


        /* These are for text based controls */
        /// <summary>
        /// Appends the supplied string to the existing textBox text
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <param name="text">Text to append to TextBox value</param>
        internal static void AppendValue(AutomationElement control, string text)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            string originalText = pattern.Current.Value;
            string appText = originalText + text;
            pattern.SetValue(appText);

            ValueVerifier<string, string>.Verify(appText, pattern.Current.Value);
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
            if (baseText == null) return;
            string insString = baseText.Insert(index, text);
            pattern.SetValue(insString);
            //TODO: Find an insert text verification
        }

    }
}