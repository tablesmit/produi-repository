namespace ProdUI.Bridge.NativePatterns
{
    //ReSharper disable InconsistentNaming

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb775234(v=VS.85).aspx
    /// </summary>
    internal enum HotKeyContolMessages
    {
        WM_USER = 0x0400,

        /// <summary>
        /// Sets the hot key combination for a hot key control.
        /// wParam: The LOBYTE of the LOWORD is the virtual key code of the hot key. The HIBYTE of the LOWORD is the key modifier that indicates the keys that define a hot key combination
        /// lParam: Must be zero.
        /// </summary>
        HKM_SETHOTKEY = (WM_USER + 1),

        /// <summary>
        /// Gets the virtual key code and modifier flags of a hot key from a hot key control.
        /// wParam: Must be zero.
        /// lParam: Must be zero.
        /// Returns the virtual key code and modifier flags. The LOBYTE of the LOWORD is the virtual key code of the hot key.
        /// The HIBYTE of the LOWORD is the key modifier that specifies the keys that define a hot key combination.
        /// </summary>
        HKM_GETHOTKEY = (WM_USER + 2),
        HKM_SETRULES = (WM_USER + 3),
    }

    internal enum HotkeyModifiers
    {
        HOTKEYF_SHIFT = 0x01,
        HOTKEYF_CONTROL = 0x02,
        HOTKEYF_ALT = 0x04,
        HOTKEYF_EXT = 0x08,
    }

    // ReSharper restore InconsistentNaming
}