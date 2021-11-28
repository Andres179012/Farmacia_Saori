using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Factura_Venta
    {
        public int Id_FacturaVenta { get; set; }
        public int Id_Usuario { get; set; }
        public Usuarios Objusuario { get; set; }
        public int Id_Cliente { get; set; }
        public Clientes Objcliente { get; set; }
        public string Fecha_Venta { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }

        public List<Detalle_Venta> oListaDetalleVenta { get; set; }
    }
}
