namespace ProdUI.Bridge.NativePatterns
{
    //ReSharper disable InconsistentNaming

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/bb775458(v=VS.85).aspx
    /// </summary>
    internal enum EditControlMessages
    {
        EM_CANUNDO = 0x00C6,
        EM_CHARFROMPOS = 0x00D7,
        EM_EMPTYUNDOBUFFER = 0x00CD,
        EM_FMTLINES = 0x00C8,

        /// <summary>
        /// Gets the zero-based index of the uppermost visible line in a multiline edit control. You can send this message to either an edit control or a rich edit control.
        /// wParam:Not used; must be zero.
        /// lParam:Not used; must be zero.
        /// The return value is the zero-based index of the uppermost visible line in a multiline edit control.
        /// Edit controls: For single-line edit controls, the return value is the zero-based index of the first visible character.
        /// Rich edit controls: For single-line rich edit controls, the return value is zero.
        /// </summary>
        /// <remarks>
        /// The number of lines and the length of the lines in an edit control depend on the width of the control and the current Wordwrap setting.
        /// </remarks>
        EM_GETFIRSTVISIBLELINE = 0x00CE,
        EM_GETHANDLE = 0x00BD,
        EM_GETIMESTATUS = 0x00D9,
        EM_GETLIMITTEXT = 0x00D5,

        /// <summary>
        /// Copies a line of text from an edit control and places it in a specified buffer. You can send this message to either an edit control or a rich edit control.
        /// wParam: The zero-based index of the line to retrieve from a multiline edit control. A value of zero specifies the topmost line. This parameter is ignored by a single-line edit control.
        /// lParam: A pointer to the buffer that receives a copy of the line. Before sending the message, set the first word of this buffer to the size, in TCHARs, of the buffer. For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters. The size in the first word is overwritten by the copied line.
        /// The return value is the number of TCHARs copied. The return value is zero if the line number specified by the wParam parameter is greater than the number of lines in the edit control.
        /// </summary>
        /// <remarks>
        /// Edit controls: The copied line does not contain a terminating null character.
        /// Rich edit controls:The copied line does not contain a terminating null character, unless no text was copied. If no text was copied, the message places a null character at the beginning of the buffer.
        /// </remarks>
        EM_GETLINE = 0x00C4,
        EM_GETLINECOUNT = 0x00BA,
        EM_GETMARGINS = 0x00D4,
        EM_GETMODIFY = 0x00B8,
        EM_GETPASSWORDCHAR = 0x00D2,
        EM_GETRECT = 0x00B2,
        EM_GETSEL = 0x00B0,
        EM_GETTHUMB = 0x00BE,
        EM_GETWORDBREAKPROC = 0x00D1,
        EM_LIMITTEXT = 0x00C5,
        EM_LINEFROMCHAR = 0x00C9,
        EM_LINEINDEX = 0x00BB,
        EM_LINELENGTH = 0x00C1,
        EM_LINESCROLL = 0x00B6,
        EM_POSFROMCHAR = 0x00D6,
        EM_REPLACESEL = 0x00C2,
        EM_SCROLL = 0x00B5,
        EM_SCROLLCARET = 0x00B7,
        EM_SETHANDLE = 0x00BC,
        EM_SETIMESTATUS = 0x00D8,
        EM_SETLIMITTEXT = EM_LIMITTEXT,
        EM_SETMARGINS = 0x00D3,
        EM_SETMODIFY = 0x00B9,
        EM_SETPASSWORDCHAR = 0x00CC,
        EM_SETREADONLY = 0x00CF,
        EM_SETRECT = 0x00B3,
        EM_SETRECTNP = 0x00B4,
        EM_SETSEL = 0x00B1,
        EM_SETTABSTOPS = 0x00CB,
        EM_SETWORDBREAKPROC = 0x00D0,
        EM_UNDO = 0x00C7
    }

    // ReSharper restore InconsistentNaming
}