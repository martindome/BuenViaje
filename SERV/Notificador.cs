using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace SERV
{
    public class Notificador
    {
        public class email
        {
            public static void Send(string pMensaje, string pAsunto, string pToAddress, string pFrom = "buenviaje@notifications.ar")
            {
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress(pFrom);
                    message.To.Add(new MailAddress(pToAddress));
                    message.Subject = pAsunto;
                    message.IsBodyHtml = true;
                    message.Body = pMensaje;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("jnahuelperez35@gmail.com", "ljztfmzqqnopukik");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (Exception ex) { throw (ex); }
            }
        }
    }
}
