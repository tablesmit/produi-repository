using System;
using System.Windows.Automation;
using ProdUI.Adapters;

/* Note: Might not be worth it to implement for native */

namespace ProdUI.Bridge.NativePatterns
{
    internal class NativeDockHelper
    {
        internal void GetDockPosition(BaseProdControl control)
        {
            IntPtr hWnd = (IntPtr)control.UIAElement.Current.NativeWindowHandle;
            ControlType type = control.UIAElement.Current.ControlType;

            if (type == ControlType.MenuBar)
                if (type == ControlType.MenuItem)
                    if (type == ControlType.Pane)
                        if (type == ControlType.ToolBar)
                            if (type == ControlType.TreeItem)
                                if (type == ControlType.Window)
                                {
                                }
        }

        internal void SetDockPosition(BaseProdControl control, DockPosition dockPosition)
        {
            IntPtr hWnd = (IntPtr)control.UIAElement.Current.NativeWindowHandle;
            ControlType type = control.UIAElement.Current.ControlType;

            if (type == ControlType.MenuBar)
                if (type == ControlType.MenuItem)
                    if (type == ControlType.Pane)
                        if (type == ControlType.ToolBar)
                            if (type == ControlType.TreeItem)
                                if (type == ControlType.Window)
                                {
                                }
        }
    }
}