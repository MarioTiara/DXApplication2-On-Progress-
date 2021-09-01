using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
	public class VehicleController : Controller
	{
		public string ACCOUNT_SID;
		public ActionResult Index()
		{
			try
			{
				if (Session["ACCOUNT_SID"] == null)
				{
					HttpContext.Response.Redirect("~/Login");
				}
			  
				   return View();
			  
			}
			 catch (Exception e)
			 {

			 }
			 return null;
		}
		[ValidateInput(false)]
		
		public ActionResult getEvent(string CUSTOMER_SID, string PROJECT_SID)
		{

			if (Session["ACCOUNT_SID"] == null)
			{
				HttpContext.Response.Redirect("~/Login");
			}

			object data;
			CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
			PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();

			Dictionary<string, string> vehicles = new Dictionary<string, string>();
			DataTable result = new DataTable();
			DataTable results = new DataTable();
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
				result = BusinessLogic.Vehicle.VehicleByCustomerProjectSID(CUSTOMER_SID , PROJECT_SID);
			}
			List<Models.VehicleWithRole> list = new List<Models.VehicleWithRole>(result.Rows.Count);
			foreach (DataRow row in result.Rows)
			{
				list.Add(new Models.VehicleWithRole(row));
			}
			data = list;
			ViewBag.Data = data;
			return PartialView("_GridView1Partial", ViewBag.Data);

		}

		public ActionResult ExamplePartial()
		{
			if (DevExpressHelper.IsCallback)
				Thread.Sleep(500);
			return null;
		}


	
	}
}