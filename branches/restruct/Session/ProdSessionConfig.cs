/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProdUI.Session
{
    /// <summary>Stores the current prod configuration</summary>
    [XmlRoot(ElementName = "session")]
    public class ProdSessionConfig
    {
        /// <summary>
        /// Gets or sets the session id.
        /// </summary>
        /// <value>
        /// The session id.
        /// </value>
        [XmlAttribute(AttributeName = "id")]
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the session.
        /// </summary>
        /// <value>
        /// The name of the session.
        /// </value>
        [XmlElement(ElementName = "sessionName")]
        public string SessionName { get; set; }

        /// <summary>
        /// Gets or sets the event timeout.
        /// </summary>
        /// <value>
        /// The event timeout.
        /// </value>
        [XmlElement(ElementName = "eventTimeout")]
        public int EventTimeout { get; set; }

        /// <summary>
        /// A List containing the parameters for any loggers set in the configuration file
        /// </summary>
        /// <value>
        /// The loggers.
        /// </value>
        [XmlArray("loggers")]
        [XmlArrayItem("logger")]
        public List<SessionLoggerConfig> Loggers { get; set; }

        /// <summary>
        /// Deserializes the specified configuration file.
        /// </summary>
        /// <param name="configFile">The config file.</param>
        /// <returns>
        /// The deserialized session
        /// </returns>
        public static ProdSessionConfig LoadConfig(string configFile)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ProdSessionConfig));
                return (ProdSessionConfig)serializer.Deserialize(fs);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }


        /// <summary>
        /// Loads a dummy config for an empty session.
        /// </summary>
        /// <returns>a ProdSessionConfig with default settings</returns>
        public static ProdSessionConfig LoadDummyConfig()
        {
            ProdSessionConfig defaults = new ProdSessionConfig {
                                                                   Loggers = new List<SessionLoggerConfig>()
                                                               };

            SessionLoggerConfig slc = new SessionLoggerConfig {
                                                                  LogLevel = 13,
                                                                  LoggerName = "default",
                                                                  LogFormat = "LogTime,Message Level,Calling Function,Message Text",
                                                                  LogDateFormat = "T"
                                                              };

            slc.LogLevel = 16;
            defaults.Loggers.Add(slc);

            return defaults;
        }

        /// <summary>
        /// Serializes the  current ProdSessionConfig, then writes out to the specified configuration file.
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        public void SaveConfig(string configFile)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ProdSessionConfig));
                serializer.Serialize(fs, this);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }

    /// <summary>Represents parameters for any ProdLoggers in the config file</summary>
    public class SessionLoggerConfig
    {
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



        /// <summary>
        /// List of verbos information
        /// </summary>
        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<LoggerParameters> Parameters;

    }

    /// <summary>
    /// Used to pass parameters beween the session and a ILogTarget
    /// </summary>
    public class LoggerParameters
    {
        /// <summary>
        /// Stores a list of strings representing the name of a parameter
        /// </summary>
        /// <value>
        /// The name of the parameter.
        /// </value>
        [XmlAttribute(AttributeName = "name")]
        public string ParamName { get; set; }

        /// <summary>
        /// Represents the data type of the parameter
        /// </summary>
        /// <value>
        /// The type of the parameter, as a string
        /// </value>
        [XmlAttribute(AttributeName = "type")]
        public string ParamType { get; set; }

        /// <summary>
        /// Stores the values for each parameter
        /// </summary>
        /// <value>
        /// The value of this parameter
        /// </value>
        [XmlElement(ElementName = "value")]
        public object ParamValue { get; set; }
    }

}