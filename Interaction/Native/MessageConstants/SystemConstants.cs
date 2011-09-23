namespace ProdUI.Interaction.Native
{

    /// <summary>
    ///     Used for the nIndex parameter in the GetSystemMetrics call. this is only a partial list. http://msdn.microsoft.com/en-us/library/ms724385(VS.85).aspx
    /// </summary>
    internal enum SystemMetric
    {
        /// <summary>
        ///     Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
        /// </summary>
        SMSwapbutton = 23,
        /// <summary>
        ///     The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
        /// </summary>
        SMCxmaxtrack = 59,
        /// <summary>
        ///     The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
        /// </summary>
        SMCymaxtrack = 60,
        /// <summary>
        ///     The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMXvirtualscreen = 76,
        /// <summary>
        ///     The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMYvirtualscreen = 77,
        /// <summary>
        ///     The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMCxvirtualscreen = 78,
        /// <summary>
        ///     The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMCyvirtualscreen = 79
    }
}