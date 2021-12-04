﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public List<SubMenu> oSubMenu { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
