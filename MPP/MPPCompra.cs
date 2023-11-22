using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPCompra
    {

        Acceso oAcceso;
        public bool Guardar(BECompra oBECompra, BECliente oBECliente)
        {
            
            oBECompra.FechaCompra = DateTime.Now;
            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@FechaCompra", oBECompra.FechaCompra),
                new SqlParameter("@Total", oBECompra.Total),
                new SqlParameter("@IdCliente", oBECliente.ID)
            };

            oAcceso = new Acceso();
            return oAcceso.Guardado("GuardarCompra", parametros);

        }
    }
}
