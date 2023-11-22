using BE;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPagoTarjeta:BLLPago
    {
        public override decimal CalcularMontoFinal(BEPago oBEPago)
        {
            decimal adicional = oBEPago.Monto * 0.10m;
            
            return adicional;
        }
    }
}
