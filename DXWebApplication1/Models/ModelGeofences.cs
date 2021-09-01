using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DXWebApplication1.Models
{
    public class ModelGeofences
    {
        public string GEOFENCE_NAME { get; set; }
        public string GEOFENCE_CODE { get; set; }
        public string GEOFENCE_TYPE { get; set; }
        public Nullable<double> GEOFENCE_SPEED { get; set; }
        public string GEOFENCE_GEOM { get; set; }
        public ModelGeofences(DataRow row)
        {
            GEOFENCE_NAME = Convert.ToString(row["GEOFENCE_NAME"]);
            GEOFENCE_CODE = Convert.ToString(row["GEOFENCE_CODE"]);
            GEOFENCE_TYPE = Convert.ToString(row["GEOFENCE_TYPE"]);
            GEOFENCE_SPEED = Convert.ToDouble(row["GEOFENCE_SPEED"]);
            GEOFENCE_GEOM = Convert.ToString(row["GEOFENCE_GEOM"]);
        }
    }

    public class ModelGeofencesCmb
    {
        public string GEOFENCE_SID { get; set; }
        public string GEOFENCE_NAME { get; set; }
        public string GEOFENCE_CODE { get; set; }
        public string GEOFENCE_TYPE { get; set; }
        public Nullable<double> GEOFENCE_SPEED { get; set; }
        public bool GEOFENCE_ALERT { get; set; }
        public string GEOFENCE_GEOM { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string GEOFENCE_LAT { get; set; }
        public string GEOFENCE_LON { get; set; }
        public string GEOFENCE_POINT { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
    }

    public class ModelGetGeofenceCode{
        public string GEOFENCE_CODE {get; set;}
    }

    public class ModelGetGeofenceFromLMS{
        public string GEOFENCE_NAME {get; set;}
        public string GEOFENCE_LAT {get; set;}
        public string GEOFENCE_LON {get; set;}
    }

    public class ModelGeofenceType
    {
        public string GEOFENCE_TYPE { get; set; }
    }
}