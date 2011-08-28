/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System.Collections.Generic;
using ProdUI.Session;

namespace ProdUI.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogTarget
    {

        /// <summary>Gets or sets the return parameters.</summary>
        /// <value>The return parameters.</value>
        List<LoggerParameters> ReturnParameters { get; set; }

        /// <summary>Writes a message to the target output</summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        void Write(LogMessage message, List<LoggerParameters> parameters);

        /// <summary>Calls the parameter form.</summary>
        /// <returns>
        /// return 1 if successful, -1 if there is an error or 0 if the are no needed parameters
        /// </returns>
        int CallParameterForm();
    }
}