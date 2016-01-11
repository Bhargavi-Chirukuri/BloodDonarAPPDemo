using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace BloodDonarAPPDemo
{
   public class detailsofperson
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class PointClass
    {
        public string name { get; set; }
        public string phone { get; set; }
        public Geoposition myPoint1 { get; set; }

    }
}
