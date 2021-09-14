using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;
using BE.Composite;

namespace BL
{
    public class LoginBL
    {
        public static UsuarioBE SingleUsuario = new UsuarioBE();

        public void ValidarLogin(string pNombre_Usuario, string pPassword)
        {
            if (SingletonSesion.Instancia.EstaLogueado())
            {
                throw new Exception("Existe una sesion iniciada");
            }

            BitacoraBE mBitacora = new BitacoraBE();
            BitacoraBL Bitacorabl = new BitacoraBL();
            UsuarioBL Usuariobl = new UsuarioBL();
            UsuarioBE mUsuario = Usuariobl.Obtener(pNombre_Usuario);
            if (mUsuario != null)
            {
                if (mUsuario.Intentos_Login >= 3)
                {
                    
                    //Crear Registro en bitacora
                    mBitacora.Descripcion = "Oper. no autorizada: intento de inicio de sesio con usuario bloqueado";
                    mBitacora.Fecha = DateTime.Now;
                    mBitacora.ID_Usuario = mUsuario.ID_Usuario;
                    mBitacora.Tipo_Evento = "HIGH";
                    Bitacorabl.Guardar(mBitacora);
                    throw new Exception("Usuario esta bloqueado");
                }
                else
                {
                    if (ValidarContraseña(mUsuario, pPassword))
                    {
                        SingletonSesion.Instancia.Login(mUsuario);
                    }
                } 
            }
            else
            {
                //Crear Registro en bitacora
                mBitacora.Descripcion = "Oper. no autorizada: intento de inicio de sesio con usuario inexistente";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = 0;
                mBitacora.Tipo_Evento = "LOW";
                Bitacorabl.Guardar(mBitacora);
                throw new Exception("Usuario no esta registrado");
            }
        }

        public bool ValidarContraseña(UsuarioBE pUsuario, string pPassword)
        {
            BitacoraBE mBitacora = new BitacoraBE();
            BitacoraBL Bitacorabl = new BitacoraBL();
            UsuarioBL Usuariobl = new UsuarioBL();
            string mPassMD5 = DAL.LoginDAL.CalcularHashMD5(pPassword);
            if (pUsuario.Contrasenia == mPassMD5)
            {
                pUsuario.Intentos_Login = 0;
                mBitacora.Descripcion = "Inicio de sesion satisfactorio";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = pUsuario.ID_Usuario;
                mBitacora.Tipo_Evento = "LOW";
                Bitacorabl.Guardar(mBitacora);
                Usuariobl.Actualizar(pUsuario);
                //SingleUsuario = pUsuario;
                return true;
            }
            else
            {
                pUsuario.Intentos_Login++;
                if (pUsuario.Intentos_Login < 3)
                {
                    mBitacora.Descripcion = "Ingreso de clave incorrecta en el inicio de sesion";
                    mBitacora.Tipo_Evento = "MEDIUM";
                    mBitacora.Fecha = DateTime.Now;
                    mBitacora.ID_Usuario = pUsuario.ID_Usuario;
                    Bitacorabl.Guardar(mBitacora);
                }
                else
                {
                    mBitacora.Descripcion = "Usuario bloqueado por maximo de ingresos incorrectos";
                    mBitacora.Tipo_Evento = "HIGH";
                    mBitacora.Fecha = DateTime.Now;
                    mBitacora.ID_Usuario = pUsuario.ID_Usuario;
                    Bitacorabl.Guardar(mBitacora);
                }
                Usuariobl.Actualizar(pUsuario);
                throw new Exception("Usuario o clave incorrectos");
            }

        }

        //public void Logout(UsuarioBE pUsuario)
        //{
        //    if (!SingletonSesion.Instancia.EstaLogueado())
        //    {
        //        throw new Exception("No existe una sesion iniciada");
        //    }

        //    //Crear Registro en bitacora
        //    BitacoraBE mBitacora = new BitacoraBE();
        //    BitacoraBL bitacoraBL = new BitacoraBL();
        //    mBitacora.Descripcion = "Usuario cerro sesion";
        //    mBitacora.Tipo_Evento = "LOW";
        //    mBitacora.Fecha = DateTime.Now;
        //    mBitacora.ID_Usuario = pUsuario.ID_Usuario;
        //    bitacoraBL.Guardar(mBitacora);

        //    //Desasigno Usuario
        //    SingletonSesion.Instancia.Logout();
        //}

        //public bool VerificarPermiso(TipoPermiso permiso)
        //{
        //    if (SingleUsuario == null)
        //    {
        //        return false;
        //    }

        //    bool valido = false;
        //    foreach (var p in SingleUsuario.Permisos)
        //    {
        //        if (p is PatenteBE && ((PatenteBE)p).Tipo.Equals(permiso))
        //        {
        //            valido = true;
        //        }
        //        else
        //        {
        //            valido = VerificarPermiso(p, permiso, valido);
        //        }
        //    }
        //    return valido;
        //}

        //public bool VerificarPermiso(CompuestoBE p, TipoPermiso permiso, bool valido)
        //{
        //    foreach (var item in p.ObtenerHijos())
        //    {
        //        if (item is PatenteBE && ((PatenteBE)item).Tipo.Equals(permiso))
        //        {
        //            valido = true;
        //        }
        //        else
        //        {
        //            valido = VerificarPermiso(item, permiso, valido);
        //        }
        //    }
        //    return valido;
        //}
    }
}
