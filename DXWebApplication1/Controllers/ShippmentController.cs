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
    public class ShippmentController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
       
        //
        // GET: /Shippment/
        public ActionResult Index()
        {

             try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                    LoadComboCustomer();
                    return View();
               

            }
             catch (Exception e)
             {

             }
             return null;
        }

        [ValidateInput(false)]
        public void LoadComboCustomer()
        {
            object data;
            CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
            PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();
            DataTable result = new DataTable();
            if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Customer.GetCustomer();
            }
            else if (string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Customer.GetCustomerProject(CUSTOMER_SID);
            }
            List<Models.GetCustomer> list = new List<Models.GetCustomer>();
            list.Add(new Models.GetCustomer { PROJECT_NAME = "SELECT ALL", PROJECT_NO = "" });
            for (int i = 0; i < result.Rows.Count; i++)
            {
                GetCustomer DataView = new GetCustomer();
                DataView.PROJECT_NAME = result.Rows[i]["PROJECT_NAME"].ToString();
                DataView.PROJECT_NO = result.Rows[i]["PROJECT_NO"].ToString();

                list.Add(DataView);
            }
            data = list;

            ViewBag.DataCustomer = data;

        }


        public ActionResult Grid()
        {
            if (Session["vwShippment"] != null)
            {
                ViewBag.Datas = Session["vwShippment"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }

        }


        [ValidateInput(false)]
        public ActionResult getData(string PROJECT_NO)
        {
            try
            {
                CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
                PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();

                LoadComboCustomer();
                object datas;
                Dictionary<string, string> vehicles = new Dictionary<string, string>();
                DataTable result = new DataTable();

                if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_NO))
                {
                    result = BusinessLogic.Order.GetShippmentAll();
                }
                else if (!string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_NO))
                {
                    result = BusinessLogic.Order.GetShippmentCustomerSid(CUSTOMER_SID);
                }
                else if (!string.IsNullOrEmpty(PROJECT_NO))
                {
                    result = BusinessLogic.Order.GetShippmentProjectNo(PROJECT_NO);
                }
                List<Models.vwShippment> list = new List<Models.vwShippment>(result.Rows.Count);
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    vwShippment DataView = new vwShippment();
                    DataView.RECORD_ID = result.Rows[i]["RECORD_ID"].ToString();
                    DataView.ORDER_NUMBER = result.Rows[i]["ORDER_NUMBER"].ToString();
                    DataView.CUSTOMER_SID = result.Rows[i]["CUSTOMER_SID"].ToString();
                    DataView.REG_NO = result.Rows[i]["REG_NO"].ToString();
                    DataView.DESCRIPTION = result.Rows[i]["DESCRIPTION"].ToString();
                    DataView.ORIGIN_CODE = result.Rows[i]["ORIGIN_CODE"].ToString();
                    DataView.ORIGIN_NAME = result.Rows[i]["ORIGIN_NAME"].ToString();
                    DataView.DESTINATION_CODE = result.Rows[i]["DESTINATION_CODE"].ToString();
                    DataView.DESTINATION_NAME = result.Rows[i]["DESTINATION_NAME"].ToString();
                   // DataView.PROJECT_SID = result.Rows[i]["PROJECT_SID"].ToString();
                    DataView.PICKUP_DATE = Convert.ToDateTime(result.Rows[i]["PICKUP_DATE"].ToString());
                    DataView.PROGRESS_DATE = Convert.ToDateTime(result.Rows[i]["PROGRESS_DATE"].ToString());
                    DataView.DELIVERY_DATE = Convert.ToDateTime(result.Rows[i]["DELIVERY_DATE"].ToString());
                    DataView.ARRIVAL_DATE = Convert.ToDateTime(result.Rows[i]["ARRIVAL_DATE"].ToString());
                    DataView.COMPLETE_DATE = Convert.ToDateTime(result.Rows[i]["COMPLETE_DATE"].ToString());
                    DataView.DUE_DATE = Convert.ToDateTime(result.Rows[i]["DUE_DATE"].ToString());
                    DataView.EXPIRED_DATE = Convert.ToDateTime(result.Rows[i]["EXPIRED_DATE"].ToString());
                    DataView.DRIVER_SID = result.Rows[i]["DRIVER_SID"].ToString();
                    DataView.DRIVER_PHONE = result.Rows[i]["DRIVER_PHONE"].ToString();
                    DataView.ROUTE_UID = result.Rows[i]["ROUTE_UID"].ToString();
                    DataView.STATUS = result.Rows[i]["STATUS"].ToString();
                    DataView.SWITCH_FROM = result.Rows[i]["SWITCH_FROM"].ToString();

                    list.Add(DataView);
                }

                datas = list;
                ViewBag.Datas = datas;
                Session["vwShippment"] = list;
                return PartialView("_GridView1Partial", ViewBag.Datas);
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