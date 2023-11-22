using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MPP;
using BE;

namespace BLL
{
    public class BLLCliente
    {
        public BLLCliente() {

            oMPPCliente = new MPPCliente();
        }
        MPPCliente oMPPCliente;
        public List<BECliente> CargarListaClientes()
        {
            return oMPPCliente.CargarListaClientes();
        } 

        public bool Guardar(BECliente oBECliente)
        {
            return oMPPCliente.Guardar(oBECliente);
        }
        public bool Eliminar (BECliente oBECliente)
        {
            return oMPPCliente.Eliminar(oBECliente);
        }
    }
}
