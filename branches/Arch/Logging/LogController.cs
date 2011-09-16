using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Logging
{
    internal class LogController
    {
        private LogController(){}

        private LogMessage _CurrentMessage;
        internal static List<ProdLogger> ActiveLoggers;

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
                int z = (int)logger.LogLevel;
                int y = (int)_CurrentMessage.MessageLevel;
                int x = (z | y);
                if (x == (int)logger.LogLevel)
                    logger.Log(_CurrentMessage);
            }
        }

    }
}
