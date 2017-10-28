using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType("response")]
    public class PointsResponse : ApiResponse
    {
        [XmlArray("players")]
        [XmlArrayItem("player")]
        public Player[] Players;
    }

    [XmlType("event")]
    public class Player
    {
        [XmlElement("id")]
        public int ID;

        [XmlElement("name")]
        public string Name;

        [XmlElement("active")]
        public bool Active;

        [XmlElement("hidden")]
        public bool Hidden;

        [XmlElement("main_id")]
        public int MainID;

        [XmlElement("main_name")]
        public string MainName;

        [XmlElement("class_id")]
        public int ClassID;

        [XmlElement("class_name")]
        public string ClassName;
    }
}
