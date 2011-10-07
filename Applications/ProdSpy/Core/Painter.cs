// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdSpy.Properties;

namespace ProdSpy.Core
{
    /// <summary>
    /// Handles drawing various graphics on a target application
    /// </summary>
    internal static class Painter
    {
        private static AutomationElement _oldel;
        private static IntPtr _parentHandle;

        /// <summary>
        /// Paints and invalidates target rectangle upon mouse focus
        /// </summary>
        /// <param name="focusedElement">The focused element.</param>
        /// <param name="parentHandle">The parent handle.</param>
        public static void PaintTarget(AutomationElement focusedElement, IntPtr parentHandle)
        {
            _parentHandle = parentHandle;

            if (_oldel != null)
            {
                bool tst = _oldel.GetHashCode() == focusedElement.GetHashCode();
                if (tst)
                {
                    return;
                }
            }

            if (_oldel == null)
            {
                _oldel = focusedElement;
            }
            /* without this thread, the mouse up event wouldn't register for wpf forms */
            Thread paint = new Thread(PaintTargetBox);
            paint.Start(focusedElement);

            _oldel = focusedElement;
        }

        /// <summary>
        /// Paints the target box with a ContainerGrabHandle icon.
        /// </summary>
        /// <param name="focusedElement">The focused element.</param>
        private static void PaintTargetBox(object focusedElement)
        {
            AutomationElement focus = (AutomationElement)focusedElement;
            Graphics test = Graphics.FromHwnd(_parentHandle);
            Rectangle r = new Rectangle();

            /* Set up to convert coordinates */
            NativeMethods.POINT p = new NativeMethods.POINT((int)focus.Current.BoundingRectangle.X, (int)focus.Current.BoundingRectangle.Y);
            NativeMethods.ScreenToClient(_parentHandle, ref p);

            /* now create something for the managed code */
            r.X = p.X;
            r.Y = p.Y;
            r.Width = (int)focus.Current.BoundingRectangle.Width;
            r.Height = (int)focus.Current.BoundingRectangle.Height;

            /* Clear the old stuff */
            NativeMethods.InvalidateRect(_parentHandle, IntPtr.Zero, false);
            NativeMethods.UpdateWindow(_parentHandle);

            ControlPaint.DrawContainerGrabHandle(test, r);

            _oldel = focus;
        }

        /// <summary>
        /// Draws a red rectangle around the element that currently has focus
        /// </summary>
        /// <param name="focusedElement">The focused element.</param>
        /// <param name="parentHandle">The parent handle.</param>
        public static void HighlightFocus(AutomationElement focusedElement, IntPtr parentHandle)
        {
            Graphics test = Graphics.FromHwnd(parentHandle);
            Rectangle r = new Rectangle();

            /* Set up to convert coordinates */
            NativeMethods.POINT p = new NativeMethods.POINT((int)focusedElement.Current.BoundingRectangle.X, (int)focusedElement.Current.BoundingRectangle.Y);
            NativeMethods.ScreenToClient(parentHandle, ref p);

            /* rectangle from the bounding rectangle */
            r.X = p.X;
            r.Y = p.Y;
            r.Width = (int)focusedElement.Current.BoundingRectangle.Width;
            r.Height = (int)focusedElement.Current.BoundingRectangle.Height;

            /* Clear the old stuff */
            NativeMethods.InvalidateRect(parentHandle, IntPtr.Zero, false);
            NativeMethods.UpdateWindow(parentHandle);

            Pen highlightPen = new Pen(Settings.Default.HighlightColor, 3);
            test.DrawRectangle(highlightPen, r);
        }

        /// <summary>
        /// Determines if are we in capture mode
        /// </summary>
        /// <param name="isMouseDown">If mouse is down (capture mode) or not</param>
        public static void SetState(bool isMouseDown)
        {
            if (isMouseDown)
            {
                Cursor.Current = Cursors.SizeAll;
                return;
            }
            Cursor.Current = Cursors.Arrow;
            NativeMethods.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
        }
    }
}