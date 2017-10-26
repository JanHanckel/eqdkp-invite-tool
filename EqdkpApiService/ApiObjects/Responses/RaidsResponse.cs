using System;
using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType("response")]
    public class RaidsResponse : ApiResponse
    {
        [XmlElement("raid")]
        //[XmlArrayItem("raid")]
        public Raid[] Raids;
    }

    [XmlType(AnonymousType = true)]
    //[XmlType("raid")]
    public class Raid
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }
        
        [XmlElement("date_timestamp")]
        public int DateTimeStamp { get; set; }

        [XmlElement("note")]
        public string Note { get; set; }

        [XmlElement("event_id")]
        public int EventID { get; set; }

        [XmlElement("event_name")]
        public string EventName { get; set; }

        [XmlElement("added_by_id")]
        public int AddedByUserID { get; set; }

        [XmlElement("added_by_name")]
        public string AddedByUser { get; set; }
        
        [XmlIgnore]
        public DateTime StartDate
        {
            get { return DateTime.Parse(Date); }
        }

        [XmlIgnore]
        public EventDetailResponse Details;
    }
}
