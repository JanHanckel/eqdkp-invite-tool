using System;
using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType("response")]
    public class EventsResponse : ApiResponse
    {
        [XmlArray("events")]
        [XmlArrayItem("event")]
        public Event[] Events;
    }

    [XmlType("event")]
    public class Event
    {
        [XmlElement("type")]
        public string Type { get; set; }

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
        public Raidstates RaidStatus { get; set; }

        [XmlElement("user_status")]
        public string user_status { get; set; }

        [XmlElement("color")]
        public string color { get; set; }

        [XmlElement("calendar")]
        public byte calendar { get; set; }

        [XmlElement("calendar_name")]
        public string calendar_name { get; set; }

        [XmlIgnore]
        public DateTime StartDate
        {
            get { return DateTime.Parse(Start); }
        }

        [XmlIgnore]
        public EventDetailResponse Details { get; set; }
    }
}