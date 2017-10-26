using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute("response", Namespace = "", IsNullable = false)]
    public class ApiResponse
    {
        [XmlElement("status")]
        public byte Status { get; set; }

        [XmlElement("error")]
        public string Error { get; set; }
    }
}
