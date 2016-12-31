using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DataReader
{

    public class XmlDataReader
    {
        public string UTF8ByteArrayToString(byte[] characters)
        {
            var encoding = new UTF8Encoding();
            var constructedString = encoding.GetString(characters);

            return (constructedString);
        }

        public byte[] StringToUTF8ByteArray(string data)
        {
            var encoding = new UTF8Encoding();
            var byteArray = encoding.GetBytes(data);

            return byteArray;
        }

        public string Serialize<T>(T pObject) where T : class
        {
            var XmlizedString = string.Empty;
            var memoryStream = new MemoryStream();
            var xs = new XmlSerializer(typeof(T));
            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            xs.Serialize(xmlTextWriter, pObject);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

            return XmlizedString;
        }

        public T Deserialize<T>(string pXmlizedString) where T : class
        {
            var xs = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));

            return xs.Deserialize(memoryStream) as T;
        }
    }
}
