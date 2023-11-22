using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPagoTarjeta : BEPago
    {
        public string TipoTarjeta { get; set; }
        public int NroTarjeta { get; set; }

    }
}
