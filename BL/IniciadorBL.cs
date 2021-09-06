using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;
using System.IO;

namespace BL
{
    public class IniciadorBL
    {
        public void ConectarBD ()
        {
            try
            {
                DAL.IniciadorDAL.ProbarConexionDB();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool ChequearArchivoDeConfiguracion(string pPath)
        {
            bool result;
            try
            {
                return result = File.Exists(pPath);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ChequearIntegridad()
        {
            try
            {
                this.ChequearDVH();
                this.ChequearDVV();
            }
            catch (Exception ex) 
            { 
                throw (ex); 
            }
        }
        #region private functions
        private void ChequearDVH()
        {
            List<DigitoVerificadorVerticalBE> Tabla = IniciadorDAL.ChequearIntegridad();
            if (Tabla.Count == 0) { }
            else
            {
                string mDetalle = "Fallo integridad";
                foreach (DigitoVerificadorVerticalBE mDVV in Tabla)
                {
                    //Crear Registro en bitacora
                    throw new Exception(mDetalle);
                }
            }
        }

        private void ChequearDVV()
        {
            List<DigitoVerificadorVerticalBE> Tabla = IniciadorDAL.ChequearDigitoVerificadorVertical();
            if (Tabla.Count == 0) { }
            else
            {
                string mDetalle = "Fallo integridad digito verificador";
                foreach (DigitoVerificadorVerticalBE mDVV in Tabla)
                {
                    //Crear Registro en bitacora
                    throw new Exception(mDetalle);
                }
            }
        }
        #endregion
    }
}
