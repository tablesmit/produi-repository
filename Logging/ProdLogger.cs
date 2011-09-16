/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting;
using ProdUI.Exceptions;
using ProdUI.Configuration;

namespace ProdUI.Logging
{
    /// <summary>
    /// Acts to route messages
    /// </summary>
    public class ProdLogger
    {

        private List<LoggerParameters> _loggerParams;

        public ILogTarget LogTarget { get; set; }
        public LoggingLevels LogLevel { get; set; }
        public string LogFormat { get; set; }
        public string LogDateFormat { get; set; }


        public ProdLogger(ProdSessionConfig config, ILogTarget target)
        {

            LogLevel = (LoggingLevels)config.Loggers[0].LogLevel;
            _loggerParams = config.Loggers[0].Parameters;
            LogFormat = config.Loggers[0].LogFormat;
            LogDateFormat = config.Loggers[0].LogDateFormat;
            LogTarget = target;

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
        public ProdLogger(ILogTarget target, LoggingLevels logLevel, string logFormat, string logDateFormat)
        {

            LogLevel = logLevel;
            _loggerParams = null;
            LogFormat = logFormat;
            LogDateFormat = logDateFormat;
            LogTarget = target;
        }


        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="loggers">The List of all active ProdLoggers.</param>
        internal void LogException(Exception ex, LogMessage message)
        {
            int errEnabled = (int)LogLevel | (int)LoggingLevels.Error;
            if (errEnabled != (int)LogLevel)
            {
                return;
            }

            FormatOutput(ref message);
            LogTarget.Write(message, _loggerParams);

        }

        internal void Log(LogMessage message)
        {
            FormatOutput(ref message);
            LogTarget.Write(message, _loggerParams);
        }

        /// <summary>
        /// Formats the output string in the loggers desired format.
        /// </summary>
        /// <param name="logger">The ProdLogger.</param>
        /// <remarks>
        /// Accessible by calling ToString() on LogMessage
        /// </remarks>
        private void FormatOutput(ref LogMessage message)
        {
            string[] formats = LogFormat.Split(new[] { ',' });

            string outString = string.Empty;

            foreach (string item in formats)
            {
                if (item == "LogTime")
                {
                    /* Set the message time (formatted) */
                    DateTime logTime = DateTime.Now;
                    message.LogTime = logTime.ToString(LogDateFormat, CultureInfo.CurrentCulture);

                    string tempstr = "[" + message.LogTime + "]";
                    outString += " " + tempstr;
                    continue;
                }
                if (item == "Message Level")
                {
                    /* Get the message level */
                    outString += message.MessageLevel.ToString();
                    continue;
                }
                if (item == "Calling Function")
                {
                    /* Get the message level */
                    outString += message.CallingMethod;
                    continue;
                }
                if (item != "Message Text")
                {
                    continue;
                }

                /* Get the message level */
                outString += message.Message;
                continue;
            }

            message.OutputString = outString;
        }
    }
}
