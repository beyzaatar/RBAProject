using Microsoft.AspNetCore.Mvc;
using RBAProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RBAProject.Controllers
{
    public class ContactpageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email model)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("beyzaatar50@gmail.com");
            mailMessage.From = new MailAddress("beyzaatar50@gmail.com");
            mailMessage.Subject = "Rant A Car" + model.Subject;
            mailMessage.Body = "Sayın " + model.Name + " kişisinden gelen mesaj aşağıdaki gibidir: <br>" + model.Message;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("beyzaatar50@gmail.com", "Ronalinci*4755");
            smtpClient.Port = 465;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                TempData["Message"] = "Mesajınız iletilmiştir. en kısa zamanda dönüş sağlanacaktır.";

            }
            catch (Exception ex)
            {

                TempData["Message"]="Mesaj gönderilemedi!"+ex.Message;
            }


            return View();
        }
    }
}