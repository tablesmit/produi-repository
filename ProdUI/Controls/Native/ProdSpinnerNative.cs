﻿/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.ComponentModel;
using ProdUI.Enums;
using ProdUI.Exceptions;
using ProdUI.Session;
using ProdUI.Utility;

namespace ProdUI.Controls.Native
{
    internal sealed class ProdSpinnerNative
    {
        internal static void SetValueNative(IntPtr windowHandle, double value)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UdmSetpoS32, 0, (int) value);

                const string logmessage = "SetValueNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        internal static double GetValueNative(IntPtr windowHandle)
        {
            try
            {
                double retVal = (double) NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UdmGetpoS32, 0, 0);

                const string logmessage = "GetValueNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return retVal;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        internal static double GetMinimumNative(IntPtr windowHandle)
        {
            int min = 0;
            int max = 0;

            try
            {
                NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UdmGetrangE32, min, max);

                const string logmessage = "GetMinimumNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return min;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        internal static double GetMaximumNative(IntPtr windowHandle)
        {
            int min = 0;
            int max = 0;

            try
            {
                NativeMethods.SendMessage(windowHandle, (int) SpinnerMessages.UdmGetrangE32, min, max);

                const string logmessage = "GetMaximumNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return max;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}