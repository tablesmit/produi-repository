namespace ProdUI.Bridge.NativePatterns
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb760726(v=VS.85).aspx
    /// </summary>
    internal enum StatusbarMessages
    {
        WM_USER = 0x0400,
        SB_GETBORDERS = (WM_USER + 7),
        SB_GETPARTS = (WM_USER + 6),
        SB_GETRECT = (WM_USER + 10),
        SB_GETTEXTLENGTHW = (WM_USER + 12),
        SB_GETTEXTW = (WM_USER + 13),
        SB_GETTIPTEXT = SB_GETTIPTEXTW,
        SB_GETTIPTEXTW = (WM_USER + 19),
        SB_ISSIMPLE = (WM_USER + 14),
        SB_SETICON = (WM_USER + 15),
        SB_SETMINHEIGHT = (WM_USER + 8),
        SB_SETPARTS = (WM_USER + 4),
        SB_SETTEXTW = (WM_USER + 11),
        SB_SETTIPTEXT = SB_SETTIPTEXTW,
        SB_SETTIPTEXTW = (WM_USER + 17),
        SB_SIMPLE = (WM_USER + 9)
    }
}