using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProducto
    {
        public BLLProducto()
        {
            oMPPProducto = new MPPProducto();
        }
        MPPProducto oMPPProducto;
        public List<BEProducto> CargarListaProductos()
        {
            return oMPPProducto.CargarListaProductos();
        }

        public bool Guardar (BEProducto oBEProducto)
        {
            return oMPPProducto.Guardar(oBEProducto);
        }
        public bool Eliminar (BEProducto oBEProducto)
        {
            return oMPPProducto.Eliminar(oBEProducto);
        }

    }
}
