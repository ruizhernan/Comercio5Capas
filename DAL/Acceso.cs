using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Configuration;
using System.Collections;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["thisConnectionString"].ToString());

        SqlCommand cmd;
        SqlTransaction transaccion;

        public DataSet Lectura(string consultaSQL)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(consultaSQL, conexion);
                DA.Fill(DS);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                conexion.Close();
            }
            return DS;
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

        public DataSet Leer(string Consulta_SQL, ArrayList Parametros)
        {
            DataSet dataSet = new DataSet();
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmd = new SqlCommand(Consulta_SQL, conexion, transaccion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                if (Parametros != null)
                {
                    foreach (SqlParameter dato in Parametros)
                    {
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                sqlDataAdapter.Fill(dataSet);
                transaccion.Commit();
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            catch (Exception ex2)
            {
                transaccion.Rollback();
                throw ex2;
            }
            finally
            {
                conexion.Close();
            }

            return dataSet;
        }

        public bool Guardado(string consultaSql, ArrayList Parametros)
        {
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmd = new SqlCommand(consultaSql, conexion, transaccion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (Parametros != null)
                {
                    foreach (SqlParameter parametro in Parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }

                int respuesta = cmd.ExecuteNonQuery();
                transaccion.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
