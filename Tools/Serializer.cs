using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tools
{
    public static class Serializer
    {
        public static string Serialize<T>(object serObject)
        {            
            var serializer = new XmlSerializer(typeof(T));            
            using (TextWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, serObject);
                return writer.ToString();
            }
        }

        public static T Deserialize<T>(string content)
        {
            T result;
            var serializer = new XmlSerializer(typeof(T));            
            using (TextReader reader = new StringReader(content))
            {
                result = (T)serializer.Deserialize(reader);
            }
            return (T)result;
        }
    }
}
