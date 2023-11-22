using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public abstract class BLLPago
    {
        public virtual decimal CalcularMontoFinal (BEPago BEPago)
        {
            return BEPago.Monto;
        }
    }
}
