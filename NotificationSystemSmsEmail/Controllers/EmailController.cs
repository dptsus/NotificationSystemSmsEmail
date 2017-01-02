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
                    EmailService emailService = new EmailService();
                    
                    await emailService.SendEmail(email); //Send sms

                    TempData["SuccessMsg"] = "Email sent Successfully.";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    TempData["SuccessMsg"] = ex.Message;
                }
            }
            return RedirectToAction("Success");
            //return View(email);
        }

        [HttpGet]
        public ActionResult Success()
        {
            ViewBag.Result = TempData["SuccessMsg"].ToString();
            return View();
        }

    }
}
