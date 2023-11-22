using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPagoEft:BLLPago
    {
        public override decimal CalcularMontoFinal(BEPago oBEPago)
        {
            
            decimal descuento = oBEPago.Monto * 0.10m;

            return descuento;
        }
    }
}
