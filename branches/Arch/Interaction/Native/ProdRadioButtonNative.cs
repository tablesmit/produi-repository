// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdRadioButtonNative
    {
        /// <summary>
        /// Gets the check state of the RadioButton.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>
        ///   <c>true</c> if selected, <c>false</c> otherwise
        /// </returns>
        internal static bool GetCheckStateNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int retVal = (int)NativeMethods.SendMessage(windowHandle, (int)ButtonMessage.BMGETCHECK, 0, 0);

            return retVal == (int)ButtonStates.BSTCHECKED;
        }

        /// <summary>
        /// Sets the check state of the RadioButton
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        internal static void SetCheckStateNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)ButtonMessage.BMSETCHECK, (int)ButtonStates.BSTCHECKED, 0);
        }
    }
}