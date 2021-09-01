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
    public class EventReportController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
        //
        // GET: /EventReport/
        public ActionResult Index(string FROM_DATE = null, string  TO_DATE = null,  string VehicleSid = "")
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                    LoadCombo();
                    return View();
                

            }
            catch (Exception e)
            {

            }
            return null;
        }

        // LOAD COMBO
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
            list.Add(new Models.vwVehicleCombo { REG_NO = "Select Vehicle", VEHICLE_SID = "" });
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
        // CALLBACK RESULT
        public ActionResult Grid()
        {

            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (Session["vwEventReport"] != null)
            {
                ViewBag.Datas = Session["vwEventReport"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }
            
        }
        // GET RESULT
        [ValidateInput(false)]
        public ActionResult getEvent(string FROM_DATE, string TO_DATE, string VehicleSid)
        {
            LoadCombo();
            
            object datas;
           
            Dictionary<string, string> vehicles = new Dictionary<string, string>();
            DataTable result = new DataTable();
            DataTable results = new DataTable();
            if (VehicleSid != null)
            {
                result = BusinessLogic.EventReport.GetData(VehicleSid, FROM_DATE, TO_DATE);
            }


            List<vwEventReport> list = new List<vwEventReport>();
            for (int i = 0; i < result.Rows.Count; i++)
            {
                vwEventReport DataView = new vwEventReport();
              
                        if (result.Rows[i]["EventName"].Equals("Enter Geofence") && Convert.ToInt64(result.Rows[i]["ID"]) == 14)
                        {
                            DataView.DESCRIPT = result.Rows[i]["EventName"].ToString();

                        }
                        else if (result.Rows[i]["EventName"].Equals("Exit Geofence") && Convert.ToInt64(result.Rows[i]["ID"]) == 13)
                        {
                            DataView.DESCRIPT = result.Rows[i]["EventName"].ToString();

                        }
                        else if (result.Rows[i]["ID"].Equals(26))
                        {
                            DataView.DESCRIPT = "Exit Kab/Kota";

                        }
                        else if (result.Rows[i]["ID"].Equals(27))
                        {
                            DataView.DESCRIPT = "Enter Kab/Kota";

                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 1 Off"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO1_Caption"].ToString() + " " + result.Rows[i]["IO1_Off_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 1 On"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO1_Caption"].ToString() + " " + result.Rows[i]["IO1_On_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 2 Off"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO2_Caption"].ToString() + " " + result.Rows[i]["IO2_Off_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 2 On"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO2_Caption"].ToString() + " " + result.Rows[i]["IO2_On_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 3 Off"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO3_Caption"].ToString() + " " + result.Rows[i]["IO3_Off_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 3 On"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO3_Caption"].ToString() + " " + result.Rows[i]["IO3_On_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 4 Off"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO4_Caption"].ToString() + " " + result.Rows[i]["IO4_Off_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else if (result.Rows[i]["EventName"].Equals("Input 4 On"))
                        {
                            DataView.DESCRIPT = result.Rows[i]["IO4_Caption"].ToString() + " " + result.Rows[i]["IO4_On_Caption"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        else
                        {
                            DataView.DESCRIPT = result.Rows[i]["EventName"].ToString();
                            DataView.GEOFENCE_NAME = "";
                        }
                        DataView.REG_NO = result.Rows[i]["REG_NO"].ToString();
                        DataView.EventTime = Convert.ToDateTime(result.Rows[i]["EventTime"].ToString());
                        DataView.POLYGON = result.Rows[i]["POLYGON"].ToString();
                        DataView.WP_JALAN = result.Rows[i]["WP_JALAN"].ToString();
                        DataView.WP_KELURAHAN = result.Rows[i]["WP_KELURAHAN"].ToString();
                        DataView.WP_KECAMATAN = result.Rows[i]["WP_KECAMATAN"].ToString();
                        DataView.WP_KABUPATEN = result.Rows[i]["WP_KABUPATEN"].ToString();
                        DataView.WP_PROPINSI = result.Rows[i]["WP_PROPINSI"].ToString();

                list.Add(DataView);
            }
            datas = list;
            ViewBag.Datas = datas;
            //var jsonResult = Json(datas, JsonRequestBehavior.AllowGet);
            //jsonResult.MaxJsonLength = int.MaxValue;
            Session["vwEventReport"] = list;
            return PartialView("_GridView1Partial");
        }



        public ActionResult ExamplePartial()
        {
            if (DevExpressHelper.IsCallback)
                Thread.Sleep(500);
            return null;
        }


     
	}
}