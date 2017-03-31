using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DenimSACCOS.Areas.Admin.Controllers
{
    public class EmailsController : Controller
    {
        // GET: Admin/Emails
        public ActionResult Index()
        {
            return View();
        }
        public void SendMail(DenimSACCOS.Areas.Admin.Models.Email _email)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("krennovatest@gmail.com");
                mail.To.Add(_email.To);
                mail.To.Add("krennovatest@gmail.com");
                mail.Subject = _email.Subject;
                mail.Body += _email.Body;
                mail.IsBodyHtml = true;
                try
                {
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("krennovatest@gmail.com", "test@123#");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
        public void SendMailtest()
        {
            if (ModelState.IsValid)
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("krennovatest@gmail.com");
                mail.To.Add("rozytwan@gmail.com");
                mail.To.Add("rozytwan@gmail.com");
                mail.Subject = "Password Recovery ";
                mail.Body += " <html>";
                mail.Body += "<body>";
                mail.Body += "<table>";
                mail.Body += "<tr>";
                mail.Body += "<td>User Name : </td><td> HAi </td>";
                mail.Body += "</tr>";

                mail.Body += "<tr>";

                mail.Body += "<td>Password : </td><td>aaaaaaaaaa</td>";
                mail.Body += "</tr>";
                mail.Body += "</table>";
                mail.Body += "</body>";
                mail.Body += "</html>";
                mail.IsBodyHtml = true;
                try
                {
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("krennovatest@gmail.com", "test@123#");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public ActionResult Inbox(DenimSACCOS.Areas.Admin.Models.Mail _objModelMail)
        {
            ViewBag.IsEmailSent = false;
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();

                mail.To.Add("krennovatest@gmail.com");
                mail.From = new MailAddress(_objModelMail.Email);

                mail.Subject = "Enquiry";
                mail.Body = "Hello <b>Admin</b>,<br/><br/>A new Mail has been Received on Oxygen Altitude Home.<br/><br/><b>" + mail.Subject + ".</b><br/><br/>" + "From:&nbsp;" + _objModelMail.Name + ".<br/>Email:&nbsp; " + _objModelMail.Email + ".<br/>Contact #:&nbsp; " + _objModelMail.Mobile + ".<br/><br/>" + _objModelMail.Body + "<br/><br/>Thanks.<br/>";

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("krennovatest@gmail.com", "test@123#");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ModelState.Clear();
                ViewBag.IsEmailSent = true;
                return View("../Home/Contact");

            }
            else
            {
                ViewBag.IsEmailSent = false;
                return View("../Home/Contact");
            }

        }
    }
}
