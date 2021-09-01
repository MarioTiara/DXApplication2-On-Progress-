using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DXWebApplication1.Models
{
    public class VehicleWithRole
    {
        public string ORDSTS { get; set; }
        public string GPS { get; set; }
        public string VEHICLE_SID { get; set; }
        public string REG_NO { get; set; }
        public double LAST_WP_LAT { get; set; }
        public double LAST_WP_LON { get; set; }
        public bool LAST_IO1 { get; set; }
        public double LAST_WP_SPEED { get; set; }
        public DateTime LAST_UPDATE { get; set; }
        public string POLYGON { get; set; }
        public string LOCATION { get; set; }
        public double HEADING { get; set; }
        public string VEHICLE_IMEI { get; set; }
        public string WP_PROPINSI { get; set; }
        public string WP_KABUPATEN { get; set; }
        public string WP_KECAMATAN { get; set; }
        public string WP_KELURAHAN { get; set; }
        public string WP_JALAN { get; set; }
        public bool LAST_IO2 { get; set; }
        public bool LAST_IO3 { get; set; }
        public bool LAST_IO4 { get; set; }
        public string MODEL_UNIT { get; set; }
        public double EXT_POWER { get; set; }
        public double KM_ODO { get; set; }
        public string CELLNO { get; set; }
        public double SUHU01 { get; set; }
        public double SUHU02 { get; set; }
        public Nullable<bool> LAST_GPS_STATUS { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string ORIGIN_NAME { get; set; }
        public string DESTINATION_NAME { get; set; }
        public string STATUS { get; set; }
        public string RECORD_ID { get; set; }
        public string CUSTOMER_SID { get; set; }
        public string DESCRIPTION { get; set; }
        public string ORIGIN_CODE { get; set; }
        public string DESTINATION_CODE { get; set; }
        public DateTime PICKUP_DATE { get; set; }
        public DateTime PROGRESS_DATE { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public DateTime ARRIVAL_DATE { get; set; }
        public DateTime COMPLETE_DATE { get; set; }
        public DateTime DUE_DATE { get; set; }
        public DateTime EXPIRED_DATE { get; set; }
        public string DRIVER_SID { get; set; }
        public string DRIVER_PHONE { get; set; }
        public string ROUTE_UID { get; set; }
        public string SWITCH_FROM { get; set; }
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

        public VehicleWithRole(DataRow row)
        {
            ORDSTS = "";
            GPS = "";
            VEHICLE_SID = "";
            REG_NO = "";
            LAST_WP_LAT = 0;
            LAST_WP_LON = 0;
            LAST_IO1 = false;
            LAST_WP_SPEED = 0;
            LAST_UPDATE = new DateTime(1900, 1, 1, 0, 0, 0);
            LOCATION = "";
            POLYGON = "";
            HEADING = 0;
            VEHICLE_IMEI = "";
            WP_PROPINSI = "-";
            WP_KABUPATEN = "-";
            WP_KECAMATAN = "-";
            WP_KELURAHAN = "-";
            WP_JALAN = "-";
            LAST_IO2 = false;
            LAST_IO3 = false;
            LAST_IO4 = false;
            MODEL_UNIT = "";
            EXT_POWER = 0;
            KM_ODO = 0;
            CELLNO = "";
            SUHU01 = 0;
            SUHU02 = 0;
            LAST_GPS_STATUS = false;
            ORDER_NUMBER = "";
            ORIGIN_NAME = "";
            DESTINATION_NAME = "";
            STATUS = "";
            RECORD_ID = "";
            CUSTOMER_SID = "";
            DESCRIPTION = "";
            ORIGIN_CODE = "";
            DESTINATION_CODE = "";
            PICKUP_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            PROGRESS_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            DELIVERY_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            ARRIVAL_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            COMPLETE_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            DUE_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            EXPIRED_DATE = new DateTime(1900, 1, 1, 0, 0, 0);
            DRIVER_SID = "";
            DRIVER_PHONE = "";
            ROUTE_UID = "";
            SWITCH_FROM = "";

            IO1_Caption = "";
            IO1_Visible = "";
            IO1_On_Caption = "";
            IO1_Off_Caption = "";

            IO2_Caption = "";
            IO2_Visible = "";
            IO2_On_Caption = "";
            IO2_Off_Caption = "";

            IO3_Caption = "";
            IO3_Visible = "";
            IO3_On_Caption = "";
            IO3_Off_Caption = "";

            IO4_Caption = "";
            IO4_Visible = "";
            IO4_On_Caption = "";
            IO4_Off_Caption = "";

            Suhu01_Caption = "";
            Suhu01_Visible = "";
            Suhu02_Caption = "";
            Suhu02_Visible = "";

            if (!DBNull.Value.Equals(row["ORDSTS"])) ORDSTS = Convert.ToString(row["ORDSTS"]);
            if (!DBNull.Value.Equals(row["GPS"])) GPS = Convert.ToString(row["GPS"]);
            if (!DBNull.Value.Equals(row["VEHICLE_SID"])) VEHICLE_SID = Convert.ToString(row["VEHICLE_SID"]);
            if (!DBNull.Value.Equals(row["REG_NO"])) REG_NO = Convert.ToString(row["REG_NO"]);
            if (!DBNull.Value.Equals(row["LAST_WP_LAT"])) LAST_WP_LAT = Convert.ToDouble(row["LAST_WP_LAT"]);
            if (!DBNull.Value.Equals(row["LAST_WP_LON"])) LAST_WP_LON = Convert.ToDouble(row["LAST_WP_LON"]);
            if (!DBNull.Value.Equals(row["LAST_IO1"])) LAST_IO1 = Convert.ToBoolean(row["LAST_IO1"]);
            if (!DBNull.Value.Equals(row["LAST_WP_SPEED"])) LAST_WP_SPEED = Convert.ToDouble(row["LAST_WP_SPEED"]);
            if (!DBNull.Value.Equals(row["LAST_UPDATE"])) LAST_UPDATE = Convert.ToDateTime(row["LAST_UPDATE"]);
            if (!DBNull.Value.Equals(row["POLYGON"])) POLYGON = Convert.ToString(row["POLYGON"]);
            if (!DBNull.Value.Equals(row["LOCATION"])) LOCATION = Convert.ToString(row["LOCATION"]);
            if (!DBNull.Value.Equals(row["HEADING"])) HEADING = Convert.ToDouble(row["HEADING"]);
            if (!DBNull.Value.Equals(row["VEHICLE_IMEI"])) VEHICLE_IMEI = Convert.ToString(row["VEHICLE_IMEI"]);
            if (!DBNull.Value.Equals(row["WP_PROPINSI"])) WP_PROPINSI = Convert.ToString(row["WP_PROPINSI"]);
            if (!DBNull.Value.Equals(row["WP_KABUPATEN"])) WP_KABUPATEN = Convert.ToString(row["WP_KABUPATEN"]);
            if (!DBNull.Value.Equals(row["WP_KECAMATAN"])) WP_KECAMATAN = Convert.ToString(row["WP_KECAMATAN"]);
            if (!DBNull.Value.Equals(row["WP_KELURAHAN"])) WP_KELURAHAN = Convert.ToString(row["WP_KELURAHAN"]);
            if (!DBNull.Value.Equals(row["WP_JALAN"])) WP_JALAN = Convert.ToString(row["WP_JALAN"]);
            if (!DBNull.Value.Equals(row["LAST_IO2"])) LAST_IO2 = Convert.ToBoolean(row["LAST_IO2"]); ;
            if (!DBNull.Value.Equals(row["LAST_IO3"])) LAST_IO3 = Convert.ToBoolean(row["LAST_IO3"]); ;
            if (!DBNull.Value.Equals(row["LAST_IO4"])) LAST_IO4 = Convert.ToBoolean(row["LAST_IO4"]); ;
            if (!DBNull.Value.Equals(row["MODEL_UNIT"])) MODEL_UNIT = Convert.ToString(row["MODEL_UNIT"]);
            if (!DBNull.Value.Equals(row["EXT_POWER"])) EXT_POWER = Convert.ToDouble(row["EXT_POWER"]);
            if (!DBNull.Value.Equals(row["KM_ODO"])) KM_ODO = Convert.ToDouble(row["KM_ODO"]);
            if (!DBNull.Value.Equals(row["CELLNO"])) CELLNO = Convert.ToString(row["CELLNO"]);
            if (!DBNull.Value.Equals(row["SUHU01"])) SUHU01 = Convert.ToDouble(row["SUHU01"]);
            if (!DBNull.Value.Equals(row["SUHU02"])) SUHU02 = Convert.ToDouble(row["SUHU02"]);
            if (!DBNull.Value.Equals(row["LAST_GPS_STATUS"])) LAST_GPS_STATUS = Convert.ToBoolean(row["LAST_GPS_STATUS"]);
            if (!DBNull.Value.Equals(row["ORDER_NUMBER"])) ORDER_NUMBER = Convert.ToString(row["ORDER_NUMBER"]);
            if (!DBNull.Value.Equals(row["ORIGIN_NAME"])) ORIGIN_NAME = Convert.ToString(row["ORIGIN_NAME"]);
            if (!DBNull.Value.Equals(row["DESTINATION_NAME"])) DESTINATION_NAME = Convert.ToString(row["DESTINATION_NAME"]);
            if (!DBNull.Value.Equals(row["STATUS"])) STATUS = Convert.ToString(row["STATUS"]);
            if (!DBNull.Value.Equals(row["RECORD_ID"])) RECORD_ID = Convert.ToString(row["RECORD_ID"]);
            if (!DBNull.Value.Equals(row["CUSTOMER_SID"])) CUSTOMER_SID = Convert.ToString(row["CUSTOMER_SID"]);
            if (!DBNull.Value.Equals(row["DESCRIPTION"])) DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
            if (!DBNull.Value.Equals(row["ORIGIN_CODE"])) ORIGIN_CODE = Convert.ToString(row["ORIGIN_CODE"]);
            if (!DBNull.Value.Equals(row["DESTINATION_CODE"])) DESTINATION_CODE = Convert.ToString(row["DESTINATION_CODE"]);
            if (!DBNull.Value.Equals(row["PICKUP_DATE"])) PICKUP_DATE = Convert.ToDateTime(row["PICKUP_DATE"]);
            if (!DBNull.Value.Equals(row["PROGRESS_DATE"])) PROGRESS_DATE = Convert.ToDateTime(row["PROGRESS_DATE"]);
            if (!DBNull.Value.Equals(row["DELIVERY_DATE"])) DELIVERY_DATE = Convert.ToDateTime(row["DELIVERY_DATE"]);
            if (!DBNull.Value.Equals(row["ARRIVAL_DATE"])) ARRIVAL_DATE = Convert.ToDateTime(row["ARRIVAL_DATE"]);
            if (!DBNull.Value.Equals(row["COMPLETE_DATE"])) COMPLETE_DATE = Convert.ToDateTime(row["COMPLETE_DATE"]);
            if (!DBNull.Value.Equals(row["DUE_DATE"])) DUE_DATE = Convert.ToDateTime(row["DUE_DATE"]);
            if (!DBNull.Value.Equals(row["EXPIRED_DATE"])) EXPIRED_DATE = Convert.ToDateTime(row["EXPIRED_DATE"]);
            if (!DBNull.Value.Equals(row["DRIVER_SID"])) DRIVER_SID = Convert.ToString(row["DRIVER_SID"]);
            if (!DBNull.Value.Equals(row["DRIVER_PHONE"])) DRIVER_PHONE = Convert.ToString(row["DRIVER_PHONE"]);
            if (!DBNull.Value.Equals(row["ROUTE_UID"])) ROUTE_UID = Convert.ToString(row["ROUTE_UID"]);
            if (!DBNull.Value.Equals(row["SWITCH_FROM"])) SWITCH_FROM = Convert.ToString(row["SWITCH_FROM"]);

            if (!DBNull.Value.Equals(row["IO1_Caption"])) IO1_Caption = Convert.ToString(row["IO1_Caption"]);
            if (!DBNull.Value.Equals(row["IO1_Visible"])) IO1_Visible = Convert.ToString(row["IO1_Visible"]);
            if (!DBNull.Value.Equals(row["IO1_On_Caption"])) IO1_On_Caption = Convert.ToString(row["IO1_On_Caption"]);
            if (!DBNull.Value.Equals(row["IO1_Off_Caption"])) IO1_Off_Caption = Convert.ToString(row["IO1_Off_Caption"]);


            if (!DBNull.Value.Equals(row["IO2_Caption"])) IO2_Caption = Convert.ToString(row["IO2_Caption"]);
            if (!DBNull.Value.Equals(row["IO2_Visible"])) IO2_Visible = Convert.ToString(row["IO2_Visible"]);
            if (!DBNull.Value.Equals(row["IO2_On_Caption"])) IO2_On_Caption = Convert.ToString(row["IO2_On_Caption"]);
            if (!DBNull.Value.Equals(row["IO2_Off_Caption"])) IO2_Off_Caption = Convert.ToString(row["IO2_Off_Caption"]);

            if (!DBNull.Value.Equals(row["IO3_Caption"])) IO3_Caption = Convert.ToString(row["IO3_Caption"]);
            if (!DBNull.Value.Equals(row["IO3_Visible"])) IO3_Visible = Convert.ToString(row["IO3_Visible"]);
            if (!DBNull.Value.Equals(row["IO3_On_Caption"])) IO3_On_Caption = Convert.ToString(row["IO3_On_Caption"]);
            if (!DBNull.Value.Equals(row["IO3_Off_Caption"])) IO3_Off_Caption = Convert.ToString(row["IO3_Off_Caption"]);


            if (!DBNull.Value.Equals(row["IO4_Caption"])) IO4_Caption = Convert.ToString(row["IO4_Caption"]);
            if (!DBNull.Value.Equals(row["IO4_Visible"])) IO4_Visible = Convert.ToString(row["IO4_Visible"]);
            if (!DBNull.Value.Equals(row["IO4_On_Caption"])) IO4_On_Caption = Convert.ToString(row["IO4_On_Caption"]);
            if (!DBNull.Value.Equals(row["IO4_Off_Caption"])) IO4_Off_Caption = Convert.ToString(row["IO4_Off_Caption"]);


            if (!DBNull.Value.Equals(row["Suhu01_Caption"])) Suhu01_Caption = Convert.ToString(row["Suhu01_Caption"]);
            if (!DBNull.Value.Equals(row["Suhu01_Visible"])) Suhu01_Visible = Convert.ToString(row["Suhu01_Visible"]);
            if (!DBNull.Value.Equals(row["Suhu02_Caption"])) Suhu02_Caption = Convert.ToString(row["Suhu02_Caption"]);
            if (!DBNull.Value.Equals(row["Suhu02_Visible"])) Suhu02_Visible = Convert.ToString(row["Suhu02_Visible"]);
        }
    }

    public class VehicleWithRoleOrder{
        public string ORDSTS { get; set; }
        public string GPS { get; set; }
        public string VSID { get; set; }
        public string REGNO { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public bool IO1 { get; set; }
        public double SPEED { get; set; }
        public DateTime LASTUPDATE { get; set; }
        public string POLYGON { get; set; }
        public double ANGLE { get; set; }
        public string IMEI { get; set; }
        //public string PROP { get; set; }
        //public string KAB { get; set; }
        //public string KEC { get; set; }
        //public string KEL { get; set; }
        //public string JALAN { get; set; }
        public bool IO2 { get; set; }
        public bool IO3 { get; set; }
        public bool IO4 { get; set; }
        public string MODEL { get; set; }
        public double PWR { get; set; }
        public double ODO { get; set; }
        public string GSMNO { get; set; }
        public double SUHU1 { get; set; }
        public double SUHU2 { get; set; }
        public Nullable<bool> GPSFIX { get; set; }
        public string ORDERNO { get; set; }
        public string ORIGIN { get; set; }
        public string DESTIN { get; set; }
        public string STATUS { get; set; }
        public string CUSTID { get; set; }
        public string DESC { get; set; }
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
    public class vwVehicleCombo{
        public string ORDSTS { get; set; }
        public string GPS { get; set; }
        public string VEHICLE_SID { get; set; }
        public string REG_NO { get; set; }
        public double LAST_WP_LAT { get; set; }
        public double LAST_WP_LON { get; set; }
        public bool LAST_IO1 { get; set; }
        public double LAST_WP_SPEED { get; set; }
        public DateTime LAST_UPDATE { get; set; }
        public string POLYGON { get; set; }
        public double HEADING { get; set; }
        public string VEHICLE_IMEI { get; set; }
        public string WP_PROPINSI { get; set; }
        public string WP_KABUPATEN { get; set; }
        public string WP_KECAMATAN { get; set; }
        public string WP_KELURAHAN { get; set; }
        public string WP_JALAN { get; set; }
        public bool LAST_IO2 { get; set; }
        public bool LAST_IO3 { get; set; }
        public bool LAST_IO4 { get; set; }
        public string MODEL_UNIT { get; set; }
        public double EXT_POWER { get; set; }
        public double KM_ODO { get; set; }
        public string CELLNO { get; set; }
        public double SUHU01 { get; set; }
        public double SUHU02 { get; set; }
        public Nullable<bool> LAST_GPS_STATUS { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string ORIGIN_NAME { get; set; }
        public string DESTINATION_NAME { get; set; }
        public string STATUS { get; set; }
        public string RECORD_ID { get; set; }
        public string CUSTOMER_SID { get; set; }
        public string DESCRIPTION { get; set; }
        public string ORIGIN_CODE { get; set; }
        public string DESTINATION_CODE { get; set; }
        public DateTime PICKUP_DATE { get; set; }
        public DateTime PROGRESS_DATE { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public DateTime ARRIVAL_DATE { get; set; }
        public DateTime COMPLETE_DATE { get; set; }
        public DateTime DUE_DATE { get; set; }
        public DateTime EXPIRED_DATE { get; set; }
        public string DRIVER_SID { get; set; }
        public string DRIVER_PHONE { get; set; }
        public string ROUTE_UID { get; set; }
        public string SWITCH_FROM { get; set; }

    }
}