using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class Raidstates
    {
        [XmlElement("status0")]
        public Raidstatus status_confirmed { get; set; }

        [XmlElement("status1")]
        public Raidstatus status_registered { get; set; }

        [XmlElement("status2")]
        public Raidstatus status_canceled { get; set; }

        [XmlElement("status3")]
        public Raidstatus status_substitude { get; set; }

        [XmlElement("required")]
        public int Required { get; set; }
    }
}
