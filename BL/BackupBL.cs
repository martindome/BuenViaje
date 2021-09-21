using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class BackupBL
    {

        public void RealizarBackup(int Partes, string Ruta)
        {
            try
            {
                BackupDAL.RealizarBackup(Partes, Ruta);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RealizarRestore(List<string> archivos)
        {
            try
            {
                BackupDAL.RealizarRestore(archivos);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
