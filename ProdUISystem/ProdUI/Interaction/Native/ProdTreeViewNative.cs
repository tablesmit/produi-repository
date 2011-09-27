// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdTreeViewNative
    {
        internal static int GetNodeCountNative(IntPtr windowHandle)
        {
            int retVal = (int)NativeMethods.SendMessage(windowHandle, (int)TreeViewMessages.TVMGetcount, 0, 0);

            return retVal;
        }
    }
}