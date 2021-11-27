using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Farmacos
    {
        public int Id_Farmaco { get; set; }
        public string Nombre_Generico { get; set; }
        public string Nombre_Comercial { get; set; }
        
        public string Concentracion { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public int Stock { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Numero_Lote { get; set; }
        public bool Prescripcion_Medica { get; set; }
        public string Descripcion { get; set; }
        public bool Stado { get; set; }
        public int Id_Proveedor { get; set; }
        public Proveedores Objproveedor { get; set; }
        public int Id_Laboratorio { get; set; }
        public Laboratorios Objlaboratorio { get; set; }
        public int Id_Categoria { get; set; }
        public Categorias Objcategoria { get; set; }
        public int Id_FormaFarmaceutica { get; set; }
        public Forma_Farmaceuticas Objformafarmaceutica { get; set; }
        public int Id_ViaAdministracion { get; set; }
        public ViaAdministracion Objviadministacion { get; set; }
    }

}
