using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class UserChars
    {   
        [XmlArrayItem("char")]
        public Character[] Characters;
    }
}
