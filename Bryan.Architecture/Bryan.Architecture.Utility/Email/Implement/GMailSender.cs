using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.Utility.Email.Implement
{
    public class GMailSender
    {
        public void Send(List<string> mailTo,
                         string fromMailAddress,
                         string displayName,
                         string subject,
                         string body,
                         bool isBodyHtml = false,
                         MailPriority mailPriority = MailPriority.Normal)
        {
            var message = GetMailMessage(mailTo, fromMailAddress, displayName, subject, body, isBodyHtml, mailPriority);

            var smtp = new SmtpClient("smtp.gmail.com", 587);
        }

        private MailMessage GetMailMessage(
            List<string> mailTo,
            string fromMailAddress,
            string displayName,
            string subject,
            string body,
            bool isBodyHtml = false,
            MailPriority mailPriority = MailPriority.Normal)
        {
            var message = new MailMessage();
            message.To.Add(string.Join(",", mailTo));
            message.From = new MailAddress(fromMailAddress, displayName);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;
            message.Priority = mailPriority;
            return message;
        }
    }
}