﻿/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.ComponentModel;
using ProdUI.Exceptions;
using ProdUI.Session;
using ProdUI.Utility;

namespace ProdUI.Controls.Native
{
    internal sealed class ProdRadioButtonNative
    {
        /// <summary>
        ///   Gets the check state of the RadioButton.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <returns>true if selected, false otherwise</returns>
        internal static bool GetCheckStateNative(IntPtr windowHandle)
        {
            try
            {
                int retVal = (int) NativeMethods.SendMessage(windowHandle, (int) ButtonMessage.BMGetcheck, 0, 0);

                const string logmessage = "GetCheckStateNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);


                return retVal == (int) ButtonStates.BstChecked;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Sets the check state of the RadioButton
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        internal static void SetCheckStateNative(IntPtr windowHandle)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) ButtonMessage.BMSetcheck, (int) ButtonStates.BstChecked, 0);

                if (!GetCheckStateNative(windowHandle))
                {
                    /* fail */
                    throw new ProdOperationException("Native call fail");
                }

                const string logmessage = "SetCheckStateNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}