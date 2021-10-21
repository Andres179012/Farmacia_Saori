using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Factura_Venta
    {
        public int Id_FacturaVenta { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Cliente { get; set; }
        public int Fecha_Venta { get; set; }
        public float Sub_Total { get; set; }
        public float Descuento { get; set; }
        public float IVA { get; set; }
        public float Total { get; set; }
        public bool Estado { get; set; }
    }
}
