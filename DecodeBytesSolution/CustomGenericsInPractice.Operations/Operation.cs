using CustomGenericsInPractice.Common;
using System.Xml;
using System.Xml.Serialization;

namespace CustomGenericsInPractice.Operations
{
    public class Operation
    {
        public string AsXml(Article article)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Article));
            using var stringWriter = new StringWriter();
            using XmlTextWriter writer = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
            xmlSerializer.Serialize(writer, article);
            return stringWriter.ToString();
        }
    }
}
