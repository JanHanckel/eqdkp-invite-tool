using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType("role")]
    public class Role
    {                
        [XmlElement("id")]
        public int ID;

        [XmlElement("name")]
        public string Name;

        [XmlElement("signed_in")]
        public bool SignedIn;        
    }
}
