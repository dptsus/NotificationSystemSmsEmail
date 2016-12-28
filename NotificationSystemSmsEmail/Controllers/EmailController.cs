using System;
using System.Web.Mvc;
using NotificationSystemSmsEmail.Models;
using System.Threading.Tasks;

namespace NotificationSystemSmsEmail.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email/SendEmail
        public ActionResult SendEmail()
        {
            return View();
        }

        // POST: Email/SendEmail
        [HttpPost]
        public async Task<ActionResult> SendEmail(EmailViewModel email, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmailService _emailService = new EmailService();
                    
                    await _emailService.SendEmail(email); //Send sms
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(email);
        }

    }
}
