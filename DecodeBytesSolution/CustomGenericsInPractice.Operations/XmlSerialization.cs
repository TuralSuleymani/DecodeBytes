using CustomGenericsInPractice.Common;
using System.Xml;
using System.Xml.Serialization;

namespace CustomGenericsInPractice.Operations
{
    public class XmlSerialization<T> : ISerialization<T> where T : DomainEntity
    {
        public string Serialize(T model)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();
            using XmlTextWriter writer = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
            serializer.Serialize(writer, model);
            return stringWriter.ToString();
        }
    }
}
