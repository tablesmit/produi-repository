/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.ComponentModel;
using System.Text;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Session;
using ProdUI.Utility;

namespace ProdUI.Interaction.Native
{
    internal static class ProdWindowNative
    {
        /// <summary>
        ///   Close the specified window using the supplied window handle
        /// </summary>
        /// <param name = "windowHandle">Handle to the target window</param>
        /// <returns>
        ///   If the function succeeds, the return value is true, otherwise, false
        /// </returns>
        internal static bool CloseWindow(IntPtr windowHandle)
        {
            if ((int) windowHandle == 0)
            {
                throw new ProdOperationException("Handle not found.");
            }
            try
            {
                NativeMethods.SendMessage(windowHandle, (int) WindowMessage.WM_CLOSE, 0, 0);

                const string logmessage = "CloseWindow using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                try
                {
                    return NativeMethods.DestroyWindow(windowHandle);
                }
                catch (Win32Exception err)
                {
                    throw new ProdOperationException(err.Message, err);
                }
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Maximizes specified window
        /// </summary>
        /// <param name = "windowHandle">Handle to the target window</param>
        internal static void MaximizeWindow(IntPtr windowHandle)
        {
            if ((int) windowHandle == 0)
            {
                throw new ProdOperationException("Handle not found.");
            }
            try
            {
                ShowWindow(windowHandle);
                NativeMethods.ShowWindowAsync(windowHandle, (int) ShowWindowCommand.SW_SHOWMAXIMIZED);
                NativeMethods.SetForegroundWindow(windowHandle);

                const string logmessage = "MaximizeWindow using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Minimizes specified window
        /// </summary>
        /// <param name = "windowHandle">Handle to the target window</param>
        /// <exception cref = "ProdOperationException"></exception>
        internal static void MinimizeWindow(IntPtr windowHandle)
        {
            if ((int) windowHandle == 0)
            {
                throw new ProdOperationException("Handle not found.");
            }
            NativeMethods.ShowWindowAsync(windowHandle, (int) ShowWindowCommand.SW_SHOWMINNOACTIVE);

            const string logmessage = "MinimizeWindow using SendMessage";

            if (ProdStaticSession._Configuration != null)
                ProdStaticSession.Log(logmessage);
        }

        /// <summary>
        ///   Shows a window in its "normal" state.
        /// </summary>
        /// <param name = "windowHandle">Handle to the target window</param>
        internal static void ShowWindow(IntPtr windowHandle)
        {
            if ((int) windowHandle == 0)
            {
                throw new ProdOperationException("Handle not found.");
            }
            NativeMethods.ShowWindowAsync(windowHandle, (int) ShowWindowCommand.SW_SHOWDEFAULT);

            const string logmessage = "ShowWindow using SendMessage";

            if (ProdStaticSession._Configuration != null)
                ProdStaticSession.Log(logmessage);
        }

        /// <summary>
        ///   Retrieves the specified windows title
        /// </summary>
        /// <param name = "windowHandle">Handle to the target window</param>
        /// <returns>Title of the specified window, null if failure</returns>
        internal static string GetWindowTitle(IntPtr windowHandle)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (NativeMethods.GetWindowText(windowHandle, sb, sb.Capacity) == 0)
                {
                    throw new ProdOperationException("Handle not found.");
                }

                const string logmessage = "GetWindowTitle using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);

                return sb.ToString();
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   sets the title of the specified window
        /// </summary>
        /// <param name = "windowHandle">Handle to the window</param>
        /// <param name = "newTitle">Text to be used as the new title</param>
        internal static void SetWindowTitle(IntPtr windowHandle, string newTitle)
        {
            try
            {
                if ((int) windowHandle == 0)
                {
                    throw new ProdOperationException("Handle not found.");
                }
                NativeMethods.SetWindowText(windowHandle, newTitle);

                /* verify it was changed */
                if (GetWindowTitle(windowHandle).CompareTo(newTitle) != 0)
                {
                    throw new ProdOperationException("unable to verify title change");
                }

                const string logmessage = "SetWindowTitle using SendMessage";

                if (ProdStaticSession._Configuration != null)
                    ProdStaticSession.Log(logmessage);
            }
            catch (Win32Exception err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///   Moves the window using MoveWindow native call.
        /// </summary>
        /// <param name = "windowHandle">The window handle.</param>
        /// <param name = "x">The x.</param>
        /// <param name = "y">The y.</param>
        /// <param name = "width">The width.</param>
        /// <param name = "height">The height.</param>
        internal static void MoveWindowNative(IntPtr windowHandle, double x, double y, double width, double height)
        {
            try
            {
                int ret = NativeMethods.MoveWindow(windowHandle, (int) x, (int) y, (int) width, (int) height, true);
                if (ret != 0)
                {
                    throw new ProdOperationException("Unable to move Window");
                }

                const string logmessage = "MoveWindowNative using SendMessage";

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