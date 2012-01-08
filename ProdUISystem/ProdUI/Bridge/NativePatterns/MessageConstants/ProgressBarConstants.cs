namespace ProdUI.Bridge.NativePatterns
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb760818(v=VS.85).aspx
    /// </summary>
    internal enum ProgressbarMessages
    {
        WM_USER = 0x0400,
        PBM_GETSTEP = (WM_USER + 13),
        PBM_GETBKCOLOR = (WM_USER + 14),
        PBM_GETBARCOLOR = (WM_USER + 15),
        PBM_SETSTATE = (WM_USER + 16), // wParam = PBST_[State] (NORMAL, ERROR, PAUSED)
        PBM_GETSTATE = (WM_USER + 17),
    }
}