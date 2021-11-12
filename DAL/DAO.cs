using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using SERV;

namespace DAL
{
    public class DAO
    {
        private static DAO _instancia;

        static SqlConnection mCon = new SqlConnection(SERV.Seguridad.Cifrado.Descifrar(ConfigurationManager.ConnectionStrings["BuenViaje"].ConnectionString));

        public DataSet ExecuteDataSet(string pCommandText)
        {
            try
            {
                SqlDataAdapter mDa = new SqlDataAdapter(pCommandText, mCon);
                DataSet mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public DataSet ExecuteDataSet(string pCommandText, Dictionary<string, Object> parameters)
        {
            try
            {
                SqlDataAdapter mDa = new SqlDataAdapter(pCommandText, mCon);
                foreach (string key in parameters.Keys)
                {
                    mDa.SelectCommand.Parameters.AddWithValue(key, parameters[key]);
                }
                DataSet mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQuery(string pCommandText, Dictionary<string, Object> parameters)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                foreach (string key in parameters.Keys)
                {
                    mCom.Parameters.AddWithValue(key, parameters[key]);
                }
                mCon.Open();
                return mCom.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQuery(string pCommandText)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                mCon.Open();
                return mCom.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public object ExecuteScalar(string pCommandText)
        {
            try
            {
                mCon.Open();
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                return mCom.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                mCon.Close();
            }
        }

        public int ObtenerUltimoId(string pTabla)
        {
            try
            {
                SqlCommand mCom = new SqlCommand("SELECT ISNULL(MAX(ID_" + pTabla + "),0) FROM " + pTabla, mCon);
                mCon.Open();
                return int.Parse(mCom.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        static public string DesecriptarStringDeConexion()
        {
            string pName = "RecolectAR";
            Seguridad.Cifrado mCifrado = new Seguridad.Cifrado();
            //Obtenemos los datos del App.Config
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[pName];
            string mConnectionString = settings.ConnectionString;
            //Parseamos el resultado
            string[] parts = mConnectionString.Split(';');
            var mServer = Regex.Match(parts[0], @"server=(.+)").Groups[1].Value;
            var mDB = Regex.Match(parts[1], @"database=(.+)").Groups[1].Value;
            var mUser = Regex.Match(parts[2], @"uid=(.+)").Groups[1].Value;
            var mPass = Regex.Match(parts[3], @"password=(.+)").Groups[1].Value;

            string mConexion =
                "server=" + mServer +
                ";database=" + mDB +
                ";uid=" + SERV.Seguridad.Cifrado.Descifrar(mUser) +
                ";password=" + SERV.Seguridad.Cifrado.Descifrar(mPass) + "";
            return mConexion;
        }

        public static DAO Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new DAO();
            }
            return _instancia;
        }

        public void ProbarConexion()
        {
            try
            {
                mCon.Open();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                mCon.Close();
            }
        }
    }
}
