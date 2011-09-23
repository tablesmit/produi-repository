using System;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    ///     Mouse event flags from From winuser.h
    /// </summary>
    [Flags]
    internal enum MOUSEEVENTF
    {
        /// <summary>
        ///     mouse move
        /// </summary>
        MouseeventfMove = 0x0001,
        /// <summary>
        ///     left button down
        /// </summary>
        MouseeventfLeftdown = 0x0002,
        /// <summary>
        ///     left button up
        /// </summary>
        MouseeventfLeftup = 0x0004,
        /// <summary>
        ///     right button down
        /// </summary>
        MouseeventfRightdown = 0x0008,
        /// <summary>
        ///     right button up
        /// </summary>
        MouseeventfRightup = 0x0010,
        /// <summary>
        ///     middle button down
        /// </summary>
        MouseeventfMiddledown = 0x0020,
        /// <summary>
        ///     middle button up
        /// </summary>
        MouseeventfMiddleup = 0x0040,
        /// <summary>
        ///     x button down
        /// </summary>
        MouseeventfXdown = 0x0080,
        /// <summary>
        ///     x button down
        /// </summary>
        MouseeventfXup = 0x0100,
        /// <summary>
        ///     wheel button rolled
        /// </summary>
        MouseeventfWheel = 0x0800,
        /// <summary>
        ///     absolute move
        /// </summary>
        MouseeventfAbsolute = 0x8000,
        /// <summary>
        ///     map to entire virtual desktop
        /// </summary>
        MouseeventfVirtualdesk = 0x4000
    }

    /// <summary>
    ///     Denotes which mouse button was clicked for sending events
    /// </summary>
    public enum MouseClick
    {
        /// <summary>
        ///     The left mouse button
        /// </summary>
        Left,
        /// <summary>
        ///     The right mouse button
        /// </summary>
        Right,
        /// <summary>
        ///     The middle mouse button
        /// </summary>
        Middle
    }
}