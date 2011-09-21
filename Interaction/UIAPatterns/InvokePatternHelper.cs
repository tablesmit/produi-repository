// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the InvokePattern pattern. implements IInvokeProvider
    /// </summary>
    internal static class InvokePatternHelper
    {
        /// <summary>
        /// Ensures the window pattern is supported, then invokes
        /// </summary>
        /// <param name="control">The UI Automation element to invoke</param>
        internal static void Invoke(AutomationElement element)
        {
                InvokePattern pattern = (InvokePattern)CommonUIAPatternHelpers.CheckPatternSupport(InvokePattern.Pattern, element);
                pattern.Invoke();
        }
    }
}