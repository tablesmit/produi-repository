using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdUI.Verification
{
    class ValueVerifier
    {
        /*
        /// <summary>
        ///     Verifies that the current text is correct. ----> From EditNative
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "text">The desired text.</param>
        /// <returns>
        ///     <c>true</c> if the text matches, <c>false</c> otherwise
        /// </returns>
        private static bool VerifyText(IntPtr windowHandle, string text)
        {
            string currentValue = GetTextNative(windowHandle);
            return string.Compare(currentValue, text, false) == 0;
        }

        /// <summary>
        ///     Verifies that the current text is correct. ----> From NativeTextProds
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "newText">The desired text.</param>
        /// <returns><c>true</c> if the text matches, <c>false</c> otherwise</returns>
        /// <exception cref = "ProdOperationException"><seealso cref = "Win32Exception" /></exception>
        private static bool VerifyText(IntPtr windowHandle, string newText)
        {
            try
            {
                string currentValue = GetTextNative(windowHandle);

                const string logmessage = "VerifyText using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return string.Compare(currentValue, newText, false, CultureInfo.CurrentCulture) == 0;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /* ProdCheckBoxNative inline
         *   if (GetCheckStateNative(windowHandle) != isChecked) throw new ProdVerificationException("SetCheckStateNative verification failed");
         *   
         * ProdWindownative
         *  verify title was changed 
        //if (GetWindowTitleNative(windowHandle).CompareTo(newTitle) != 0)
        //{
        //    throw new ProdOperationException("unable to verify title change");
        //}

        /// <summary>
        ///     Verifies the toggle state. -----> TogglePatternHelper
        /// </summary>
        /// <param name = "control">The control to verify.</param>
        /// <param name = "toggleState">Desired toggleState</param>
        /// <returns>
        ///     <c>true</c> if verified, <c>false</c> if failure
        /// </returns>
        private static bool VerifyCheckState(AutomationElement control, ToggleState toggleState)
        {
            // now verify toggle 
            if (GetToggleState(control) == toggleState)
                return true;
            return false;
        }

        /// <summary>
        ///     Verifies that supplied text matches what is currently in the control -----> ValuePatternHelper
        /// </summary>
        /// <param name = "control">control to verify</param>
        /// <param name = "text">the text to verify</param>
        /// <returns>
        ///     0 if match, anything else otherwise
        /// </returns>
        private static int VerifyText(AutomationElement control, string text)
        {
            ValuePattern pattern = (ValuePattern)CommonUIAPatternHelpers.CheckPatternSupport(ValuePattern.Pattern, control);
            string currentText = pattern.Current.Value;

            if (text.Length == 0 || currentText.Length == 0)
            {
                return 0;
            }
            return String.Compare(text, currentText, StringComparison.Ordinal);
        }


        /// <summary>
        ///     Verifies the window is closed. ---->WindowPatternHelper
        /// </summary>
        /// <param name = "pattern">The WindowPattern of the current control</param>
        /// <param name = "state">The desired <see cref = "WindowVisualState" /></param>
        /// <returns>
        ///     0 if ok, -1 if error
        /// </returns>
        private static int VerifyState(WindowPattern pattern, WindowVisualState state)
        {
            if (false == pattern.WaitForInputIdle(10000))
            {
                return -1;
            }

            if (pattern.Current.WindowVisualState != state)
            {
                return -1;
            }
            return 0;
        }
    */
    }
}
