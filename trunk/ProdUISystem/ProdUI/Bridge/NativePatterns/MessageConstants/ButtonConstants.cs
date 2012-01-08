// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;

namespace ProdUI.Bridge.NativePatterns
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
        BST_UNCHECKED = 0x0000,
        /// <summary>
        /// The button is checked.
        /// </summary>
        BST_CHECKED = 0x0001,
        /// <summary>
        /// The state of the button is indeterminate. Applies only if the button has the BS_3STATE or BS_AUTO3STATE style.
        /// </summary>
        BST_INDETERMINATE = 0x0002,
        /// <summary>
        /// The button is being shown in the pushed state.
        /// </summary>
        BST_PUSHED = 0x0004,
        /// <summary>
        /// The button has the keyboard focus.
        /// </summary>
        BST_FOCUS = 0x0008,
        /// <summary>
        /// Windows Vista. The button is in the drop-down state. Applies only if the button has the TBSTYLE_DROPDOWN style.
        /// </summary>
        BST_DROPDOWNPUSHED = 0x0400
    }

    /// <summary>
    /// Win32 button message constants
    /// </summary>
    internal enum ButtonMessages
    {
        BM_GETCHECK = 0x00F0,
        /// <summary>
        /// Sets the check state of a radio button or check box.
        /// </summary>
        BM_SETCHECK = 0x00F1,
        /// <summary>
        /// Sends the button a WM_LBUTTONDOWN and a WM_LBUTTONUP message, and sends the parent window a BN_CLICKED notification code.
        /// </summary>
        BM_CLICK = 0x00F5,
        /// <summary>
        /// Returns the current check state, push state, and focus state of the button.
        /// </summary>
        BM_GETSTATE = 0x00F2,
        /// <summary>
        /// Sets the highlight state of a button. The highlight state indicates whether the button is highlighted as if the user had pushed it.
        /// </summary>
        BM_SETSTATE = 0x00F3,
        /// <summary>
        /// Retrieves a handle to the image (icon or bitmap) associated with the button.
        /// </summary>
        BM_GETIMAGE = 0x00F6
    }
}