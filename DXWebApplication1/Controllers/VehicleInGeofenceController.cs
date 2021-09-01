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
            list.Add(new Models.vwVehicleCombo { REG_NO = "SELECT VEHICLE", VEHICLE_SID = "" });
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

                List<Models.ModelGeofences> list = new List<Models.ModelGeofences>(result.Rows.Count);
            
            foreach (DataRow row in result.Rows)
            {   
                list.Add(new Models.ModelGeofences(row));
            }
            data = list;

            ViewBag.DataGeo = data;

        }

        public ActionResult Grid()
        {
            if (Session["vwVehicleInGeofence"] != null)
            {
                ViewBag.Datas = Session["vwVehicleInGeofence"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }

        }


        public ActionResult getEvent(string FROM_DATE, string TO_DATE, string VehicleSid, string Geofence)
        {
            try
            {
                LoadCombo();
                object datas;
                Dictionary<string, string> vehicles = new Dictionary<string, string>();
                DataTable result = new DataTable();

                if (string.IsNullOrEmpty(VehicleSid))
                {
                    result = BusinessLogic.Report.VehicleInGeofence(FROM_DATE, TO_DATE, Geofence);

                }
                else if (!string.IsNullOrEmpty(VehicleSid) && string.IsNullOrEmpty(Geofence))
                {
                    result = BusinessLogic.Report.VehicleInGeofenceRegNo(FROM_DATE, TO_DATE, VehicleSid);
                }
                else if (!string.IsNullOrEmpty(VehicleSid) && !string.IsNullOrEmpty(Geofence))
                {
                    result = BusinessLogic.Report.VehicleInGeofenceRegNoAndPolygon(FROM_DATE, TO_DATE, Geofence, VehicleSid);
                }

                List<vwVehicleInGeofence> list = new List<vwVehicleInGeofence>();
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    try
                    {
                        vwVehicleInGeofence dataVw = new vwVehicleInGeofence();
                        dataVw.REG_NO = result.Rows[i]["REG_NO"].ToString();
                        dataVw.Polygon = result.Rows[i]["Polygon"].ToString();
                        dataVw.EnterTime = Convert.ToDateTime(result.Rows[i]["EnterTime"]);
                        dataVw.ExitTime = Convert.ToDateTime(result.Rows[i]["ExitTime"]);
                        var diffTicks = (dataVw.ExitTime - dataVw.EnterTime);
                        dataVw.DURATION = diffTicks.Days + " Days " + diffTicks.Hours + " Hours :" + diffTicks.Minutes + " Minutes :" + diffTicks.Seconds + " Seconds :";
                        list.Add(dataVw);
                    }
                    catch (Exception e)
                    {

                    }
                }
                datas = list;
                ViewBag.Datas = datas;
                Session["vwVehicleInGeofence"] = list;
                return PartialView("_GridView1Partial");
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