using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    public class XMLFileData
    {
        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                TextWriter writer = new StreamWriter(filePath);
                xmlSerialize.Serialize(writer, data);
                writer.Close();
            }



        }

        public object XmlDeserializer(Type dataType, string filePath)
        {
            object obj = null;
            XmlSerializer xmlDeserialize = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlDeserialize.Deserialize(textReader);
                textReader.Close();
            }

            return obj;
        }
    }
}
