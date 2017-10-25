using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute("response", Namespace = "", IsNullable = false)]
    public class ApiResponse
    {
        public ApiResponse()
        {
        }

        [XmlElement(ElementName = "status")]
        public byte Status { get; set; }
    }
}
