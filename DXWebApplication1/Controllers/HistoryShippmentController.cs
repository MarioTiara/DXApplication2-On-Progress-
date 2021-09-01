using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using DXWebApplication1.Models;
using DevExpress.XtraPrinting;
using System.Web.UI.WebControls;
using System.Reflection;
using DevExpress.Web.Mvc;
using DevExpress.Web.Demos;
using System.Threading;


namespace DXWebApplication1.Controllers
{
    public class HistoryShippmentController : Controller
    {
        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
        //
        // GET: /HistoryShippment/
        public ActionResult Index()
        {
            try
            {
                if (Session["ACCOUNT_SID"] == null)
                {
                    HttpContext.Response.Redirect("~/Login");
                }
                    LoadComboCustomerProject();
                    return View();
               

            }
            catch (Exception e)
            {

            }
            return null;
        }

        [ValidateInput(false)]
        public void LoadComboCustomerProject()
        {
            CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
            PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();
            object data;
          

            DataTable result = new DataTable();

            if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Customer.GetCustomerProjectAll();
            }
            else if (string.IsNullOrEmpty(PROJECT_SID))
            {
                result = BusinessLogic.Customer.GetCustomerProject(CUSTOMER_SID);
            }
            List<Models.GetCustomerProject> list = new List<Models.GetCustomerProject>();
            list.Add(new Models.GetCustomerProject { PROJECT_NAME = "SELECT", PROJECT_NO = "" });
            for (int i = 0; i < result.Rows.Count; i++)
            {
                GetCustomerProject DataView = new GetCustomerProject();
                DataView.PROJECT_NAME = result.Rows[i]["PROJECT_NAME"].ToString();
                DataView.PROJECT_NO = result.Rows[i]["PROJECT_NO"].ToString();

                list.Add(DataView);
            }
            data = list;

            ViewBag.DataCustomerProject = data;

        }

        public ActionResult Grid()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }
            if (Session["vwHistoryShippment"] != null)
            {
                ViewBag.Datas = Session["vwHistoryShippment"];
                return PartialView("_GridView1Partial");
            }
            else
            {
                return PartialView("_GridView1Partial");
            }

        }


        [ValidateInput(false)]
        public ActionResult getData(string PROJECT_NO, string FROM_DATE, string TO_DATE)
        {
            try
            {

                CUSTOMER_SID = System.Web.HttpContext.Current.Session["CUSTOMER_SID"].ToString();
                PROJECT_SID = System.Web.HttpContext.Current.Session["PROJECT_SID"].ToString();

                if (string.IsNullOrEmpty(PROJECT_NO) && string.IsNullOrEmpty(FROM_DATE) && string.IsNullOrEmpty(TO_DATE))
                {
                    FROM_DATE = DateTime.Now.ToString("yyyyMMdd");
                    TO_DATE = DateTime.Now.ToString("yyyyMMdd");
                
                }
             
                Session["CUSTOMER_SID"] = CUSTOMER_SID;
                Session["PROJECT_SID"] = PROJECT_SID;
                Session["FROM_DATE"] = FROM_DATE;
                Session["TO_DATE"] = TO_DATE;
                Session["PROJECT_NO"] = PROJECT_NO;
              

                object datas;
                DataTable result = new DataTable();

                if (string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_NO))
                {
                 
                    result = BusinessLogic.Order.GetHistoryShippmentAll(FROM_DATE, TO_DATE);
                }
                else if (!string.IsNullOrEmpty(CUSTOMER_SID) && string.IsNullOrEmpty(PROJECT_NO))
                {
                    result = BusinessLogic.Order.GetHistoryShippmentCustomerSid(CUSTOMER_SID, FROM_DATE, TO_DATE);
                }
                else if (!string.IsNullOrEmpty(PROJECT_NO))
                {
                    result = BusinessLogic.Order.GetHistoryShippmentProjectNo(PROJECT_NO, FROM_DATE, TO_DATE);

                }
                List<Models.vwModelHistoryShippment> list = new List<Models.vwModelHistoryShippment>();
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    vwModelHistoryShippment DataView = new vwModelHistoryShippment();
                    DataView.RECORD_ID = result.Rows[i]["RECORD_ID"].ToString();
                    DataView.ORDER_NUMBER = result.Rows[i]["ORDER_NUMBER"].ToString();
                    DataView.CUSTOMER_SID = result.Rows[i]["CUSTOMER_SID"].ToString();
                    DataView.REG_NO = result.Rows[i]["REG_NO"].ToString();
                    DataView.DESCRIPTION = result.Rows[i]["OrderGPNo1"].ToString() + result.Rows[i]["OrderGPNo2"].ToString() + result.Rows[i]["AllocOrderWaybillNo"].ToString();
                    DataView.ORIGIN_CODE = result.Rows[i]["ORIGIN_CODE"].ToString();
                    DataView.ORIGIN_NAME = result.Rows[i]["ORIGIN_NAME"].ToString();
                    DataView.DESTINATION_CODE = result.Rows[i]["DESTINATION_CODE"].ToString();
                    DataView.DESTINATION_NAME = result.Rows[i]["DESTINATION_NAME"].ToString();
                    // DataView.PROJECT_SID = result.Rows[i]["PROJECT_SID"].ToString();
                    DataView.PICKUP_DATE = Convert.ToDateTime(result.Rows[i]["PICKUP_DATE"].ToString());
                    DataView.DUE_DATE = Convert.ToDateTime(result.Rows[i]["DUE_DATE"].ToString());
                    DataView.DRIVER_SID = result.Rows[i]["DRIVER_SID"].ToString();
                    DataView.DRIVER_PHONE = result.Rows[i]["DRIVER_PHONE"].ToString();
                    list.Add(DataView);
                }

                LoadComboCustomerProject();
                datas = list;
                ViewBag.Datas = datas;
                Session["vwHistoryShippment"] = list;
                return PartialView("_GridView1Partial");
            }
            catch (Exception e)
            {

            }
            return null;

        }

  
        public ActionResult MasterDetailDetailPartial(string ORDER_NUMBER)
        {
            object dataDetail;
            DataTable resultDetail = new DataTable();
            resultDetail = BusinessLogic.Order.GetHistoryShippmentDetail(ORDER_NUMBER);
            List<Models.vwvwModelHistoryShippmentDetail> listDetail = new List<Models.vwvwModelHistoryShippmentDetail>();
            ViewData["ORDER_NUMBER"] = ORDER_NUMBER;
            for (int i = 0; i < resultDetail.Rows.Count; i++)
            {
                vwvwModelHistoryShippmentDetail DataView = new vwvwModelHistoryShippmentDetail();
                DataView.ORDER_NUMBER = resultDetail.Rows[i]["ORDER_NUMBER"].ToString();
                DataView.HISTORY_DATE =  Convert.ToDateTime(resultDetail.Rows[i]["HISTORY_DATE"].ToString());
                DataView.HISTORY_LOCATION = resultDetail.Rows[i]["HISTORY_LOCATION"].ToString();
                DataView.STATUS = resultDetail.Rows[i]["STATUS"].ToString();

                listDetail.Add(DataView);
            
            }

            dataDetail = listDetail;
            ViewBag.DataDetail = dataDetail;
            Session["DataDetail"] = dataDetail;
            return PartialView("MasterDetailMasterPartial");
        }



        public class ListtoDataTable
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
        }


	}


}