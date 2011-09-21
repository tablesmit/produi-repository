// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.ObjectModel;
using System.Text;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///     Provides methods to interact with ListBox controls using the Win32 API
    /// </summary>
    internal sealed class ProdListBoxNative
    {
        /// <summary>
        ///     Uses SendMessage to get # of items in ListBox
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to the control</param>
        /// <returns>Number of items in the list box, -1 on fail</returns>
        internal static int GetItemCountNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGETCOUNT, 0, 0);
        }

        /// <summary>
        ///     Uses SendMessage to get the number of selected items from a multi-select ListBox
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <returns>number of selected items, -1 on fail</returns>
        /// <remarks>
        ///     This will FAIL on a single select
        /// </remarks>
        internal static int GetSelectedItemCountNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGETSELCOUNT, 0, 0);
        }

        /// <summary>
        ///     Uses SendMessage to get a collection of all items in a ListBox
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to ListBox</param>
        /// <returns>A string collection containing each item in the ListBox</returns>
        internal static Collection<object> GetItemsNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int itemCount = GetItemCountNative(windowHandle);
            return GetAllItems(windowHandle, itemCount);
        }

        /// <summary>
        ///     Uses SendMessage to select an item in the ListBox, deselecting all other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void SelectItemNative(IntPtr windowHandle, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int sndReturn = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSETCURSEL, index, 0);
        }

        /// <summary>
        ///     Uses SendMessage to select an item in the ListBox, deselecting all other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "itemText">string to search ListBox for. Case insensitive</param>
        internal static void SelectItemNative(IntPtr windowHandle, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int stringIndex = FindString(windowHandle, itemText);

            int sndReturn = (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSETCURSEL, stringIndex, 0);
        }

        /// <summary>
        ///     Uses SendMessage to deselect an item in the ListBox
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void DeSelectItemNative(IntPtr windowHandle, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSETSEL, 0, index);
        }

        /// <summary>
        ///     Uses SendMessage to deselect an item in the ListBox
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "itemText">string to search ListBox for. Case insensitive</param>
        internal static void DeSelectItemNative(IntPtr windowHandle, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int stringIndex = FindString(windowHandle, itemText);

            NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSETSEL, 0, stringIndex);
        }

        /// <summary>
        ///     Uses SendMessage to select an item in a multi-select ListBox without deselecting other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void AddSelectedItemNative(IntPtr windowHandle, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSETSEL, 1, index);
        }

        /// <summary>
        ///     Uses SendMessage to select an item in a multi-select ListBox without deselecting other items
        /// </summary>
        /// <param name = "windowHandle">handle to ListBox</param>
        /// <param name = "itemText">string to search ListBox for. Case insensitive</param>
        internal static void AddSelectedItemNative(IntPtr windowHandle, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int stringIndex = FindString(windowHandle, itemText);

            NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBSETSEL, 1, stringIndex);
        }

        internal static int GetSelectedIndexNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int)NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGETCURSEL, 0, 0);
        }

        /* Utility */

        private static Collection<object> GetAllItems(IntPtr windowHandle, int itemCount)
        {
            StringBuilder sb = new StringBuilder();
            Collection<object> returnCollection = new Collection<object>();

            for (int i = 0; i < itemCount - 1; i++)
            {
                NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBGETTEXT, i, sb);
                returnCollection.Add(sb.ToString());
                sb.Clear();
            }

            return returnCollection;
        }

        private static int FindString(IntPtr windowHandle, string itemText)
        {
            return NativeMethods.SendMessage(windowHandle, (int)ListboxMessage.LBFINDSTRING, -1, itemText);

        }
    }
}