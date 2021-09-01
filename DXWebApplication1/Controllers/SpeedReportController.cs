using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DXWebApplication1.Models;
using System.Threading;
using DevExpress.Web.Mvc;



namespace DXWebApplication1.Controllers
{
	public class SpeedReportController : Controller
	{
		public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
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


		public ActionResult Grid()
		{
			if (Session["vwSpeedReport"] != null)
			{
				ViewBag.Datas = Session["vwSpeedReport"];
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
			try
			{
				LoadCombo();
				object datas;
				Dictionary<string, string> vehicles = new Dictionary<string, string>();
				DataTable result = new DataTable();
				DataTable results = new DataTable();
				if (VehicleSid != null)
				{
					result = BusinessLogic.Report.SpeedReport(VehicleSid, FROM_DATE, TO_DATE);
				}
				List<Models.SpeedReport> list = new List<Models.SpeedReport>(result.Rows.Count);
				for (int i = 0; i < result.Rows.Count; i++)
				{
					SpeedReport DataView = new SpeedReport();

					if (Convert.ToDouble(result.Rows[i]["WP_SPEED"]) > 20 && result.Rows[i]["POLYGON"] != "")
					{
						DataView.DESCRIPT = "Overspeed In Geofence";
						DataView.SPEEDLIMIT = 20;
					}
					else if (Convert.ToDouble(result.Rows[i]["WP_SPEED"]) > 60 && result.Rows[i]["POLYGON"] != "")
					{
						DataView.DESCRIPT = "Overspeed On Road";
						DataView.SPEEDLIMIT = 60;
					}
					else
					{
						DataView.DESCRIPT = " ";
					}
					if (result.Rows[i]["POLYGON"].ToString() != "")
					{
						DataView.SPEEDLIMIT = 20;
					}
					else if (result.Rows[i]["POLYGON"].ToString() == "") {
						DataView.SPEEDLIMIT = 60;
					}
					DataView.REG_NO = result.Rows[i]["REG_NO"].ToString();
					DataView.WP_TIME = Convert.ToDateTime(result.Rows[i]["WP_TIME"].ToString());
					DataView.WP_SPEED = Convert.ToDouble(result.Rows[i]["WP_SPEED"].ToString());
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
				Session["vwSpeedReport"] = list;
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