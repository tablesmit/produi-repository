// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdEhllapi
{
    internal static class EhllapiStructures
    {
        #region Nested type: EhllapiFunctionCode

        /// <summary>
        /// Function Name (Function Number) <see ref="http://publib.boulder.ibm.com/infocenter/pcomhelp/v5r9/index.jsp?topic=/com.ibm.pcomm.doc/books/html/emulator_programming08.htm"/>
        /// </summary>
        internal enum EhllapiFunctionCode
        {
            /// <summary>
            /// 1
            /// </summary>
            ConnectPS = 1,
            /// <summary>
            /// 2
            /// </summary>
            DisconnectPS = 2,
            /// <summary>
            /// 3
            /// </summary>
            SendKey = 3,
            /// <summary>
            /// 4
            /// </summary>
            Wait = 4,
            /// <summary>
            ///   5
            /// </summary>
            CopyPS = 5,
            /// <summary>
            ///   6
            /// </summary>
            SearchPS = 6,
            /// <summary>
            ///   7
            /// </summary>
            QueryCursorLocation = 7,
            /// <summary>
            ///   11
            /// </summary>
            Reserve = 11,
            /// <summary>
            ///   12
            /// </summary>
            Release = 12,
            /// <summary>
            ///   14
            /// </summary>
            QueryFieldAttribute = 14,
            /// <summary>
            ///   15
            /// </summary>
            CopyStringtoPS = 15,
            /// <summary>
            ///   18
            /// </summary>
            Pause = 18,
            /// <summary>
            ///   21
            /// </summary>
            ResetSystem = 21,
            /// <summary>
            ///   22
            /// </summary>
            QuerySessionStatus = 22,
            /// <summary>
            ///   23
            /// </summary>
            StartHostNotification = 23,
            /// <summary>
            ///   24
            /// </summary>
            QueryHostUpdate = 24,
            /// <summary>
            ///   25
            /// </summary>
            StopHostNotification = 25,
            /// <summary>
            ///   30
            /// </summary>
            SearchField = 30,
            /// <summary>
            ///   31
            /// </summary>
            FindFieldPosition = 31,
            /// <summary>
            ///   32
            /// </summary>
            FindFieldLength = 32,
            /// <summary>
            ///   33
            /// </summary>
            CopyStringtoField = 33,
            /// <summary>
            ///   34
            /// </summary>
            CopyFieldtoString = 34,
            /// <summary>
            ///   40
            /// </summary>
            SetCursor = 40,
            /// <summary>
            ///   60
            /// </summary>
            LockPSAPI = 60,
            /// <summary>
            ///   61
            /// </summary>
            LockWindowServicesAPI = 61,
            /// <summary>
            ///   99
            /// </summary>
            ConvertPosition = 99,
            /// <summary>
            ///   101
            /// </summary>
            ConnectWindowServices = 101,
            /// <summary>
            ///   102
            /// </summary>
            DisconnectWindowService = 102,
            /// <summary>
            ///   103
            /// </summary>
            QueryWindowCoordinates = 103,
            /// <summary>
            ///   104
            /// </summary>
            WindowStatus = 104,
        }

        #endregion Nested type: EhllapiFunctionCode
    }
}