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
    public class OdoMeterSummaryController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
        //
        // GET: /OdoMeterSummary/
        public ActionResult Index()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }
            LoadCombo();
            return View();
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

            if (Session["vwOdoMeterReport"] != null)
            {
                ViewBag.Datas = Session["vwOdoMeterReport"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }

        }

        public ActionResult getData(string VehicleSid , string FROM_DATE, string TO_DATE)
        {
            try
            {

                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }

                LoadCombo();
                object datas;
                Dictionary<string, string> vehicles = new Dictionary<string, string>();
                DataTable result = new DataTable();
                DataTable results = new DataTable();
                if (string.IsNullOrEmpty(VehicleSid))
                {
                    result = BusinessLogic.Report.OdoMeterReport(FROM_DATE, TO_DATE);
                }
                else if (!string.IsNullOrEmpty(VehicleSid))
                {
                    result = BusinessLogic.Report.OdoMeterReportByVehicle(VehicleSid, FROM_DATE, TO_DATE);
                }
                List<Models.vwOdoMeterReport> list = new List<Models.vwOdoMeterReport>(result.Rows.Count);
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    vwOdoMeterReport DataView = new vwOdoMeterReport();
                    DataView.RECORD_ID = result.Rows[i]["RECORD_ID"].ToString();
                    DataView.VehicleSid = result.Rows[i]["VehicleSid"].ToString();
                    DataView.RegNo = result.Rows[i]["REG_NO"].ToString();
                    DataView.TripDate = Convert.ToDateTime(result.Rows[i]["TripDate"]);
                    DataView.StartOdometer = Convert.ToInt32(result.Rows[i]["StartOdometer"]);
                    DataView.StartGeofence = result.Rows[i]["StartGeofence"].ToString();
                    DataView.LocationStart = result.Rows[i]["StartJalan"].ToString() + ", " + result.Rows[i]["StartKelurahan"].ToString() + ", " + result.Rows[i]["StartKecamatan"].ToString() + ", " + result.Rows[i]["StartKabupaten"].ToString() + ", " + result.Rows[i]["StartPropinsi"].ToString();
                    DataView.LocationEnd = result.Rows[i]["EndJalan"].ToString() + ", " + result.Rows[i]["EndKelurahan"].ToString() + ", " + result.Rows[i]["EndKecamatan"].ToString() + ", " + result.Rows[i]["EndKabupaten"].ToString() + ", " + result.Rows[i]["EndPropinsi"].ToString();
                    DataView.EndGeofence = result.Rows[i]["EndGeofence"].ToString();
                    DataView.EndOdometer = Convert.ToInt32( result.Rows[i]["EndOdometer"]);
                    DataView.Mileage = Math.Round(Convert.ToInt32(result.Rows[i]["Mileage"])*1e-3);
                    list.Add(DataView);
                }
                datas = list;
                ViewBag.Datas = datas;
                Session["vwOdoMeterReport"] = list;
                return PartialView("_GridView1Partial");
            }
            catch (Exception e)
            {

            }
            return null;

            }
           

        

	}
}