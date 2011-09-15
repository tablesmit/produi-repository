/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;

namespace ProdUI.Logging
{
    /// <summary>
    ///   Attribute used to mark methods that need to interact with the logging system
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Constructor)]
    public sealed class ProdLoggingAttribute : Attribute
    {
        private readonly LoggingLevels _logLevel;

        /// <summary>
        /// Instantiates a ProdLoggingAttribute
        /// </summary>
        /// <param name="logLevel">The LoggingLevel of messages to output to the log</param>
        /// <remarks>
        /// If a LoggingVerbosity is not specified, it will default to minimum
        /// </remarks>
        public ProdLoggingAttribute(LoggingLevels logLevel)
        {
            _logLevel = logLevel;
        }

        /// <summary>
        /// The <see cref="LoggingLevels"/> of messages to output to the log
        /// </summary>
        public LoggingLevels LogLevel
        {
            get { return _logLevel; }
        }

        /// <summary>
        /// A <see cref="LoggingVerbosity"/> indicating how detailed the information written to the log can be
        /// </summary>
        /// <value>
        /// The verbosity support.
        /// </value>
        public LoggingVerbosity VerbositySupport { get; set; }
    }
}