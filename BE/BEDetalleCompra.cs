﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DetalleCompra
    {
        public BEProducto Producto { get; set; }
        public string producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
