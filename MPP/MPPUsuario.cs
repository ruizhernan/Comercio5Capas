using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPUsuario
    {
        private Acceso oAcceso;

        public bool VerificarCredenciales(BEUsuario oBEUsuario)
        {
            try
            {
                oAcceso = new Acceso();

               
                ArrayList parametros = new ArrayList
            {
                new SqlParameter("@NombreUsuario", oBEUsuario.Usuario),
                new SqlParameter("@Contraseña", oBEUsuario.pass)
            };

               
                DataSet result = oAcceso.Leer("VerificarCredenciales", parametros);

                
                int count = Convert.ToInt32(result.Tables[0].Rows[0]["Count"]);

               
                return count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CrearCredencial(BEUsuario oBEUsuario)
        {
            try
            {
                oAcceso = new Acceso();

               
                ArrayList parametros = new ArrayList
            {
                new SqlParameter("@NombreUsuario", oBEUsuario.Usuario),
                new SqlParameter("@Contraseña", oBEUsuario.pass)
            };

                
                return oAcceso.Guardado("CrearCredencial", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

