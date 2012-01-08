namespace ProdUI.Bridge.NativePatterns
{
    //ReSharper disable InconsistentNaming

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb787529(v=VS.85).aspx
    /// </summary>
    internal enum ScollbarMessages
    {
        SBM_ENABLE_ARROWS = 0x00E4,
        SBM_GETPOS = 0x00E1,
        SBM_GETRANGE = 0x00E3,
        SBM_SETPOS = 0x00E0,
        SBM_SETRANGE = 0x00E2,
        SBM_SETRANGEREDRAW = 0x00E6,
        SBM_SETSCROLLINFO = 0x00E9,
        SBM_GETSCROLLINFO = 0x00EA
    }

    internal struct SCROLLINFO
    {
        uint cbSize;
        uint fMask;
        int nMin;
        int nMax;
        uint nPage;
        int nPos;
        int nTrackPos;
    }

    // ReSharper restore InconsistentNaming
}