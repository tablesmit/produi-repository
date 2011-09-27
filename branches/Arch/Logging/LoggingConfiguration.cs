// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting;
using System.Xml.Serialization;
using ProdUI.Exceptions;

namespace ProdUI.Logging
{
    /// <summary>
    /// Stores a logging configuration for later use
    /// </summary>
    [XmlRoot(ElementName = "loggingConfig")]
    public class LoggingConfiguration
    {
        private ProdLogger _tempLogger;
        private LoggingConfiguration Configuration;

        /// <summary>
        ///     A List containing the parameters for any loggers set in the configuration file
        /// </summary>
        /// <value>
        ///     The loggers.
        /// </value>
        [XmlArray("loggers")]
        [XmlArrayItem("logger")]
        public List<ProdLoggerParameters> LoggerParameters { get; set; }

        [XmlIgnore]
        public List<ProdLogger> LoadedLoggers { get; private set; }

        /// <summary>
        /// De-serializes the specified configuration file.
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        public void LoadConfiguration(string configFile)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(LoggingConfiguration));
                Configuration = (LoggingConfiguration)serializer.Deserialize(fs);
                GetLoggers();
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
        /// Serializes the  current ProdSessionConfig, then writes out to the specified configuration file.
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        public void SaveConfiguration(string configFile)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(LoggingConfiguration));
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

        /// <summary>
        /// Instantiates and adds loggers from the configuration file.
        /// </summary>
        private void GetLoggers()
        {
            LoadedLoggers = new List<ProdLogger>();

            if (Configuration.LoadedLoggers == null || Configuration.LoggerParameters[0].AssemblyPath == null)
            {
                return;
            }

            foreach (ProdLoggerParameters item in Configuration.LoggerParameters)
            {
                /* needs to be a valid ProdLogger that implements ILogger */
                string tempPath = item.AssemblyPath;
                if (tempPath == null)
                {
                    throw new ProdOperationException("Configuration file error: No logger assembly specified");
                }

                /* try to grab a logger */
                ILogTarget tst = InitializeLogger(tempPath, item.LoggerType);

                /* Set the parameters, then add it to list of loggers */
                _tempLogger = new ProdLogger(Configuration, tst);
                LoadedLoggers.Add(_tempLogger);
            }
        }

        /// <summary>
        /// Creates an instance of the logger type
        /// </summary>
        /// <param name="dllPath">The path to the dll that contains the ProdLogger .</param>
        /// <param name="loggerType">The ILogTarget from the configuration file</param>
        /// <returns>
        /// An unwrapped and casted ProdLogger
        /// </returns>
        private static ILogTarget InitializeLogger(string dllPath, string loggerType)
        {
            try
            {
                ObjectHandle oh = Activator.CreateInstanceFrom(dllPath, loggerType);

                return (ILogTarget)oh.Unwrap();
            }
            catch (TypeLoadException err)
            {
                throw new ProdOperationException(err);
            }
            catch (FileNotFoundException err)
            {
                throw new ProdOperationException("Cannot find specified ProdLogger dll", err);
            }
            catch (BadImageFormatException err)
            {
                throw new ProdOperationException(err);
            }
        }
    }
}