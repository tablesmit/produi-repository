using System;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using ExpandCollapseState;
using ProdUI.Adapters;

namespace ProdUI.Bridge.NativePatterns
{
    internal class NativeExpandCollapseHelper
    {
        #region SendMessage

        /// <summary>
        /// Sends a message to the message window and waits until the WndProc method has processed the message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="msg">CB_SHOWDROPDOWN</param>
        /// <param name="wParam">A BOOL that specifies whether the drop-down list box is to be shown or hidden. A value of TRUE shows the list box; a value of FALSE hides it.</param>
        /// <param name="lParam">Not used.</param>
        /// <returns>
        /// TRUE
        /// </returns>
        /// <remarks>
        /// An application sends a CB_SHOWDROPDOWN message to show or hide the list box of a combo box
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.SysInt)] int msg, [MarshalAs(UnmanagedType.Bool)] bool wParam, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        /// <summary>
        /// Sends a message to the message window and waits until the WndProc method has processed the message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="msg">CB_GETDROPPEDSTATE</param>
        /// <param name="wParam"> Not used; must be zero.</param>
        /// <param name="lParam"> Not used; must be zero.</param>
        /// <returns>
        /// If the list box is visible, the return value is TRUE; otherwise, it is FALSE
        /// </returns>
        /// <remarks>
        /// Determines whether the list box of a combo box is dropped down
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SendMessage(IntPtr windowHandle, [MarshalAs(UnmanagedType.SysInt)] int msg, [MarshalAs(UnmanagedType.SysInt)]int wParam, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        #endregion SendMessage

        /// <summary>
        /// Expands the specified control.
        /// </summary>
        /// <param name="hWnd">The control handle to the application window.</param>
        /// <param name="control">The control that supports ExpandCollapse.</param>
        internal void Expand(IntPtr hWnd, BaseProdControl control)
        {
            int controlHandle = control.UIAElement.Current.NativeWindowHandle;

            if (control.UIAElement.Current.ControlType == ControlType.Tree)
            {
                SendMessage(hWnd, (int)TreeViewMessages.TVM_EXPAND, (int)TreeViewExpandArgs.TVE_EXPAND, controlHandle);
                return;
            }

            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
            {
                SendMessage(hWnd, (int)ComboBoxMessages.CB_SHOWDROPDOWN, true, 0);
                return;
            }
        }

        /// <summary>
        /// Collapses the specified control.
        /// </summary>
        /// <param name="hWnd">The control handle to the application window.</param>
        /// <param name="control">The control that supports ExpandCollapse.</param>
        internal void Collapse(IntPtr hWnd, BaseProdControl control)
        {
            int controlHandle = control.UIAElement.Current.NativeWindowHandle;

            if (control.UIAElement.Current.ControlType == ControlType.Tree)
            {
                SendMessage(hWnd, (int)TreeViewMessages.TVM_EXPAND, (int)TreeViewExpandArgs.TVE_COLLAPSE, controlHandle);
                return;
            }
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
            {
                SendMessage(hWnd, (int)ComboBoxMessages.CB_SHOWDROPDOWN, false, 0);
                return;
            }
        }

        /// <summary>
        /// Gets the ExpandCollapseState of the selected element.
        /// </summary>
        /// <param name="hWnd">The control handle to the application window.</param>
        /// <param name="control">The control that supports ExpandCollapse.</param>
        /// <returns>returns a <see cref="System.Windows.Automation.ExpandCollapseState"/> or null if operation fails</returns>
        internal System.Windows.Automation.ExpandCollapseState? ExpandCollapseState(IntPtr hWnd, BaseProdControl control)
        {
            int controlHandle = control.UIAElement.Current.NativeWindowHandle;

            if (control.UIAElement.Current.ControlType == ControlType.Tree)
            {
                uint mask = NativeMethods.SendMessage(hWnd, (int)TreeViewMessages.TVM_GETITEMSTATE, controlHandle, (uint)TreeViewItemStates.TVIS_EXPANDED);
                if (((uint)TreeViewItemStates.TVIS_EXPANDED & mask) == (uint)TreeViewItemStates.TVIS_EXPANDED) return System.Windows.Automation.ExpandCollapseState.Expanded;
                return System.Windows.Automation.ExpandCollapseState.Collapsed;
            }
            if (control.UIAElement.Current.ControlType == ControlType.ComboBox)
            {
                bool retVal = SendMessage(hWnd, (int)ComboBoxMessages.CB_GETDROPPEDSTATE, 0, 0);

                if (retVal) return System.Windows.Automation.ExpandCollapseState.Expanded;
                return System.Windows.Automation.ExpandCollapseState.Collapsed;
            }
            return null;
        }
    }
}