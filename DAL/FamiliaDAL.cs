using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.Composite;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class FamiliaDAL
    {

        public static List<PatenteBE> ListarPatentes(FamiliaBE pFamilia)
        {
            List<PatenteBE> patentes = new List<PatenteBE>();

            string mCommand = "SELECT p.ID_Permiso, p.Nombre, p.Descripcion, p.Tipo_Permiso, f.ID_Familia " +
                "FROM Permiso AS p " +
                "INNER JOIN Permiso_Familia AS pf ON pf.ID_Permiso = p.ID_Permiso " +
                "INNER JOIN Familia AS f ON pf.ID_Familia = f.ID_Familia " +
                "WHERE f.ID_Familia = " + pFamilia.ID_Compuesto;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDataRow in mDataSet.Tables[0].Rows)
                {
                    PatenteBE pPatente = new PatenteBE();
                    PatenteDAL.ValorizarEntidad(pPatente, mDataRow);
                    patentes.Add(pPatente);
                }
            }
            return patentes;
        }

        internal static void ValorizarEntidad(FamiliaBE pFamilia, DataRow mDataRow)
        {
            pFamilia.ID_Compuesto = int.Parse(mDataRow["ID_Familia"].ToString());
            pFamilia.Nombre = mDataRow["Nombre"].ToString();
            pFamilia.Descripcion = mDataRow["Descripcion"].ToString();
        }
    }
}
