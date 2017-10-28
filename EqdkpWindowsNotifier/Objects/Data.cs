using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EqdkpWindowsNotifier.Objects
{
    public class Data
    {
        [XmlElement]
        public DateTime ExpireDate;
    }
}
