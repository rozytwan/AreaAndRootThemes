using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using DenimSACCOS.Areas.Admin.Models;
using Microsoft.AspNet.Identity;

namespace DenimSACCOS.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {          

            if(User.Identity.IsAuthenticated)
            {
                ViewBag.AdminEmail = User.Identity.Name;
                //ViewBag.IsLoggedIn = User.Identity.IsAuthenticated;
                return View();
            }

            return RedirectToAction("Index", "../Home");
        }

        public ActionResult Mail()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }
        public ActionResult Calculator()
        {
            return View();
        }
        static string tablehtml = "";

        [WebMethod]
        public string SendAmmortization(string table)
        {
            ViewBag.AmmorTable = table;
            tablehtml = table;
            return table;
        }

        [WebMethod]
        public ActionResult viewTable()
        {
            ViewBag.AmmorTable = tablehtml;
            return View();
        }


public ActionResult ContactUs(Email objModelMail, HttpPostedFileBase fileUploader)
    {
        if (ModelState.IsValid)
        {
            string from = "Email"; //example:- sourabh9303@gmail.com
            using (MailMessage mail = new MailMessage(from, objModelMail.To))
            {
                mail.Subject = objModelMail.Subject;
                mail.Body = objModelMail.Body;
                if (fileUploader != null)
                {
                    string fileName = Path.GetFileName(fileUploader.FileName);
                    mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                }
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "password");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
                ViewBag.Message = "Sent";
                return View("ContactUs", objModelMail);
            }
        }
        else
        {
            return View();
        }
    }
        List<DenimSACCOS.Models.Gallery> files;
        public ActionResult Gallery()
        {
            files = GalleyList();
            //objHomeGallery.ImageList = files;
            //objHomeGallery = files;
            return View("Gallery", files);
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
                    ImagePath = "~/Areas/Gallary/" + fileName
                });
            }
            List<DenimSACCOS.Models.Gallery> objimg = files.ToList();
            return objimg;
        }

    }

}


