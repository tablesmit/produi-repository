// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Logging;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdSpinnerNative
    {
        internal static void SetValueNative(IntPtr windowHandle, double value)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UDMSETPOS32, 0, (int) value);
        }

        internal static double GetValueNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (double) NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UDMGETPOS32, 0, 0);
        }

        internal static double GetMinimumNative(IntPtr windowHandle)
        {
            int min = 0;
            int max = 0;

            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UDMGETRANGE32, min, max);

            return min;
        }

        internal static double GetMaximumNative(IntPtr windowHandle)
        {
            int min = 0;
            int max = 0;

            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UDMGETRANGE32, min, max);

            return max;
        }
    }
}