/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ProdUI.Exceptions;
using ProdUI.Configuration;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    internal sealed class ProdComboBoxNative
    {
        private const int CBErr = -1;

        /// <summary>
        ///   Gets the selected index from the ComboBox list.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <returns>The index of the selected list item</returns>
        internal static int GetSelectedIndexNative(IntPtr windowHandle)
        {
            try
            {
                int ret = (int) NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBGetcursel, 0, 0);

                const string logmessage = "GetSelectedIndex using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return ret;
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Uses SendMessage to select an item in the ComboBox, deselecting all other items
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to ComboBox</param>
        /// <param name = "index">Zero based index of item to select</param>
        internal static void SelectItemNative(IntPtr windowHandle, int index)
        {
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBShowdropdown, 1, 0);
                int sndReturn = (int) NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBSetcursel, index, 0);
                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBShowdropdown, 1, 0);
                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBShowdropdown, 0, 0);
                if (index != -1 && sndReturn == CBErr)
                {
                    throw new ProdOperationException("Could not select item");
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
        ///   Uses SendMessage to select an item in the ComboBox, deselecting all other items
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to ComboBox</param>
        /// <param name = "itemText">String to search ComboBox for. Case insensitive</param>
        internal static void SelectItemNative(IntPtr windowHandle, string itemText)
        {
            try
            {
                int stringIndex = FindString(windowHandle, itemText);

                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBShowdropdown, 1, 0);
                int sndReturn = (int) NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBSetcursel, stringIndex, 0);
                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBShowdropdown, 1, 0);
                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBShowdropdown, 0, 0);

                if (sndReturn == CBErr)
                {
                    throw new ProdOperationException("Could not select item");
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
        ///   Finds the desired string in the ComboBox list.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "itemText">The item text.</param>
        /// <returns></returns>
        private static int FindString(IntPtr windowHandle, string itemText)
        {
            int stringIndex = NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBFindstring, -1, itemText);

            if (stringIndex == CBErr)
            {
                throw new ProdOperationException("Could not find item");
            }

            string logmessage = "FindString using SendMessage: " + stringIndex;

            if (ProdStaticSession._Configuration != null)
                ProdStaticSession.Log(logmessage);

            return stringIndex;
        }

        /// <summary>
        ///   Uses SendMessage to get a collection of all items in a ComboBox
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to ComboBox</param>
        /// <returns>A string collection containing each item in the ComboBox</returns>
        internal static List<object> GetItemsNative(IntPtr windowHandle)
        {
            try
            {
                int itemCount = GetItemCountNative(windowHandle);
                return GetAllItems(windowHandle, itemCount);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Gets all items in the ComboBox List.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "itemCount">The item count.</param>
        /// <returns>A collection of all the items in the list</returns>
        private static List<object> GetAllItems(IntPtr windowHandle, int itemCount)
        {
            StringBuilder sb = new StringBuilder();
            List<object> returnCollection = new List<object>();

            for (int i = 0; i < itemCount - 1; i++)
            {
                NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBGetlbtext, i, sb);

                const string logmessage = "GetAllItems using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                returnCollection.Add(sb.ToString());
                sb.Clear();
            }

            return returnCollection;
        }

        /// <summary>
        ///   Uses SendMessage to get # of items in ComboBox
        /// </summary>
        /// <param name = "windowHandle">NativeWindowHandle to the control</param>
        /// <returns>Number of items in the ComboBox</returns>
        internal static int GetItemCountNative(IntPtr windowHandle)
        {
            try
            {
                int retVal = (int) NativeMethods.SendMessage(windowHandle, (int) ComboBoxMessage.CBGetcount, 0, 0);
                if (retVal == CBErr)
                {
                    throw new ProdOperationException("Native call fail");
                }

                string logmessage = "GetItemCountNative using SendMessage: " + retVal;

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