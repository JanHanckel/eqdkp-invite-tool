using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    public class SaltResponse : ApiResponse
    {
        [XmlElement(ElementName = "salt")]
        public string Salt { get; set; }
    }
}
