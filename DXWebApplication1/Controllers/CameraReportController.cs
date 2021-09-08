using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using DXWebApplication1.Models;
using DXWebApplication1.ViewModels;
using System.Drawing;


namespace DXWebApplication1.Controllers
{
    public class CameraReportController : Controller
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

            foreach (System.IO.FileInfo file in di.GetFiles())
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

            if (Session["ImageViewModel"] != null)
            {
                ViewBag.Datas = Session["ImageViewModel"];
                return PartialView("_ImageViewPartial");
            }
            else
            {
                return PartialView("_ImageViewPartial");
            }

        }

        [ValidateInput(false)]
        public ActionResult getEventCamera1(string FROM_DATE, string TO_DATE, string VehicleSid)
        {
            //string FROM_DATE = "2021-09-02 00:00:00";
            //string TO_DATE = "2021-09-06 23:59:59";
            //string VehicleSid = "SIL00299";

            string ImagePath;
            object datas;
            int countImage1 = 0;
            

            string ImageDirCamp1 = "~/Content/ImgSouce_id(0)/";
           
            ClearTempImg(ImageDirCamp1);
      
            DataTable result = new DataTable();

            if (VehicleSid != null)
            {
                result = BusinessLogic.Report.CameraReport1(VehicleSid, FROM_DATE, TO_DATE);
            }

            List<vwCameraReport1> list = new List<vwCameraReport1>(result.Rows.Count);
            foreach (DataRow row in result.Rows)
            {
                list.Add(new vwCameraReport1(row));
            }

            List<ImageViewModelCam1> ImageVMList = new List<ImageViewModelCam1>();

            foreach (var Data in list)
            {
                Image myImage = Base64ToImage(Data.IMAGE_DATA);
                ImageViewModelCam1 objcvm = new ImageViewModelCam1();

                ImagePath = "~/Content/ImgSouce_id(0)/ImageFromCamp1_" + Convert.ToString(countImage1) + ".jpg";
                myImage.Save(Server.MapPath(ImagePath));
                objcvm.imageUrlCamera1 = ImagePath;
                objcvm.CaptureTimeCamera1 = Data.CAPTURE_TIME;
                countImage1 += 1;

                ImageVMList.Add(objcvm);
            }

            datas = ImageVMList;
            ViewBag.Datas1 = datas;
            Session["vwCameraReport1"] = ImageVMList;
            return PartialView("_ImageViewPartial1");
        }

        [ValidateInput(false)]
        public ActionResult getEventCamera2(string FROM_DATE, string TO_DATE, string VehicleSid)
        {
            //string FROM_DATE = "2021-09-02 00:00:00";
            //string TO_DATE = "2021-09-06 23:59:59";
            //string VehicleSid = "SIL00299";

            string ImagePath;
            object datas;
            int countImage2 = 0;


            string ImageDirCamp1 = "~/Content/ImgSouce_id(1)/";

            ClearTempImg(ImageDirCamp1);

            DataTable result = new DataTable();

            if (VehicleSid != null)
            {
                result = BusinessLogic.Report.CameraReport2(VehicleSid, FROM_DATE, TO_DATE);
            }

            List<vwCameraReport2> list = new List<vwCameraReport2>(result.Rows.Count);
            foreach (DataRow row in result.Rows)
            {
                list.Add(new vwCameraReport2(row));
            }

            List<ImageViewModelCam2> ImageVMList = new List<ImageViewModelCam2>();

            foreach (var Data in list)
            {
                Image myImage = Base64ToImage(Data.IMAGE_DATA);
                ImageViewModelCam2 objcvm = new ImageViewModelCam2();

                ImagePath = "~/Content/ImgSouce_id(1)/ImageFromCamp2_" + Convert.ToString(countImage2) + ".jpg";
                myImage.Save(Server.MapPath(ImagePath));
                objcvm.imageUrlCamera2 = ImagePath;
                objcvm.CaptureTimeCamera2 = Data.CAPTURE_TIME;
                countImage2 += 1;

                ImageVMList.Add(objcvm);
            }

            datas = ImageVMList;
            ViewBag.Datas2 = datas;
            Session["vwCameraReport2"] = ImageVMList;
            return PartialView("_ImageViewPartial2");
        }

        public ActionResult DownloadCamera1()
        {
            FileDownloads1 obj = new FileDownloads1(); 
            var filesCol = obj.GetFile().ToList();
            using (var memoryStream = new MemoryStream())
            {
                using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < filesCol.Count; i++)
                    {
                        ziparchive.CreateEntryFromFile(filesCol[i].FilePath, filesCol[i].FileName);
                    }
                }
                return File(memoryStream.ToArray(), "application/zip", "ImagesDocoumentationCamera1.zip");
            }
        }

        public ActionResult DownloadCamera2()
        {
            FileDownloads2 obj = new FileDownloads2();
            var filesCol = obj.GetFile().ToList();
            using (var memoryStream = new MemoryStream())
            {
                using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < filesCol.Count; i++)
                    {
                        ziparchive.CreateEntryFromFile(filesCol[i].FilePath, filesCol[i].FileName);
                    }
                }
                return File(memoryStream.ToArray(), "application/zip", "ImagesDocoumentationCamera2.zip");
            }
        }
        
    }
}