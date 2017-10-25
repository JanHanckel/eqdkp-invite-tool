using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects.Responses
{    
    public class ErrorResponse : ApiResponse
    {        
        [XmlElement(ElementName = "error")]
        public string Error { get; set; }
    }
}