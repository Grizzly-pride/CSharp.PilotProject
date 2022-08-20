using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace PilotProject.Services
{
    internal sealed class MailSenderService
    {
        private string name = "DotNet Pizza";
        private string email = "dotnetpizza@rambler.ru";
        private string password = "Alexander1991";
        private string smtpServer = "smtp.rambler.ru";
        private int port = 465;
        public MailAddress FromAddress { get; private set; }
        public MailAddress ToAddress { get; private set; }
             
        public void SendMessage(string toAddress, string themaMessage, string textMessage)
        {
            FromAddress = new MailAddress(email, name);
            ToAddress = new(toAddress);

            MailMessage message = new(FromAddress, ToAddress)
            {
                Subject = themaMessage,
                Body = textMessage,
                IsBodyHtml = true,
            };

            SmtpClient smtp = new(smtpServer, port)
            {               
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email, password)
            };

            smtp.Send(message);
            Console.Read();
        }
    }
}
