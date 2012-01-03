// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdUI.Controls.Native
{
    /// <summary>
    /// Used for the nIndex parameter in the GetSystemMetrics call. this is only a partial list. http://msdn.microsoft.com/en-us/library/ms724385(VS.85).aspx
    /// </summary>
    internal enum SystemMetric
    {
        /// <summary>
        /// Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
        /// </summary>
        SMSWAPBUTTON = 23,
        /// <summary>
        /// The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
        /// </summary>
        SMCXMAXTRACK = 59,
        /// <summary>
        /// The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
        /// </summary>
        SMCYMAXTRACK = 60,
        /// <summary>
        /// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMXVIRTUALSCREEN = 76,
        /// <summary>
        /// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMYVIRTUALSCREEN = 77,
        /// <summary>
        /// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMCXVIRTUALSCREEN = 78,
        /// <summary>
        /// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors
        /// </summary>
        SMCYVIRTUALSCREEN = 79
    }
}