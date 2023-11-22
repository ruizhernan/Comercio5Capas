using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using System.Data.SqlClient;

namespace MPP
{
    public class MPPProducto
    {
        Acceso oAcceso;

        public List<BEProducto> CargarListaProductos()
        {
            List<BEProducto> ListBEProductos = new List<BEProducto>();
            DataSet DS;
            string query = "SELECT * FROM Producto";
            oAcceso = new Acceso();
            DS = oAcceso.Lectura(query);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow fila in DS.Tables[0].Rows)
                {
                    BEProducto oBEPRoducto = new BEProducto();
                    oBEPRoducto.Id = Convert.ToInt32(fila["IdProducto"]);
                    oBEPRoducto.Nombre = fila["Nombre"].ToString();
                    oBEPRoducto.Precio = Convert.ToInt32(fila["Precio"]);
                    ListBEProductos.Add(oBEPRoducto);
                }

            }
            else
            {
                ListBEProductos = null;
            }
            return ListBEProductos;
        }

        public bool Guardar(BEProducto oBEProducto)
        {
            try
            {
                oAcceso = new Acceso();
               ArrayList parametros = new ArrayList
            {
                new SqlParameter("@IdProducto", oBEProducto.Id),
                new SqlParameter("@Nombre", oBEProducto.Nombre),
                new SqlParameter("@Precio", oBEProducto.Precio)
            };
                                
                return oAcceso.Guardado("GuardarProducto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BEProducto oBEProducto)
        {
            try
            {
                oAcceso = new Acceso();
                ArrayList parametros = new ArrayList
            {
                new SqlParameter("@IdProducto", oBEProducto.Id)
            };

                
                return oAcceso.Guardado("EliminarProducto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
