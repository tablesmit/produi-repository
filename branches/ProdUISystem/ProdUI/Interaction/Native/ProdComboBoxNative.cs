// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Text;
using ProdUI.Logging;
using ProdUI.Verification;
using System.Collections.ObjectModel;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdComboBoxNative
    {
        /// <summary>
        /// Gets the selected index from the ComboBox list.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>
        /// The index of the selected list item
        /// </returns>
        internal static int GetSelectedIndexNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int)NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBGETCURSEL, 0, 0);
        }

        /// <summary>
        /// Uses SendMessage to select an item in the ComboBox, deselecting all other items
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to ComboBox</param>
        /// <param name="index">Zero based index of item to select</param>
        internal static void SelectItemNative(IntPtr windowHandle, int index)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSHOWDROPDOWN, 1, 0);
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSETCURSEL, index, 0);
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSHOWDROPDOWN, 1, 0);
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSHOWDROPDOWN, 0, 0);

            ValueVerifier<int, int>.Verify(index, GetSelectedIndexNative(windowHandle));
        }

        /// <summary>
        /// Uses SendMessage to select an item in the ComboBox, deselecting all other items
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to ComboBox</param>
        /// <param name="itemText">String to search ComboBox for. Case insensitive</param>
        internal static void SelectItemNative(IntPtr windowHandle, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int stringIndex = FindString(windowHandle, itemText);

            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSHOWDROPDOWN, 1, 0);
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSETCURSEL, stringIndex, 0);
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSHOWDROPDOWN, 1, 0);
            NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBSHOWDROPDOWN, 0, 0);

            ValueVerifier<int, int>.Verify(stringIndex, GetSelectedIndexNative(windowHandle));
        }

        /// <summary>
        /// Finds the desired string in the ComboBox list.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="itemText">The item text.</param>
        /// <returns></returns>
        private static int FindString(IntPtr windowHandle, string itemText)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBFINDSTRING, -1, itemText);
        }

        /// <summary>
        /// Uses SendMessage to get a collection of all items in a ComboBox
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to ComboBox</param>
        /// <returns>
        /// A string collection containing each item in the ComboBox
        /// </returns>
        internal static Collection<object> GetItemsNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            int itemCount = GetItemCountNative(windowHandle);
            return GetAllItems(windowHandle, itemCount);
        }

        /// <summary>
        /// Gets all items in the ComboBox List.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="itemCount">The item count.</param>
        /// <returns>
        /// A collection of all the items in the list
        /// </returns>
        private static Collection<object> GetAllItems(IntPtr windowHandle, int itemCount)
        {
            StringBuilder sb = new StringBuilder();
            Collection<object> returnCollection = new Collection<object>();
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            for (int i = 0; i < itemCount - 1; i++)
            {
                NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBGETLBTEXT, i, sb);

                returnCollection.Add(sb.ToString());
                sb.Clear();
            }

            return returnCollection;
        }

        /// <summary>
        /// Uses SendMessage to get # of items in ComboBox
        /// </summary>
        /// <param name="windowHandle">NativeWindowHandle to the control</param>
        /// <returns>
        /// Number of items in the ComboBox
        /// </returns>
        internal static int GetItemCountNative(IntPtr windowHandle)
        {
            LogController.ReceiveLogMessage(new LogMessage("Using SendMessage"));
            return (int)NativeMethods.SendMessage(windowHandle, (int)ComboBoxMessage.CBGETCOUNT, 0, 0);
        }
    }
}