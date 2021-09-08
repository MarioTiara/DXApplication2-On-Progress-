using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Drawing;
using System.IO;
using DXWebApplication1.Models;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;

namespace DXWebApplication1.Controllers
{
    public class FolderBindingController : Controller
    {

        public string CUSTOMER_SID, PROJECT_SID, ACCOUNT_SID;
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
        //Converter Base64 to Image
        public Image Base64ToImage(string base64String)   
        {  
            byte[] imageBytes = Convert.FromBase64String(base64String);  
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);  
            ms.Write(imageBytes, 0, imageBytes.Length);  
            Image image = System.Drawing.Image.FromStream(ms, true);  
            return image;  
        }

        public void ClearTempImg(string Serverdirectory)
        {
            string path = Server.MapPath(Serverdirectory);

            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        //Calback Funtion
        public ActionResult Grid()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (Session["vwCameraReport"] != null)
            {
                ViewBag.Datas = Session["vwCameraReport"];
                return PartialView("_ImageViewPartial");
            }
            else
            {
                return PartialView("_ImageViewPartial");
            }

        }

        [ValidateInput(false)]
        public ActionResult getEvent(string FROM_DATE, string TO_DATE, string VehicleSid)
        {
            //string FROM_DATE = "2021-08-04 00:00:00";
            //string TO_DATE = "2021-09-06 23:59:59";
            //string VehicleSid = "SIL02994";


            object datas;
            int countImage1 = 0;
            int countImage2 = 0;

            string ImageDirCamp1 = "~/Content/ImgSouce_id(0)/";
            string ImageDirCamp2 = "~/Content/ImgSouce_id(1)/";
            ClearTempImg(ImageDirCamp1);
            ClearTempImg(ImageDirCamp2);


            DataTable result = new DataTable();

            if (VehicleSid != null)
            {
                result = BusinessLogic.Report.CameraReport(VehicleSid, FROM_DATE, TO_DATE);
            }

            List<vwCameraReport> list = new List<vwCameraReport>(result.Rows.Count);
            foreach (DataRow row in result.Rows)
            {
                list.Add(new vwCameraReport(row));
            }


            foreach (var Data in list)
            {
                string ImagePath;
                if (Data.SOURCE_ID==0)
                {
                    Image myImage = Base64ToImage(Data.IMAGE_DATA);
                    ImagePath = "~/Content/ImgSouce_id(0)/ImageFromCamp1_" + Convert.ToString(countImage1) + ".jpg";
                    myImage.Save(Server.MapPath(ImagePath));

                   
                    countImage1 += 1;
                }
                else if (Data.SOURCE_ID==1)
                {
                    Image myImage = Base64ToImage(Data.IMAGE_DATA);
                    ImagePath = "~/Content/ImgSouce_id(1)/ImageFromCamp2_" + Convert.ToString(countImage2) + ".jpg";
                    myImage.Save(Server.MapPath(ImagePath));
                    var ImageDatas = new List<vwImageModel>
                    {
                        new vwImageModel{CaptureTime=Data.CAPTURE_TIME, imageUrl=ImagePath}
                    };
                    countImage1 += 1;
                }
            }


            datas = list;
            ViewBag.Datas = datas;
            Session["vwCameraReport"] = list;
            return PartialView("_ImageViewPartial");


        }
     
	}





}