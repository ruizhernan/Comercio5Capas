﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFactura
    {
        public int ID { get; set; }
        public DateTime FechaEmision { get; set; }  
       
        public BECompra BECompra { get; set; }

    }
}
