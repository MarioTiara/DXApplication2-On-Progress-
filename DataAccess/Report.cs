using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Report
    {
        public const string SQL__Detail_Activity_Report = "~/App_Data/SQL__Detail_Activity_Reports.sql";
        public const string SQL__Speed_Report = "~/App_Data/SQL__Speed_Reports.sql";
        public const string SQL__Vehicle_In_Geofence = "~/App_Data/SQL__Vehicle_In_Geofence.sql";
        public const string SQL__Vehicle_In_Geofence_OnlyRegNo = "~/App_Data/SQL__Vehicle_In_Geofence_OnlyRegNo.sql";
        public const string SQL__Vehicle_In_Geofence_RegNoPolygon = "~/App_Data/SQL__Vehicle_In_Geofence_RegNoPolygon.sql";
        public const string SQL__Vehicle_Report_OdoMeter = "~/App_Data/SQL__Vehicle_Report_OdoMeter.sql";
        public const string SQL__Vehicle_Report_OdoMeter_ByVehicle = "~/App_Data/SQL__Vehicle_Report_OdoMeter_ByVehicle.sql";
        public const string SQL__Camera_Report1 = "~/App_Data/SQL__Camera_Report1.sql";
        public const string SQL__Camera_Report2 = "~/App_Data/SQL__Camera_Report2.sql";
        
       
        

        // Stored Procedure
        public const string SP__Vehicle_In_Geofence = "v2.sp__VehicleInGeovence_By_Geofence";
        public const string SP__Vehicle_In_Geofence_RegNo = "v2.sp__VehicleInGeovence_By_RegNo";
    }

    public class EventReport
    {
        public const string SQL__Event_Report = "~/App_Data/SQL__Event_Reports.sql";

    }
}
