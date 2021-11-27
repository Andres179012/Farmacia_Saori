using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Detalle_Compra
    {
        public int Id_DetalleCompra { get; set; }
        public int Cantidad_Compra { get; set; }
        public decimal Precio_Compra { get; set; }
        public int Lote { get; set; }
        public float Unitario { get; set; }
        public int Id_Farmaco { get; set; }
        public Farmacos objFarmacos { get; set; }
    }
}
