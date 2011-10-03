// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Interaction.Native
{
    /// <summary>
    /// Win32 Button state constants
    /// </summary>
    [Flags]
    internal enum ButtonStates
    {
        /// <summary>
        /// No special state. Equivalent to zero.
        /// </summary>
        BSTUNCHECKED = 0x0000,
        /// <summary>
        /// The button is checked.
        /// </summary>
        BSTCHECKED = 0x0001,
        /// <summary>
        /// The state of the button is indeterminate. Applies only if the button has the BS_3STATE or BS_AUTO3STATE style.
        /// </summary>
        BSTINDETERMINATE = 0x0002,
        /// <summary>
        /// The button is being shown in the pushed state.
        /// </summary>
        BSTPUSHED = 0x0004,
        /// <summary>
        /// The button has the keyboard focus.
        /// </summary>
        BSTFOCUS = 0x0008,
        /// <summary>
        /// Windows Vista. The button is in the drop-down state. Applies only if the button has the TBSTYLE_DROPDOWN style.
        /// </summary>
        BSTDROPDOWNPUSHED = 0x0400
    }

    /// <summary>
    /// Win32 button message constants
    /// </summary>
    internal enum ButtonMessage
    {
        BMGETCHECK = 0x00F0,
        /// <summary>
        /// Sets the check state of a radio button or check box.
        /// </summary>
        BMSETCHECK = 0x00F1,
        /// <summary>
        /// Sends the button a WM_LBUTTONDOWN and a WM_LBUTTONUP message, and sends the parent window a BN_CLICKED notification code.
        /// </summary>
        BMCLICK = 0x00F5,
        /// <summary>
        /// Returns the current check state, push state, and focus state of the button.
        /// </summary>
        BMGETSTATE = 0x00F2,
        /// <summary>
        /// Sets the highlight state of a button. The highlight state indicates whether the button is highlighted as if the user had pushed it.
        /// </summary>
        BMSETSTATE = 0x00F3,
        /// <summary>
        /// Retrieves a handle to the image (icon or bitmap) associated with the button.
        /// </summary>
        BMGETIMAGE = 0x00F6
    }
}