using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class UserStatus
    {
        [XmlElement("status")]
        public int Status { get; set; }

        [XmlElement("status_name")]
        public string StatusName { get; set; }

        [XmlElement("char_id")]
        public int CharacterID { get; set; }

        [XmlElement("char_class")]
        public int CharacterClassID { get; set; }

        [XmlElement("char_name")]
        public string ChracterName { get; set; }

        [XmlElement("raidgroup")]
        public int RaidGroup { get; set; }

        [XmlElement("char_roleid")]
        public int CharacterRoleID { get; set; }

        [XmlElement("char_role")]
        public string CharacterRole { get; set; }
    }
}
