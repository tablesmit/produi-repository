/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System.Collections.Generic;
using System.Diagnostics;
using ProdUI.Logging;

/// <summary>
/// Uses the Visual studio DebugOut as its target
/// </summary>
public sealed class DebugLogger : ILogTarget
{

    /// <summary>
    /// Writes the specified message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="parameters">The parameters.</param>
    public void Write(LogMessage message, List<ProdUI.Session.LoggerParameters> parameters)
    {

        Debug.WriteLine(message.ToString());

        if (message.VerboseInformation == null)
        {
            return;
        }


        foreach (string item in message.VerboseInformation)
        {
            Debug.WriteLine(item);
        }
    }

    /// <summary>
    /// Calls the parameter form.
    /// </summary>
    /// <returns>
    /// 0 because there is no input interface
    /// </returns>
    int ILogTarget.CallParameterForm()
    {
        return 0;
    }


    /// <summary>
    /// Gets or sets the return parameters.
    /// </summary>
    /// <value>
    /// The return parameters.
    /// </value>
    /// <remarks>Not used in this logger</remarks>
    public List<ProdUI.Session.LoggerParameters> ReturnParameters
    {
        get
        {
            return null;
        }
        set
        {
            ;
        }
    }
}