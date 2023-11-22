using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Collections;

namespace MPP
{
    public class MPPCliente
    {
         Acceso oDatos;
        
        public List<BECliente> CargarListaClientes()
        {
            List<BECliente> ListaClientes = new List<BECliente>();
            DataSet Ds;


            oDatos = new Acceso();
            Ds = oDatos.Leer("ObtenerClientes", null);
            if (Ds.Tables[0].Rows.Count > 0 )
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BECliente bECliente = new BECliente();
                    bECliente.ID = Convert.ToInt32(fila[0]);
                    bECliente.Nombre = fila["Nombre"].ToString();
                    bECliente.Direccion = fila["Direccion"].ToString();
                    ListaClientes.Add(bECliente);
                }
            }
            else
            {
                ListaClientes = null;
            }
            return ListaClientes;
        }

        public bool Guardar(BECliente oBECliente)
        {
            try
            {
                

                
                ArrayList parametros = new ArrayList
            {
                new SqlParameter("@IdCliente", oBECliente.ID),
                new SqlParameter("@Nombre", oBECliente.Nombre),
                new SqlParameter("@Direccion", oBECliente.Direccion)
            };

               
                return oDatos.Guardado("GuardarCliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Eliminar(BECliente oBECliente)
        {
            try
            {
                oDatos = new Acceso();

                
                ArrayList parametros = new ArrayList
            {
                new SqlParameter("@IdCliente", oBECliente.ID)
            };

             
                return oDatos.Guardado("EliminarCliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
