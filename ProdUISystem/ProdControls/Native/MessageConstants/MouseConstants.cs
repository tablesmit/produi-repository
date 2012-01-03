// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Controls.Native
{
    /// <summary>
    /// Mouse event flags from From winuser.h
    /// </summary>
    [Flags]
    internal enum MOUSEEVENTF
    {
        /// <summary>
        /// mouse move
        /// </summary>
        MOUSEEVENTFMOVE = 0x0001,
        /// <summary>
        /// left button down
        /// </summary>
        MOUSEEVENTFLEFTDOWN = 0x0002,
        /// <summary>
        /// left button up
        /// </summary>
        MOUSEEVENTFLEFTUP = 0x0004,
        /// <summary>
        /// right button down
        /// </summary>
        MOUSEEVENTFRIGHTDOWN = 0x0008,
        /// <summary>
        /// right button up
        /// </summary>
        MOUSEEVENTFRIGHTUP = 0x0010,
        /// <summary>
        /// middle button down
        /// </summary>
        MOUSEEVENTFMIDDLEDOWN = 0x0020,
        /// <summary>
        /// middle button up
        /// </summary>
        MOUSEEVENTFMIDDLEUP = 0x0040,
        /// <summary>
        /// x button down
        /// </summary>
        MOUSEEVENTFXDOWN = 0x0080,
        /// <summary>
        /// x button down
        /// </summary>
        MOUSEEVENTFXUP = 0x0100,
        /// <summary>
        /// wheel button rolled
        /// </summary>
        MOUSEEVENTFWHEEL = 0x0800,
        /// <summary>
        /// absolute move
        /// </summary>
        MOUSEEVENTFABSOLUTE = 0x8000,
        /// <summary>
        /// map to entire virtual desktop
        /// </summary>
        MOUSEEVENTFVIRTUALDESK = 0x4000
    }

    /// <summary>
    /// Denotes which mouse button was clicked for sending events
    /// </summary>
    public enum MouseClick
    {
        /// <summary>
        /// The left mouse button
        /// </summary>
        Left,
        /// <summary>
        /// The right mouse button
        /// </summary>
        Right,
        /// <summary>
        /// The middle mouse button
        /// </summary>
        Middle
    }
}