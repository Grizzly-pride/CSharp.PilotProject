using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace PilotProject
{
    internal sealed class MailSender
    {
        public MailAddress FromAddress { get; private set; }
        public MailAddress ToAddress { get; private set; }
        public MailMessage Message { get; private set; }    

        public void SendMessage(string fromAddress, string fromName, string pass, string toAddress, string themaMessage, string textMessage)
        {
            FromAddress = new MailAddress(fromAddress, fromName);
            ToAddress = new(toAddress);

            Message = new(FromAddress, ToAddress)
            {
                Subject = themaMessage,
                Body = textMessage,
                IsBodyHtml = true,
            };

            SmtpClient smtp = new("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromAddress, pass),
                EnableSsl = true
            };

            smtp.Send(Message);
            Console.Read();
        }
    }
}
