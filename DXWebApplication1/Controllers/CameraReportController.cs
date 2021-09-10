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
        private string _ImageDirCamp1 = "~/Content/ImgSouce_id(0)/";
        private string _ImageDirCamp2 = "~/Content/ImgSouce_id(1)/";

        DateTime LocalTime = DateTime.Now;

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

                //Clear Image in Content 
                ClearTempImg(_ImageDirCamp1);
                ClearTempImg(_ImageDirCamp2);

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

        //Clear Imgae Method
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

       
        //Event For Camera 1
        [ValidateInput(false)]
        public ActionResult getEventCamera1(string FROM_DATE, string TO_DATE, string VehicleSid)
        {
           
            string ImagePath;
            object datas;
            int countImage1 = 0;
            ClearTempImg(_ImageDirCamp1);
      
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

                ImagePath = _ImageDirCamp1 + Convert.ToString(countImage1) + ".jpg";
                myImage.Save(Server.MapPath(ImagePath));
                objcvm.imageUrlCamera1 = ImagePath;
                objcvm.CaptureTimeCamera1 = Data.CAPTURE_TIME;
                countImage1 += 1;

                ImageVMList.Add(objcvm);
            }

            datas = ImageVMList;
            ViewBag.Datas1 = datas;
            Session["ImageViewModelCam1"] = ImageVMList;
            return PartialView("_ImageViewPartial1");
        }
        //Calback Funtion Camera 1
        public ActionResult GridCamera1()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (Session["ImageViewModelCam1"] != null)
            {
                ViewBag.Datas = Session["ImageViewModelCam1"];
                return PartialView("_ImageViewPartial1");
            }
            else
            {
                return PartialView("_ImageViewPartial1");
            }

        }

        //Image Download for Camera 1
        public ActionResult DownloadCamera1()
        {
            string ZipName = LocalTime.ToString("dddd, dd MMMM yyyy") + "_ImagesDocCamera1.zip";
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
                return File(memoryStream.ToArray(), "application/zip", ZipName);
            }
        }
        //Event For Camera 2
        [ValidateInput(false)]
        public ActionResult getEventCamera2(string FROM_DATE, string TO_DATE, string VehicleSid)
        {
            //string FROM_DATE = "2021-09-02 00:00:00";
            //string TO_DATE = "2021-09-06 23:59:59";
            //string VehicleSid = "SIL00299";

            string ImagePath;
            object datas;
            int countImage2 = 0;
            ClearTempImg(_ImageDirCamp2);

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

                ImagePath = _ImageDirCamp2 + Convert.ToString(countImage2) + ".jpg";
                myImage.Save(Server.MapPath(ImagePath));

                objcvm.imageUrlCamera2 = ImagePath;
                objcvm.CaptureTimeCamera2 = Data.CAPTURE_TIME;
                ImageVMList.Add(objcvm);

                countImage2 += 1;
            }

            datas = ImageVMList;
            ViewBag.Datas2 = datas;
            Session["vwCameraReport2"] = ImageVMList;
            return PartialView("_ImageViewPartial2");
        }
        //Calback Funtion Camera 2
        public ActionResult GridCamera2()
        {
            if (Session["ACCOUNT_SID"] == null)
            {
                HttpContext.Response.Redirect("~/Login");
            }

            if (Session["ImageViewModelCam2"] != null)
            {
                ViewBag.Datas = Session["ImageViewModelCam2"];
                return PartialView("_ImageViewPartial2");
            }
            else
            {
                return PartialView("_ImageViewPartial2");
            }

        }
        //Image Download for Camera 1
        public ActionResult DownloadCamera2()
        {
            string ZipName = LocalTime.ToString("dddd, dd MMMM yyyy")+ "_ImagesDocCamera2.zip";
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
                return File(memoryStream.ToArray(), "application/zip", ZipName);
            }
        }
        
    }
}