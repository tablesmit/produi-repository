// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Collections.Generic;

namespace ProdUI.Logging
{
    /// <summary>
    /// Provides a single point for controlling logging of prods
    /// </summary>
    public static class LogController
    {
        internal static List<ProdLogger> ActiveLoggers = new List<ProdLogger>();
        private static LogMessage _CurrentMessage;

        /// <summary>
        /// Used to add a List of loggers to the controller
        /// </summary>
        /// <param name="loggers">The loggers to add.</param>
        public static void AddActiveLogger(List<ProdLogger> loggers)
        {
            if (loggers == null) return;
            ActiveLoggers.AddRange(loggers);
        }

        /// <summary>
        /// Adds a logger to the controller.
        /// </summary>
        /// <param name="newLogger">The logger to add.</param>
        public static void AddActiveLogger(ProdLogger newLogger)
        {
            if (newLogger == null) return;
            ActiveLoggers.Add(newLogger);
        }

        /// <summary>
        /// Gets the active loggers list.
        /// </summary>
        /// <returns>The List of loggers loaded into the controller</returns>
        internal static List<ProdLogger> GetActiveLoggers()
        {
            return ActiveLoggers;
        }

        /// <summary>
        /// Receives the log message from a log source (I.E. a control).
        /// </summary>
        /// <param name="message">The message to log.</param>
        internal static void ReceiveLogMessage(LogMessage message)
        {
            if (message == null) return;

            _CurrentMessage = message;
            ProcessMessage();
        }

        private static void ProcessMessage()
        {
            foreach (ProdLogger logger in ActiveLoggers)
            {
                /* determine whether to log */
                int z = (int)logger.LogLevel;
                int y = (int)_CurrentMessage.MessageLevel;
                int x = (z | y);
                if (x == (int)logger.LogLevel)
                    logger.Log(_CurrentMessage);
            }
        }
    }
}