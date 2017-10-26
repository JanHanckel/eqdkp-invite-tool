using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class Character
    {
        [XmlElement("id")]
        public int ID;

        [XmlElement("name")]
        public string Name;

        [XmlElement("signed_in")]
        public bool SignedIn;

        [XmlElement("main")]
        public bool main;

        [XmlElement("class")]
        public int Class;
                      
        [XmlElement("classid")]
        public int ClassID;

        [XmlArray("roles")]
        [XmlArrayItem("role")]
        public Role[] Roles;      

        [XmlElement("raidgroup")]
        public int RaidGroup;

        [XmlElement("signedbyadmin")]
        public bool SignedByAdmin;

        [XmlElement("note")]
        public string note;

        [XmlElement("rank")]
        public string Rank;
    }
}
