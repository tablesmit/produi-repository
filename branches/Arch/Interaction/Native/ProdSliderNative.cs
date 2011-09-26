// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    /// Sends TrackBar Messages
    /// </summary>
    internal sealed class ProdSliderNative
    {
        internal static void SetValueNative(IntPtr windowHandle, double value)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)TrackBarMessages.TBMSETPOS, 1, (int)value);
            ValueVerifier<double, double>.Verify(value, GetValueNative(windowHandle));
        }

        internal static double GetValueNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (double)NativeMethods.SendMessage(windowHandle, (int)TrackBarMessages.TBMGETPOS, 0, 0);
        }

        internal static double GetMinimumNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (double)NativeMethods.SendMessage(windowHandle, (int)TrackBarMessages.TBMGETRANGEMIN, 0, 0);
        }

        internal static double GetMaximumNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (double)NativeMethods.SendMessage(windowHandle, (int)TrackBarMessages.TBMGETRANGEMAX, 0, 0);
        }

        internal static IntPtr GetLargeChangeNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return NativeMethods.SendMessage(windowHandle, (int)TrackBarMessages.TBMGETPAGESIZE, 0, 0);
        }

        internal static IntPtr GetSmallChangeNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return NativeMethods.SendMessage(windowHandle, (int)TrackBarMessages.TBMGETLINESIZE, 0, 0);
        }
    }
}