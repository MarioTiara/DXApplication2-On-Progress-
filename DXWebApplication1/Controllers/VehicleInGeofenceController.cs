using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using DXWebApplication1.Models;
using System.Threading;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class VehicleInGeofenceController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID,ACCOUNT_SID;
        //
        // GET: /VehicleInGeofence/
        public ActionResult Index()
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                    LoadCombo();
                    LoadComboGeofences();
                    return View();
            }
             
             catch (Exception e)
             {

             }
             return null;
        }
        [ValidateInput(false)]
        public void LoadCombo()
        {
            object data;
            CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
            PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();
            DataTable result = new DataTable();

            if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Vehicle.GetAll();
            }
            else if (string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Vehicle.VehicleByCustomer(CUSTOMER_SID);
            }
            else if (!string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Vehicle.VehicleByCustomerProjectSID(CUSTOMER_SID, PROJECT_SID);
            }
            List<Models.vwVehicleCombo> list = new List<Models.vwVehicleCombo>();
            list.Add(new Models.vwVehicleCombo { REG_NO = "ALL VEHICLE", VEHICLE_SID = "" });
            for (int i = 0; i < result.Rows.Count; i++)
            {
                vwVehicleCombo DataView = new vwVehicleCombo();
                DataView.REG_NO = result.Rows[i]["REG_NO"].ToString();
                DataView.VEHICLE_SID = result.Rows[i]["VEHICLE_SID"].ToString();                          
                list.Add(DataView);
            }
            data = list;
           
            ViewBag.Data = data;

        }

        [ValidateInput(false)]
        public void LoadComboGeofences()
        {
            object data;
           

            DataTable result = new DataTable();

            result = BusinessLogic.Geofences.GetAll();

            List<Models.vwGeofenceCombo> list = new List<Models.vwGeofenceCombo>();
            list.Add(new Models.vwGeofenceCombo { GEOFENCE_NAME = "ALL GEOFENCE", GEOFENCE_SID=null});
            foreach (DataRow row in result.Rows)
            {
                vwGeofenceCombo objvwGeofenceCombo = new vwGeofenceCombo();
                objvwGeofenceCombo.GEOFENCE_NAME = Convert.ToString(row["GEOFENCE_NAME"]);
                objvwGeofenceCombo.GEOFENCE_SID = Convert.ToInt32(row["GEOFENCE_SID"]);
                list.Add(objvwGeofenceCombo);
            }
            data = list;
            ViewBag.DataGeo = data;

        }

        public ActionResult Grid()
        {
            if (Session["vwVehicleInGeofence"] != null)
            {
                ViewBag.Data = Session["vwVehicleInGeofence"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }

        }

        public ActionResult getViG(string VehicleSid, string FROM_DATE, string TO_DATE, Nullable<int> GeofenceSid)
        {       
    
            try
            {

                LoadCombo();
                object data;
                DataTable VinGDataTable = new DataTable();

                //Get data through DataAdapter based on input value from ComboBox
                if (string.IsNullOrEmpty(VehicleSid) && GeofenceSid != null)
                {
                    VinGDataTable = BusinessLogic.Report.VehicleInGeofenceGeoName(FROM_DATE, TO_DATE, GeofenceSid);
                }
                else if (!string.IsNullOrEmpty(VehicleSid) && GeofenceSid == null)
                {
                    VinGDataTable = BusinessLogic.Report.VehicleInGeofenceRegNo(FROM_DATE, TO_DATE, VehicleSid);
                }
                else if (string.IsNullOrEmpty(VehicleSid) && GeofenceSid == null)
                {
                    VinGDataTable = BusinessLogic.Report.VehicleInGeofenceAll(FROM_DATE, TO_DATE);
                }
                else if (!string.IsNullOrEmpty(VehicleSid) && GeofenceSid != null)
                {
                    VinGDataTable = BusinessLogic.Report.VehicleInGeofenceRegNoAndGeofenceName(FROM_DATE, TO_DATE, GeofenceSid, VehicleSid);
                }

                List<vwVehicleInGeofence> VehicleInGeoLIst = new List<vwVehicleInGeofence>();

                foreach (DataRow row in VinGDataTable.Rows)
                {
                    try
                    {
                        vwVehicleInGeofence objVehicleInGeofence = new vwVehicleInGeofence();
                        objVehicleInGeofence.VehicleSid = Convert.ToString(row["VehicleSid"]);
                        objVehicleInGeofence.REG_NO = Convert.ToString(row["REG_NO"]);
                        objVehicleInGeofence.GEOFENCE_NAME = Convert.ToString(row["GEOFENCE_NAME"]);
                        objVehicleInGeofence.EnterDate = Convert.ToDateTime(row["EnterDate"]);
                        objVehicleInGeofence.ExitDate = Convert.ToDateTime(row["ExitDate"]);
                        var Times = objVehicleInGeofence.ExitDate - objVehicleInGeofence.EnterDate;
                        if (Times.Days >0)
                        {
                            objVehicleInGeofence.DURATION = Times.ToString("%d") + " day(s) " +Times.ToString(@"hh\:mm\:ss");
                        }
                        else
                        {
                            objVehicleInGeofence.DURATION = Times.ToString(@"hh\:mm\:ss");
                        }

                        VehicleInGeoLIst.Add(objVehicleInGeofence);
                    }
                    catch (Exception e)
                    {
                        
                    }
                    
                }
                data = VehicleInGeoLIst;
                ViewBag.Data = data;
                Session["vwVehicleInGeofence"] = VehicleInGeoLIst;

               return PartialView("_GridView1Partial");
               //return View(data);
            }

            catch (Exception e)
            {
                
                
            }

            return null;
        }

        public ActionResult ExamplePartial()
        {
            if (DevExpressHelper.IsCallback)
                Thread.Sleep(500);
            return null;
        }
       
	}
}