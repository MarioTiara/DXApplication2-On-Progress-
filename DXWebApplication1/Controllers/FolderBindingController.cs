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

namespace DXWebApplication1.Controllers
{
    public class FolderBindingController : Controller
    {
        //
        // GET: /FolderBinding/
        public ActionResult Index()
        {
            // Get image path  
            string imgPath = Server.MapPath("~/Content/Images/img/img2.png");

            // Convert image to byte array  
            byte[] byteData = System.IO.File.ReadAllBytes(imgPath);

            //Convert byte arry to base64string   
            string imreBase64Data = Convert.ToBase64String(byteData);

            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);

            byte[] bytes = Convert.FromBase64String(imreBase64Data);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                image.Save("C:\\test.jpg");
                
            }

            //Passing image data in viewbag to view  
            ViewBag.ImageData = image;

            return View(); 
        }

     
	}





}