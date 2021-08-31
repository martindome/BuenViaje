using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SERV
{
    public class Integridad
    {
        static Seguridad.Cifrado mCifra = new Seguridad.Cifrado();

        public string ObtenerDVH(string pString)
        {
            return mCifra.ObtenerHashMD5(pString);
        }

        public string ObtenerDVV(List<string> pRows)
        {
            string valores = "";
            foreach(string Registro in pRows)
            {
                valores += ToBinary(ConvertToByteArray(Registro, Encoding.ASCII));
            }

            return mCifra.ObtenerHashMD5(valores.ToString());
        }

        private static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        private static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}
