// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace ProdUI.Logging
{
    /// <summary>
    /// Encapsulates a message to be passed to the logging system
    /// </summary>
    public sealed class LogMessage
    {
        internal string OutputString = string.Empty;

        #region Constructors

        /// <summary>
        /// Instantiates a new LogMessage
        /// </summary>
        /// <param name="message">A custom message to be written to the log</param>
        public LogMessage(string message)
        {
            DateTime logTime = DateTime.Now;
            LogTime = logTime.ToString("T", CultureInfo.CurrentCulture);

            Message = message;
            VerboseInformation = null;
            SetMessageParams();
        }

        /// <summary>
        /// Instantiates a new LogMessage
        /// </summary>
        /// <param name="message">A custom message to be written to the log</param>
        /// <param name="verboseInformation">String Collection to be used in verbose logging.</param>
        public LogMessage(string message, List<object> verboseInformation)
        {
            DateTime logTime = DateTime.Now;
            LogTime = logTime.ToString("T", CultureInfo.CurrentCulture);

            Message = message;
            VerboseInformation = verboseInformation;
            SetMessageParams();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessage"/> class.
        /// </summary>
        /// <param name="message">The message text.</param>
        /// <param name="messageLevel">The messages LoggingLevel.</param>
        public LogMessage(string message, LoggingLevels messageLevel)
        {
            DateTime logTime = DateTime.Now;
            LogTime = logTime.ToString("T", CultureInfo.CurrentCulture);

            Message = message;
            VerboseInformation = null;
            SetMessageParams(messageLevel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessage"/> class.
        /// </summary>
        /// <param name="message">The message text.</param>
        /// <param name="verboseInformation">The verbose information.</param>
        /// <param name="messageLevel">The messages LoggingLevel.</param>
        public LogMessage(string message, List<object> verboseInformation, LoggingLevels messageLevel)
        {
            DateTime logTime = DateTime.Now;
            LogTime = logTime.ToString("T", CultureInfo.CurrentCulture);

            Message = message;
            VerboseInformation = verboseInformation;
            SetMessageParams(messageLevel);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the name of the Prod method that sent the log request
        /// </summary>
        /// <value>
        /// The calling method.
        /// </value>
        public string CallingMethod { get; set; }

        /// <summary>
        /// Gets time of event
        /// </summary>
        /// <value>
        /// The log time.
        /// </value>
        public string LogTime { get; set; }

        /// <summary>
        /// Gets message text to be written to log
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets the type of LoggingLevel this message is categorized as
        /// </summary>
        /// <value>
        /// The message level.
        /// </value>
        public LoggingLevels MessageLevel { get; set; }

        /// <summary>
        /// Gets the verbosity attribute of the method
        /// </summary>
        /// <value>
        /// The verbosity.
        /// </value>
        public LoggingVerbosity Verbosity { get; set; }

        /// <summary>
        /// Gets the extra information to print to the log target if the user specifies verbose output.
        /// </summary>
        /// <value>
        /// The verbose information.
        /// </value>
        public List<object> VerboseInformation { get; set; }

        #endregion Properties

        /// <summary>
        /// Sets the message parameters for verbosity and log level
        /// </summary>
        private void SetMessageParams()
        {
            try
            {
                /* get last call */
                StackFrame sf = new StackTrace().GetFrame(4);
                CallingMethod = sf.GetMethod().Name;

                /* get method attributes, which at this point only support ProdLoggingAttribute */
                object[] attributes = sf.GetMethod().GetCustomAttributes(typeof(ProdLoggingAttribute), false);

                if (attributes.Length <= 0)
                {
                    Verbosity = LoggingVerbosity.Minimum;
                    MessageLevel = LoggingLevels.Info;
                }
                else
                {
                    if (attributes[0] is ProdLoggingAttribute)
                    {
                        Verbosity = ((ProdLoggingAttribute)attributes[0]).VerbositySupport;
                        MessageLevel = ((ProdLoggingAttribute)attributes[0]).LogLevel;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException.Message);
            }
        }

        /// <summary>
        /// Sets the message parameters for verbosity and log level
        /// </summary>
        /// <param name="logLevel">The messages LoggingLevel.</param>
        private void SetMessageParams(LoggingLevels logLevel)
        {
            /* get last call */
            StackFrame sf = new StackTrace().GetFrame(4);
            CallingMethod = sf.GetMethod().Name;

            /* get method attributes, which at this point only support ProdLoggingAttribute */
            object[] attributes = sf.GetMethod().GetCustomAttributes(typeof(ProdLoggingAttribute), false);

            if (attributes.Length <= 0)
            {
                if (VerboseInformation == null)
                {
                    Verbosity = LoggingVerbosity.Minimum;
                }
                else
                {
                    Verbosity = LoggingVerbosity.Minimum;
                }
                MessageLevel = logLevel;
            }
            else
            {
                /* See if there are function attributes to use, then use em */
                if (attributes[0] is ProdLoggingAttribute)
                {
                    Verbosity = ((ProdLoggingAttribute)attributes[0]).VerbositySupport;
                    MessageLevel = ((ProdLoggingAttribute)attributes[0]).LogLevel;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return OutputString;
        }
    }
}