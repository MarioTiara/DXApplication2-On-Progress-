using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace DXWebApplication1.Models
{
    public class FileInfo
    {
        public int FileId {get;set;}
        public string FileName{get;set;}
        public string FilePath{get;set;}
    } 

    public class FileDownloads1
    {  
        public List < FileInfo > GetFile() {  
            List < FileInfo > listFiles = new List < FileInfo > ();
            string fileSavePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/ImgSouce_id(0)");  
            DirectoryInfo dirInfo = new DirectoryInfo(fileSavePath);  
            int i = 0;  
            foreach(var item in dirInfo.GetFiles()) {  
                listFiles.Add(new FileInfo() {  
                    FileId = i + 1,  
                        FileName = item.Name,  
                        FilePath = dirInfo.FullName  +@"\" + item.Name });  
                i = i + 1;  
            }  
            return listFiles;  
        }  
    }

    public class FileDownloads2
    {
        public List<FileInfo> GetFile()
        {
            List<FileInfo> listFiles = new List<FileInfo>();
            string fileSavePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/ImgSouce_id(1)");
            DirectoryInfo dirInfo = new DirectoryInfo(fileSavePath);
            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                listFiles.Add(new FileInfo()
                {
                    FileId = i + 1,
                    FileName = item.Name,
                    FilePath = dirInfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }
            return listFiles;
        }
    }

}