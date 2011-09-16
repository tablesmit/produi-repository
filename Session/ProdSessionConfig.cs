/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProdUI.Configuration
{
    /// <summary>
    /// Stores the current prod configuration
    /// </summary>
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





}