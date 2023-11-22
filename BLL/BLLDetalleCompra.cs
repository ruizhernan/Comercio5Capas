using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
namespace BLL
{
    public class BLLDetalleCompra
    {
       public BLLDetalleCompra() {
            oMPPDetalleCompra = new MPPDetalleCompra();
        }

        MPPDetalleCompra oMPPDetalleCompra;


        public bool Guardar (BEProducto oBEProducto, BECliente oBECliente, BECompra oBECompra)
        {
            return oMPPDetalleCompra.Guardar(oBEProducto, oBECliente, oBECompra);
        }
        public bool GuardarDetalleCompra (List<DetalleCompra> carrito, BECompra oBECompra)
      {
           return oMPPDetalleCompra.GuardarDetalleCompra(carrito, oBECompra);
       }
    }
   
}
