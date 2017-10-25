using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot("request", Namespace = "", IsNullable = false)]
    public class LoginRequest
    {
        [XmlElement(ElementName = "user")]
        /// <remarks/>
        public string User { get; set; }

        [XmlElement(ElementName = "password")]
        /// <remarks/>
        public string Password { get; set; }
    }
}
