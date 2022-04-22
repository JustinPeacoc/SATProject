using System.Web.Mvc;
using System;
using System.Data.Entity;
using System.Net.Mail;
using SATProject.MVC.Models;
using System.Net;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You have received an email from {cvm.Name}.<br />" +
                $"Subject: {cvm.Subject}<br />" +
                $"Message: {cvm.Message}<br />" +
                $"Please reply to {cvm.Email} with your response at your earliest convenience.";

            //MailMessage - What sends the email
            //Overload for MailMessage - FROM, TO, SUBJECT, BODY
            MailMessage mm = new MailMessage("admin@ot.com", "admin@yahoo.com", cvm.Subject, message);

            //MailMessage Properties
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            //Reply to the sender, and not our website/webmail
            mm.ReplyToList.Add(cvm.Email);

            //SmtpClient - Info from the host that allows emails to be sent
            SmtpClient client = new SmtpClient("mail.orangetraining.com");

            //Client Credentials
            client.Credentials = new NetworkCredential("administrator@orangetraining.com", "trashman");

            //Port options -- SMTP uses two ports 25 and 8889. Test with both to determine
            //if your internet provider blocks/does not use one of these.
            //client.Port = 25;
            //client.Port = 8889;

            //Try to send the email
            try
            {
                //Attempt to send the email
                client.Send(mm);
            }
            catch (System.Exception ex)
            {

                ViewBag.CustomerMessage = $"We're sorry, but your request could not be completed at this time. " +
                    $"Please try again later. If the issue persists, please contact your site administrator and provide " +
                    $"the following info:<br />{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);

        }
    }
}
