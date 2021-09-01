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
    public class DetailActivityReportController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID , ACCOUNT_SID;
       
        public ActionResult Index()
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


        public ActionResult Grid()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (Session["vwDetailActivityReport"] != null)
            {
                ViewBag.Datas = Session["vwDetailActivityReport"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }

        }

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
                result = BusinessLogic.Report.GetDataDetailActivityReport(VehicleSid, FROM_DATE, TO_DATE);
            }

            List<Models.vwDetailActivityReport> list = new List<Models.vwDetailActivityReport>(result.Rows.Count);
            foreach (DataRow row in result.Rows)
            {
                list.Add(new Models.vwDetailActivityReport(row));
            }
            datas = list;
            ViewBag.Datas = datas;
            Session["vwDetailActivityReport"] = list;
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