using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute("response", Namespace = "", IsNullable = false)]
    public class ApiResponse
    {
        [XmlElement(ElementName = "status")]
        public byte Status { get; set; }

        [XmlElement(ElementName = "error")]
        public string Error { get; set; }
    }
}
