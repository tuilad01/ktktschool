using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using lawfirm.Common;

namespace lawfirm.Controllers
{
    public class Message
    {
        public void SendMessageMail(string body, string fromName, string fromMail, string toMail, string subject)
        {
            var messagae = new MailMessage()
            {
                From = new MailAddress(fromMail),
                To = { toMail},
                Subject = subject,
                IsBodyHtml = true,
                Body = $"<p>Email From: {fromName} ({fromMail})</p><p>Message:</p><p>{"hihihi"}</p>"
            };
            using (var stmp = new SmtpClient())
            {
                var clientCertificates = new NetworkCredential()
                {
                    UserName = DefaultStmp.UserName,
                    Password = DefaultStmp.Password,
                };
                stmp.Credentials = clientCertificates;
                stmp.Host = DefaultStmp.Host;
                stmp.Port = DefaultStmp.Port;
                stmp.EnableSsl = true;
                stmp.Send(messagae);
            }
        }
    }
}