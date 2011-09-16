/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using ProdUI.Exceptions;
using ProdUI.Configuration;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///   Provides methods to interact with ListBox controls using the Win32 API
    /// </summary>
    internal sealed class ProdListBoxNative
    {
        private const int LBERR = -1;

        /// <summary>
        ///   Uses SendMessage to get # of items in ListBox
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to the control</param>
        /// <returns>Number of items in the list box</returns>
        internal static int GetItemCountNative(IntPtr windowHandle)
        {
            int retVal = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGetcount, 0, 0);
            if (retVal == LBERR)
            {
                throw new ProdOperationException("Native call fail");
            }

            string logmessage = "GetItemCountNative using SendMessage: " + retVal;

            if (ProdStaticSession._Configuration != null)
                ProdStaticSession.Log(logmessage);

            return retVal;

        }

        /// <summary>
        ///   Uses SendMessage to get the number of selected items from a multi-select ListBox
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <returns>number of selected items</returns>
        /// <remarks>
        ///   This will FAIL on a single select
        /// </remarks>
        internal static int GetSelectedItemCountNative(IntPtr windowHandle)
        {
            int retVal = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGetselcount, 0, 0);
            if (retVal == LBERR)
            {
                throw new ProdOperationException("Native call fail");
            }

            string logmessage = "GetSelectedItemCountNative using SendMessage: " + retVal;

            if (ProdStaticSession._Configuration != null)
                ProdStaticSession.Log(logmessage);

            return retVal;

        }

        /// <summary>
        ///   Uses SendMessage to get a collection of all items in a ListBox
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to ListBox</param>
        /// <returns>A string collection containing each item in the ListBox</returns>
        internal static Collection<object> GetItemsNative(IntPtr windowHandle)
        {
            try
            {
                int itemCount = GetItemCountNative(windowHandle);

                const string logmessage = "GetItemsNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return GetAllItems(windowHandle, itemCount);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to select an item in the ListBox, deselecting all other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void SelectItemNative(IntPtr windowHandle, int index)
        {
            try
            {
                int sndReturn = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSetcursel, index, 0);

                if (index != -1 && sndReturn == LBERR)
                {
                    throw new ProdOperationException("Native call fail");
                }

                const string logmessage = "SelectItemNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to select an item in the ListBox, deselecting all other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "itemText">string to search ListBox for. Case insensitive</param>
        internal static void SelectItemNative(IntPtr windowHandle, string itemText)
        {
            try
            {
                int stringIndex = FindString(windowHandle, itemText);

                int sndReturn = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSetcursel, stringIndex, 0);

                if (sndReturn == LBERR)
                {
                    throw new ProdOperationException("Native call fail");
                }

                const string logmessage = "SelectItemNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to deselect an item in the ListBox
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void DESelectItemNative(IntPtr windowHandle, int index)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSetsel, 0, index);

                const string logmessage = "DeSelectItemNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to deselect an item in the ListBox
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "itemText">string to search ListBox for. Case insensitive</param>
        internal static void DESelectItemNative(IntPtr windowHandle, string itemText)
        {
            try
            {
                int stringIndex = FindString(windowHandle, itemText);

                NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSetsel, 0, stringIndex);

                const string logmessage = "DeSelectItemNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to select an item in a multi-select ListBox without deselecting other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void AddSelectedItemNative(IntPtr windowHandle, int index)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSetsel, 1, index);

                const string logmessage = "AddSelectedItemNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to select an item in a multi-select ListBox without deselecting other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "itemText">string to search ListBox for. Case insensitive</param>
        internal static void AddSelectedItemNative(IntPtr windowHandle, string itemText)
        {
            try
            {
                int stringIndex = FindString(windowHandle, itemText);

                NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSetsel, 1, stringIndex);

                const string logmessage = "AddSelectedItemNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        internal static int GetSelectedIndexNative(IntPtr windowHandle)
        {
            try
            {
                int retVal = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGetcursel, 0, 0);

                const string logmessage = "GetSelectedIndexNative using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return retVal;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /* Util */

        private static Collection<object> GetAllItems(IntPtr windowHandle, int itemCount)
        {
            StringBuilder sb = new StringBuilder();
            Collection<object> returnCollection = new Collection<object>();

            for (int i = 0; i < itemCount - 1; i++)
            {
                NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGettext, i, sb);
                returnCollection.Add(sb.ToString());
                sb.Clear();
            }

            return returnCollection;
        }

        private static int FindString(IntPtr windowHandle, string itemText)
        {
            int stringIndex = NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBFindstring, -1, itemText);

            if (stringIndex == LBERR)
            {
                throw new ProdOperationException("Native call fail", new Win32Exception(Marshal.GetLastWin32Error()));
            }
            return stringIndex;
        }
    }
}