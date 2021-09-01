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

        public string CalcularDVH(string pString)
        {
            int acum = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(pString);
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                acum += asciiBytes[i] * i;
            }
            //return mCifra.CalcularHashMD5(pString);
            return acum.ToString();
        }
        public string CalcularDVV(List<string> pRows)
        {
            int acum = 0;
            foreach(string Registro in pRows)
            {
                acum += int.Parse(Registro);
            }
            return acum.ToString();
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
