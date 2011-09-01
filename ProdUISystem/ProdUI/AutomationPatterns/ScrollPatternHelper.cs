/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Used for controls that support the ScrollPattern and ScrollItemPattern control patterns. implements IScrollProvider,IScrollItemProvider
    /// </summary>
    internal static class ScrollPatternHelper
    {
        #region ScrollItemPattern Implementation

        /// <summary>
        /// Gets the horizontal scroll percent.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        /// The horizontal scroll position as a percentage of the total content area within the control
        /// </returns>
        internal static double GetHorizontalScrollPercent(AutomationElement control)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                return pat.Current.HorizontalScrollPercent;
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
        /// Gets the current horizontal view size.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        /// The horizontal size of the viewable region as a percentage of the total content area within the control
        /// </returns>
        internal static double GetHorizontalViewSize(AutomationElement control)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                return pat.Current.HorizontalViewSize;
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
        /// Gets a value that indicates whether the control can scroll horizontally.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element.</param>
        /// <returns>
        /// <c>true</c> if the control can scroll horizontally; otherwise <c>false</c>
        /// </returns>
        internal static bool GetHorizontallyScrollable(AutomationElement control)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                return pat.Current.HorizontallyScrollable;
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
        /// Scrolls the visible region of the content area horizontally and vertically
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element.</param>
        /// <param name="horizontalAmount">The horizontal increment specific to the control. NoScroll (-1) should be passed in if the control cannot be scrolled in this direction</param>
        /// <param name="verticalAmount">The vertical increment specific to the control. NoScroll (-1) should be passed in if the control cannot be scrolled in this direction</param>
        internal static void Scroll(AutomationElement control, ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                pat.Scroll(horizontalAmount, verticalAmount);
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
        /// Sets the horizontal and vertical scroll position as a percentage of the total content area within the control.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element</param>
        /// <param name="horizontalPercent">The horizontal position as a percentage of the content area's total range.NoScroll (-1) should be passed in if the control cannot be scrolled in this direction</param>
        /// <param name="verticalPercent">The vertical position as a percentage of the content area's total range.NoScroll (-1) should be passed in if the control cannot be scrolled in this direction</param>
        internal static void SetScrollPercent(AutomationElement control, double horizontalPercent, double verticalPercent)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                if (pat == null)
                pat.SetScrollPercent(horizontalPercent, verticalPercent);
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
        /// Gets the current vertical scroll position.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        /// The vertical scroll position as a percentage of the total content area within the control
        /// </returns>
        internal static double GetVerticalScrollPercent(AutomationElement control)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                return pat.Current.VerticalScrollPercent;
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
        /// Gets the vertical view size
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        /// The vertical size of the viewable region as a percentage of the total content area within the control
        /// </returns>
        internal static double GetVerticalViewSize(AutomationElement control)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                return pat.Current.VerticalViewSize;
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
        /// Gets a value that indicates whether the control can scroll vertically
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element</param>
        /// <returns>
        /// true if the control can scroll vertically; otherwise false
        /// </returns>
        internal static bool GetVerticallyScrollable(AutomationElement control)
        {
            try
            {
                ScrollPattern pat = (ScrollPattern)CommonPatternHelpers.CheckPatternSupport(ScrollPattern.Pattern, control);
                return pat.Current.VerticallyScrollable;
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

        #region IScrollItemProvider Implentation

        /// <summary>
        /// Scrolls the content area of a container object in order to display the control within the visible region (viewport) of the container.
        /// </summary>
        /// <param name="control">The UI Automation identifier (ID) for the element</param>
        /// <remarks>
        /// This method does not provide the ability to specify the position of the control within the visible region (viewport) of the container
        /// </remarks>
        internal static void ScrollIntoView(AutomationElement control)
        {
            try
            {
                ScrollItemPattern pat = (ScrollItemPattern)CommonPatternHelpers.CheckPatternSupport(ScrollItemPattern.Pattern, control);
                pat.ScrollIntoView();
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