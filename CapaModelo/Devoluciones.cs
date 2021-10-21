using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Devoluciones
    {
        public int Id_Devolucion { get; set; }
        public int Id_Proveedor { get; set; }
        public string Concepto { get; set; }
        public int Fecha_Devolucion { get; set; }
        public bool Estado { get; set; }

    }
}
