using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenimSACCOS.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        // GET: Admin/Upload
        public ActionResult Index()
        {
            return View();
        }
  
 public ActionResult Upload(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Areas/Files/" + file.FileName);//file path
            file.SaveAs(path);//save file
            ViewBag.path = path;
            return View();
        }

        public ActionResult Uploads()
        {
            return View();
        }

        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Areas/Images/" + file.FileName);//file path
            file.SaveAs(path);//save file
            ViewBag.path = path;
            return View();
        }
        public ActionResult Uploadgal()
        {
            return View();
        }
        public ActionResult UploadGallary(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Areas/Gallary/" + file.FileName);//file path
            file.SaveAs(path);//save file
            ViewBag.path = path;
            return View();
        }



        //for Download of the files which is Uploaded above
        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Areas/Files/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }
        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/Files/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));

        }

        public ActionResult DownloadImage()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Areas/Images/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }
        public FileResult DownloadImg(string ImageName)
        {
            var FileVirtualPath = "~/Images/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));

        }

        public ActionResult DownloadGallary()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Areas/Gallary/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }
        public FileResult DownloadGal(string ImageName)
        {
            var FileVirtualPath = "~/Gallary/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));

        }

        public ActionResult Delete(string ImageName)
        {

            string fullPath = Request.MapPath("~/Areas/Files/" + ImageName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
              
            }
            return RedirectToAction("Downloads");
        }
        public ActionResult DeleteImg(string ImageName)
        {

            string fullPath = Request.MapPath("~/Areas/Images/" + ImageName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);

            }
            return RedirectToAction("DownloadImage");
        }
        public ActionResult DeleteGal(string ImageName)
        {

            string fullPath = Request.MapPath("~/Areas/Gallary/" + ImageName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);

            }
            return RedirectToAction("DownloadGallary");
        }
    }
}
