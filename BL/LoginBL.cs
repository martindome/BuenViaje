using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;

namespace BL
{
    public class LoginBL
    {
        private UsuarioBE mBE = new UsuarioBE();
        public void ValidarLogin(string pUser, string pPass)
        {
            //Por defecto instanacia de bitacora inicia con Nivel=INFO
            //Bitacora mB = mRegistro.Clone() as Bitacora;
            //mUsuario.user = pUser;
            //Usuario mUsu = new Usuario();
            UsuarioBE mUsu = mUsuario.Obtener(pUser);
            if (mUsu != null)
            {
                //if (mUsu.Intentos_Login >= 3)
                //{
                //    if (mUsu.BadLogins >= 3)
                //    {
                //        //Crear Registro en bitacora
                //        mB.Detalle = "Oper. no autorizada: intento de inicio de sesio con usuario bloqueado";
                //        mB.Fecha = DateTime.Now;
                //        mB.idUsuario = mUsu.id;
                //        mB.Nivel = "CRIT";
                //        BL.Bitacora.GrabarBitacora(mB);
                //        throw new LoginException("Usuario esta bloqueado");
                //    }
                //    else
                //    {
                        ValidarPWD(mUsu, pPass);
            //        }
            //    }
            //    else
            //    {
            //        //Crear Registro en bitacora
            //        mB.Detalle = "Oper. no autorizada: intento de inicio de sesion con usuario no activo";
            //        mB.Fecha = DateTime.Now;
            //        mB.idUsuario = mUsu.id;
            //        mB.Nivel = "CRIT";
            //        BL.Bitacora.GrabarBitacora(mB);
            //        throw new LoginException("Usuario no puede iniciar sesion, contactese con el administrador.");
            //    }
            //}
            //else
            //{
            //    //Crear Registro en bitacora
            //    mB.Detalle = "Oper. no autorizada: intento de inicio de sesio con usuario inexistente";
            //    mB.Fecha = DateTime.Now;
            //    mB.idUsuario = mUsu.id;
            //    mB.Nivel = "INFO";
            //    BL.Bitacora.GrabarBitacora(mB);
            //    throw new LoginException("Usuario no esta registrado");
            }
        }

        public bool ValidarPWD(UsuarioBE pUser, string pPwd)
        {
            //Bitacora mB = mRegistro.Clone() as Bitacora;
            string mPass = DAL.LoginDAL.CalcularHashMD5(pPwd);
            if (pUser.Contrasenia == mPass)
            {
                //pUser.LastLogin = DateTime.Now.Date;
                //ResetearBadPWD(pUser);
                ////Crear Registro en bitacora
                //mB.Detalle = "Inicio de sesion satisfactorio";
                //mB.Fecha = DateTime.UtcNow;
                //mB.idUsuario = pUser.id;
                //BL.Bitacora.GrabarBitacora(mB);
                //UsuarioLogeado = pUser;
                return true;
            }
            else
            {
                IncrementBadPwd(pUser);
                throw new Exception("Usuario o clave incorrectos");
            }

        }

        private void IncrementBadPwd(UsuarioBE pUser)
        {
            //Bitacora mB = mRegistro.Clone() as Bitacora;
            //pUser.BadLogins++;
            ////Crear Registro en bitacora
            //mB.Detalle = "Inicio de sesion erroneo: se incrementa contador de ingreso erroneo";
            //mB.Nivel = "WARN";
            //mB.Fecha = DateTime.Now;
            //mB.idUsuario = pUser.id;
            //BL.Bitacora.GrabarBitacora(mB);

            //if (pUser.BadLogins == 3)
            //{
            //    //Bloquear usuario
            //    pUser.Bloqueado = true;
            //    mB.Detalle = "Accion sobre usuario: se bloqueo el usuario.";
            //    mB.Nivel = "CRIT";
            //    mB.Fecha = DateTime.Now;
            //    mB.idUsuario = pUser.id;
            //    DAL.BitacoraDAL.CrearRegistro(mB);
            //    mUsuario.Actualizar(pUser);
            //}
            //mUsuario.Actualizar(pUser);
        }
    }
}
