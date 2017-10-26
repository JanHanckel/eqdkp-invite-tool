using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class UserStatus
    {
        [XmlElement("status")]
        public int Status;

        [XmlElement("status_name")]
        public string StatusName;

        [XmlElement("char_id")]
        public int CharacterID;

        [XmlElement("char_class")]
        public int CharacterClassID;

        [XmlElement("char_name")]
        public string ChracterName;

        [XmlElement("raidgroup")]
        public int RaidGroup;

        [XmlElement("char_roleid")]
        public int CharacterRoleID;

        [XmlElement("char_role")]
        public string CharacterRole;
    }
}
