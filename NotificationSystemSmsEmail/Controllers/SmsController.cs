using NotificationSystemSmsEmail.Models;
using System;
using System.Web.Mvc;

namespace NotificationSystemSmsEmail.Controllers
{
    public class SmsController : Controller
    {
        [HttpGet]
        public ActionResult SendSMS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(SMS sms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmsService _smsService = new SmsService();
                    string response = _smsService.Send(sms); //Send sms
                    ViewData["SuccessMsg"] = response;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(sms);
        }
    }
}