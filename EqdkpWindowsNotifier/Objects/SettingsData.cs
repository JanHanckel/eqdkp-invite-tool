using System.Xml.Serialization;

namespace EqdkpWindowsNotifier.Objects
{
    [XmlRoot("Settings")]
    public class SettingsData : Data
    {
        [XmlElement]
        public string ApiUrl;

        [XmlElement]
        public string ApiKey;

        [XmlElement]
        public string WowPath;
    }
}
