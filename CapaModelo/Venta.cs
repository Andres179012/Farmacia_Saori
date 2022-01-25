﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string TipoDocumento { get; set; }
        public string Codigo { get; set; }
        public float TotalCosto { get; set; }
        public float SubTotal { get; set; }
        public int Descuento { get; set; }
        public int Iva { get; set; }
        public string TextoTotalCosto { get; set; }
        public float ImporteRecibido { get; set; }
        public string TextoImporteRecibido { get; set; }
        public float ImporteCambio { get; set; }
        public string TextoImporteCambio { get; set; }
        public string FechaRegistro { get; set; }
        public int IdFormaPago { get; set; }
        public Forma_Pago oFormaPago { get; set; }
        public DateTime VFechaRegistro { get; set; }
        public Usuario oUsuario { get; set; }
        public Cliente oCliente { get; set; }
        public List<DetalleVenta> oListaDetalleVenta { get; set; }

    }
}
