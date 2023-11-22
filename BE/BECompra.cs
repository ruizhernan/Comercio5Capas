using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECompra
    {
        #region Propiedades
        public int Codigo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set;}
        public BECliente BECliente { get; set; }   
        public List<BEProducto> LiProductos { get; set; }
        public BEPago BEPago { get; set; }
        
        #endregion
    }
}
