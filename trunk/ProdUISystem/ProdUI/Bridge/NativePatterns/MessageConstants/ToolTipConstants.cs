namespace ProdUI.Bridge.NativePatterns
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb760246(v=VS.85).aspx
    /// </summary>
    internal enum TooltipMessages
    {
        WM_USER = 0x0400,
        TTM_ACTIVATE = (WM_USER + 1),
        TTM_ADDTOOL = (WM_USER + 50),
        TTM_ADJUSTRECT = (WM_USER + 31),
        TTM_DELTOOL = (WM_USER + 51),
        TTM_ENUMTOOLS = (WM_USER + 58),
        TTM_GETBUBBLESIZE = (WM_USER + 30),
        TTM_GETCURRENTTOOL = (WM_USER + 59),
        TTM_GETDELAYTIME = (WM_USER + 21),
        TTM_GETMARGIN = (WM_USER + 27),
        TTM_GETMAXTIPWIDTH = (WM_USER + 25),
        TTM_GETTEXT = (WM_USER + 56),
        TTM_GETTIPBKCOLOR = (WM_USER + 22),
        TTM_GETTIPTEXTCOLOR = (WM_USER + 23),
        TTM_GETTITLE = (WM_USER + 35),
        TTM_GETTOOLCOUNT = (WM_USER + 13),
        TTM_GETTOOLINFO = (WM_USER + 53),
        TTM_HITTEST = (WM_USER + 55),
        TTM_NEWTOOLRECT = (WM_USER + 52),
        TTM_POP = (WM_USER + 28),
        TTM_POPUP = (WM_USER + 34),
        TTM_RELAYEVENT = (WM_USER + 7),
        TTM_SETDELAYTIME = (WM_USER + 3),
        TTM_SETMARGIN = (WM_USER + 26),
        TTM_SETMAXTIPWIDTH = (WM_USER + 24),
        TTM_SETTIPBKCOLOR = (WM_USER + 19),
        TTM_SETTIPTEXTCOLOR = (WM_USER + 20),
        TTM_SETTITLE = (WM_USER + 33),
        TTM_SETTOOLINFO = (WM_USER + 54),
        TTM_TRACKACTIVATE = (WM_USER + 17),
        TTM_TRACKPOSITION = (WM_USER + 18),
        TTM_UPDATE = (WM_USER + 29),
        TTM_UPDATETIPTEXT = (WM_USER + 57),
        TTM_WINDOWFROMPOINT = (WM_USER + 16)
    }

    internal enum TooltipIcons
    {
        TTI_NONE = 0,
        TTI_INFO = 1,
        TTI_WARNING = 2,
        TTI_ERROR = 3,
        TTI_INFO_LARGE = 4,
        TTI_WARNING_LARGE = 5,
        TTI_ERROR_LARGE = 6
    }
}