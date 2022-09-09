using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using PilotProject.Services;
using System.Net;

namespace PilotProject.Entities
{
    internal static class Messenger
    {
        static string _Name = "DotNet Pizza";
        static string _Email = "dotnetpizza@mail.ru";
        static string _Password = "mipDMdBya0ZKPdYNfYRL";
        static string _SmtpName = "smtp.mail.ru";
        static int _Port = 2525;

        public static async Task SendMessage(string addressee, Letter letter)
        {
            MailSenderService MailSender = new();
            using (SmtpClient smtp = MailSender.CreateSmtp(_SmtpName, _Port))
            {
                MailAddress sender = MailSender.CreateSender(smtp, _Name, _Email, _Password);
                MailMessage mailMessage = MailSender.CreateMessage(letter.Theme, letter.Message);
                mailMessage.From = sender;
                mailMessage.To.Add(addressee);
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}
