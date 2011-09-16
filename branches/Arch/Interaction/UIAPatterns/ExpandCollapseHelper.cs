/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the ExpandCollapseHelper control pattern. implements IExpandCollapseProvider
    /// </summary>
    internal static class ExpandCollapseHelper
    {
        #region IExpandCollapsePattern Implementation

        /// <summary>
        /// Collapses the specified control.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// 0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdOperationException">The exception that is thrown when a control handle is not valid</exception>
        internal static int Collapse(AutomationElement control)
        {
            try
            {
                ExpandCollapsePattern pat = (ExpandCollapsePattern)CommonUIAPatternHelpers.CheckPatternSupport(ExpandCollapsePattern.Pattern, control);
                pat.Collapse();
                return 0;
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
        /// Expands the specified control.
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        /// 0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static int Expand(AutomationElement control)
        {
            try
            {
                ExpandCollapsePattern pat = (ExpandCollapsePattern)CommonUIAPatternHelpers.CheckPatternSupport(ExpandCollapsePattern.Pattern, control);
                pat.Expand();
                return 0;
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
        /// Gets the current ExpandCollapseState of the supplied element
        /// </summary>
        /// <param name="control">The UI Automation element</param>
        /// <returns>
        ///   <see cref="ExpandCollapseState"/>
        /// </returns>
        internal static ExpandCollapseState ExpandCollapseState(AutomationElement control)
        {
            try
            {
                return (ExpandCollapseState)control.GetCurrentPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty);
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
    }
}