using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Factura_Compra
    {
        public int Id_FacturaCompra { get; set; }
        public int Id_Laboratorio { get; set; }
        public int Id_Proveedor { get; set; }
        public int Fecha_Compra { get; set; }
        public float Sub_Total { get; set; }
        public float Descuento { get; set; }
        public float IVA { get; set; }
        public float Total { get; set; }
        public bool Estado { get; set; }
    }
}
