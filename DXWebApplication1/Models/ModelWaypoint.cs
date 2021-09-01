using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class ModelWaypoint
    {

        public string REGNO { get; set; }
        public double WP_LAT { get; set; }
        public double WP_LON { get; set; }
        public bool WP_IO1 { get; set; }
        public double WP_SPEED { get; set; }
        public DateTime WP_TIME { get; set; }
        //public string POLYGON { get; set; }
        public double ANGLE { get; set; }
        //public string PROP { get; set; }
        //public string KAB { get; set; }
        //public string KEC { get; set; }
        //public string KEL { get; set; }
        //public string JALAN { get; set; }
        public bool WP_IO2 { get; set; }
        public bool WP_IO3 { get; set; }
        public bool WP_IO4 { get; set; }
        public string MODEL { get; set; }
        public double PWR { get; set; }
        public double ODO { get; set; }
        public string GSMNO { get; set; }
        public double SUHU1 { get; set; }
        public double SUHU2 { get; set; }
        public string IO1KEY { get; set; }
        public string IO1VALUE { get; set; }
        public string IO2KEY { get; set; }
        public string IO2VALUE { get; set; }
        public string IO3KEY { get; set; }
        public string IO3VALUE { get; set; }
        public string IO4KEY { get; set; }
        public string IO4VALUE { get; set; }
        public string SUHU1KEY { get; set; }
        public string SUHU2KEY { get; set; }
        public string LOC { get; set; }
    }
}