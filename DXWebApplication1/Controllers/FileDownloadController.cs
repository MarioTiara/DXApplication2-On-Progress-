using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.Compression;
using System.IO;
using DXWebApplication1.Models;

namespace DXWebApplication1.Controllers
{
    public class FileDownloadController : Controller
    {
        //
        // GET: /FileDownload/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download()
        {
            FileDownloads obj = new FileDownloads();
            //////int CurrentFileID = Convert.ToInt32(FileID);  
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
                return File(memoryStream.ToArray(), "application/zip", "Attachments.zip");
            }
        }
	}
}