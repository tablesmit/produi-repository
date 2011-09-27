// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace ProdEhllapi
{
    /// <summary>
    /// Contains functions for working with the EHLLAPI
    /// </summary>
    public class EhllapiFunctions
    {
        private char _sessionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="EhllapiFunctions"/> class.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        public EhllapiFunctions(char sessionId)
        {
            _sessionId = sessionId;
        }

        #region Connection and Session functions

        /// <summary>
        /// The Connect Presentation Space function establishes a connection between your EHLLAPI application program and the host presentation space
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0  The Connect Presentation Space function was successful; the host presentation space is unlocked and ready for input.
        /// 1  An incorrect host presentation space ID was specified. The specified session either does not exist or is a logical printer session. This return code could also mean that the API Setting for DDE/EHLLAPI is not set on.
        /// 4  Successful connection was achieved, but the host presentation space is busy.
        /// 5  Successful connection was achieved, but the host presentation space is locked (input inhibited).
        /// 9  A system error was encountered.
        /// 11 This resource is unavailable. The host presentation space is already being used by another system function.
        ///   </pre>
        /// </remarks>
        public int ConnectPS()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.ConnectPS;
            int len = 1;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref _sessionId, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Converts the host presentation space positional value into the display row and column coordinates
        /// </summary>
        /// <param name="psCoord">The Presentation Space coord.</param>
        /// <returns>
        /// location as a 2 element array = row,column
        /// </returns>
        public int[] ConvertToRowCol(int psCoord)
        {
            /* Using math instead of ConvertPosition() because I cant get it to work :( */

            int row = (psCoord / 80) + 1;
            int col = psCoord - ((row - 1) * 80);

            int[] position = { row, col };

            return position;
        }

        /// <summary>
        /// Converts the display row and column coordinates into the host presentation space positional value
        /// </summary>
        /// <param name="row">Row location</param>
        /// <param name="col">Column location</param>
        /// <returns> The host presentation space positional value</returns>
        public int ConvertToPSPosition(int row, int col)
        {
            int ps = ((row - 1) * 80) + col;

            return ps;
        }

        /// <summary>
        /// The Disconnect Presentation Space function drops the connection between your EHLLAPI application program and the host presentation space. Also, if a host presentation space is reserved using the Reserve (11) function, it is released upon execution of the Disconnect Presentation Space function.
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0  The Disconnect Presentation Space function was successful.
        /// 1  Your program was not currently connected to the host presentation space.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int DisconnectPS()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.DisconnectPS;
            string dataString = string.Empty;
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// allows the application to obtain or release exclusive control of the presentation space window over other Windows 32-bit applications. While locked, no other application can connect to the presentation space window
        /// </summary>
        /// <param name="lockSpace">if set to <c>true</c> [lock space].</param>
        /// <returns>
        ///   <pre>
        /// 0  The Lock Presentation Space API function was successful.
        /// 1  An incorrect host presentation space short session ID was specified or was not connected.
        /// 2  An error was made in specifying parameters.
        /// 9  A system error was encountered.
        /// 43  The API was already locked by another EHLLAPI application (on LOCK) or API not locked (on UNLOCK).
        ///   </pre>
        /// </returns>
        public int LockPsapi(bool lockSpace)
        {
            int func = (int)EhllapiStructures.EhllapiFunctionCode.LockPSAPI;

            string lockFlag = lockSpace
                                  ? "L"
                                  : "U";

            string queryData = _sessionId + string.Empty + lockFlag + "R" + string.Empty;
            int len = 3;
            int rc = 0;

            NativeMethods.hllapi(ref func, ref queryData, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Waits for a specified amount of time. It should be used in place of timing loops to wait for an event to occur
        /// </summary>
        /// <param name="length">The length of time to pause</param>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0 - The wait duration has expired.
        /// 9 - An internal system error was encountered. The time results are unpredictable.
        /// 26 - The host session presentation space or OIA has been updated
        ///   </pre>
        /// </remarks>
        public int Pause(double length)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.Pause;
            string dataString = string.Empty;
            int len = (int)length;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// The Query Session Status function is used to obtain session-specific information
        /// </summary>
        /// <returns></returns>
        public StringBuilder QuerySessionStatus()
        {
            int func = (int)EhllapiStructures.EhllapiFunctionCode.QuerySessionStatus;

            //Pre-allocated target string the size of your host presentation space. This can vary depending on how your host presentation space is configured. When the Set Session Parameters (9) function with the EAB option is issued, the length of the data string must be at least twice the length of the presentation space.
            StringBuilder queryData = new StringBuilder();
            int len = 20;
            int rc = 0;
            queryData.Append('*');

            NativeMethods.hllapi(ref func, queryData, ref len, ref rc);

            return queryData;
        }

        /// <summary>
        /// The Release function unlocks the keyboard that is associated with the host presentation space reserved using the Reserve (11) function
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0  The Release function was successful.
        /// 1  Your program is not connected to a host session.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int Release()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.Release;
            String queryData = string.Empty;
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// The Reserve function locks the keyboard that is associated with the host-connected presentation space to block input from the terminal operator
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// 0  The Reserve function was successful.
        /// 1  Your program is not connected to a host session.
        /// 5  Presentation space cannot be used.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int Reserve()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.Reserve;
            String queryData = string.Empty;
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);
            return rc;
        }

        /// <summary>
        /// Reinitializes EHLLAPI to its starting state
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0 - The Reset System function was successful.
        /// 1 - EHLLAPI is not loaded.
        /// 9 - A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int ResetSystem()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.ResetSystem;
            String queryData = string.Empty;
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);
            return rc;
        }

        /// <summary>
        /// The Wait function checks the status of the host-connected presentation space.
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        /// If the session is waiting for a host response (indicated by XCLOCK (X []) or XSYSTEM), the Wait function causes EHLLAPI to wait up to 1 minute to see if the condition clears
        /// <pre>
        /// Return codes:
        /// 0  The keyboard is unlocked and ready for input.
        /// 1  Your application program is not connected to a valid session.
        /// 4  Timeout while still in XCLOCK (X []) or XSYSTEM.
        /// 5  The keyboard is locked.
        /// 9  A system error was encountered.
        /// </pre>
        /// </remarks>
        public int Wait()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.Wait;
            String queryData = string.Empty;
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);

            return rc;
        }

        #endregion Connection and Session functions

        #region Searching, cursor, and text

        /// <summary>
        /// Copies an ASCII data string directly into the host presentation space
        /// </summary>
        /// <param name="text">The text to place on Presentation Space.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0  The Copy String to Presentation Space function was successful.
        /// 1  Your program is not connected to a host session.
        /// 2  Parameter error or zero length for copy.
        /// 5  The target presentation space is protected or inhibited, or incorrect data was sent to the target presentation space (such as a field attribute byte).
        /// 6  The copy was completed, but the data was truncated.
        /// 7  The host presentation space position is not valid.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int CopyStringtoPS(string text, int row, int col)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.CopyStringtoPS;
            string dataString = text;
            int len = text.Length;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Copies the contents of the host-connected presentation space into a data string that you define in your EHLLAPI application program
        /// </summary>
        /// <returns>
        /// The contents of the entire presentation space
        /// </returns>
        public StringBuilder CopyPS()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.CopyPS;
            //Pre allocated target string the size of your host presentation space. This can vary depending on how your host presentation space is configured. When the Set Session Parameters (9) function with the EAB option is issued, the length of the data string must be at least twice the length of the presentation space.
            StringBuilder dataString = new StringBuilder(3000);
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, dataString, ref len, ref rc);
            Debug.WriteLine(rc.ToString(CultureInfo.CurrentCulture));
            return dataString;

            /*
            0  The host presentation space contents were copied to the application program. The target presentation space was active, and the keyboard was unlocked.
            1  Your program is not connected to a host session.
            4  The host presentation space contents were copied. The connected host presentation space was waiting for host response.
            5  The host presentation space was copied. The keyboard was locked.
            9  A system error was encountered.
            */
        }

        /// <summary>
        /// Determines where the cursor is located in the presentation space, expressed as an offset from the beginning the presentation space.
        /// </summary>
        /// <returns>
        /// Cursor location as an offset from the beginning the presentation space
        /// </returns>
        public int QueryCursorLocation()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.QueryCursorLocation;
            String queryData = string.Empty;
            int len = 0;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);

            return len;
        }

        /// <summary>
        /// Returns the attribute byte of the field containing the input host presentation space position
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <returns>
        /// The decimal value of the return from the emulator
        /// </returns>
        /// <remarks>
        /// The return value will need to be converted to binary and that value use with the clients inplementation of the result of this call
        /// </remarks>
        public int QueryFieldAttribute(char sessionId, int row, int col)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.QueryFieldAttribute;
            String queryData = string.Empty;
            int len = 0;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);

            return len;
        }

        /// <summary>
        /// Lets your EHLLAPI program examine the host presentation space for the occurrence of a specified string
        /// </summary>
        /// <param name="searchText">Text to search for</param>
        /// <returns>
        /// 0 - The string was not found. -1 for error, otherwise, the presentation space location of the string
        /// </returns>
        public int SearchPS(string searchText)
        {
            int func = (int)EhllapiStructures.EhllapiFunctionCode.SearchPS;
            StringBuilder queryData = new StringBuilder();
            queryData.Append(searchText);
            int len = searchText.Length;
            int rc = 0;

            NativeMethods.hllapi(ref func, queryData, ref len, ref rc);

            if (rc == 0)
            {
                return len;
            }
            //Return code contains the error
            return -1;
        }

        /// <summary>
        /// The Send Key function is used to send either a keystroke or a string of keystrokes to the host presentation space
        /// </summary>
        /// <param name="keyStrokes">A string of keystrokes, maximum 255. Uppercase and lowercase ASCII characters are represented literally.
        /// Function keys and shifted function keys are represented by mnemonics</param>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return codes:
        /// 0  The keystrokes were sent; status is normal.
        /// 1  Your program is not connected to a host session.
        /// 2  An incorrect parameter was passed to EHLLAPI.
        /// 4  The host session was busy; all of the keystrokes could not be sent.
        /// 5  Input to the target session was inhibited or rejected; all of the keystrokes could not be sent.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int SendKey(string keyStrokes)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.SendKey;
            String queryData = keyStrokes;
            int len = keyStrokes.Length;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);
            return rc;
        }

        /// <summary>
        /// Used to set the position of the cursor within the host presentation space.
        /// Before using the Set Cursor function, a workstation application must be connected to the host presentation
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// 0  Cursor was successfully located at the specified position.
        /// 1  Your program is not connected to a host session.
        /// 4  The session is busy.
        /// 7  A cursor location less than 1 or greater than the size of the connected host presentation space was specified.
        /// 9  A system error occurred.
        ///   </pre>
        /// </remarks>
        public int SetCursor(int row, int col)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.SetCursor;
            String queryData = string.Empty;
            int len = 0;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);

            return rc;
        }

        #endregion Searching, cursor, and text

        #region field formatted

        /// <summary>
        /// Function transfers a string of characters into a specified field in the host-connected presentation space.
        /// </summary>
        /// <param name="row">The fields row.</param>
        /// <param name="col">The fields column.</param>
        /// <param name="text">The text to copy to field.</param>
        /// <returns>
        /// 0 if string not found, location otherwise
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// This function can be used only in a field-formatted host presentation space
        /// Return Codes:
        /// 0  The Copy String to Field function was successful.
        /// 1  Your program is not connected to a host session.
        /// 2  Parameter error or zero length for copy.
        /// 5  The target field was protected or inhibited, or incorrect data was sent to the target field (such as a field attribute).
        /// 6  Copy was completed, but data is truncated.
        /// 7  The host presentation space position is not valid.
        /// 9  A system error was encountered.
        /// 24  Unformatted host presentation space.
        ///   </pre>
        /// </remarks>
        public int CopyStringtoField(int row, int col, string text)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.CopyStringtoField;

            string dataString = text;
            int len = text.Length;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc == 0
                       ? len
                       : rc;
        }

        /// <summary>
        /// Function transfers a string of characters into the current field in the host-connected presentation space.
        /// </summary>
        /// <param name="text">The text to copy to field.</param>
        /// <returns>
        /// 0 if string not found, location otherwise
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// This function can be used only in a field-formatted host presentation space
        /// Return Codes:
        /// 0  The Copy String to Field function was successful.
        /// 1  Your program is not connected to a host session.
        /// 2  Parameter error or zero length for copy.
        /// 5  The target field was protected or inhibited, or incorrect data was sent to the target field (such as a field attribute).
        /// 6  Copy was completed, but data is truncated.
        /// 7  The host presentation space position is not valid.
        /// 9  A system error was encountered.
        /// 24  Unformatted host presentation space.
        ///   </pre>
        /// </remarks>
        public int CopyStringtoField(string text)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.CopyStringtoField;

            string dataString = text;
            int len = text.Length;
            int rc = QueryCursorLocation();

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Transfers characters from a field in the host-connected presentation space into a string
        /// </summary>
        /// <param name="row">The fields row.</param>
        /// <param name="col">The fields column.</param>
        /// <returns></returns>
        public string CopyFieldtoString(int row, int col)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.CopyFieldtoString;

            StringBuilder dataString = new StringBuilder(20);
            int len = dataString.Length;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, dataString, ref len, ref rc);

            return rc == 0
                       ? dataString.ToString()
                       : null;
        }

        /// <summary>
        /// Transfers characters from the current field in the host-connected presentation space into a string
        /// </summary>
        /// <returns></returns>
        public string CopyFieldtoString()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.CopyFieldtoString;

            StringBuilder dataString = new StringBuilder(20);
            int len = dataString.Length;
            int rc = QueryCursorLocation();

            NativeMethods.hllapi(ref function, dataString, ref len, ref rc);

            return rc == 0
                       ? dataString.ToString()
                       : null;
        }

        /// <summary>
        /// Returns the beginning position of a target field in the host-connected presentation space.
        /// </summary>
        /// <param name="row">The fields row.</param>
        /// <param name="col">The fields column.</param>
        /// <returns>
        /// Beginning position of the current field
        /// </returns>
        /// <remarks>
        /// This function can be used to find either protected or unprotected fields but only in a field-formatted host presentation space
        /// </remarks>
        public int FindFieldPosition(int row, int col)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.FindFieldPosition;

            string dataString = "T ";
            int len = 0;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            //Relative position of the requested field from the origin of the host presentation space. This position is defined to be the first position after the attribute byte
            return len;
        }

        /// <summary>
        /// Returns the beginning position of the current field in the host-connected presentation space.
        /// </summary>
        /// <returns>
        /// Beginning position of the current field
        /// </returns>
        /// <remarks>
        /// This function can be used to find either protected or unprotected fields but only in a field-formatted host presentation space
        /// </remarks>
        public int FindFieldPosition()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.FindFieldPosition;

            string dataString = "T ";
            int len = 0;
            int rc = QueryCursorLocation();

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            //Relative position of the requested field from the origin of the host presentation space. This position is defined to be the first position after the attribute byte
            return len;
        }

        /// <summary>
        /// Returns the length of a target field in the connected presentation space.
        /// </summary>
        /// <param name="row">The fields row.</param>
        /// <param name="col">The fields column.</param>
        /// <returns>
        /// length of target field
        /// </returns>
        /// <remarks>
        /// This function can be used to find either protected or unprotected fields but only in a field-formatted host presentation space
        /// </remarks>
        public int FindFieldLength(int row, int col)
        {
            int rc = ConvertToPSPosition(row, col);
            string dataString = "T ";
            int len = 0;
            int function = (int)EhllapiStructures.EhllapiFunctionCode.FindFieldLength;
            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc == 0
                       ? len
                       : rc;
        }

        /// <summary>
        /// Returns the length of the field where the cursor is currently located in the connected presentation space.
        /// </summary>
        /// <returns>
        /// Length of the current field
        /// </returns>
        /// <remarks>
        /// This function can be used to find either protected or unprotected fields but only in a field-formatted host presentation space
        /// </remarks>
        public int FindFieldLength()
        {
            int rc = QueryCursorLocation();
            string dataString = "T ";
            int len = 0;
            int function = (int)EhllapiStructures.EhllapiFunctionCode.FindFieldLength;
            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);

            return rc == 0
                       ? len
                       : rc;
        }

        /// <summary>
        /// Examines a field within the connected host presentation space for the occurrence of a specified string.
        /// </summary>
        /// <param name="row">The fields row.</param>
        /// <param name="col">The fields column.</param>
        /// <param name="searchText">The search text.</param>
        /// <returns>
        /// 0 if string not found, location otherwise
        /// </returns>
        /// <remarks>
        /// If the target string is found, this function returns the decimal position of the string numbered from the beginning of the host presentation space
        /// </remarks>
        public int SearchField(int row, int col, string searchText)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.SearchField;
            string dataString = searchText;
            int len = searchText.Length;
            int rc = ConvertToPSPosition(row, col);

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);
            return len;
        }

        /// <summary>
        /// Examines the current field within the connected host presentation space for the occurrence of a specified string.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>
        /// 0 if string not found, location otherwise
        /// </returns>
        /// <remarks>
        /// If the target string is found, this function returns the decimal position of the string numbered from the beginning of the host presentation space
        /// </remarks>
        public int SearchField(string searchText)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.SearchField;
            string dataString = searchText;
            int len = searchText.Length;
            int rc = QueryCursorLocation();

            NativeMethods.hllapi(ref function, ref dataString, ref len, ref rc);
            return len;
        }

        #endregion field formatted

        #region Window Services

        /// <summary>
        /// Activates the emulators window
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        /// Prerequisite Calls: ConnectWindowServices()
        /// <pre>
        /// Return Codes:
        /// 0  The Window Status function was successful.
        /// 1  The presentation space was not valid or not connected.
        /// 2  An incorrect option was specified.
        /// 9  A system error occurred.
        /// 12 The session stopped.
        /// </pre>
        /// </remarks>
        internal int ActivateEmulatorWindow()
        {
            string dataString = _sessionId + string.Empty + "010080";
            int func = (int)EhllapiStructures.EhllapiFunctionCode.WindowStatus;
            int len = 17;
            int rc = 0;

            NativeMethods.hllapi(ref func, ref dataString, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// The Connect Window Services function allows the application to manage the presentation space windows.
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        /// Only one EHLLAPI application at a time can be connected to a presentation space for window services.
        /// An EHLLAPI application can connect to more than one presentation space concurrently for window services.
        /// <pre>
        /// Return Codes:
        /// 0  The Connect Window Services function was successful.
        /// 1  An incorrect host presentation space short session ID was specified, or the Sessions Window Services manager was not connected. This return code could also mean that the API Setting for DDE/EHLLAPI is not set on.
        /// 9  A system error occurred.
        /// 10  The function is not supported by the emulation program.
        /// 11  This resource is unavailable. The host presentation space is already being used by another system function.
        /// </pre>
        /// </remarks>
        public int ConnectWindowServices()
        {
            int func = (int)EhllapiStructures.EhllapiFunctionCode.ConnectWindowServices;
            int len = 1;
            int rc = 0;

            NativeMethods.hllapi(ref func, ref _sessionId, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// The Disconnect Window Service function disconnects the window services connection between the EHLLAPI program and the specified host presentation space window.
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        /// Prerequisite Calls: ConnectWindowServices()
        /// <pre>
        /// Return Codes:
        /// 0  The Disconnect Window Service function was successful.
        /// 1  Your program is not connected for Window Services.
        /// 9  A system error occurred.
        /// </pre>
        /// </remarks>
        public int DisconnectWindowService()
        {
            int func = (int)EhllapiStructures.EhllapiFunctionCode.DisconnectWindowService;
            int len = 1;
            int rc = 0;

            NativeMethods.hllapi(ref func, ref _sessionId, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Allows the application to obtain or release exclusive control of the presentation space window over other Windows 32-bit applications.
        /// While locked, no other application can connect to the presentation space window
        /// </summary>
        /// <param name="lockSpace">if set to <c>true</c> [lock space].</param>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        /// Prerequisite Calls: ConnectWindowServices()
        /// <pre>
        /// Return Codes:
        /// 0  The Lock Window Services API function was successful.
        /// 1  An incorrect host presentation space short session ID was specified or was not connected.
        /// 2  An error was made in specifying parameters.
        /// 9  A system error was encountered.
        /// 38 Requested function was not complete.
        /// 43 The API was already locked by another EHLLAPI application (on LOCK) or API not locked (on UNLOCK).
        /// </pre>
        /// </remarks>
        public int LockWindowServicesApi(bool lockSpace)
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.LockWindowServicesAPI;

            string lockFlag = lockSpace
                                  ? "L"
                                  : "U";

            string queryData = _sessionId + string.Empty + lockFlag + "R" + string.Empty;
            int len = 3;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref queryData, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// requests the coordinates for the window of a presentation space. The window coordinates are returned in pels.
        /// </summary>
        /// <returns>
        ///   <pre>
        /// returns a data string:
        /// Byte   Definition
        /// 1      One of the following values:
        /// A 1-character presentation space short session ID
        /// A blank or null indicating a function call for the current connection presentation space
        /// 2-4    Reserved
        /// 2-17   Four 32-bit unsigned integers that return:
        /// 2-5    XLeft Long integer in pels of the left X coordinate of the rectangular window relative to the desktop window
        /// 6-9    YBottom Long integer in pels of the bottom Y coordinate of the rectangular window relative to the desktop window
        /// 10-13  XRight Long integer in pels of the right X coordinate of the rectangular window relative to the desktop window
        /// 14-17  YTop Long integer in pels of the top Y coordinate of the rectangular window relative to the desktop window
        ///   </pre>
        /// </returns>
        /// <remarks>
        /// Prerequisite Calls: ConnectWindowServices()
        /// </remarks>
        public string QueryWindowCoordinates()
        {
            string dataString = _sessionId.ToString(CultureInfo.CurrentCulture);
            int func = (int)EhllapiStructures.EhllapiFunctionCode.QueryWindowCoordinates;
            int len = 17;
            int rc = 0;

            NativeMethods.hllapi(ref func, ref dataString, ref len, ref rc);

            return dataString;
        }

        #endregion Window Services

        /// <summary>
        /// Begins the process by which your EHLLAPI application program determines if the host presentation space has been updated.
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Return Codes:
        /// 0  The Start Host Notification function was successful.
        /// 1  An incorrect host presentation space was specified.
        /// 2  An error was made in designating parameters.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int StartHostNotification()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.StartHostNotification;
            string dataString = _sessionId + string.Empty + string.Empty + string.Empty + "P";
            int len = 6;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref _sessionId, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Determines if the host has updated the host presentation space
        /// </summary>
        /// <returns>
        /// 0 if no update has been made, 22 if the presentation space was updated. anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// Prerequisite Calls: StartHostNotification()
        /// Return Codes:
        /// 0  No updates have been made since the last call.
        /// 1  An incorrect host presentation space was specified.
        /// 8  No prior Start Host Notification (23) function was called for the host presentation space ID.
        /// 9  A system error was encountered.
        /// 21  The OIA was updated.
        /// 22  The presentation space was updated.
        /// 23  Both the OIA and the host presentation space were updated.
        /// 44  Printing has completed in the printer session.
        ///   </pre>
        /// </remarks>
        public int QueryHostUpdate()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.QueryHostUpdate;
            string dataString = _sessionId.ToString(CultureInfo.CurrentCulture);
            int len = 1;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref _sessionId, ref len, ref rc);

            return rc;
        }

        /// <summary>
        /// Disables the capability of the Query Host Update (24) function to determine if the host presentation space has been updated
        /// </summary>
        /// <returns>
        /// 0 if successful, anything else for an error
        /// </returns>
        /// <remarks>
        ///   <pre>
        /// This function also stops host events from affecting the Pause (18) function
        /// 0  The Stop Host Notification function was successful.
        /// 1  An incorrect host presentation space was specified.
        /// 8  No previous Start Host Notification (23) function was issued.
        /// 9  A system error was encountered.
        ///   </pre>
        /// </remarks>
        public int StopHostNotification()
        {
            int function = (int)EhllapiStructures.EhllapiFunctionCode.StopHostNotification;
            string dataString = _sessionId + string.Empty;
            int len = 1;
            int rc = 0;

            NativeMethods.hllapi(ref function, ref _sessionId, ref len, ref rc);

            return rc;
        }
    }
}