using NotificationSystemSmsEmail;
using NotificationSystemSmsEmail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NotificationSystemSmsEmail.Controllers
{
    public class SmsController : Controller
    {
        

        // GET: Sms
        public ActionResult Index()
        {
            ///Send SMS using C#

            //Your authentication key
            string authKey = "YourAuthKey";
            //Multiple mobiles numbers separated by comma
            string mobileNumber = "9999999";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "102234";
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.UrlEncode("Test message");

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "default");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "https://control.msg91.com/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }

            return View();
        }



        [HttpPost, ActionName("send-sms")]
        public ActionResult SendSMS(SMS sms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSuccess = false;
                    string errMsg = null;
                    string response = _smsService.Send(sms); //Send sms

                    string code = _smsService.GetResponseMessage(response, out isSuccess, out errMsg);

                    if (!isSuccess)
                    {
                        ModelState.AddModelError("", errMsg);
                    }
                    else
                    {
                        ViewData["SuccessMsg"] = "Message was successfully sent.";
                    }
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