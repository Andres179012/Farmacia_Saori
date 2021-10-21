using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Clientes
    {
        public int Id_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Identificacion { get; set; }
        public bool Estado { get; set; }
    }
}
