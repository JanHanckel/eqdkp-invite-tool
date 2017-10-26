using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class Raidstatus
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("maxcount")]
        public int MaxCount { get; set; }
    }
}