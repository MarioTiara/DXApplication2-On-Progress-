using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DXWebApplication1.Models;

namespace DXWebApplication1.Controllers
{
	public class CamReportController : Controller
	{
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
	
		public ActionResult Index()
		{
			if (Session["ACCOUNT_SID"] == null)
			{
				HttpContext.Response.Redirect("~/Login");
			}

			object data;
			Dictionary<string, string> vehicles = new Dictionary<string, string>();
			DataTable result = new DataTable();
			DataTable results = new DataTable();
			result = BusinessLogic.Report.CameraReport();

			List<ModelCamera> list = new List<ModelCamera>(result.Rows.Count);
			foreach (DataRow row in result.Rows)
			{
				list.Add(new ModelCamera(row));
			}
			data = list;
			ViewBag.Data = data;
			return PartialView(data);
		}

      
	}
}