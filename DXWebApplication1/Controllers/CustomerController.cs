using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using DXWebApplication1.Models;

namespace DXWebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            try
            {
                this.ACCOUNT_SID = Session["ACCOUNT_SID"].ToString();
                if (!string.IsNullOrEmpty(ACCOUNT_SID))
                {
                    return View();
                }
                else if (string.IsNullOrEmpty(ACCOUNT_SID))
                {
                    HttpContext.Response.Redirect("~/Login");
                }

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
            list.Add(new Models.GetCustomer{ PROJECT_NAME = "SELECT", PROJECT_NO = "" });
            for (int i = 0; i < result.Rows.Count; i++)
            {
                GetCustomer DataView = new GetCustomer();
                DataView.PROJECT_NAME = result.Rows[i]["PROJECT_NAME"].ToString();
                DataView.PROJECT_NO = result.Rows[i]["PROJECT_NO"].ToString();

                list.Add(DataView);
            }
            data = list;

            ViewBag.DataCustomert = data;

        }

        [ValidateInput(false)]
        public void LoadComboCustomerProject()
        {
            object data;
            CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
            PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();
            DataTable result = new DataTable();
            if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Customer.GetCustomerProjectAll();
            }
            else if (string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Customer.GetCustomerProject(CUSTOMER_SID);
            }
            List<Models.GetCustomer> list = new List<Models.GetCustomer>();
            list.Add(new Models.GetCustomer { PROJECT_NAME = "SELECT", PROJECT_NO = "" });
            for (int i = 0; i < result.Rows.Count; i++)
            {
                GetCustomer DataView = new GetCustomer();
                DataView.PROJECT_NAME = result.Rows[i]["PROJECT_NAME"].ToString();
                DataView.PROJECT_NO = result.Rows[i]["PROJECT_NO"].ToString();

                list.Add(DataView);
            }
            data = list;

            ViewBag.DataCustomerProject = data;

        }
	}
}