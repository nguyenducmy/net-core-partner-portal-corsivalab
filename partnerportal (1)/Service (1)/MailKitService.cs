using MimeKit;
using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace partnerportal.Service
{
    public class MailKitService : partnerportal.Service.IEmailService
    {
        public string SmtpHost = "send.smtp.com";
        public int _portNumber = 25;
        public string _sendFrom = "test@mailgridapp.com";
        public string _password = "UkvtH9vbD$TC9UC";

        public MailKitService() { }
        public Task SendEmail(string to, string body, string subject)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_sendFrom));
            email.To.Add(MailboxAddress.Parse(to));

            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(SmtpHost, _portNumber, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_sendFrom, _password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            return Task.CompletedTask;
        }
    }
}
