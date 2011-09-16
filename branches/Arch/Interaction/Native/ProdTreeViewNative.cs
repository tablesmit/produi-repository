/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.ComponentModel;
using ProdUI.Exceptions;
using ProdUI.Configuration;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdTreeViewNative
    {
        internal static int GetNodeCountNative(IntPtr windowHandle)
        {
            try
            {
                int retVal = (int) NativeMethods.SendMessage(windowHandle, (int) TreeViewMessages.TVMGetcount, 0, 0);

                const string logmessage = "GetNodeCountNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return retVal;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }
    }
}