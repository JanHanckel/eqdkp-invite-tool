using EqdkpApiService.ApiObjects;
using System.Xml.Serialization;

namespace EqdkpWindowsNotifier.Objects
{
    [XmlRoot("PlayerData")]
    public class PlayerData : Data
    {
        [XmlArray("Players")]
        [XmlArrayItem("Player")]
        public Player[] Player;
    }
}
