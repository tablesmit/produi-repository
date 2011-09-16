/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Configuration
{
    /// <summary>
    /// Represents a ProdSession
    /// </summary>
    public class ProdSession
    {
        private ProdLogger _tempLogger;
        internal LogController logController;

        /// <summary>
        /// Gets the current ProdSessionConfig.
        /// </summary>
        internal ProdSessionConfig Configuration { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProdSession"/> class.
        /// </summary>
        /// <param name="configFile">The path to the .ses file that contains the sessions parameters.</param>
        public ProdSession(string configFile)
        {
            Configuration = ProdSessionConfig.LoadConfig(configFile);

            /* Process any loggers from config file */
            logController = LogController.Create(GetLoggers());
            

            /* Set up the loggers for the static Prods */
            ProdStaticSession.Load(logController.GetActiveLoggers());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProdSession"/> class.
        /// </summary>
        public ProdSession()
        {
            /* Create the id and name using a Guid */
            string defaultId = Guid.NewGuid().ToString("N", CultureInfo.CurrentCulture);

            /* There's a read only .ses file containing some default values */
            Configuration = ProdSessionConfig.LoadDummyConfig();

            /* use the Guid */
            Configuration.SessionId = defaultId;
            Configuration.SessionName = defaultId;

            /* Process any loggers from config file */
            logController = LogController.Create(GetLoggers());

            /* Set up the loggers for the static Prods */
            ProdStaticSession.Load(logController.GetActiveLoggers());
        }

        /// <summary>
        /// Instantiates and adds loggers from the configuration file.
        /// </summary>
        /// <returns>A List of all of the sessions loggers</returns>
        private List<ProdLogger> GetLoggers()
        {
            List<ProdLogger> Loggers = new List<ProdLogger>();

            if (Configuration.Loggers == null || Configuration.Loggers[0].AssemblyPath == null)
            {
                return Loggers;
            }

            foreach (SessionLoggerConfig item in Configuration.Loggers)
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
                Loggers.Add(_tempLogger);
            }

            return Loggers;
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
