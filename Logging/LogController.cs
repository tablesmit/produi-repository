// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Collections.Generic;

namespace ProdUI.Logging
{
    internal static class LogController
    {
        internal static List<ProdLogger> ActiveLoggers;
        private static LogMessage _CurrentMessage;

        internal static void AddActiveLogger(List<ProdLogger> loggers)
        {
            if (loggers == null) return;
            ActiveLoggers.AddRange(loggers);
        }

        internal static  void AddActiveLogger(ProdLogger newLogger)
        {
            if (newLogger == null) return;
            ActiveLoggers.Add(newLogger);
        }

        internal static List<ProdLogger> GetActiveLoggers()
        {
            return ActiveLoggers;
        }

        internal static void ReceiveLogMessage(LogMessage message)
        {
            if (message == null) return;

            _CurrentMessage = message;
            ProcessMessage();
        }

        private static  void ProcessMessage()
        {
            foreach (ProdLogger logger in ActiveLoggers)
            {
                /* determine whether to log */
                int z = (int) logger.LogLevel;
                int y = (int) _CurrentMessage.MessageLevel;
                int x = (z | y);
                if (x == (int) logger.LogLevel)
                    logger.Log(_CurrentMessage);
            }
        }
    }
}