using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class SubMenu
    {
        public int IdSubMenu { get; set; }
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public string Controlador { get; set; }
        public string Vista { get; set; }
        public string Icono { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
