using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Factura_Compra
    {
        public int Id_FacturaCompra { get; set; }
        public int Id_Laboratorio { get; set; }
        public Laboratorios Objlaboratorio { get; set; }
        public int Id_Proveedor { get; set; }
        public Proveedores Objproveedores { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }
    }

}
