using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Detalle_Compra
    {
        public int Id_DetalleCompra { get; set; }
        public int Id_FacturaCompra { get; set; }
        public int Id_Farmaco { get; set; }
        public int Id_FormaFarmaceutica { get; set; }
        public int Id_FormaPago { get; set; }
        public int Cantidad_Compra { get; set; }
        public int Precio_Compra { get; set; }
        public int Lote { get; set; }
        public int Unitario { get; set; }
        public bool Estado { get; set; }
    }
}
