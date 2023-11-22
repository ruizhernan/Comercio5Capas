using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPago
    {
        public int ID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public BECompra BECompra { get; set; }  
    }
}
