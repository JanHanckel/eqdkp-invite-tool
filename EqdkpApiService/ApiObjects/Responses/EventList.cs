using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{   
    public partial class EventsResponse : ApiResponse
    {
        /// <remarks/>
        [XmlArray("events")]
        public Event[] Events { get; set; }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class Event
    {   
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "type")]
        public string Title { get; set; }

        [XmlElement(ElementName = "start")]
        public DateTime Start { get; set; }

        [XmlElement(ElementName = "start_timestamp")]        
        public int StartTimeStamp { get; set; }

        [XmlElement(ElementName = "end")]
        public DateTime End { get; set; }

        [XmlElement(ElementName = "end_timestamp")]
        public int EndTimeStamp { get; set; }

        [XmlElement(ElementName = "allDay")]
        public bool AllDay { get; set; }

        [XmlElement(ElementName = "closed")]
        public bool Closed { get; set; }

        [XmlElement(ElementName = "eventid")]
        public int EventID { get; set; }
        
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }
        
        [XmlElement(ElementName = "note")]
        public string Note { get; set; }

        [XmlElement(ElementName = "raidleader")]        
        public string RaidLeader { get; set; }

        [XmlElement(ElementName = "raidstatus")]
        public EventRaidstatus RaidStatus { get; set; }

        [XmlElement(ElementName = "user_status")]
        public string user_status { get; set; }

        [XmlElement(ElementName = "color")]
        public string color { get; set; }

        [XmlElement(ElementName = "calendar")]
        public byte calendar { get; set; }

        [XmlElement(ElementName = "calendar_name")]
        public string calendar_name { get; set; }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class EventRaidstatus
    {
        [XmlElement(ElementName = "status0")]
        public Raidstatus status0 { get; set; }

        [XmlElement(ElementName = "status1")]
        public Raidstatus status1 { get; set; }

        [XmlElement(ElementName = "status2")]
        public Raidstatus status2 { get; set; }

        [XmlElement(ElementName = "status3")]
        public Raidstatus status3 { get; set; }

        [XmlElement(ElementName = "required")]
        public int Required { get; set; }
    }

    
    [XmlType(AnonymousType = true)]
    public partial class Raidstatus
    {
        [XmlElement(ElementName = "id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "count")]
        public int Count { get; set; }
    }
}