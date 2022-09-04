using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using PilotProject.Interfaces;

namespace PilotProject.Services
{
    internal sealed class MailSenderService : IMailSenderService<string, int>
    {
        //private string _name = "DotNet Pizza";
        //private string _email = "dotnetpizza@mail.ru";
        //private string _password = "mipDMdBya0ZKPdYNfYRL";
        //private string _smtpServer = "smtp.mail.ru";
        //private int _port = 2525;
        //public MailAddress FromAddress { get; private set; }
        //public MailAddress ToAddress { get; private set; }

        //public void SendMessage(string toAddress, string themaMessage, string textMessage)
        //{
        //    FromAddress = new MailAddress(_email, _name);
        //    ToAddress = new(toAddress);

        //    MailMessage message = new(FromAddress, ToAddress)
        //    {
        //        Subject = themaMessage,
        //        Body = textMessage,
        //        IsBodyHtml = true,
        //    };

        //    SmtpClient smtp = new(_smtpServer, _port)
        //    {
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(_email, _password)
        //    };

        //    try
        //    {
        //        smtp.Send(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //---------------------------------------------------------------------------------------------

        public MailMessage CreateMessage(string themaMessage, string textMessage)
        {
            MailMessage message = new()
            {
                Subject = themaMessage,
                Body = textMessage,
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

        //-----------------------------------------------------------------------------------------------


    }
}
