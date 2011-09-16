using System;
using System.ComponentModel;
using System.Text;
using ProdUI.Exceptions;
using ProdUI.Configuration;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///   Provides methods to interact with Textbox controls via the UI Automation API
    /// </summary>
    internal class ProdEditNative
    {
        /// <summary>
        ///   Uses SendMessage to try and get the text value
        /// </summary>
        /// <param name = "windowHandle">handle to the control</param>
        /// <returns>A string containing the text</returns>
        /// <exception cref = "ProdOperationException"><seealso cref = "Win32Exception" /></exception>
        internal static string GetTextNative(IntPtr windowHandle)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                NativeMethods.SendMessage(windowHandle, (int) WindowMessages.WM_GETTEXT, sb.Capacity, sb);

                const string logmessage = "GetTextNative using SendMessage";

                //if (ProdSession.Configuration != null)
                //    ProdSession.Log(logmessage);

                return sb.ToString();
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to set and verify the text value.
        /// </summary>
        /// <param name = "windowHandle">handle to the control</param>
        /// <param name = "newText">Desired text</param>
        /// <returns>true if successful, false if failure</returns>
        /// <exception cref = "ProdOperationException"><seealso cref = "Win32Exception" /></exception>
        internal static bool SetTextNative(IntPtr windowHandle, string newText)
        {
            try
            {
                bool retVal = NativeMethods.SendMessage(windowHandle, (int) WindowMessages.WM_SETTEXT, 0, newText) == 1 && VerifyText(windowHandle, newText);

                const string logmessage = "SetTextNative using SendMessage";

                //if (ProdSession.Configuration != null)
                //    ProdSession.Log(logmessage);

                return retVal;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Appends the text using SendMessages.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "newText">The new text.</param>
        /// <exception cref = "ProdOperationException"><seealso cref = "Win32Exception" /></exception>
        internal static void AppendTextNative(IntPtr windowHandle, string newText)
        {
            try
            {
                string tempstring = GetTextNative(windowHandle);
                string newstring = tempstring + newText;
                ClearTextNative(windowHandle);
                SetTextNative(windowHandle, newstring);
                if (!VerifyText(windowHandle, newstring)) throw new ProdVerificationException("Verification of append failed");

                const string logmessage = "AppendTextNative using SendMessage";

                //if (ProdSession.Configuration != null)
                //    ProdSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Inserts text using SendMessages.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "newText">The new text.</param>
        /// <param name = "insertIndex">Index of the insertion point.</param>
        /// <exception cref = "ProdOperationException"><seealso cref = "Win32Exception" /></exception>
        internal static void InsertTextNative(IntPtr windowHandle, string newText, int insertIndex)
        {
            try
            {
                string baseText = GetTextNative(windowHandle);

                /* If index is out of range, defer to ProdErrorManager */
                if (baseText != null) baseText.Insert(insertIndex, newText);

                const string logmessage = "InsertTextNative using SendMessage";

                //if (ProdSession.Configuration != null)
                //    ProdSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Clears the text using SendMessage.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <exception cref = "ProdOperationException"><seealso cref = "Win32Exception" /></exception>
        internal static void ClearTextNative(IntPtr windowHandle)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) WindowMessages.WM_CLEAR, 0, 0);

                const string logmessage = "ClearTextNative using SendMessage";

                //if (ProdSession.Configuration != null)
                //    ProdSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Verifies that the current text is correct.
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

                //if (ProdSession.Configuration != null)
                //    ProdSession.Log(logmessage);

                return string.Compare(currentValue, newText, false) == 0;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}