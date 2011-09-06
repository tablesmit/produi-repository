/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using ProdUI.Session;

namespace ProdUI.Logging
{
    /// <summary>Acts to route messages</summary>
    public class ProdLogger
    {
        private static LogMessage _currentMessage;
        private static ProdLogger _thisLogger;
        private ILogTarget _logTarget;
        private LoggingLevels _logLevel;
        private string _logFormat;
        private string _logDateFormat;
        private List<LoggerParameters> _loggerParams;



        private ProdLogger() { }


        /// <summary>
        /// Creates a ProdLogger.
        /// </summary>
        /// <param name="config">The current prod configuration.</param>
        /// <param name="target">A log target.</param>
        /// <returns>
        /// A new ProdLogger
        /// </returns>
        public static ProdLogger CreateLogger(ProdSessionConfig config, ILogTarget target)
        {
            _thisLogger = new ProdLogger
                              {
                                  _logLevel = (LoggingLevels)config.Loggers[0].LogLevel,
                                  _loggerParams = config.Loggers[0].Parameters,
                                  _logFormat = config.Loggers[0].LogFormat,
                                  _logDateFormat = config.Loggers[0].LogDateFormat,
                                  _logTarget = target
                              };

            return _thisLogger;
        }

        /// <summary>
        /// Creates a ProdLogger.
        /// </summary>
        /// <param name="target">The target logger.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="logFormat">The log format.</param>
        /// <param name="logDateFormat">The log date format.</param>
        /// <returns>A new ProdLogger</returns>
        /// <remarks>This provides a way for someone to create a new logger on the fly</remarks>
        public static ProdLogger CreateLogger(ILogTarget target, LoggingLevels logLevel, string logFormat, string logDateFormat)
        {
            _thisLogger = new ProdLogger
            {
                _logLevel = logLevel,
                _loggerParams = null,
                _logFormat = logFormat,
                _logDateFormat = logDateFormat,
                _logTarget = target
            };

            return _thisLogger;
        }


        /// <summary>
        /// Writes the log message to the registered output logs
        /// </summary>
        /// <param name="msg">The log message to use</param>
        /// <param name="loggers">The List of all active ProdLoggers.</param>
        public static void Log(LogMessage msg, List<ProdLogger> loggers)
        {
            _currentMessage = msg;
            //ProdLogger logger = loggers[0];
            foreach (ProdLogger logger in loggers)
            {
                if (!VerifyLogLevel(logger))
                {
                    //return;
                    continue;
                }


                FormatOutput(logger);

                logger._logTarget.Write(_currentMessage, logger._loggerParams);
            }
        }

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="loggers">The List of all active ProdLoggers.</param>
        public static void LogException(Exception ex, List<ProdLogger> loggers)
        {
            _currentMessage = new LogMessage(ex.Message, LoggingLevels.Error);

            foreach (ProdLogger logger in loggers)
            {
                int x = (int)logger._logLevel | (int)LoggingLevels.Error;
                if (x != (int)logger._logLevel)
                {
                    return;
                }

                logger._logTarget.Write(_currentMessage, logger._loggerParams);

            }
        }


        /// <summary>
        /// Verifies the log level of the current message against the loggers level.
        /// </summary>
        /// <param name="logger">The ProdLogger.</param>
        /// <returns>
        ///   <c>true</c> if message is to be logged, <c>false</c> otherwise
        /// </returns>
        private static bool VerifyLogLevel(ProdLogger logger)
        {
            /* determine whether to log */
            int z = (int)logger._logLevel;
            int y = (int)_currentMessage.MessageLevel;
            int x = (z | y);
            if (x == (int)logger._logLevel)
                return true;
            return false;
        }

        /// <summary>
        /// Formats the output string in the loggers desired format.
        /// </summary>
        /// <param name="logger">The ProdLogger.</param>
        /// <remarks>
        /// Accessible by calling ToString() on LogMessage
        /// </remarks>
        private static void FormatOutput(ProdLogger logger)
        {
            string[] formats = logger._logFormat.Split(new[] { ',' });

            string outString = string.Empty;

            foreach (string item in formats)
            {
                if (item == "LogTime")
                {
                    /* Set the message time (formatted) */
                    DateTime logTime = DateTime.Now;
                    _currentMessage.LogTime = logTime.ToString(logger._logDateFormat, CultureInfo.CurrentCulture);

                    string tempstr = "[" + _currentMessage.LogTime + "]";
                    outString += " " + tempstr;
                    continue;
                }
                if (item == "Message Level")
                {
                    /* Get the message level */
                    outString += _currentMessage.MessageLevel.ToString();
                    continue;
                }
                if (item == "Calling Function")
                {
                    /* Get the message level */
                    outString += _currentMessage.CallingMethod;
                    continue;
                }
                if (item != "Message Text")
                {
                    continue;
                }

                /* Get the message level */
                outString += _currentMessage.Message;
                continue;
            }

            _currentMessage.OutputString = outString;
        }

    }
}
