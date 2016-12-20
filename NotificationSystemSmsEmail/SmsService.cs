using NotificationSystemSmsEmail.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace NotificationSystemSmsEmail
{
    public class SmsService
    {
        private ConfigService _config;
        private Cache _cache;

        public SmsService()
        {
            _config = new ConfigService();
            _cache = HttpContext.Current.Cache;
        }

        public string Send(SMS sms)
        {
            //Your authentication key
            string authKey = _config.SmsAuthKey;
            //Multiple mobiles numbers separated by comma
            string mobileNumber = sms.Numbers;
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = sms.SenderId;
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.UrlEncode("Test message");

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", 4);

            try
            {
                //Call Send SMS API
                string sendSMSUri = _config.SmsUrl;
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
                return responseString;
            }
            catch (SystemException ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}