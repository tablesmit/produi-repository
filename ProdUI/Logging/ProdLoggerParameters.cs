// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProdUI.Logging
{
    /// <summary>
    /// Represents parameters for any ProdLoggers in the configuration file
    /// </summary>
    public class ProdLoggerParameters
    {
        /// <summary>
        /// List of verbose information
        /// </summary>
        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<ProdLoggerInputParameters> Parameters;

        /// <summary>
        /// Gets or sets the type of LoggingTarget.
        /// </summary>
        /// <value>
        /// A string representing the type of LoggingTarget
        /// </value>
        [XmlAttribute(AttributeName = "type")]
        public string LoggerType { get; set; }

        /// <summary>
        /// Gets or sets the path to the corresponding ProdTarget assembly .
        /// </summary>
        /// <value>
        /// The path to the assembly.
        /// </value>
        [XmlAttribute(AttributeName = "assemblyPath")]
        public string AssemblyPath { get; set; }

        /// <summary>
        /// Gets or sets the name of the logger.
        /// </summary>
        /// <value>
        /// The name of the logger.
        /// </value>
        [XmlAttribute(AttributeName = "name")]
        public string LoggerName { get; set; }

        /// <summary>
        /// Gets or sets the desired format of the message string.
        /// </summary>
        /// <value>
        /// The format the logger will present the output
        /// </value>
        [XmlElement(ElementName = "logFormat")]
        public string LogFormat { get; set; }

        /// <summary>
        /// Gets or sets the desired log date format.
        /// </summary>
        /// <value>
        /// The format string to use with the date.
        /// </value>
        /// <remarks>
        ///   <see cref="http://msdn.microsoft.com/en-us/library/az4se3k1.aspx"/>
        /// </remarks>
        [XmlElement(ElementName = "logDateFormat")]
        public string LogDateFormat { get; set; }

        /// <summary>
        /// Gets or sets the desired log level.
        /// </summary>
        /// <value>
        /// The desired log level.
        /// </value>
        [XmlElement(ElementName = "logLevel")]
        public int LogLevel { get; set; }

        /// <summary>
        /// Gets or sets the desired verbosity.
        /// </summary>
        /// <value>
        /// The desired verbosity.
        /// </value>
        [XmlElement(ElementName = "logVerbosity")]
        public int Verbosity { get; set; }
    }
}