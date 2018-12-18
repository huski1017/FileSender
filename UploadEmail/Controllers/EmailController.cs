using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using UploadEmail.Models;
using System.IO;

namespace UploadEmail.Controllers
{
    public class EmailController : Controller
    {
        private string _file_path;
        // GET: Email
        public ActionResult Email()
        {
            /**/

            Console.WriteLine("Message sent successfully !");

            return View();
        }

        [HttpPost]
        public ActionResult Create(EmailModel Email, HttpPostedFileBase File)
        {
            if (Email.To != null && Email.Subject != null && File.ContentLength > 0)
            {
                //string path = Path.Combine(Server.MapPath("~/Uploaded"), Path.GetFileName(File.FileName));
                //File.SaveAs(path);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("HubertTester1@gmail.com", "toto42toto42");

                MailMessage msg = new MailMessage();
                msg.To.Add(Email.To);
                if (Email.Cc != "" && Email.Cc != null)
                {
                    msg.To.Add(Email.Cc);
                }
                msg.From = new MailAddress("HubertTester1@gmail.com");
                msg.Subject = Email.Subject;
                msg.Body = Email.Body != null ? Email.Body : "No message specified by the author";
                string fileName = Path.GetFileName(File.FileName);
                msg.Attachments.Add(new Attachment(File.InputStream, fileName));
                client.Send(msg);
            }
            return View();
        }
    }
}