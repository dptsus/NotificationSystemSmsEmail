using System;
using System.Configuration;

namespace NotificationSystemSmsEmail.Models
{
    public class ConfigService
    {
        public ConfigService() { }

        /// <summary>
        /// Get the SMS gateway url
        /// </summary>
        public string SmsUrl
        {
            get { return getAppSetting(typeof(string), "SmsUrl").ToString(); }
        }

        /// <summary>
        /// Get the SMS Auth key
        /// </summary>
        public string SmsAuthKey
        {
            get { return getAppSetting(typeof(string), "SmsAuthKey").ToString(); }
        }

        /// <summary>
        /// Get the SMS Auth key
        /// </summary>
        public string SendGridAPIKey
        {
            get { return getAppSetting(typeof(string), "SendGridAPIKey").ToString(); }
        }

        private static object getAppSetting(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings[key]; //.Get(key);

            if (value == null)
            {
                throw new Exception(
                    string.Format("The config file does not have the key '{0}' defined in the AppSetting section.", key));
            }

            if (expectedType.Equals(typeof(int)))
            {
                return int.Parse(value);
            }

            if (expectedType.Equals(typeof(string)))
            {
                return value;
            }
            else
                throw new Exception("Type not supported.");
        }
    }
}