﻿/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Session
{
    /// <summary>
    /// Represents a ProdSession
    /// </summary>
    public class ProdSession
    {
        private ProdLogger _tempLogger;

        /// <summary>
        /// Gets or sets the list of active ProdLoggers.
        /// </summary>
        /// <value>
        /// A ProdLogger.
        /// </value>
        public List<ProdLogger> Loggers { get; set; }

        /// <summary>
        /// Gets the current ProdSessionConfig.
        /// </summary>
        public ProdSessionConfig Configuration { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProdSession"/> class.
        /// </summary>
        /// <param name="configFile">The path to the .ses file that contains the sessions parameters.</param>
        public ProdSession(string configFile)
        {
            Loggers = new List<ProdLogger>();

            Configuration = ProdSessionConfig.LoadConfig(configFile);

            /* Process any loggers from config file */
            GetLoggers();

            /* Set up the loggers for the static Prods */
            ProdStaticSession.Load(Loggers);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProdSession"/> class.
        /// </summary>
        public ProdSession()
        {
            /* Create the id and name using a Guid */
            string defaultId = Guid.NewGuid().ToString("N", CultureInfo.CurrentCulture);

            Loggers = new List<ProdLogger>();

            /* There's a read only .ses file containing some default values */
            Configuration = ProdSessionConfig.LoadDummyConfig();

            /* use the Guid */
            Configuration.SessionId = defaultId;
            Configuration.SessionName = defaultId;

            /* Process any loggers from config file */
            GetLoggers();

            /* Set up the loggers for the static Prods */
            ProdStaticSession.Load(Loggers);
        }

        /// <summary>
        /// Instantiates and adds loggers from the configuration file.
        /// </summary>
        private void GetLoggers()
        {
            if (Configuration.Loggers == null || Configuration.Loggers[0].AssemblyPath == null)
            {
                return;
            }

            foreach (SessionLoggerConfig item in Configuration.Loggers)
            {
                /* needs to be a valid ProdLogger that implements ILogger */
                string tempPath = item.AssemblyPath;
                if (tempPath == null)
                {
                    throw new ProdOperationException("Config file error: No logger assembly specified");
                }

                /* try to grab a logger */
                ILogTarget tst = InitializeLogger(tempPath, item.LoggerType);

                /* Set the params, then add it to list of loggers */
                _tempLogger = ProdLogger.Create(Configuration, tst);
                Loggers.Add(_tempLogger);
            }
        }

        /// <summary>
        /// Creates an instance of the logger type
        /// </summary>
        /// <param name="dllPath">The path to the dll that contains the ProdLogger .</param>
        /// <param name="loggerType">The ILogTarget from the config file</param>
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