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
    public class PatenteDAL
    {
        public static void ValorizarEntidad(PatenteBE pPatente, DataRow mDataRow)
        {
            pPatente.ID_Compuesto = int.Parse(mDataRow["ID_Permiso"].ToString());
            pPatente.Nombre = mDataRow["Nombre"].ToString();
            pPatente.Descripcion = mDataRow["Descripcion"].ToString();
            pPatente.Tipo = (BE.Composite.TipoPermiso)Enum.Parse(typeof(BE.Composite.TipoPermiso), mDataRow["Tipo_Permiso"].ToString());
        }

    }
}
