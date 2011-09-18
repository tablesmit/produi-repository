// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;

namespace ProdUI.Logging
{
    /// <summary>
    ///     Determines which messages are logged and which are filtered out.
    ///     "OR ing" values allows multiple message types
    /// </summary>
    /// <example>
    ///     Setting level to: <code>LoggingLevel.Error | LoggingLevel.Prod</code> would only log prods and errors, ignoring the rest
    /// </example>
    [Flags]
    public enum LoggingLevels
    {
        /// <summary>
        ///     Log Exceptions and Errors
        /// </summary>
        Error = 1,
        /// <summary>
        ///     Log Warnings, symptoms of system instability
        /// </summary>
        Warn = 2,
        /// <summary>
        ///     Log any informational messages from ProdUI. Designed for use by developers to assign any custom messages
        /// </summary>
        Info = 4,
        /// <summary>
        ///     Log whenever a control performs a prod
        /// </summary>
        Prod = 8,
        /// <summary>
        ///     Will include the Error,Info and Prod message types
        /// </summary>
        Default = (Error | Info | Prod),
        /// <summary>
        ///     Log Nothing
        /// </summary>
        Off = 16,
    }

    /// <summary>
    ///     Determines how much information to log
    /// </summary>
    public enum LoggingVerbosity
    {
        /// <summary>
        ///     Default. shows errors and actions
        /// </summary>
        Minimum = 1,
        /// <summary>
        ///     This will include a dump of returned items when a "GetItems" call is made
        /// </summary>
        Maximum = 2,
    }
}