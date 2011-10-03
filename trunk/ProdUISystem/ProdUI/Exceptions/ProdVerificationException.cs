// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Runtime.Serialization;
using System.Windows.Automation;
using ProdUI.Logging;

namespace ProdUI.Exceptions
{
    /// <summary>
    /// Raised when an element or action fails verification
    /// </summary>
    [Serializable]
    public class ProdVerificationException : Exception
    {
        /// <summary>
        /// Empty
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public ProdVerificationException()
        {
            LogController.ReceiveLogMessage(new LogMessage("ProdVerificationException: " + InnerException.Message, LoggingLevels.Error));
        }

        /// <summary>
        /// Provide a description of error
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public ProdVerificationException(string message)
            : base(message)
        {
            LogController.ReceiveLogMessage(new LogMessage("ProdVerificationException: " + message, LoggingLevels.Error));
        }

        /// <summary>
        /// Provide a description of error
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="ex">The exception to pass up</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public ProdVerificationException(string message, Exception ex)
            : base(message, ex)
        {
            LogController.ReceiveLogMessage(new LogMessage("ProdVerificationException: " + message, LoggingLevels.Error));
        }

        /// <summary>
        /// Provide a description of error
        /// </summary>
        /// <param name="control">The control.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public ProdVerificationException(AutomationElement control)
            : base(control.Current.Name)
        {
            LogController.ReceiveLogMessage(new LogMessage("ProdVerificationException: " + control.Current.Name, LoggingLevels.Error));
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        protected ProdVerificationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            LogController.ReceiveLogMessage(new LogMessage("ProdVerificationException: " + info.FullTypeName, LoggingLevels.Error));
        }
    }
}