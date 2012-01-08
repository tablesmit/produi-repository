namespace ProdUI.Bridge.NativePatterns
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb760917(v=VS.85).aspx
    /// </summary>
    internal enum MonthCalendarMessages
    {
        MCM_FIRST = 0x1000,
        MCM_GETCALENDARBORDER = MCM_FIRST + 31,
        MCM_GETCALENDARCOUNT = MCM_FIRST + 23,
        MCM_GETCALENDARGRIDINFO = MCM_FIRST + 24,
        MCM_GETCALID = MCM_FIRST + 27,
        MCM_GETCOLOR = MCM_FIRST + 11,
        MCM_GETCURRENTVIEW = MCM_FIRST + 22,
        MCM_GETCURSEL = MCM_FIRST + 1,
        MCM_GETFIRSTDAYOFWEEK = MCM_FIRST + 16,
        MCM_GETMAXSELCOUNT = MCM_FIRST + 3,
        MCM_GETMAXTODAYWIDTH = MCM_FIRST + 21,
        MCM_GETMINREQRECT = MCM_FIRST + 9,
        MCM_GETMONTHDELTA = MCM_FIRST + 19,
        MCM_GETMONTHRANGE = MCM_FIRST + 7,
        MCM_GETRANGE = MCM_FIRST + 17,
        MCM_GETSELRANGE = MCM_FIRST + 5,
        MCM_GETTODAY = MCM_FIRST + 13,
        MCM_SETCALENDARBORDER = MCM_FIRST + 30,
        MCM_SETCALID = MCM_FIRST + 28,
        MCM_SETCOLOR = MCM_FIRST + 10,
        MCM_SETCURRENTVIEW = MCM_FIRST + 32,
        MCM_SETCURSEL = MCM_FIRST + 2,
        MCM_SETDAYSTATE = MCM_FIRST + 8,
        MCM_SETFIRSTDAYOFWEEK = MCM_FIRST + 15,
        MCM_SETMAXSELCOUNT = MCM_FIRST + 4,
        MCM_SETMONTHDELTA = MCM_FIRST + 20,
        MCM_SETRANGE = MCM_FIRST + 18,
        MCM_SETSELRANGE = MCM_FIRST + 6,
        MCM_SETTODAY = MCM_FIRST + 12,
        MCM_SIZERECTTOMIN = MCM_FIRST + 29
    }

    internal enum MonthCalendarView
    {
        MCMV_MONTH = 0,
        MCMV_YEAR = 1,
        MCMV_DECADE = 2,
        MCMV_CENTURY = 3,
        MCMV_MAX = MCMV_CENTURY
    }
}