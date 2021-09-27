using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;

namespace DAL
{
    public class ClienteDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<ClienteBE> Listar()
        {
            List<ClienteBE> Lista = new List<ClienteBE>();
            string mCommand = "SELECT b.ID_Cliente, b.Nombre, b.Apellido, b.DNI, b.Email from Cliente as b";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    ClienteBE mCliente = new ClienteBE();
                    ValorizarEntidad(mCliente, mRow);
                    Lista.Add(mCliente);

                }
            }
            return Lista;
        }

        public static ClienteBE Obtener(int pId)
        {
            string mCommand = "SELECT b.ID_Cliente, b.Nombre, b.Apellido, b.DNI, b.Email from Cliente as b WHERE ID_Cliente = " + pId;
            DataSet mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                ClienteBE mCliente = new ClienteBE();
                ValorizarEntidad(mCliente, mDataSet.Tables[0].Rows[0]);
                return mCliente;
            }
            else
            {
                return null;
            }
        }

        public static void Guardar(ClienteBE pCliente)
        {
            string mCommand = "";
            pCliente.Nombre = SERV.Seguridad.Cifrado.Cifrar(pCliente.Nombre);
            pCliente.Apellido = SERV.Seguridad.Cifrado.Cifrar(pCliente.Apellido);
            pCliente.DNI = SERV.Seguridad.Cifrado.Cifrar(pCliente.DNI);
            pCliente.Email = SERV.Seguridad.Cifrado.Cifrar(pCliente.Email);
            if (pCliente.ID_Cliente == 0)
            {
                pCliente.ID_Cliente = ProximoId();
                mCommand = "INSERT INTO Cliente (ID_Cliente, Nombre, Apellido, DNI, Email) VALUES (" + pCliente.ID_Cliente + ", '" + pCliente.Nombre + "', '" + pCliente.Apellido + "', '" + pCliente.DNI + "', '" + pCliente.Email + "')";
            }
            else
            {
                mCommand = "UPDATE Cliente SET Nombre = '" + pCliente.Nombre + "', Apellido = '" + pCliente.Apellido + "', DNI = '" + pCliente.DNI + "', Email = '" + pCliente.Email + "' WHERE ID_Cliente = " + pCliente.ID_Cliente;
            }
            DAO.Instancia().ExecuteNonQuery(mCommand);
        }

        public static void Eliminar(ClienteBE pCliente)
        {
            string mCommand = "DELETE Cliente WHERE ID_Cliente = " + pCliente.ID_Cliente;
            DAO.Instancia().ExecuteNonQuery(mCommand);
        }

        #region private functions
        private static void ValorizarEntidad(ClienteBE pCliente, DataRow pDataRow)
        {
            pCliente.ID_Cliente = int.Parse(pDataRow["ID_Cliente"].ToString());
            pCliente.Nombre = SERV.Seguridad.Cifrado.Descifrar((pDataRow["Nombre"].ToString()));
            pCliente.Apellido = SERV.Seguridad.Cifrado.Descifrar(pDataRow["Apellido"].ToString());
            pCliente.DNI = SERV.Seguridad.Cifrado.Descifrar(pDataRow["DNI"].ToString());
            pCliente.Email = SERV.Seguridad.Cifrado.Descifrar(pDataRow["Email"].ToString());
        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.Instancia()).ObtenerUltimoId("Cliente");
            mId += 1;
            return mId;
        }
        #endregion
    }
}
