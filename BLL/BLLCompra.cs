using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCompra
    {
        public BLLCompra()
        {
          oMPPCompra = new MPPCompra(); 
        }

        MPPCompra oMPPCompra;


        public bool Guardar (BECompra oBECompra, BECliente oBECliente)
        {
            return oMPPCompra.Guardar(oBECompra, oBECliente);
        }
    }
}
