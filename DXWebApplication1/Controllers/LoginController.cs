using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace DXWebApplication1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(string ACCOUNT_SID, string PASSWORDZ)
        {
            //if (Session["ACCOUNT_SID"] == null)
            //{
            //    HttpContext.Response.Redirect("~/Login");
            //}
            if (ModelState.IsValid)
            {
                DataTable result = new DataTable();
              

                result = BusinessLogic.Accounts.AccountzLogin(ACCOUNT_SID, PASSWORDZ);
                List<Models.ModelAccounts> LastUpdate = new List<Models.ModelAccounts>(result.Rows.Count);

                if (result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {

                       Session["ACCOUNT_SID"] = row[0];
                       Session["PASSWORDZ"] = row[1];
                       Session["FULL_NAME"] = row[2];
                       Session["CUSTOMER_SID"] = row[3];
                       Session["PROJECT_SID"] = row[4];
                       Session["ROLE"] = row[5];
                       Session["COMPANY_SID"] = row[6];
                       Session["DIVISION_SID"] = row[7];
                       Session["SUBDIVISION_SID"] = row[8];
                       ViewBag.Name = row[2];
                       LastUpdate.Add(new Models.ModelAccounts());
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                return RedirectToAction("Index", "Maps");
                // }

            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOut()
        {
            BusinessLogic.Accounts.LastLogin(Session["ACCOUNT_SID"].ToString());
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Login");
        }
        

	}

}