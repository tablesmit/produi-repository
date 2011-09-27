// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Xml.Serialization;

[XmlRoot(ElementName = "entry")]
internal class XMLEntry
{
    [XmlElement(ElementName = "logtime")]
    public string LogTime { get; set; }

    [XmlElement(ElementName = "message")]
    public string Message { get; set; }

    [XmlAttribute(AttributeName = "level")]
    public string MessageLevel { get; set; }

    [XmlElement(ElementName = "callingmethod")]
    public string CallingMethod { get; set; }

    [XmlElement(ElementName = "extraInformation")]
    public string ExtraInformation { get; set; }
}