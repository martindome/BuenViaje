using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class SingletonSesion
    {

        private static Sesion pInstancia;
        private static Object pLock = new object();

        public static Sesion Instancia
        {
            get
            {
                lock (pLock)
                {
                    if (pInstancia == null)
                        pInstancia = new Sesion();
                }

                return pInstancia;
            }
        }
    }
}
