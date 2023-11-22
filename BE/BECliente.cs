using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente
    {
        #region Propiedades
        public int ID {  get; set; }
        public string Nombre { get; set; } 
        public string Direccion { get; set; }
        #endregion
    }
}
