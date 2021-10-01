using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using DevExpress.Web.Mvc;
using DXWebApplication1.Models;
using System.Globalization;
using System.Reflection;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace DXWebApplication1.Controllers
{
    [SessionState(SessionStateBehavior.Required)]   
    public class MapsController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
        public int ROLE;
        public DataTable result;
        public object datas;
        public string ORDST { get; set; }
        public string GPSST { get; set; }
      
        public ActionResult Index()
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                    getData();
                    getDataGeo();
                    getLatLon();
                    ViewBag.DataNull = "Select";
                    ViewBag.Data = Session["Vehicle"];
                    ViewBag.GeoNull = "Select";
                    ViewBag.DataGeo = Session["Geo"];
                    ViewBag.DataLatLOng = Session["LatLOng"];
                
                    return View();
              
            }
            catch (Exception e)
            {

            }
            return null;
        }

       

      
     
        public ActionResult getData()
        {


            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }
                   
                    try
                    {
                      this.CUSTOMER_SID = Session["CUSTOMER_SID"].ToString();
                    this.PROJECT_SID = Session["PROJECT_SID"].ToString();
                    if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_SID))
                    {
                        result = BusinessLogic.Vehicle.GetAll();
                    }
                    else if (string.IsNullOrEmpty(PROJECT_SID))
                    {
                        result = BusinessLogic.Vehicle.VehicleByCustomer(CUSTOMER_SID);
                    }else if  (!string.IsNullOrEmpty(PROJECT_SID))
                    {
                        result = BusinessLogic.Vehicle.VehicleByCustomerProjectSID(CUSTOMER_SID, PROJECT_SID);
                    }
                    List<VehicleWithRoleOrder> list = new List<VehicleWithRoleOrder>();
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        try
                        {
                            VehicleWithRoleOrder dataVw = new VehicleWithRoleOrder();
                            dataVw.VSID = result.Rows[i]["VEHICLE_SID"].ToString();
                            dataVw.ORDSTS = result.Rows[i]["ORDSTS"].ToString();
                            dataVw.GPS = result.Rows[i]["GPS"].ToString();
                            dataVw.REGNO = result.Rows[i]["REG_NO"].ToString();
                            dataVw.IMEI = result.Rows[i]["VEHICLE_IMEI"].ToString();
                            dataVw.LASTUPDATE = Convert.ToDateTime(result.Rows[i]["LAST_UPDATE"]);
                             if (DBNull.Value.Equals(result.Rows[i]["LAST_UPDATE"])){
                                 dataVw.LASTUPDATE = new DateTime(1970, 1, 1, 0, 0, 0);
                             }
                            dataVw.POLYGON = result.Rows[i]["POLYGON"].ToString();
                            dataVw.LOC = result.Rows[i]["WP_JALAN"].ToString() + ", " + result.Rows[i]["WP_KELURAHAN"].ToString()+", "+ result.Rows[i]["WP_KELURAHAN"].ToString()+", "+result.Rows[i]["WP_KECAMATAN"].ToString()+", "+result.Rows[i]["WP_KABUPATEN"].ToString()+", "+result.Rows[i]["WP_PROPINSI"].ToString();
                            dataVw.ANGLE = Convert.ToDouble(result.Rows[i]["HEADING"]);
                            dataVw.X = Convert.ToDouble(result.Rows[i]["LAST_WP_LAT"].ToString());
                            dataVw.Y = Convert.ToDouble(result.Rows[i]["LAST_WP_LON"].ToString());
                            dataVw.SPEED = Convert.ToDouble(result.Rows[i]["LAST_WP_SPEED"].ToString());
                            dataVw.ODO = Convert.ToDouble(result.Rows[i]["KM_ODO"].ToString());
                            dataVw.PWR = Convert.ToDouble(result.Rows[i]["EXT_POWER"].ToString());
                            dataVw.IO1 = Convert.ToBoolean(result.Rows[i]["LAST_IO1"]);
                            if (DBNull.Value.Equals(result.Rows[i]["LAST_IO1"]))
                            {
                                dataVw.IO1 = false;
                            }
                            dataVw.IO2 = Convert.ToBoolean(result.Rows[i]["LAST_IO2"]);
                            if (DBNull.Value.Equals(result.Rows[i]["LAST_IO2"]))
                            {
                                dataVw.IO2 = false;
                            }
                            dataVw.IO3 = Convert.ToBoolean(result.Rows[i]["LAST_IO3"]);
                            if (DBNull.Value.Equals(result.Rows[i]["LAST_IO3"]))
                            {
                                dataVw.IO3 = false;
                            }
                            dataVw.IO4 = Convert.ToBoolean(result.Rows[i]["LAST_IO4"]);
                            if (DBNull.Value.Equals(result.Rows[i]["LAST_IO4"]))
                            {
                                dataVw.IO4 = false;
                            }
                            dataVw.GPSFIX = Convert.ToBoolean( result.Rows[i]["LAST_GPS_STATUS"]);
                            dataVw.GSMNO = result.Rows[i]["CELLNO"].ToString();
                            dataVw.ORDERNO = result.Rows[i]["ORDER_NUMBER"].ToString();
                            dataVw.STATUS = result.Rows[i]["STATUS"].ToString();
                            dataVw.DESTIN = result.Rows[i]["DESTINATION_NAME"].ToString();
                            dataVw.ORIGIN = result.Rows[i]["ORIGIN_NAME"].ToString();
                            dataVw.IO1KEY = result.Rows[i]["IO1_Caption"].ToString();
                            dataVw.IO2KEY = result.Rows[i]["IO2_Caption"].ToString();
                            dataVw.IO3KEY = result.Rows[i]["IO3_Caption"].ToString();
                            dataVw.IO4KEY = result.Rows[i]["IO4_Caption"].ToString();
                            dataVw.SUHU1 = Convert.ToDouble(result.Rows[i]["SUHU01"].ToString());
                            dataVw.SUHU2 = Convert.ToDouble(result.Rows[i]["SUHU02"].ToString());
                            dataVw.IO1VALUE = result.Rows[i]["IO1_Off_Caption"].ToString();
                            if(dataVw.IO1.Equals(true))
                                dataVw.IO1VALUE = result.Rows[i]["IO1_On_Caption"].ToString();
                            dataVw.IO2VALUE = result.Rows[i]["IO2_Off_Caption"].ToString();
                            if (dataVw.IO2.Equals(true))
                                dataVw.IO2VALUE = result.Rows[i]["IO2_On_Caption"].ToString();
                            dataVw.IO3VALUE = result.Rows[i]["IO3_Off_Caption"].ToString();
                            if (dataVw.IO3.Equals(true))
                                dataVw.IO3VALUE = result.Rows[i]["IO3_On_Caption"].ToString();
                            dataVw.IO4VALUE = result.Rows[i]["IO4_Off_Caption"].ToString();
                            if (dataVw.IO4.Equals(true))
                                dataVw.IO4VALUE = result.Rows[i]["IO4_On_Caption"].ToString();
                            dataVw.SUHU1KEY = "";
                            if (!DBNull.Value.Equals(result.Rows[i]["Suhu01_Caption"]))
                                dataVw.SUHU1KEY = Convert.ToString(result.Rows[i]["Suhu01_Caption"]);
                            dataVw.SUHU2KEY = "";
                            if (!DBNull.Value.Equals(result.Rows[i]["Suhu02_Caption"]))
                                dataVw.SUHU2KEY = Convert.ToString(result.Rows[i]["Suhu02_Caption"]);
                            list.Add(dataVw);
                        
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.Write(e);
                        }
                    }
                    datas = list;
                    Session["Vehicle"] = datas;
                    var jsonResult = Json(datas, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception e)
                {

                }
              
              
                return null;
              
        }


        [ValidateInput(false)]
        public ActionResult getDataGeo()
        {
            try
            {
                object datageos;

                DataTable geofence = new DataTable();
                geofence = BusinessLogic.Geofences.GetAll();
                List<ModelGeofencesCmb> listGeo = new List<ModelGeofencesCmb>();
                for (int j = 0; j < geofence.Rows.Count; j++)
                {
                    ModelGeofencesCmb dataVw = new ModelGeofencesCmb();
                    dataVw.GEOFENCE_CODE = geofence.Rows[j]["GEOFENCE_CODE"].ToString();
                    dataVw.GEOFENCE_SPEED = Convert.ToDouble(geofence.Rows[j]["GEOFENCE_SPEED"]);
                    dataVw.GEOFENCE_TYPE = geofence.Rows[j]["GEOFENCE_TYPE"].ToString();
                    dataVw.GEOFENCE_GEOM = geofence.Rows[j]["GEOFENCE_GEOM"].ToString();
                    dataVw.GEOFENCE_NAME = geofence.Rows[j]["GEOFENCE_NAME"].ToString();

                    listGeo.Add(dataVw);
                }

             
                datageos = listGeo;
                Session["Geo"] = datageos;

                var jsonResult = Json(datageos, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception e)
            {

            }
            return null;
        }


        public ActionResult getGeofencesInfo(string GEONAME)
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                object datageoinfo;

                DataTable geofence = new DataTable();
                geofence = BusinessLogic.Geofences.GetGeofenceInfo(GEONAME);
                List<ModelGeofencesCmb> listGeo = new List<ModelGeofencesCmb>();
                for (int j = 0; j < geofence.Rows.Count; j++)
                {
                    ModelGeofencesCmb dataVw = new ModelGeofencesCmb();
                    dataVw.GEOFENCE_SID = geofence.Rows[j]["GEOFENCE_SID"].ToString();
                    dataVw.GEOFENCE_CODE = geofence.Rows[j]["GEOFENCE_CODE"].ToString();
                    dataVw.GEOFENCE_SPEED = Convert.ToDouble(geofence.Rows[j]["GEOFENCE_SPEED"]);
                    dataVw.GEOFENCE_TYPE = geofence.Rows[j]["GEOFENCE_TYPE"].ToString();
                    dataVw.GEOFENCE_POINT = geofence.Rows[j]["GEOFENCE_POINT"].ToString();
                    dataVw.GEOFENCE_NAME = geofence.Rows[j]["GEOFENCE_NAME"].ToString();
                    dataVw.GEOFENCE_GEOM = geofence.Rows[j]["GEOFENCE_GEOM"].ToString();
                    dataVw.GEOFENCE_LAT = geofence.Rows[j]["GEOFENCE_LAT"].ToString();
                    dataVw.GEOFENCE_LON = geofence.Rows[j]["GEOFENCE_LON"].ToString();
                    dataVw.GEOFENCE_ALERT = Convert.ToBoolean(geofence.Rows[j]["GEOFENCE_ALERT"].ToString());
                    dataVw.IS_ACTIVE = Convert.ToBoolean(geofence.Rows[j]["IS_ACTIVE"].ToString());
                    listGeo.Add(dataVw);
                    Session["GeoSid"] = dataVw.GEOFENCE_SID;
                    Session["Alert"] = dataVw.GEOFENCE_ALERT;
                    Session["Active"] = dataVw.IS_ACTIVE;

                }


                datageoinfo = listGeo;
                //Session["Geo"] = datageos;

                var jsonResult = Json(datageoinfo, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult getWaypointInfo(string VEHICLE_SID, string FROM_DATE, string TO_DATE)
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                object datawaypoint;

                DataTable waypoint = new DataTable();
                waypoint = BusinessLogic.Waypoint.GetWaypointInfo(VEHICLE_SID, FROM_DATE, TO_DATE);
                List<ModelWaypoint> listwaypoint = new List<ModelWaypoint>();
                for (int j = 0; j < waypoint.Rows.Count; j++)
                {
                    ModelWaypoint dataVw = new ModelWaypoint();
                    dataVw.REGNO = waypoint.Rows[j]["REG_NO"].ToString();
                    dataVw.WP_LAT = Convert.ToDouble(waypoint.Rows[j]["WP_LAT"]);
                    dataVw.WP_LON = Convert.ToDouble(waypoint.Rows[j]["WP_LON"]);
                    dataVw.WP_IO1 = Convert.ToBoolean(waypoint.Rows[j]["WP_IO1"]);
                    dataVw.WP_SPEED = Convert.ToDouble(waypoint.Rows[j]["WP_SPEED"]);
                    dataVw.LOC = waypoint.Rows[j]["WP_JALAN"].ToString() + ", " + waypoint.Rows[j]["WP_KELURAHAN"].ToString() + ", " + waypoint.Rows[j]["WP_KECAMATAN"].ToString() + ", " + waypoint.Rows[j]["WP_KABUPATEN"].ToString() + ", " + waypoint.Rows[j]["WP_PROPINSI"].ToString() + "(" + waypoint.Rows[j]["POLYGON"].ToString()+")";
                    dataVw.WP_TIME = Convert.ToDateTime(waypoint.Rows[j]["WP_TIME"]);
                    dataVw.ANGLE = Convert.ToDouble(waypoint.Rows[j]["HEADING"]);
                    dataVw.WP_IO2 = Convert.ToBoolean(waypoint.Rows[j]["WP_IO2"]);
                    dataVw.WP_IO3 = Convert.ToBoolean(waypoint.Rows[j]["WP_IO3"]);
                    dataVw.WP_IO4 = Convert.ToBoolean(waypoint.Rows[j]["WP_IO4"]);
                    dataVw.MODEL = waypoint.Rows[j]["MODEL_UNIT"].ToString();
                    dataVw.PWR = Convert.ToDouble(waypoint.Rows[j]["EXT_POWER"]);
                    dataVw.ODO = Convert.ToDouble(waypoint.Rows[j]["KM_ODO"]);
                    dataVw.GSMNO = waypoint.Rows[j]["CELLNO"].ToString();
                    dataVw.SUHU1 = Convert.ToDouble(waypoint.Rows[j]["SUHU01"]);
                    dataVw.SUHU2 = Convert.ToDouble(waypoint.Rows[j]["SUHU02"]);
                    dataVw.IO1KEY = Convert.ToString(waypoint.Rows[j]["IO1_Caption"]);
                    dataVw.IO2KEY = Convert.ToString(waypoint.Rows[j]["IO2_Caption"]);
                    dataVw.IO3KEY = Convert.ToString(waypoint.Rows[j]["IO3_Caption"]);
                    dataVw.IO4KEY = Convert.ToString(waypoint.Rows[j]["IO4_Caption"]);

                    dataVw.IO1VALUE = Convert.ToString(waypoint.Rows[j]["IO1_Off_Caption"]);
                    if (dataVw.WP_IO1.Equals(true))
                    {
                        dataVw.IO1VALUE = Convert.ToString(waypoint.Rows[j]["IO1_On_Caption"]);
                    }
                    dataVw.IO2VALUE = Convert.ToString(waypoint.Rows[j]["IO2_Off_Caption"]);
                    if (dataVw.WP_IO2.Equals(true))
                    {
                        dataVw.IO2VALUE = Convert.ToString(waypoint.Rows[j]["IO2_On_Caption"]);
                    }
                    dataVw.IO3VALUE = Convert.ToString(waypoint.Rows[j]["IO3_Off_Caption"]);
                    if (dataVw.WP_IO3.Equals(true))
                    {
                        dataVw.IO3VALUE = Convert.ToString(waypoint.Rows[j]["IO3_On_Caption"]);
                    }
                    dataVw.IO4VALUE = Convert.ToString(waypoint.Rows[j]["IO4_Off_Caption"]);
                    if (dataVw.WP_IO4.Equals(true))
                    {
                        dataVw.IO4VALUE = Convert.ToString(waypoint.Rows[j]["IO4_On_Caption"]);
                    }
                    listwaypoint.Add(dataVw);
                }


                datawaypoint = listwaypoint;
                var jsonResult = Json(datawaypoint, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult GridViewPartialView(string ORDERSTS,string Title)
        {

            object DataS;
            
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }

                if (!string.IsNullOrEmpty(ORDERSTS))
                {
                    Session["STAT"] = ORDERSTS; 
                }

                if (Session["STAT"].ToString().Equals("OFGOENSN"))
                {
                    Title = "No Orders - GPS OFF";
                }
                else if (Session["STAT"].ToString().Equals("OFGUETSN"))
                {
                    Title = "No Orders - Engine ON";
                }
                else if (Session["STAT"].ToString().Equals("OFGUEFSN"))
                {
                    Title = "No Orders - Engine OFF";
                }
                else if (Session["STAT"].ToString().Equals("OFGUEFSN"))
                {

                }
                else if (Session["STAT"].ToString().Equals("OFGUETSN"))
                {
                    Title = "No Orders - Engine ON";
                }
                else if (Session["STAT"].ToString().Equals("OFGUEFSN"))
                {
                    Title = "No Orders - Engine OFF";
                }
                else if (Session["STAT"].ToString().Equals("OTGDENSN"))
                {
                    Title = "With Orders - GPS Delay";
                }
                else if (Session["STAT"].ToString().Equals("OTGUEOSOVS"))
                {
                    Title = "With Orders - Overstay";
                }
                else if (Session["STAT"].ToString().Equals("OTGUENSNLD"))
                {
                    Title = "With Orders - No Load";
                }
                else if (Session["STAT"].ToString().Equals("OTGUENSWTG"))
                {
                    Title = "With Orders - Waiting For Loading";
                }
                else if (Session["STAT"].ToString().Equals("OTGUENSOND"))
                {
                    Title = "With Orders - On Delivery";
                }
                else if (Session["STAT"].ToString().Equals("OTGUENSOVN"))
                {
                    Title = "With Orders - Overnigth";
                }
                else if (Session["STAT"].ToString().Equals("OTGUENSABN"))
                {
                    Title = "With Orders - Late Pickup Or Late Arrival";
                }

                ViewBag.TitlePopup = Title;

               DataS = Session["Vehicle"];
               var Details = DataS as List<VehicleWithRoleOrder>;
               ListtoDataTable lsttodt = new ListtoDataTable();
               DataTable res = lsttodt.ToDataTable(Details);
                List<VehicleWithRoleOrder> list = new List<VehicleWithRoleOrder>();
                for (var i = 0; i < Details.Count; i++)
                {
                    VehicleWithRoleOrder dataVw = new VehicleWithRoleOrder();
                    dataVw.ORDSTS = res.Rows[i]["ORDSTS"].ToString();
                    if (Session["STAT"].Equals(dataVw.ORDSTS))
                    {
                        try
                        {
                            dataVw.REGNO = Convert.ToString(res.Rows[i]["REGNO"]);
                            dataVw.LASTUPDATE = Convert.ToDateTime(res.Rows[i]["LASTUPDATE"]);
                            dataVw.IMEI = Convert.ToString(res.Rows[i]["IMEI"]);
                            dataVw.LOC = res.Rows[i]["LOC"].ToString();
                            dataVw.POLYGON = res.Rows[i]["POLYGON"].ToString();
                            dataVw.SPEED = Convert.ToDouble(res.Rows[i]["SPEED"].ToString());
                            dataVw.ODO = Math.Round(Convert.ToDouble(res.Rows[i]["ODO"].ToString()));
                            dataVw.GPSFIX = Convert.ToBoolean(res.Rows[i]["GPSFIX"].ToString());
                            dataVw.IO1 = Convert.ToBoolean(res.Rows[i]["IO1"].ToString());
                            dataVw.IO2 = Convert.ToBoolean(res.Rows[i]["IO2"].ToString());
                            dataVw.IO3 = Convert.ToBoolean(res.Rows[i]["IO3"].ToString());
                            dataVw.IO4 = Convert.ToBoolean(res.Rows[i]["IO4"].ToString());
                            list.Add(dataVw);
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.Write(e);
                        }
                    }
                }
                Session["OrderVehicle"] = list;
                ViewBag.Vec = list;
                return PartialView("GridViewPartialView");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e);
            }
            //ViewBag.Vec = Session["Vehicle"];
            return null;
        }

        public ActionResult GridViewPartialViewGPS(string GPSTAT, string Title)
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }

                if (!string.IsNullOrEmpty(GPSTAT))
                {
                    Session["GPSTAT"] = GPSTAT; 
                }

                if (Session["GPSTAT"].ToString().Equals("INACTIVE"))
                {
                    Title = "INACTIVE";
                }
                else if (Session["GPSTAT"].ToString().Equals("DELAY"))
                {
                    Title = "DELAY";
                }
                else if (Session["GPSTAT"].ToString().Equals("ACTIVE"))
                {
                    Title = "ACTIVE";
                }

                ViewBag.TitlePopup = Title;
                object DataS = Session["Vehicle"];
                var Details = DataS as List<VehicleWithRoleOrder>;
                ListtoDataTable lsttodt = new ListtoDataTable();
                DataTable res = lsttodt.ToDataTable(Details);
                List<VehicleWithRoleOrder> list = new List<VehicleWithRoleOrder>();
                for (var i = 0; i < Details.Count; i++)
                {
                    VehicleWithRoleOrder dataVw = new VehicleWithRoleOrder();
                    dataVw.GPS = res.Rows[i]["GPS"].ToString();
                    if (Session["GPSTAT"].Equals(dataVw.GPS))
                    {
                        try
                        {
                            dataVw.REGNO = Convert.ToString(res.Rows[i]["REGNO"]);
                            dataVw.LASTUPDATE = Convert.ToDateTime(res.Rows[i]["LASTUPDATE"]);
                            dataVw.IMEI = Convert.ToString(res.Rows[i]["IMEI"]);
                            dataVw.GSMNO = Convert.ToString(res.Rows[i]["GSMNO"]);
                            dataVw.LOC = res.Rows[i]["LOC"].ToString();
                            dataVw.POLYGON = res.Rows[i]["POLYGON"].ToString();
                            dataVw.SPEED = Convert.ToDouble(res.Rows[i]["SPEED"].ToString());
                            dataVw.ODO =  Math.Round(Convert.ToDouble(res.Rows[i]["ODO"].ToString()));
                            dataVw.GPSFIX = Convert.ToBoolean(res.Rows[i]["GPSFIX"].ToString());
                            dataVw.IO1 = Convert.ToBoolean(res.Rows[i]["IO1"].ToString());
                            dataVw.IO2 = Convert.ToBoolean(res.Rows[i]["IO2"].ToString());
                            dataVw.IO3 = Convert.ToBoolean(res.Rows[i]["IO3"].ToString());
                            dataVw.IO4 = Convert.ToBoolean(res.Rows[i]["IO4"].ToString());
                            list.Add(dataVw);
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.Write(e);
                        }
                    }
                }
                Session["GPSVehicle"] = list;
                ViewBag.Vec = list;
                return PartialView("PopUpStat");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e);
            }
            return null;
        }

        public ActionResult SetFormGeofence(string TYPE)
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (TYPE.Equals("Add")){
                getGeofenceCode();
                getGeofenceType();
            }
            else if (TYPE.Equals("Edit"))
            {
               getGeofenceType();
               ViewBag.Alert = Session["Alert"];
               ViewBag.Active = Session["Active"];
            }
            return PartialView("FormGeofence");
        }

        public ActionResult getLatLon()
        {
            try
            {
                object LatLongData;

                DataTable GeofenceLatLongDataTable = new DataTable();
                GeofenceLatLongDataTable = BusinessLogic.Geofences.GetGeofenceLatLong();
                List<ModellatLong> LatLongDataList = new List<ModellatLong>();
                foreach ( DataRow row in GeofenceLatLongDataTable.Rows)
                {
                    ModellatLong objlatLong = new ModellatLong();
                    objlatLong.geofence_name = Convert.ToString(row["geofence_name"]);
                    objlatLong.LatLong = Convert.ToString(row["latLong"]);
                    LatLongDataList.Add(objlatLong);
                }

                LatLongData = LatLongDataList;
                Session["LatLOng"] = LatLongData;
            }
            catch (Exception e)
            {
                
                
            }

            return null; 
        }

        //Get Geofence From LMS

        [ValidateInput(false)]
        public ActionResult getGeofenceType()
        {
            try
            {
                object datageotype;
                DataTable geofence = new DataTable();
                geofence = BusinessLogic.Geofences.GetGeofenceType();
                List<ModelGeofenceType> listGeo = new List<ModelGeofenceType>();
                for (int j = 0; j < geofence.Rows.Count; j++)
                {
                    ModelGeofenceType dataVw = new ModelGeofenceType();
                    dataVw.GEOFENCE_TYPE = geofence.Rows[j]["GEOFENCE_TYPE"].ToString();
                    listGeo.Add(dataVw);
                }
                datageotype = listGeo;
                Session["GeoType"] = datageotype;
                ViewBag.GEOType = Session["GeoType"];

                var jsonResult = Json(ViewBag.GEOCODE, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception e)
            {

            }
            return null;
        }


        [ValidateInput(false)]
        public ActionResult getGeofenceCode()
        {
            try
            {
                object datageocode;
                DataTable geofence = new DataTable();
                geofence = BusinessLogic.Geofences.GetGeofenceCode();
                List<ModelGetGeofenceCode> listGeo = new List<ModelGetGeofenceCode>();
                for (int j = 0; j < geofence.Rows.Count; j++)
                {
                    ModelGetGeofenceCode dataVw = new ModelGetGeofenceCode();
                    dataVw.GEOFENCE_CODE = geofence.Rows[j]["GEOFENCE_CODE"].ToString();
                    listGeo.Add(dataVw);
                }
                datageocode = listGeo;
                Session["GeoCode"] = datageocode;
                ViewBag.GEOCODE = Session["GeoCode"];

                var jsonResult = Json(ViewBag.GEOCODE, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception e)
            {

            }
            return null;
        }



        public ActionResult GetGeofenceInfoLMS(string GEOFENCE_CODE)
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }

                object datageolms;

                DataTable geofence = new DataTable();
                geofence = BusinessLogic.Geofences.GetGeofenceInfoLMS(GEOFENCE_CODE);
                List<ModelGetGeofenceFromLMS> listGeo = new List<ModelGetGeofenceFromLMS>();
                for (int j = 0; j < geofence.Rows.Count; j++)
                {
                    ModelGetGeofenceFromLMS dataVw = new ModelGetGeofenceFromLMS();
                    dataVw.GEOFENCE_NAME = geofence.Rows[j]["GEOFENCE_NAME"].ToString();   
                    dataVw.GEOFENCE_LAT = geofence.Rows[j]["GEOFENCE_LAT"].ToString();
                    dataVw.GEOFENCE_LON = geofence.Rows[j]["GEOFENCE_LON"].ToString();
                    listGeo.Add(dataVw);
                }
                datageolms = listGeo;
                Session["GeoDataLMS"] = datageolms;
                ViewBag.GeoDataLMS = datageolms;
                //return ViewBag.GeoDataLMS;
                var jsonResult = Json(ViewBag.GeoDataLMS, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception e)
            {

            }
            return null;
        }


        public ActionResult SaveNewGeofence
            ( 
               string GEOFENCE_TYPE,
               string GEOFENCE_CODE,
               string GEOFENCE_NAME,
               string GEOFENCE_LAT,
               string GEOFENCE_LON,
               string GEOFENCE_SPEED,
               string GEOFENCE_GEOM,
               string GEOFENCE_ALERT,
               string IS_ACTIVE
            )
        
             
        {   
            try
            {
                string COMPANY_SID = Session["COMPANY_SID"].ToString();
                string DIVISION_SID = Session["DIVISION_SID"].ToString();
                string SUBDIVISION_SID = Session["SUBDIVISION_SID"].ToString();
                if (DIVISION_SID.Equals(null) || DIVISION_SID.Equals(""))
                {
                    DIVISION_SID = "00000000-0000-0000-0000-000000000000";
                }
                if (SUBDIVISION_SID.Equals(null) || SUBDIVISION_SID.Equals(""))
                {
                    SUBDIVISION_SID = "00000000-0000-0000-0000-000000000000";
                }
                string ACCOUNT_SID = Session["ACCOUNT_SID"].ToString();
                DateTime CREATE_DATE = DateTime.Now;
                if (GEOFENCE_CODE.Count() > 0 || GEOFENCE_TYPE.Equals("OTH"))
                {
                    BusinessLogic.Geofences.Insert(
                            COMPANY_SID,
                            DIVISION_SID,
                            SUBDIVISION_SID,
                            GEOFENCE_TYPE,
                            GEOFENCE_CODE,
                            GEOFENCE_NAME,
                            GEOFENCE_LAT,
                            GEOFENCE_LON,
                            GEOFENCE_SPEED,
                            GEOFENCE_GEOM,
                            ACCOUNT_SID,
                            GEOFENCE_ALERT,
                            IS_ACTIVE
                        );
                }
               
            }
            catch (Exception e)
            {

            }
            return null;
        }


        public ActionResult UpdateGeofence
           (
              string GEOFENCE_TYPE,
              string GEOFENCE_CODE,
              string GEOFENCE_NAME,
              string GEOFENCE_LAT,
              string GEOFENCE_LON,
              string GEOFENCE_SPEED,
              string GEOFENCE_GEOM,
              string GEOFENCE_ALERT,
              string IS_ACTIVE
           )
        {
            try
            {
                string COMPANY_SID = Session["COMPANY_SID"].ToString();
                string DIVISION_SID = Session["DIVISION_SID"].ToString();
                string SUBDIVISION_SID = Session["SUBDIVISION_SID"].ToString();
                if (DIVISION_SID.Equals(null) || DIVISION_SID.Equals(""))
                {
                    DIVISION_SID = "00000000-0000-0000-0000-000000000000";
                }
                if (SUBDIVISION_SID.Equals(null) || SUBDIVISION_SID.Equals(""))
                {
                    SUBDIVISION_SID = "00000000-0000-0000-0000-000000000000";
                }
                string ACCOUNT_SID = Session["ACCOUNT_SID"].ToString(); 
                string GEOFENCE_SID = Convert.ToString(Session["GeoSid"]);
                if (GEOFENCE_CODE.Count() > 0 || GEOFENCE_TYPE.Equals("OTH"))
                {
                    BusinessLogic.Geofences.Update(
                            COMPANY_SID,
                            DIVISION_SID,
                            SUBDIVISION_SID,
                            GEOFENCE_TYPE,
                            GEOFENCE_CODE,
                            GEOFENCE_NAME,
                            GEOFENCE_LAT,
                            GEOFENCE_LON,
                            GEOFENCE_SPEED,
                            GEOFENCE_GEOM,
                            ACCOUNT_SID,
                            GEOFENCE_ALERT,
                            IS_ACTIVE,
                            GEOFENCE_SID
                        );
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }


        public ActionResult GetSession()
        {
            string surname  = "";  
            if (Session["ACCOUNT_SID"] == null)
            {
                //HttpContext.Response.Redirect("~/Login");
                surname = "";
            }
            else if (System.Web.HttpContext.Current.Session["ACCOUNT_SID"] != null)
            {
                surname = System.Web.HttpContext.Current.Session["ACCOUNT_SID"].ToString();
            }
            var jsonResult = Json(surname , JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        
        }
        // Convert To Datatable
        public class ListtoDataTable
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
        }

        public ActionResult ExamplePartial()
        {
            if (DevExpressHelper.IsCallback)
                Thread.Sleep(500);
            return null;
        }
      

	}
}