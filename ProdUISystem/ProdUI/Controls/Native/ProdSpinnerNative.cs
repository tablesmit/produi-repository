// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Controls.Native
{
    internal sealed class ProdSpinnerNative
    {
        /// <summary>
        /// Sets the value of the slider.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="value">The desired value.</param>
        internal static void SetValueNative(IntPtr windowHandle, double value)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)SpinnerMessages.UDMSETPOS32, 0, (int)value);
            ValueVerifier<double, double>.Verify(value, GetValueNative(windowHandle));
        }

        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>The current value</returns>
        internal static double GetValueNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (double)NativeMethods.SendMessage(windowHandle, (int)SpinnerMessages.UDMGETPOS32, 0, 0);
        }

        /// <summary>
        /// Gets the maximum value the control can have.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>The minimum value the control can have.</returns>
        internal static double GetMinimumNative(IntPtr windowHandle)
        {
            int min = 0;
            int max = 0;

            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)SpinnerMessages.UDMGETRANGE32, min, max);

            return min;
        }

        /// <summary>
        /// Gets the maximum native.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>The maximum value the control can have.</returns>
        internal static double GetMaximumNative(IntPtr windowHandle)
        {
            int min = 0;
            int max = 0;

            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)SpinnerMessages.UDMGETRANGE32, min, max);

            return max;
        }
    }
}