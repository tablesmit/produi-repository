/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections;
using System.Collections.Generic;
using ProdUI.Exceptions;
using ProdUI.Logging;
using System.Globalization;

namespace ProdUI.Session
{
    /// <summary>
    /// Provided to allow event monitoring and logging of any statically invoked Prods
    /// </summary>
    public sealed class ProdStaticSession
    {

        private static List<ProdLogger> _loggers;
        internal static ProdSessionConfig _Configuration;

        /* constructor */
        private ProdStaticSession(){}

        #region Properties

        /// <summary>
        /// The number of seconds to wait for a event to be raised before notification
        /// </summary>
        /// <value>The event timeout in seconds.</value>
        public static int EventTimeout { get; set; }

        /// <summary>The unique ID of this session</summary>
        public static string SessionId { get; private set; }

        /// <summary>The 'friendly' name of the session</summary>
        /// <value>The name of the session.</value>
        public static string SessionName { get; set; }

        #endregion


        /// <summary>Loads an instance of a ProdStaticSession.</summary>
        /// <param name="loggers">The List of loggers  to use during the session.</param>
        /// <returns>An instance of the ProdStaticSession</returns>
        public static ProdStaticSession Load(List<ProdLogger> loggers)
        {
            ProdStaticSession session = new ProdStaticSession();
            _loggers = loggers;

            Setup();
            return session;
        }

        /// <summary>
        /// Loads an instance of a ProdStaticSession using settings from the supplied configuration file
        /// </summary>
        /// <param name="configFile">The path to the configuration file</param>
        /// <param name="loggers">The List of loggers  to use during the session.</param>
        /// <returns>An instance of the ProdStaticSession</returns>
        public static ProdStaticSession Load(string configFile, List<ProdLogger> loggers)
        {
            ProdStaticSession session = new ProdStaticSession();
            _loggers = loggers;
            Setup(configFile);
            return session;
        }

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message text.</param>
        /// <param name="messageLevel">The message level.</param>
        public static void Log(string message, LoggingLevels messageLevel = LoggingLevels.Info)
        {
            if (_loggers == null){ throw new ProdOperationException("A static session has not been loaded"); }

            ProdLogger.Log(new LogMessage(message, messageLevel), _loggers);
        }

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message text.</param>
        /// <param name="additional">The additional information to write out if in verbose mode.</param>
        /// <param name="messageLevel">The message level.</param>
        public static void Log(string message, ArrayList additional, LoggingLevels messageLevel = LoggingLevels.Info)
        {
            if (_loggers == null) { throw new ProdOperationException("A static session has not been loaded"); }

            if (additional.Count == 0)
            {
                ProdLogger.Log(new LogMessage(message),_loggers);
            }
            else
            {
                ProdLogger.Log(new LogMessage(message, additional, messageLevel),_loggers);
            }

        }

        /// <summary>
        /// Loads a configuration file for a ProdSession, providing default values
        /// </summary>
        private static void Setup()
        {
            /* set the id and default name */
            SessionId = Guid.NewGuid().ToString("N", CultureInfo.CurrentCulture);
            SessionName = SessionId;
            EventTimeout = 12;
        }

        /// <summary>Loads a configuration file for a ProdSession</summary>
        /// <param name="configFile">The configuration file.</param>
        private static void Setup(string configFile)
        {
            _Configuration = ProdSessionConfig.LoadConfig(configFile);

            /* session configuration */
            SessionId = _Configuration.SessionId;
            SessionName = _Configuration.SessionName;
            EventTimeout = _Configuration.EventTimeout;

        }

    }
}