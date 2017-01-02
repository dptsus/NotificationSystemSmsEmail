using NotificationSystemSmsEmail.Models;
using System;
using System.Web.Mvc;

namespace NotificationSystemSmsEmail.Controllers
{
    public class SmsController : Controller
    {
        [HttpGet]
        public ActionResult SendTransactionalSMS()
        {
            SMS model = new SMS();
            model.SenderId = "DOCTOR";
            return View(model);
        }

        [HttpPost]
        public ActionResult SendTransactionalSMS(SMS sms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmsService _smsService = new SmsService();
                    sms.Route = 4;
                    string response = _smsService.Send(sms); //Send sms
                    TempData["SuccessMsg"] = response;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return RedirectToAction("Success");
            //return View(sms);
        }

        [HttpGet]
        public ActionResult SendPromotionalSMS()
        {
            SMS model = new SMS();
            model.SenderId = "777777";
            return View(model);
        }

        [HttpPost]
        public ActionResult SendPromotionalSMS(SMS sms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmsService _smsService = new SmsService();
                    sms.Route = 1;
                    string response = _smsService.Send(sms); //Send sms
                    TempData["SuccessMsg"] = response;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return RedirectToAction("Success");
            //return View(sms);
        }

        [HttpGet]
        public ActionResult Success()
        {
            ViewBag.Result = TempData["SuccessMsg"].ToString();
            return View();
        }

    }
}