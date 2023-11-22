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
    public class MPPDetalleCompra
    {

        Acceso oAcceso;
        public bool Guardar(BEProducto oBEProducto, BECliente oBECliente, BECompra oBECompra)
        {
            try
            {
                oAcceso = new Acceso();

                
                ArrayList parametros = new ArrayList
            {
                new SqlParameter("@Cantidad", oBECompra.LiProductos.Count),
                new SqlParameter("@PrecioUnitario", oBEProducto.Precio),
                new SqlParameter("@IdProducto", Convert.ToInt32(oBEProducto.Id)),
                new SqlParameter("@IdCompra", oBECompra.Codigo),
                new SqlParameter("@IdCliente", oBECliente.ID)
            };

                return oAcceso.Guardado("GuardarDetalleCompra", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool GuardarDetalleCompra(List<DetalleCompra> carrito, BECompra oBECompra)
        {
            try
            {
                oAcceso = new Acceso();

                foreach (var detalle in carrito)
                {
                    ArrayList parametros = new ArrayList
                    {
                        new SqlParameter("@Cantidad", detalle.Cantidad),
                        new SqlParameter("@IdProducto", detalle.Producto.Id),
                        new SqlParameter("@IdCompra", oBECompra.Codigo)
                    };

                    oAcceso.Guardado("GuardarDetalleCompra", parametros);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
