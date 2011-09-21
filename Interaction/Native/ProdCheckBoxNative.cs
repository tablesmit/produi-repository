﻿// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.ComponentModel;
using System.Windows.Automation;
using ProdUI.Configuration;
using ProdUI.Exceptions;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///     Methods to work with Checkbox controls using the UI Automation framework
    /// </summary>
    internal sealed class ProdCheckBoxNative
    {
        /// <summary>
        ///     Uses SendMessage to check the state
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to the checkbox</param>
        /// <returns>
        ///     one of the <see cref = "System.Windows.Automation.ToggleState" />ToggleStates
        /// </returns>
        internal static ToggleState GetCheckStateNative(IntPtr windowHandle)
        {
            try
            {
                /* get valid ButtonCheckStates */
                int bcs = (int) NativeMethods.SendMessage(windowHandle, (int) ButtonMessage.BMGETCHECK, 0, 0);

                string logmessage = "Retrieved CheckBox state using SendMessage: " + ConvertButtonStates(bcs);

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return ConvertButtonStates(bcs);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Uses SendMessage to post the state
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to the checkbox</param>
        /// <param name = "isChecked">one of the <see cref = "System.Windows.Automation.ToggleState" />ToggleStates</param>
        internal static void SetCheckStateNative(IntPtr windowHandle, ToggleState isChecked)
        {
            ButtonStates bst = ConvertToggleStates(isChecked);

            try
            {
                /* send the message */
                NativeMethods.SendMessage(windowHandle, (int) ButtonMessage.BMSETSTATE, (int) bst, 0);

                /* Verify it */
                if (GetCheckStateNative(windowHandle) == isChecked)
                {
                    string logmessage = "CheckBox state set using SendMessage: " + isChecked;

                    if (ProdStaticSession._Configuration != null)
                        ProdStaticSession.Log(logmessage);
                    return;
                }
                return;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Converts Automation ToggleStates to Win32 BST
        /// </summary>
        /// <param name = "isChecked"><see cref = "System.Windows.Automation.ToggleState" /></param>
        /// <returns><see cref = "ButtonStates" /></returns>
        internal static ButtonStates ConvertToggleStates(ToggleState isChecked)
        {
            ButtonStates bst;

            /* Convert to button state */
            switch (isChecked)
            {
                case ToggleState.Indeterminate:
                    bst = ButtonStates.BSTINDETERMINATE;
                    break;
                case ToggleState.Off:
                    bst = ButtonStates.BSTUNCHECKED;
                    break;
                case ToggleState.On:
                    bst = ButtonStates.BSTCHECKED;
                    break;
                default:
                    bst = ButtonStates.BSTINDETERMINATE;
                    break;
            }
            return bst;
        }

        /// <summary>
        ///     Converts Win32 BST_ to Automation ToggleStates
        /// </summary>
        /// <param name = "bcs"><see cref = "ButtonStates" /></param>
        /// <returns><see cref = "System.Windows.Automation.ToggleState" /></returns>
        internal static ToggleState ConvertButtonStates(int bcs)
        {
            switch (bcs)
            {
                case (int) ButtonStates.BSTUNCHECKED:
                    return ToggleState.Off;
                case (int) ButtonStates.BSTCHECKED:
                    return ToggleState.On;
                case (int) ButtonStates.BSTINDETERMINATE:
                    return ToggleState.Indeterminate;
                default:
                    return ToggleState.Indeterminate;
            }
        }

        internal static void ClickIt(IntPtr windowHandle)
        {
            ToggleState currState = GetCheckStateNative(windowHandle);

            if (currState == ToggleState.On)
            {
                SetCheckStateNative(windowHandle, ToggleState.Off);
                return;
            }
            SetCheckStateNative(windowHandle, ToggleState.On);
        }
    }
}