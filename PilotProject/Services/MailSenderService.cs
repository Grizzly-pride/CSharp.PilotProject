using System.Text;
using System.Net.Mail;
using System.Net;
using PilotProject.Interfaces;


namespace PilotProject.Services
{
    internal sealed class MailSenderService : IMailSenderService<string, int>
    {
        public MailMessage CreateMessage(string themaMessage, string textMessage)
        {
            MailMessage message = new()
            {
                Subject = themaMessage,
                Body = textMessage,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
            };
            return message;
        }

        public MailAddress CreateSender(SmtpClient smtp, string name, string email, string password)
        {
            smtp.Credentials = new NetworkCredential(email, password);
            return new MailAddress(email, name);
        }

        public SmtpClient CreateSmtp(string smtpName, int port)
        {
            SmtpClient smtp = new(smtpName, port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
            };
            return smtp;
        }
    }
}