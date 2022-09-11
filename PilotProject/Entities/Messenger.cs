using System.Net.Mail;
using PilotProject.Services;


namespace PilotProject.Entities
{
    internal static class Messenger
    {
        static readonly string _Name = "DotNet Pizza";
        static readonly string _Email = "dotnetpizza@mail.ru";
        static readonly string _Password = "mipDMdBya0ZKPdYNfYRL";
        static readonly string _SmtpName = "smtp.mail.ru";
        static readonly int _Port = 2525;

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