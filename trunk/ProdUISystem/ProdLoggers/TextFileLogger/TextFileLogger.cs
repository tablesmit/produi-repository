/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.IO;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Session;


/// <summary>
/// Represents a simple log target that writes each message to the specified text file
/// </summary>
public sealed class TextFileLogger : ILogTarget
{
    /* Stuff for writing output */
    private string _outfile;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextFileLogger"/> class.
    /// </summary>
    public TextFileLogger()
    {
        ReturnParameters = new List<LoggerParameters>();
    }

    /// <summary>
    /// Writes the specified message.
    /// </summary>
    /// <param name="message">The message to be written to the file.</param>
    /// <param name="inputParameters">Any extra input parameters (verbosity).</param>
    public void Write(LogMessage message, List<LoggerParameters> inputParameters)
    {

        if (inputParameters == null || (inputParameters[0].ParamName != null && String.IsNullOrEmpty(inputParameters[0].ParamName)))
        {
            throw new ProdOperationException("A valid file path must be specified");
        }

        _outfile = inputParameters[0].ParamValue.ToString();
        WriteToFile(message);


    }

    /// <summary>
    /// Writes the line to the designated file.   //todo:possible deadlocking or racing
    /// </summary>
    /// <param name="message">The message to be written to the file</param>
    private void WriteToFile(LogMessage message)
    {
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(_outfile);
            sw.WriteLine(message.ToString());
            sw.Flush();

            if (message.VerboseInformation == null)
            {
                return;
            }


            foreach (string item in message.VerboseInformation)
            {
                sw.WriteLine(item);
            }
            sw.Flush();
        }
        catch (IOException err)
        {
            throw new ProdOperationException(err);
        }
        finally
        {
            if (sw != null)
            {
                sw.Close();
            }
        }

    }


    /******************  Getting needed parameters ******************/
    /// <summary>
    /// Calls the parameter form to get the output file path.
    /// </summary>
    /// <returns>
    /// 1 on success
    /// </returns>
    public int CallParameterForm()
    {
        ParameterForm frm = new ParameterForm();
        try
        {
            frm.ShowDialog();
            LoggerParameters t = new LoggerParameters { ParamName = "OutputFile", ParamType = "string", ParamValue = frm.SavePath };
            ReturnParameters.Add(t);

            return 1;
        }
        finally
        {
            frm.Dispose();
        }

    }

    /// <summary>
    /// Gets or sets the return parameters.
    /// </summary>
    /// <value>
    /// The return parameters.
    /// </value>
    /// <remarks>
    /// unused
    /// </remarks>
    public List<LoggerParameters> ReturnParameters { get; set; }
}