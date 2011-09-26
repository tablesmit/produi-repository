// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Text;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///     Provides methods to interact with Textbox controls via the UI Automation API
    /// </summary>
    internal sealed class NativeTextProds
    {
        /// <summary>
        ///     Uses SendMessage to try and get the text value
        /// </summary>
        /// <param name = "windowHandle">handle to the control</param>
        /// <returns>A string containing the text</returns>
        internal static string GetTextNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            StringBuilder sb = new StringBuilder();

            NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_GETTEXT, sb.Capacity, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Uses SendMessage to set and verify the text value.
        /// </summary>
        /// <param name="windowHandle">handle to the control</param>
        /// <param name="newText">Desired text</param>
        internal static void SetTextNative(IntPtr windowHandle, string newText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_SETTEXT, 0, newText);
            ValueVerifier<string, string>.Verify(newText, GetTextNative(windowHandle));
        }

        /// <summary>
        /// Appends the text using SendMessages.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="newText">The new text.</param>
        internal static void AppendTextNative(IntPtr windowHandle, string newText)
        {
            string tempstring = GetTextNative(windowHandle);
            string newstring = tempstring + newText;
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            ClearTextNative(windowHandle);
            SetTextNative(windowHandle, newstring);

            ValueVerifier<string, string>.Verify(newstring, GetTextNative(windowHandle));
        }

        /// <summary>
        /// Inserts text using SendMessages.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="newText">The new text.</param>
        /// <param name="insertIndex">Index of the insertion point.</param>
        internal static void InsertTextNative(IntPtr windowHandle, string newText, int insertIndex)
        {
            string baseText = GetTextNative(windowHandle);
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            /* If index is out of range, defer to ProdErrorManager */
            if (baseText != null)
            {
                baseText.Insert(insertIndex, newText);
            }
        }

        /// <summary>
        /// Clears the text using SendMessage.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        internal static void ClearTextNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_CLEAR, 0, 0);
        }


    }
}