using System;
using System.Windows.Automation;

namespace ProdUI.Bridge.NativePatterns
{
    class NativeDockHelper
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
                                if (type == ControlType.Window) ;

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
                                if (type == ControlType.Window) ;
        }
    }
}
