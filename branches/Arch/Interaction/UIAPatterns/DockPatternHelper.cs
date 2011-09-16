/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    /// Used for controls that support the DockPattern control pattern. implements IDockProvider
    /// </summary>
    internal static class DockPatternHelper
    {

        #region DockProvider Implementations

        /// <summary>
        /// Gets the current DockPosition of the control within a docking container.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        ///   <see cref="DockPosition"/>
        /// </returns>
        internal static DockPosition GetDockPosition(AutomationElement control)
        {
            try
            {
                DockPattern pat = (DockPattern)CommonUIAPatternHelpers.CheckPatternSupport(DockPattern.Pattern, control);
                return pat.Current.DockPosition;
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
        /// Docks the control within a docking container.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element.</param>
        /// <param name="dockPosition">The <see cref="DockPosition"/>.</param>
        internal static void SetDockPosition(AutomationElement control, DockPosition dockPosition)
        {
            try
            {
                DockPattern pat = (DockPattern)CommonUIAPatternHelpers.CheckPatternSupport(DockPattern.Pattern, control);
                pat.SetDockPosition(dockPosition);
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