/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ProdUI.Logging;
using ProdUI.Session;
using ProdUI.Exceptions;

    /// <summary>
    /// Provides for logging to an XML file
    /// </summary>
    public sealed class XMLLogger : ILogTarget
    {
        /* Stuff for writing output */
        private string _outfile;

        /// <summary>
        /// Gets or sets the return parameters.
        /// </summary>
        /// <value>
        /// The return parameters.
        /// </value>
        public List<LoggerParameters> ReturnParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLLogger"/> class.
        /// </summary>
        public XMLLogger()
        {
            ReturnParameters = new List<LoggerParameters>();
        }

        /// <summary>
        /// Calls the form to get the output path.
        /// </summary>
        /// <returns>
        /// 1 for success
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
        /// Puts together data to be written out as an XMLEntry, then calls serialize.
        /// </summary>
        /// <param name="message">The message to be written to the file</param>
        /// <param name="inputParameters">The input parameters.</param>
        public void Write(LogMessage message, List<LoggerParameters> inputParameters)
        {
            /* make sure we have a filename */
            if (inputParameters == null || (inputParameters[0].ParamName != null && String.IsNullOrEmpty(inputParameters[0].ParamName)))
            {
                throw new ProdOperationException("A valid file path must be specified");
            }

            _outfile = inputParameters[0].ParamValue.ToString();

            /* add message entry */
            WriteXML(message);
        }

        /// <summary>
        /// Writes the XML file entry.
        /// </summary>
        /// <param name="message">The message to be written to the file.</param>
        private void WriteXML(LogMessage message)
        {
            /* Make a new entry */
            XMLEntry ent = new XMLEntry {
                                            LogTime = message.LogTime,
                                            Message = message.Message,
                                            MessageLevel = message.MessageLevel.ToString(),
                                            CallingMethod = message.CallingMethod
                                        };

            /* if we have verbose info, write it, otherwise, forget it */
            if (message.VerboseInformation.Count > 0)
            {
                string output = string.Empty;
                foreach (string item in message.VerboseInformation)
                {
                    output += item + "\n";
                }
                ent.ExtraInformation = output;
            }

            /* Serialize as append */
            SaveConfig();
        }

        /// <summary>
        /// Serializes the  current XMLEntry data. Note, this is in Append mode.
        /// </summary>
        public void SaveConfig()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(_outfile, FileMode.Append);
                XmlSerializer serializer = new XmlSerializer(typeof(XMLEntry));
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

/* Example of XML log output
<?xml version="1.0" encoding="utf-8" ?>
<log xmlns="http://tempuri.org/">
  <entry>
    <time>2011-12-11T12:12:12</time>
    <message level="Prod">Simple Message</message>
    <callingMethod>ProdButton.Click()</callingMethod>
    <extraInformation>Some extra info
      usually from a list
      </extraInformation>
   </entry>
</log>
*/