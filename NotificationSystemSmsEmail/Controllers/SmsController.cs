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
                    //bool isSuccess = false;
                    //string errMsg = null;
                    string response = _smsService.Send(sms); //Send sms
                    ViewData["SuccessMsg"] = response;
                    //if (!isSuccess)
                    //{
                    //    ModelState.AddModelError("", errMsg);
                    //}
                    //else
                    //{
                        
                    //}
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