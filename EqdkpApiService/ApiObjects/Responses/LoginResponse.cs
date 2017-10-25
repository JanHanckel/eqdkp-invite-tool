using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    public class LoginResponse : ApiResponse
    {
        [XmlElement(ElementName = "sid")]
        public string SessionID { get; set; }
    }
}
