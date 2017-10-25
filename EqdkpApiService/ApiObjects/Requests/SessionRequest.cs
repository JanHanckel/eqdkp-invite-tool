using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("request", Namespace = "", IsNullable = false)]
    class SessionRequest
    {
        [XmlElement(ElementName = "sid")]        
        public string SessionID { get; set; }        
    }
}
