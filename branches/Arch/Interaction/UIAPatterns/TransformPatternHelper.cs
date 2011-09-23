// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Used for controls that support the TransformPattern control pattern. implements ITransformProvider
    /// </summary>
    internal static class TransformPatternHelper
    {
        /// <summary>
        ///     Determines whether this instance can be moved
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     Whether the control can be moved, null if InvalidOperationException is raised
        /// </returns>
        internal static bool? CanMove(AutomationElement control)
        {
            TransformPattern pat = (TransformPattern) CommonUIAPatternHelpers.CheckPatternSupport(TransformPattern.Pattern, control);
            return pat.Current.CanMove;
        }

        /// <summary>
        ///     Determines whether this instance can be resized
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>
        ///     Whether the control can be resized, null if InvalidOperationException is raised
        /// </returns>
        internal static bool? CanResize(AutomationElement control)
        {
            TransformPattern pat = (TransformPattern) CommonUIAPatternHelpers.CheckPatternSupport(TransformPattern.Pattern, control);
            return pat.Current.CanResize;
        }

        /// <summary>
        ///     Determines whether this instance can rotate
        /// </summary>
        /// <param name = "control">The UI Automation element.</param>
        /// <returns>
        ///     Whether control can be rotated, null if InvalidOperationException is raised
        /// </returns>
        internal static bool? CanRotate(AutomationElement control)
        {
            TransformPattern pat = (TransformPattern) CommonUIAPatternHelpers.CheckPatternSupport(TransformPattern.Pattern, control);
            return pat.Current.CanRotate;
        }

        /// <summary>
        ///     Moves the control to the specified location.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "x">The top left corner</param>
        /// <param name = "y">The right</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        internal static int Move(AutomationElement control, double x, double y)
        {
            TransformPattern pat = (TransformPattern) CommonUIAPatternHelpers.CheckPatternSupport(TransformPattern.Pattern, control);
            if (pat.Current.CanMove)
            {
                pat.Move(x, y);
                return 0;
            }
            return -1;
        }

        /// <summary>
        ///     Resizes the control.
        /// </summary>
        /// <param name = "control">The control to resize</param>
        /// <param name = "width">desired width in pixels</param>
        /// <param name = "height">the desired height in pixels</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        internal static int Resize(AutomationElement control, double width, double height)
        {
            TransformPattern pat = (TransformPattern) CommonUIAPatternHelpers.CheckPatternSupport(TransformPattern.Pattern, control);
            if (pat.Current.CanResize)
            {
                pat.Resize(width, height);
                return 0;
            }
            return -1;
        }

        /// <summary>
        ///     Rotates the specified control.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <param name = "degrees">The degrees to rotate. use a negative number to rotate counter-clockwise</param>
        /// <returns>
        ///     0 if no problems encountered, -1 if InvalidOperationException is raised
        /// </returns>
        internal static int Rotate(AutomationElement control, double degrees)
        {
            TransformPattern pat = (TransformPattern) CommonUIAPatternHelpers.CheckPatternSupport(TransformPattern.Pattern, control);
            if (pat.Current.CanRotate)
            {
                pat.Rotate(degrees);
                return 0;
            }
            return -1;
        }
    }
}