// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using NotificationSystemSmsEmail.Models;

namespace NotificationSystemSmsEmail
{
    public class EmailService
    {
        public async Task SendEmail(EmailViewModel model)
        {
            string apiKey = Environment.GetEnvironmentVariable("VishSendGridAPIKey", EnvironmentVariableTarget.User);
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