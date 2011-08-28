/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System.Collections.Generic;
using ProdUI.Logging;

/// <summary>
/// Uses the Windows forms MessageBox to as a log target
/// </summary>
public sealed class MboxLogger : ILogTarget
{

    /// <summary>
    /// Writes a message to the target output
    /// </summary>
    /// <param name="message">The message object to log</param>
    /// <param name="parameters">Any additional verbose information</param>
    public void Write(LogMessage message, List<ProdUI.Session.LoggerParameters> parameters)
    {
        string messageString = message.ToString();

        if (message.VerboseInformation != null)
        {
            foreach (string item in message.VerboseInformation)
            {
                messageString += "\n" + item;
            }
        }
        System.Windows.Forms.MessageBox.Show(messageString, "ProdUI");
    }

    /// <summary>
    /// Gets or sets the return parameters.
    /// </summary>
    /// <value>
    /// Not used in this log target
    /// </value>
    public List<ProdUI.Session.LoggerParameters> ReturnParameters
    {
        get
        {
            return null;
        }
        set
        {

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

}
