using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.Composite;
using DAL;
using SERV;

namespace BL
{
    public class UsuarioBL
    {
        private UsuarioBE mBE = new UsuarioBE();
        //public int ID_Usuario { get {return mBE.ID_Usuario; } set { mBE.ID_Usuario = value; } }
        //public string Nombre { get { return mBE.Nombre; } set { mBE.Nombre = value; } }
        //public string Apellido { get { return mBE.Apellido; } set { mBE.Apellido = value; } }
        //public string Nombre_Usuario { get { return mBE.Nombre_Usuario; } set { mBE.Nombre_Usuario = value; } }
        //public string Contrasenia { get { return mBE.Contrasenia; } set { mBE.Contrasenia = value; } }
        //public string DVH { get { return mBE.DVH; } set { mBE.DVH = value; } }
        //public int Intentos_Login { get { return mBE.Intentos_Login; } set { mBE.Intentos_Login = value; } }

        public UsuarioBE Obtener(string pNombreUsuario)
        {
            //this.user = pUsuario.user;
            return (UsuarioBE)UsuarioDAL.Obtener(pNombreUsuario);
        }

        public void Guardar(UsuarioBE pUsuario)
        {
            //Validar que todas las patentes esten asigandas a un usuario por lo menos
            PatenteBL patentebl = new PatenteBL();
            UsuarioBL usuariobl = new UsuarioBL();
            FamiliaBL familiabl = new FamiliaBL();
            List<PatenteBE> patentes = patentebl.Listar();
            bool TodasPatentesFlag = true;
            foreach (PatenteBE patente in patentes)
            {
                bool PatenteFlag = false;
                foreach (UsuarioBE user in UsuarioDAL.Listar())
                {
                    //Cuando el user no es pUsuario, tengo que ir a buscar los permisos a la BD porque no los tengo cargados en memoria
                    if (user.ID_Usuario != pUsuario.ID_Usuario)
                    {
                        foreach (CompuestoBE permiso in usuariobl.ObtenerPermisos(user))
                        {
                            if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                            {
                                PatenteFlag = true;
                                break;
                            }
                            else if (permiso is FamiliaBE)
                            {
                                foreach (CompuestoBE innerPatente in permiso.ObtenerHijos())
                                {
                                    if (innerPatente is PatenteBE && ((PatenteBE)innerPatente).Tipo == patente.Tipo)
                                    {
                                        PatenteFlag = true;
                                        break;
                                    }
                                }
                                if (PatenteFlag)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Cuando el user es pUsuario, tengo los permisos en memoria
                        foreach (CompuestoBE permiso in pUsuario.Permisos)
                        {
                            if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                            {
                                PatenteFlag = true;
                                break;
                            }
                            else if(permiso is FamiliaBE)
                            {
                                foreach (PatenteBE innerPatente in familiabl.ListarPatentes((FamiliaBE)permiso))
                                {
                                    if ( innerPatente.Tipo == patente.Tipo)
                                    {
                                        PatenteFlag = true;
                                        break;
                                    }
                                }
                                if (PatenteFlag)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (PatenteFlag)
                    {
                        break;
                    }
                }
                TodasPatentesFlag = TodasPatentesFlag && PatenteFlag;
                if (!TodasPatentesFlag)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("No todas las patentes estan asignadas a un usuario", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }

            //Guardamos y borramos permisos
            UsuarioDAL.Guardar(pUsuario);
            List<CompuestoBE> permisosViejos = this.ObtenerPermisos(pUsuario);
            foreach (CompuestoBE permiso in pUsuario.Permisos)
            {
                bool flag = false;
                foreach (CompuestoBE permisoViejo in permisosViejos)
                {
                    if (permiso is PatenteBE && permisoViejo is PatenteBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                    else if (permiso is FamiliaBE && permisoViejo is FamiliaBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    if (permiso is PatenteBE)
                    {
                        PatenteDAL.GuardarPatenteUsuario((PatenteBE)permiso, pUsuario);
                    }
                    else if (permiso is FamiliaBE)
                    {
                        FamiliaDAL.GuardarFamiliaUsuario((FamiliaBE)permiso, pUsuario);
                    }
                }
            }
            foreach (CompuestoBE permisoViejo in permisosViejos)
            {
                bool flag = false;
                foreach (CompuestoBE permiso in pUsuario.Permisos)
                {
                    if (permiso is PatenteBE && permisoViejo is PatenteBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                    else if (permiso is FamiliaBE && permisoViejo is FamiliaBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    if (permisoViejo is PatenteBE)
                    {
                        PatenteDAL.BorrarPatenteUsuario((PatenteBE)permisoViejo, pUsuario);
                    }
                    else if (permisoViejo is FamiliaBE)
                    {
                        FamiliaDAL.BorrarFamiliaUsuario((FamiliaBE)permisoViejo, pUsuario);
                    }
                }
            }
        }

        private static bool VerificarTodasPatentes(UsuarioBE pUsuario)
        {
            //Validar que todas las patentes esten asigandas a un usuario por lo menos
            PatenteBL patentebl = new PatenteBL();
            UsuarioBL usuariobl = new UsuarioBL();
            List<PatenteBE> patentes = patentebl.Listar();
            bool TodasPatentesFlag = true;
            foreach (PatenteBE patente in patentes)
            {
                bool PatenteFlag = false;
                foreach (UsuarioBE user in UsuarioDAL.Listar())
                {
                    // Elimino de la lista al usuario que estoy borrando
                    if (user.ID_Usuario != pUsuario.ID_Usuario)
                    {
                        foreach (CompuestoBE permiso in usuariobl.ObtenerPermisos(user))
                        {
                            if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                            {
                                PatenteFlag = true;
                                break;
                            }
                        }
                    }
                    if (PatenteFlag)
                    {
                        break;
                    }
                }
                TodasPatentesFlag = TodasPatentesFlag && PatenteFlag;
                if (!TodasPatentesFlag)
                {
                    return false;
                }
            }
            return true;
        }

        public void Eliminar(UsuarioBE pUsuario)
        {
            if (pUsuario.ID_Usuario == SingletonSesion.Instancia.Usuario.ID_Usuario)
            {
                throw new Exception(IdiomaBL.ObtenerMensajeTextos("Un usuario no se puede eliminar a si mismo", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            }
            //Validar que todas las patentes esten asigandas a un usuario por lo menos
            PatenteBL patentebl = new PatenteBL();
            UsuarioBL usuariobl = new UsuarioBL();
            List<PatenteBE> patentes = patentebl.Listar();
            bool TodasPatentesFlag = true;
            foreach (PatenteBE patente in patentes)
            {
                bool PatenteFlag = false;
                foreach (UsuarioBE user in UsuarioDAL.Listar())
                {
                    //Cuando user es pUsuario, lo saco porque quiero ver el estado de los permisos cuando pUsuario sea removido
                    if (user.ID_Usuario != pUsuario.ID_Usuario)
                    {
                        foreach (CompuestoBE permiso in usuariobl.ObtenerPermisos(user))
                        {
                            if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                            {
                                PatenteFlag = true;
                                break;
                            }
                        }
                    }
                    if (PatenteFlag)
                    {
                        break;
                    }
                }
                TodasPatentesFlag = TodasPatentesFlag && PatenteFlag;
                if (!TodasPatentesFlag)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("No todas las patentes estan asignadas a un usuario", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }
            //Eliminamos permisos y patentes
            foreach (CompuestoBE permiso in pUsuario.Permisos)
            {
                if (permiso is PatenteBE)
                {
                    PatenteDAL.BorrarPatenteUsuario((PatenteBE)permiso, pUsuario);
                }
                else if (permiso is FamiliaBE)
                {
                    FamiliaDAL.BorrarFamiliaUsuario((FamiliaBE)permiso, pUsuario);
                }
            }
            UsuarioDAL.Eliminar(pUsuario);

        }

        public void Actualizar(UsuarioBE pUsuario)
        {
            UsuarioDAL.Actualizar(pUsuario);
        }

        public List<UsuarioBE> Listar()
        {
            return UsuarioDAL.Listar();
        }

        public string ObtenerIdiomaUsuario(UsuarioBE pUsuario)
        {
            return UsuarioDAL.ObtenerIdiomaUsuario(pUsuario);
        }

        public void CambiarContrasenia(UsuarioBE pUsuario, string contraseniaActual, string NuevaContrasenia)
        {
            contraseniaActual = DAL.LoginDAL.CalcularHashMD5(contraseniaActual);
            NuevaContrasenia = DAL.LoginDAL.CalcularHashMD5(NuevaContrasenia);
            if (pUsuario.Contrasenia != contraseniaActual)
            {
                throw new Exception(IdiomaBL.ObtenerMensajeTextos("Clave actual incorrecta", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                throw new Exception("Clave actual incorrecta");
            }
            if (pUsuario.Contrasenia == NuevaContrasenia)
            {
                throw new Exception(IdiomaBL.ObtenerMensajeTextos("La clave anterior y nueva son iguales", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                throw new Exception("La clave anterior y nueva son iguales");
            }
            //BitacoraBE mBitacora = new BitacoraBE();
            //BitacoraBL Bitacorabl = new BitacoraBL();
            UsuarioBL Usuariobl = new UsuarioBL();
            pUsuario.Contrasenia = NuevaContrasenia;
            //mBitacora.Descripcion = "Cambio de clave usuario: "+ pUsuario.Nombre_Usuario;
            //mBitacora.Fecha = DateTime.Now;
            //mBitacora.ID_Usuario = pUsuario.ID_Usuario;
            //mBitacora.Tipo_Evento = "HIGH";
            //Bitacorabl.Guardar(mBitacora);
            Usuariobl.Actualizar(pUsuario);
        }

        public void ResetarConstrasenia(UsuarioBE pUsuario)
        {
            //BitacoraBE mBitacora = new BitacoraBE();
            //BitacoraBL Bitacorabl = new BitacoraBL();
            //mBitacora.Descripcion = "Reset clave usuario: "+ pUsuario.Nombre_Usuario;
            //mBitacora.Fecha = DateTime.Now;
            //mBitacora.ID_Usuario = pUsuario.ID_Usuario;
            //mBitacora.Tipo_Evento = "HIGH";
            //Bitacorabl.Guardar(mBitacora);
            string newPassword = UsuarioDAL.ResetearConstrasenia(pUsuario);
        }
        public List<CompuestoBE> ObtenerPermisos(UsuarioBE pUsuario)
        {
            return UsuarioDAL.ObtenerPermisos(pUsuario);
        }

        public List<PatenteBE> ObtenerPatentes(UsuarioBE usuario)
        {
            return UsuarioDAL.ListarPatentes(usuario);
        }

        public List<CompuestoBE> ObtenerFamilias(UsuarioBE usuario)
        {
            return UsuarioDAL.ListarFamilias(usuario);
        }
    }
}
