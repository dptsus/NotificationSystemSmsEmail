// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using NotificationSystemSmsEmail.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace NotificationSystemSmsEmail
{
    public class EmailService
    {
        private ConfigService _config;
        private Cache _cache;

        public EmailService()
        {
            _config = new ConfigService();
            _cache = HttpContext.Current.Cache;

        }

        public async Task SendEmail(EmailViewModel model)
        {
            string apiKey = _config.SendGridAPIKey;
            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email(model.EmailFrom);
            //string subject = "Sending with SendGrid is Fun";
            string subject = model.EmailSubject;
            Email to = new Email(model.EmailTo);
            //Content content = new Content("text/plain", "and easy to do anywhere, even with C#");
            Content content = new Content("text/plain", model.EmailContent);
            Mail mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}