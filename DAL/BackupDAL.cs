using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BackupDAL
    {
        static int mId;


        public static void RealizarBackup(int Partes, string Ruta)
        {
            string mCommand = "BACKUP DATABASE [BuenViaje] TO ";
            for (int i = 1; i <= Partes; i++){
                mCommand = mCommand + "DISK = '" + Ruta + "\\BuenViaje_Backup_" + i + ".bak'";
                if(i < Partes)
                {
                    mCommand = mCommand + ", ";
                }
                else
                {
                    mCommand = mCommand + " ";
                }
            }
            mCommand = mCommand + "WITH NOFORMAT, NOINIT, NAME = 'BuenViajeBackup-" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            try
            {
                DAO.Instancia().ExecuteNonQuery(mCommand);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static void RealizarRestore(List<string> archivos)
        {
            //string mCommand = "USE MASTER ALTER DATABASE BuenViaje SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE BuenViaje FROM ";
            string mCommand = "USE MASTER ALTER DATABASE BuenViaje SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE BuenViaje FROM ";
            for (int i = 0; i < archivos.Count; i++)
            {
                mCommand = mCommand + "DISK = '" + archivos[i] + "'" ;
                if (i < archivos.Count - 1)
                {
                    mCommand = mCommand + ", ";
                }
                else
                {
                    mCommand = mCommand + " WITH REPLACE ";
                }
            }
            //mCommand = mCommand + "ALTER DATABASE BuenViaje SET MULTI_USER";
            try
            {
                DAO.Instancia().ExecuteNonQuery(mCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
