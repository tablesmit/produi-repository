// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Xml.Serialization;

namespace ProdUI.Logging
{
    /// <summary>
    /// Used to pass parameters between the session and a ILogTarget
    /// </summary>
    public class ProdLoggerInputParameters
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