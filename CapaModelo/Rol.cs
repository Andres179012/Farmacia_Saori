using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
