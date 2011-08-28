/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Used for controls that support the InvokePattern pattern. implements IInvokeProvider
    /// </summary>
    internal static class InvokePatternHelper
    {
        /// <summary>
        ///   Ensures the window pattern is supported, then invokes
        /// </summary>
        /// <param name = "control">The UI Automation element to invoke</param>
        /// <returns>
        ///   0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static int Invoke(AutomationElement control)
        {
            try
            {
                InvokePattern pat = (InvokePattern)CommonPatternHelpers.CheckPatternSupport(InvokePattern.Pattern, control);
                if (pat == null)
                {
                    return -1;
                }

                pat.Invoke();
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return -1;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            return 0;
        }
    }
}