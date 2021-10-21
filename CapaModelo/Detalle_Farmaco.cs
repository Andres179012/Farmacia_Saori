using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Detalle_Farmaco
    {
        public int Id_DetalleFarmaco { get; set; }
        public int Id_Farmaco { get; set; }
        public int Id_FormaFarmaceutica { get; set; }
        public int Id_Equivalencia { get; set; }
        public int Id_Laboratorio { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_ViaAdministracion { get; set; }
        public string Nombre_Comercial { get; set; }
        public int Concentracion { get; set; }
        public int Fecha_Vencimiento { get; set; }
        public int Stock { get; set; }
        public float Precio_Venta { get; set; }
        public float Precio_Compra { get; set; }
        public int Numero_Lote { get; set; }
        public string Descripcion { get; set; }
        public string Prescripcion_Medica { get; set; }
    }
}
