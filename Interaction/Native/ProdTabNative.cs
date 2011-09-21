// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.ComponentModel;
using ProdUI.Configuration;
using ProdUI.Exceptions;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///     Methods to work with Button controls using the UI Automation framework
    /// </summary>
    internal sealed class ProdTabNative
    {
        /// <summary>
        ///     Gets the tab count.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <returns>The number of tabs within the tabControl</returns>
        internal static int GetTabCount(IntPtr windowHandle)
        {
            try
            {
                int retVal = (int) NativeMethods.SendMessage(windowHandle, (int) TabControlMessage.TCMGETITEMCOUNT, 0, 0);

                const string logmessage = "GetTabCount using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return retVal;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Gets the selected tab.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <returns>The zero based index of the selected TabItem</returns>
        internal static int GetSelectedTab(IntPtr windowHandle)
        {
            try
            {
                int retVal = (int) NativeMethods.SendMessage(windowHandle, (int) TabControlMessage.TCMGETCURSEL, 0, 0);

                const string logmessage = "GetSelectedTab using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return retVal;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Sets the selected tab.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "index">The index.</param>
        internal static void SetSelectedTab(IntPtr windowHandle, int index)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) TabControlMessage.TCMSETCURSEL, index, 0);

                const string logmessage = "SetSelectedTab using SendMessage";

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