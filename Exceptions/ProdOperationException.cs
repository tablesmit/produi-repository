// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Runtime.Serialization;
using ProdUI.Logging;

namespace ProdUI.Exceptions
{
    /// <summary>
    ///     Final Error thrown by the Prod system.
    /// </summary>
    [Serializable]
    public class ProdOperationException : Exception
    {
        /// <summary>
        ///     Empty
        /// </summary>
        public ProdOperationException()
        {
        }

        /// <summary>
        ///     Provide a description of error
        /// </summary>
        /// <param name = "message">The message that describes the error</param>
        public ProdOperationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     if you need to pass the exception up the chain, but want to add to the description
        /// </summary>
        /// <param name = "inner">The exception that is the cause of the current exception</param>
        public ProdOperationException(Exception inner) : base(inner.Message, inner)
        {
        }

        /// <summary>
        ///     if you need to pass the exception up the chain, but want to add to the description
        /// </summary>
        /// <param name = "message">The message that describes the error</param>
        /// <param name = "inner">The exception that is the cause of the current exception</param>
        public ProdOperationException(string message, Exception inner) : base(message, inner)
        {
        }


        /// <summary>
        ///     Initializes a new instance of the Exception class with serialized data.
        /// </summary>
        /// <param name = "info">The SerializationInfo that holds the serialized object data about the exception being thrown</param>
        /// <param name = "context">The StreamingContext that contains contextual information about the source or destination</param>
        /// <exception cref = "T:System.ArgumentNullException">The <paramref name = "info" /> parameter is null. </exception>
        /// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult" /> is zero (0). </exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        protected ProdOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}