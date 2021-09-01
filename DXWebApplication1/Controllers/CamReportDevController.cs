using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DXWebApplication1.Models;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class CamReportDevController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
        //
        // GET: /CamReportDev/
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

        public ActionResult Grid()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (Session["ModelCamera"] != null)
            {
                ViewBag.Datas = Session["ModelCamera"];
                return PartialView("_ImageViewPartial");
            }
            else
            {
                return PartialView("_ImageViewPartial");
            }

        }


        [ValidateInput(false)]
        public ActionResult getEvent(string FROM_DATE, string TO_DATE, String VehicleSid )
        {
            LoadCombo();
            object datas;
            DataTable result = new DataTable();
            if (VehicleSid!=null)
            {
                result = BusinessLogic.Report.CameraReport_Sort(VehicleSid, FROM_DATE, TO_DATE);
            }
            List<ModelCamera> list = new List<ModelCamera>(result.Rows.Count);
            foreach(DataRow row in result.Rows)
            {
                list.Add(new ModelCamera(row));
            }

            datas = list;
            ViewBag.Datas = datas;
            Session["ModelCamera"] = list;
            return PartialView("_ImageViewPartial");
        }


	}
}