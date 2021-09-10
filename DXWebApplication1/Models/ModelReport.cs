using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Web.Mvc;


namespace DXWebApplication1.Models
{
    public class ModelReport
    {
    
   
    }
    //Event Report
    public partial class vwEventReport
    {
        public string VehicleSid { get; set; }
        public string REG_NO { get; set; }
        public DateTime? EventTime { get; set; }
        public long PositionID { get; set; }
        public string EventName { get; set; }
        public long ID { get; set; }
        public long WP_SID { get; set; }
        public string POLYGON { get; set; }
        public string WP_PROPINSI { get; set; }
        public string WP_KABUPATEN { get; set; }
        public string WP_KECAMATAN { get; set; }
        public string WP_JALAN { get; set; }
        public string ObjectID { get; set; }
        public string GEOFENCE_NAME { get; set; }
        public string WP_KELURAHAN { get; set; }

        public string IO1_Caption { get; set; }
        public string IO1_Visible { get; set; }
        public string IO1_On_Caption { get; set; }
        public string IO1_Off_Caption { get; set; }
        public string IO2_Caption { get; set; }
        public string IO2_Visible { get; set; }
        public string IO2_On_Caption { get; set; }
        public string IO2_Off_Caption { get; set; }
        public string IO3_Caption { get; set; }
        public string IO3_Visible { get; set; }
        public string IO3_On_Caption { get; set; }
        public string IO3_Off_Caption { get; set; }
        public string IO4_Caption { get; set; }
        public string IO4_Visible { get; set; }
        public string IO4_On_Caption { get; set; }
        public string IO4_Off_Caption { get; set; }
        public string Suhu01_Caption { get; set; }
        public string Suhu02_Caption { get; set; }
        public string Suhu01_Visible { get; set; }
        public string Suhu02_Visible { get; set; }
        public bool LAST_IO1 { get; set; }
        public bool LAST_IO2 { get; set; }
        public bool LAST_IO3 { get; set; }
        public bool LAST_IO4 { get; set; }
        public string DESCRIPT { get; set; }
        public string GEOFENCE { get; set; }
        //public vwEventReport(DataRow row)
        //{

        //    LAST_IO1 = false;
        //    LAST_IO2 = false;
        //    LAST_IO3 = false;
        //    LAST_IO4 = false;

        //    IO1_Caption = "";
        //    IO1_Visible = "";
        //    IO1_On_Caption = "";
        //    IO1_Off_Caption = "";

        //    IO2_Caption = "";
        //    IO2_Visible = "";
        //    IO2_On_Caption = "";
        //    IO2_Off_Caption = "";

        //    IO3_Caption = "";
        //    IO3_Visible = "";
        //    IO3_On_Caption = "";
        //    IO3_Off_Caption = "";

        //    IO4_Caption = "";
        //    IO4_Visible = "";
        //    IO4_On_Caption = "";
        //    IO4_Off_Caption = "";

        //    Suhu01_Caption = "";
        //    Suhu01_Visible = "";
        //    Suhu02_Caption = "";
        //    Suhu02_Visible = "";

        //    VehicleSid = row["VehicleSid"].ToString();
        //    REG_NO = row["REG_NO"].ToString();
        //    EventTime = row.IsNull("EventTime") ? (DateTime?)null : (DateTime?)row["EventTime"];
        //    EventName = row["EventName"].ToString();
        //    POLYGON = row["POLYGON"].ToString();
        //    WP_PROPINSI = row["WP_PROPINSI"].ToString();
        //    WP_KABUPATEN = row["WP_KABUPATEN"].ToString();
        //    WP_KECAMATAN = row["WP_KECAMATAN"].ToString();
        //    WP_JALAN = row["WP_JALAN"].ToString();
        //    ID = Convert.ToInt64(row["ID"].ToString());
        //    GEOFENCE_NAME = row["GEOFENCE_NAME"].ToString();
        //    WP_KELURAHAN = row["WP_KELURAHAN"].ToString();

        //    if (!DBNull.Value.Equals(row["LAST_IO1"])) LAST_IO1 = Convert.ToBoolean(row["LAST_IO1"]);
        //    if (!DBNull.Value.Equals(row["LAST_IO2"])) LAST_IO2 = Convert.ToBoolean(row["LAST_IO2"]);
        //    if (!DBNull.Value.Equals(row["LAST_IO3"])) LAST_IO3 = Convert.ToBoolean(row["LAST_IO3"]);
        //    if (!DBNull.Value.Equals(row["LAST_IO4"])) LAST_IO4 = Convert.ToBoolean(row["LAST_IO4"]);

        //    if (!DBNull.Value.Equals(row["IO1_Caption"])) IO1_Caption = Convert.ToString(row["IO1_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO1_Visible"])) IO1_Visible = Convert.ToString(row["IO1_Visible"]);
        //    if (!DBNull.Value.Equals(row["IO1_On_Caption"])) IO1_On_Caption = Convert.ToString(row["IO1_On_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO1_Off_Caption"])) IO1_Off_Caption = Convert.ToString(row["IO1_Off_Caption"]);


        //    if (!DBNull.Value.Equals(row["IO2_Caption"])) IO2_Caption = Convert.ToString(row["IO2_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO2_Visible"])) IO2_Visible = Convert.ToString(row["IO2_Visible"]);
        //    if (!DBNull.Value.Equals(row["IO2_On_Caption"])) IO2_On_Caption = Convert.ToString(row["IO2_On_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO2_Off_Caption"])) IO2_Off_Caption = Convert.ToString(row["IO2_Off_Caption"]);

        //    if (!DBNull.Value.Equals(row["IO3_Caption"])) IO3_Caption = Convert.ToString(row["IO3_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO3_Visible"])) IO3_Visible = Convert.ToString(row["IO3_Visible"]);
        //    if (!DBNull.Value.Equals(row["IO3_On_Caption"])) IO3_On_Caption = Convert.ToString(row["IO3_On_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO3_Off_Caption"])) IO3_Off_Caption = Convert.ToString(row["IO3_Off_Caption"]);


        //    if (!DBNull.Value.Equals(row["IO4_Caption"])) IO4_Caption = Convert.ToString(row["IO4_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO4_Visible"])) IO4_Visible = Convert.ToString(row["IO4_Visible"]);
        //    if (!DBNull.Value.Equals(row["IO4_On_Caption"])) IO4_On_Caption = Convert.ToString(row["IO4_On_Caption"]);
        //    if (!DBNull.Value.Equals(row["IO4_Off_Caption"])) IO4_Off_Caption = Convert.ToString(row["IO4_Off_Caption"]);


        //    if (!DBNull.Value.Equals(row["Suhu01_Caption"])) Suhu01_Caption = Convert.ToString(row["Suhu01_Caption"]);
        //    if (!DBNull.Value.Equals(row["Suhu01_Visible"])) Suhu01_Visible = Convert.ToString(row["Suhu01_Visible"]);
        //    if (!DBNull.Value.Equals(row["Suhu02_Caption"])) Suhu02_Caption = Convert.ToString(row["Suhu02_Caption"]);
        //    if (!DBNull.Value.Equals(row["Suhu02_Visible"])) Suhu02_Visible = Convert.ToString(row["Suhu02_Visible"]);
        //}
    }
    public partial class vwDetailActivityReport
    {
        public DateTime? WP_TIME { get; set; }
        public string WP_JALAN { get; set; }
        public string WP_KELURAHAN { get; set; }
        public string WP_KECAMATAN { get; set; }
        public string WP_KABUPATEN { get; set; }
        public string WP_PROPINSI { get; set; }
        public string POLYGON { get; set; }
        public Nullable<double> WP_SPEED { get; set; }
        public Nullable<double> HEADING { get; set; }
        public Nullable<double> KM_ODO { get; set; }
        public string REG_NO { get; set; }
        public string VEHICLE_SID { get; set; }

        public vwDetailActivityReport(DataRow row)
        {

            VEHICLE_SID = row["VEHICLE_SID"].ToString();
            REG_NO = row["REG_NO"].ToString();
            WP_TIME = row.IsNull("WP_TIME") ? (DateTime?)null : (DateTime?)row["WP_TIME"];
            WP_JALAN = row["WP_JALAN"].ToString();
            WP_KELURAHAN = row["WP_KELURAHAN"].ToString();
            WP_KECAMATAN = row["WP_KECAMATAN"].ToString();
            WP_KABUPATEN = row["WP_KABUPATEN"].ToString();
            WP_PROPINSI = row["WP_PROPINSI"].ToString();
            POLYGON = row["POLYGON"].ToString();
            WP_SPEED = Convert.ToDouble(row["WP_SPEED"].ToString());
            HEADING = Convert.ToDouble(row["HEADING"].ToString());
            KM_ODO = Convert.ToDouble(row["KM_ODO"].ToString());


        }
    }
    public class SpeedReportParam
    {
        public DateTime? FROM_DATE { get; set; }
        public DateTime? TO_DATE { get; set; }
        public string VEHICLE_SID { get; set; }
        public SpeedReportParam()
        
        {
            FROM_DATE = DateTime.Now.Date;
            TO_DATE = DateTime.Now.Date;
        }
    }
    public class SpeedReport{
       
        public DateTime? WP_TIME { get; set; }
        public string WP_JALAN { get; set; }
        public string WP_KELURAHAN { get; set; }
        public string WP_KECAMATAN { get; set; }
        public string WP_KABUPATEN { get; set; }
        public string WP_PROPINSI { get; set; }
        public string POLYGON { get; set; }
        public Nullable<double> WP_SPEED { get; set; }
        public Nullable<double> HEADING { get; set; }
        public Nullable<double> KM_ODO { get; set; }
        public string REG_NO { get; set; }
        public string VEHICLE_SID { get; set; }
        public string DESCRIPT { get; set; }
        public double SPEEDLIMIT { get; set; }
        //public SpeedReport(DataRow row)
        //{
       
        //    VEHICLE_SID = row["VEHICLE_SID"].ToString();
        //    REG_NO = row["REG_NO"].ToString();
        //    WP_TIME = row.IsNull("WP_TIME") ? (DateTime?)null : (DateTime?)row["WP_TIME"];
        //    WP_JALAN = row["WP_JALAN"].ToString();
        //    WP_KELURAHAN = row["WP_KELURAHAN"].ToString();
        //    WP_KECAMATAN = row["WP_KECAMATAN"].ToString();
        //    WP_KABUPATEN = row["WP_KABUPATEN"].ToString();
        //    WP_PROPINSI = row["WP_PROPINSI"].ToString();
        //    POLYGON = row["POLYGON"].ToString();
        //    WP_SPEED = Convert.ToDouble(row["WP_SPEED"].ToString());
        //    HEADING = Convert.ToDouble(row["HEADING"].ToString());
        //    KM_ODO = Convert.ToDouble(row["KM_ODO"].ToString());

        //}

    }

    public class vwVehicleInGeofence
    {
        public string RECORD_ID { get; set; }
        public string REG_NO { get; set; }
        public string VehicleSid { get; set; }
        public int EnterId { get; set; }
        public int ExitId { get; set; }
        public string Polygon { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string DURATION { get; set; }

    }

    public class vwOdoMeterReport
    {
        public string RECORD_ID { get; set; }
        public string Id { get; set; }
        public string VehicleSid { get; set; }
        public string RegNo { get; set; }
        public DateTime TripDate { get; set; }
        public string SubdivisionSid { get; set; }
        public double StartOdometer { get; set; }
        public string StartJalan { get; set; }
        public string StartKelurahan { get; set; }
        public string StartKota { get; set; }
        public string StartPropinsi { get; set; }
        public string StartGeofence { get; set; }
        public double EndOdometer { get; set; }
        public string EndJalan { get; set; }
        public string EndKelurahan { get; set; }
        public string EndKecamatan { get; set; }
        public string EndKota { get; set; }
        public string EndPropinsi { get; set; }
        public string EndGeofence { get; set; }
        public double Mileage { get; set; }
        public string LocationStart { get; set; }
        public string LocationEnd { get; set; }
        public DateTime CreateDate { get; set; }
    }

    //=================CAMERA REPORT====================

    //Data From DB for Camera 1
    public partial class vwCameraReport1
    {
        public string VEHICLE_SID { get; set; }
        public string REG_NO { get; set; }
        public DateTime? CAPTURE_TIME { get; set; }
        public int? SOURCE_ID { get; set; }
        public string IMAGE_DATA { get; set; }

        public vwCameraReport1(DataRow row)
        {
            VEHICLE_SID = row["VehicleSid"].ToString();
            REG_NO = row["REG_NO"].ToString();
            CAPTURE_TIME = row.IsNull("CaptureTime") ? (DateTime?)null : (DateTime?)row["CaptureTime"];
            SOURCE_ID = Convert.ToInt32(row["SourceId"].ToString());

            byte[] myImage = (byte[])row["ImageData"];
            IMAGE_DATA = Convert.ToBase64String(myImage);
        }
    }

    //Data From DB for Camera 2
    public partial class vwCameraReport2
    {
        public string VEHICLE_SID { get; set; }
        public string REG_NO { get; set; }
        public DateTime? CAPTURE_TIME { get; set; }
        public int? SOURCE_ID { get; set; }
        public string IMAGE_DATA { get; set; }

        public vwCameraReport2(DataRow row)
        {
            VEHICLE_SID = row["VehicleSid"].ToString();
            REG_NO = row["REG_NO"].ToString();
            CAPTURE_TIME = row.IsNull("CaptureTime") ? (DateTime?)null : (DateTime?)row["CaptureTime"];
            SOURCE_ID = Convert.ToInt32(row["SourceId"].ToString());

            byte[] myImage = (byte[])row["ImageData"];
            IMAGE_DATA = Convert.ToBase64String(myImage);
        }
    }

}