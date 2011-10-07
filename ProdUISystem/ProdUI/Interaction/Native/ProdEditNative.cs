﻿// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Text;
using ProdUI.Logging;
using ProdUI.Verification;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    /// Provides methods to interact with Textbox controls via the UI Automation API
    /// </summary>
    internal sealed class ProdEditNative
    {
        /// <summary>
        /// Uses SendMessage to try and get the text value
        /// </summary>
        /// <param name="windowHandle">handle to the control</param>
        /// <returns>
        /// A string containing the text
        /// </returns>
        internal static string GetTextNative(IntPtr windowHandle)
        {
            StringBuilder sb = new StringBuilder();

            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_GETTEXT, sb.Capacity, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Uses SendMessage to set and verify the text value.
        /// </summary>
        /// <param name="windowHandle">handle to the control</param>
        /// <param name="text">Desired text</param>
        internal static void SetTextNative(IntPtr windowHandle, string text)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_SETTEXT, 0, text);

            string currentValue = GetTextNative(windowHandle);
            ValueVerifier<string, string>.Verify(currentValue, text);
        }

        /// <summary>
        /// Appends the text using SendMessages.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="text">The new text.</param>
        internal static void AppendTextNative(IntPtr windowHandle, string text)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            string tempstring = GetTextNative(windowHandle);
            string newstring = tempstring + text;
            ClearTextNative(windowHandle);
            SetTextNative(windowHandle, newstring);
            string currentValue = GetTextNative(windowHandle);
            ValueVerifier<string, string>.Verify(currentValue, text);
        }

        /// <summary>
        /// Inserts text using SendMessages.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="text">The new text.</param>
        /// <param name="index">Index of the insertion point.</param>
        internal static void InsertTextNative(IntPtr windowHandle, string text, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            string baseText = GetTextNative(windowHandle);
            if (baseText != null) baseText.Insert(index, text);
            //TODO: Verify String Insert
        }

        /// <summary>
        /// Clears the text using SendMessage.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        internal static void ClearTextNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)WindowMessages.WM_CLEAR, 0, 0);

            string currentValue = GetTextNative(windowHandle);
            ValueVerifier<string, string>.Verify(currentValue, "");
        }
    }
}