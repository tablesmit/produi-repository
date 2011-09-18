// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Collections.Generic;

namespace ProdUI.Logging
{
    internal class LogController
    {
        internal static List<ProdLogger> ActiveLoggers;
        private LogMessage _CurrentMessage;

        private LogController()
        {
        }

        internal static LogController Create(List<ProdLogger> loggers)
        {
            ActiveLoggers = loggers;
            return new LogController();
        }

        internal List<ProdLogger> GetActiveLoggers()
        {
            return ActiveLoggers;
        }

        internal void AddActiveLogger(ProdLogger newLogger)
        {
            if (newLogger == null) return;
            ActiveLoggers.Add(newLogger);
        }

        internal void ReceiveLogMessage(LogMessage message)
        {
            if (message == null) return;

            _CurrentMessage = message;
            ProcessMessage();
        }

        private void ProcessMessage()
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