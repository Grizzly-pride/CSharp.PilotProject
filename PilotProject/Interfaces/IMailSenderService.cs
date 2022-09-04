using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PilotProject.Interfaces
{
    internal interface IMailSenderService<T1, T2>
    {
        MailMessage CreateMessage(T1 themaMessage, T1 textMessage);
        SmtpClient CreateSmtp(T1 smtpName, T2 port);
        MailAddress CreateSender(SmtpClient smtp, T1 name, T1 email, T1 password);
    }
}
