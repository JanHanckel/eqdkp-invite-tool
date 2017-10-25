using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    public class LoginResponse : ApiResponse
    {
        [XmlElement(ElementName = "sid")]
        public string SessionID { get; set; }

        [XmlElement(ElementName = "end")]
        public string End { get; set; }
    }
}
