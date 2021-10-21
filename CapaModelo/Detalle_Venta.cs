using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Detalle_Venta
    {
        public int Id_DetalleVenta { get; set; }
        public int Id_FacturaVenta { get; set; }
        public int Id_Farmaco { get; set; }
        public int Id_FormaPago { get; set; }
        public float Cantidad_Venta { get; set; }
        public float Precio_Venta { get; set; }
        public bool Estado { get; set; }
    }
}
