using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Proveedores
    {
        public int Id_Proveedor { get; set; }
        public string Proveedor { get; set; }
        public string Visitador { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
