using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace SERV
{
    public class Seguridad
    {
        public class Cifrado
        {
            public string CalcularHashMD5(string input)
            {
                // Use input string to calculate MD5 hash
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Convert the byte array to hexadecimal string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
            public static string Cifrar(string input)
            {
                if (string.IsNullOrEmpty(input)) 
                { 
                    throw new ArgumentNullException("Text was not provided"); 
                }
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
            }
            public static bool IsBase64String(string base64String)
            {
                base64String = base64String.Trim();
                return (base64String.Length % 4 == 0) &&
                       Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
            }
            public static string Descifrar(string input)
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentNullException("cipherText");

                if (!IsBase64String(input))
                    throw new Exception("The cipherText input parameter is not base64 encoded");
                return Encoding.UTF8.GetString(Convert.FromBase64String(input));
            }
        }

        public class Notificacion
        {
            public static void EnviarEmail(string pMensaje, string pAsunto, string pToAddress, string pFrom = "buenviaje@notifications.ar")
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
                    smtp.Credentials = new NetworkCredential("buen.viaje.traveling@gmail.com", "3ncr1pt4d0");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (Exception ex) { throw (ex); }
            }
        }

        public class Contrasenia
        {
            static string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%abcdefghijklmnopqrstuvwxyz0123456789";
            static char[] stringCaracteres = new char[16];
            static Random random = new Random();

            public class ContraseniaException : Exception
            {
                public ContraseniaException() { }

                public ContraseniaException(string mensaje) : base(mensaje) { }

                public ContraseniaException(string mensaje, Exception inner) : base (mensaje, inner) { } 

            }
            public static void ValidarContrasenia(string pString)
            {
                Regex mContraseniaRegex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{11,}$");
                if (!mContraseniaRegex.IsMatch(pString))
                {
                    throw new ContraseniaException("Contrasenia No Valida");
                }
            }
            public static string CrearRandomContrasenia(string pTo)
            {
                try
                {
                    for (int i = 0; i < stringCaracteres.Length; i++)
                    {
                        stringCaracteres[i] = caracteres[random.Next(caracteres.Length)];
                    } 
                    String finalString = new String(stringCaracteres);
                    EnviarPWDByMail(finalString, pTo);
                    return finalString;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            private static void EnviarNuevaContrasenia(string pPWD, string pTo)
            {
                try
                {
                    string mAsunto = "Acceso a RecolectAR";
                    string mMensaje = "La clave para que accedas al sistema es:\t" + pPWD;
                    Notificacion.EnviarEmail(mMensaje, mAsunto, pTo);
                }
                catch (Exception ex) {
                    throw (ex);
                }
            }
        }


    }
}
