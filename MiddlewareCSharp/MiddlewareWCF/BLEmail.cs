using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class BLEmail
    {
        private readonly SmtpClient smtpClient;
        private readonly MailAddress from;

        public BLEmail()
        {
            from = new MailAddress("noreply.dettes.cesi@gmail.com");

            smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("noreply.dettes.cesi@gmail.com", "6wM2edtsMZn&$S"),
                EnableSsl = true,
            };
        }

        public MailMessage CreateMailMessage(string subject, string body)
        {
            return new MailMessage
            {
                From = from,
                Subject = subject,
                Body = body
            };
        }

        public MailMessage AddAttachment(MailMessage message, Attachment attachment)
        {
            message.Attachments.Add(attachment);
            return message;
        }

        public bool SendEmail(string recipient, MailMessage message)
        {
            try
            {
                message.To.Add(recipient);
                smtpClient.Send(message);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
