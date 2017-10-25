using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    public class SessionResponse : ApiResponse
    {
        [XmlElement(ElementName = "valid")]
        public bool Valid { get; set; }
    }
}
