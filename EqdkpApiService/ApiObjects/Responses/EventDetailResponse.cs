using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType("response")]
    public class EventDetailResponse : ApiResponse
    {
        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("categories")]
        public string Categories { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("start")]
        public string Start { get; set; }

        [XmlElement("start_timestamp")]
        public int StartTimeStamp { get; set; }

        [XmlElement("end")]
        public string End { get; set; }

        [XmlElement("end_timestamp")]
        public int EndTimeStamp { get; set; }

        [XmlElement("allDay")]
        public bool AllDay { get; set; }

        [XmlElement("closed")]
        public bool Closed { get; set; }

        [XmlElement("eventid")]
        public int EventID { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("icon")]
        public string Icon { get; set; }

        [XmlElement("note")]
        public string Note { get; set; }

        [XmlElement("raidleader")]
        public string RaidLeader { get; set; }

        [XmlElement("raidstatus")]
        public EventDetailRaidStates RaidStatus { get; set; }

        //[XmlElement("user_status")]
        //public string user_status { get; set; }

        [XmlElement("color")]
        public string color { get; set; }

        [XmlElement("calendar")]
        public byte calendar { get; set; }

        [XmlElement("calendar_name")]
        public string calendar_name { get; set; }

        [XmlElement("user_status")]
        public UserStatus UserStatus { get; set; }

        [XmlArray("user_chars")]
        [XmlArrayItem("char")]
        public Character[] Characters { get; set; }

        public DateTime StartDate
        {
            get { return DateTime.Parse(Start); }
        }
    }

    [XmlType(AnonymousType = true)]
    public class EventDetailRaidStates
    {
        [XmlElement("status0")]
        public EventDetailRaidStatus status_confirmed { get; set; }

        [XmlElement("status1")]
        public EventDetailRaidStatus status_registered { get; set; }

        [XmlElement("status2")]
        public EventDetailRaidStatus status_canceled { get; set; }

        [XmlElement("status3")]
        public EventDetailRaidStatus status_substitude { get; set; }

        public IEnumerable<EventDetailRaidStatus> AllStates => new List<EventDetailRaidStatus> {
            status_confirmed,
            status_registered,
            status_canceled,
            status_substitude
        };
    }
}
