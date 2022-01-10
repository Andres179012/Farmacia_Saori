﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string Codigo { get; set; }
        public string NumeroCompra { get; set; }
        public int IdUsuario { get; set; }
        public Usuario oUsuario { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor oProveedor { get; set; }
        public List<DetalleCompra> oListaDetalleCompra { get; set; }
        public decimal TotalCosto { get; set; }
        public string TipoComprobante { get; set; }
        public bool Activo { get; set; }
        public string FechaRegistro { get; set; }
        public DateTime VFechaRegistro { get; set; }
    }
}
