using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using DenimSACCOS.Models;
    
    
    namespace DenimSACCOS.Controllers
{
    public class HomeController : Controller
    {
      
         
       // HomeGallery objHomeGallery = null;
        public ActionResult Index()
        {
          files = imageslist();
           
            return View("Index",files);


        }
        List<DenimSACCOS.Models.Gallery> files;
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Notice()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Saving()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Loan()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Remittance()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            files = GalleyList();
            //objHomeGallery.ImageList = files;
            //objHomeGallery = files;
            return View("Gallery", files);
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


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
            var FileVirtualPath = "~/Areas/Files/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }



        static string tablehtml = "";
  [WebMethod]
        public string SendAmmortization(string table)
        {
            ViewBag.AmmorTable = table;
            tablehtml = table;
            return table;
        }

        public ActionResult viewTable()
        {
            ViewBag.AmmorTable = tablehtml;
            return View();
        }

        [WebMethod]
        public ActionResult RedirectToTable()
        {
            ViewBag.AmmorTable = tablehtml;
           return redirectToView();
        }

        public ActionResult redirectToView()
        {
            return Redirect(Url.Action("viewTable", "Home"));
        }

        public List<DenimSACCOS.Models.Gallery> imageslist()
        {
            string folderPath = Server.MapPath("~/Areas/Images/");
            string[] filePaths = Directory.GetFiles(folderPath);
            files = new List<DenimSACCOS.Models.Gallery>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new DenimSACCOS.Models.Gallery
                {
                    ImageName = fileName.Split('.')[0].ToString(),
                    ImagePath = "../Areas/Images/" + fileName
                });
            }
            List<DenimSACCOS.Models.Gallery> objimg = files.ToList();
            return objimg;
        }
        public List<DenimSACCOS.Models.Gallery> GalleyList()
        {
            string folderPath = Server.MapPath("~/Areas/Gallary/");
            string[] filePaths = Directory.GetFiles(folderPath);
            files = new List<DenimSACCOS.Models.Gallery>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new DenimSACCOS.Models.Gallery
                {
                    ImageName = fileName.Split('.')[0].ToString(),
                    ImagePath = "../Areas/Gallary/" + fileName
                });
            }
            List<DenimSACCOS.Models.Gallery> objimg = files.ToList();
            return objimg;
        }

    }
}