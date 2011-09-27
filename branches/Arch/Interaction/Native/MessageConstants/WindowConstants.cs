// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Interaction.Native
{
    internal enum WindowMessages : uint
    {
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_ENABLE = 0x000A,
        WM_SETTEXT = 0x000C,
        /// <summary>
        ///     Copies the text that corresponds to a window into a buffer provided by the caller.
        /// </summary>
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_CLOSE = 0x0010,
        WM_QUIT = 0x0012,
        WM_SHOWWINDOW = 0x0018,
        WM_CLEAR = 0x0303
    }

    /* Show Window Messages */

    /// <summary>
    ///     Controls how the window is to be shown. Used for ShowWindow calls
    /// </summary>
    internal enum ShowWindowCommand
    {
        /// <summary>
        ///     Hides the window and activates another window.
        /// </summary>
        SW_HIDE,
        /// <summary>
        ///     Activates and displays a window. If the window is minimized or maximized, the system restores it
        ///     to its original size and position.
        /// </summary>
        SW_SHOWNORMAL,
        /// <summary>
        ///     Activates the window and displays it as a minimized window.
        /// </summary>
        SW_SHOWMINIMIZED,
        /// <summary>
        ///     Activates the window and displays it as a maximized window.
        /// </summary>
        SW_SHOWMAXIMIZED,
        /// <summary>
        ///     Displays a window in its most recent size and position.
        ///     This value is similar to SW_SHOWNORMAL, except that the window is not activated.
        /// </summary>
        SW_SHOWNOACTIVATE,
        /// <summary>
        ///     Activates the window and displays it in its current size and position
        /// </summary>
        SW_SHOW,
        /// <summary>
        ///     Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        SW_MINIMIZE,
        /// <summary>
        ///     Displays the window as a minimized window.
        ///     This value is similar to SW_SHOWMINIMIZED, except the window is not activated
        /// </summary>
        SW_SHOWMINNOACTIVE,
        /// <summary>
        ///     Displays the window in its current size and position.
        ///     This value is similar to SW_SHOW, except that the window is not activated.
        /// </summary>
        SW_SHOWNA,
        /// <summary>
        ///     Activates and displays the window
        /// </summary>
        SW_RESTORE,
        /// <summary>
        ///     Sets the show state based on the SW_ value specified in the STARTUPINFO
        ///     structure passed to the CreateProcess function by the program that started the application.
        /// </summary>
        SW_SHOWDEFAULT,
        /// <summary>
        ///     Minimizes a window, even if the thread that owns the window is not responding.
        ///     This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        SW_FORCEMINIMIZE
    }

    [Flags]
    internal enum WindowPlacementFlags : uint
    {
        /// <summary>
        /// The coordinates of the minimized window may be specified. This flag must be specified if the coordinates are set in the ptMinPosition member.
        /// </summary>
        WPF_SETMINPOSITION = 0x0001,

        /// <summary>
        /// The restored window will be maximized, regardless of whether it was maximized before it was minimized.
        /// This setting is only valid the next time the window is restored. It does not change the default restoration behavior.
        /// This flag is only valid when the SW_SHOWMINIMIZED value is specified for the showCmd member.
        /// </summary>
        WPF_RESTORETOMAXIMIZED = 0x0002,

        /// <summary>
        /// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window.
        /// This prevents the calling thread from blocking its execution while other threads process the request.
        /// </summary>
        WPF_ASYNCWINDOWPLACEMENT = 0x0004
    }

    internal enum ShowCmdFlags : uint
    {
        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        SW_SHOWMINIMIZED = 2,

        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        SW_SHOWMAXIMIZED = 3,
    }
}