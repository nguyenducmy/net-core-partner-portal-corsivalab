using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace partnerportal.Service
{
    public class EmailService : IEmailService
    {
        public string _smtpServer = "send.smtp.com";
        public int _portNumber = 25;
        public string _sendFrom = "test@mailgridapp.com";
        public string _Password = "UkvtH9vbD$TC9UC";

        public EmailService() { }

        public EmailService(string smtpServer, int portNumber, string sendFrom, string password)
        {
            _smtpServer = smtpServer;
            _portNumber = portNumber;
            _sendFrom = sendFrom;
            _Password = password;
        }

        public async Task SendEmail(string to, string body, string subject)
        {
            MailMessage message = new MailMessage(_sendFrom, to);

            message.Subject = subject;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            SmtpClient client = new SmtpClient(_smtpServer, _portNumber);
            NetworkCredential credential = new NetworkCredential(_sendFrom, _Password);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = credential;

            /*client.SendCompleted += (s, e) => {
                client.Dispose();
                message.Dispose();
            };*/

            await client.SendMailAsync(message);
        }

        Task IEmailService.SendEmail(string to, string body, string subject)
        {
            throw new System.NotImplementedException();
        }
    }
}
