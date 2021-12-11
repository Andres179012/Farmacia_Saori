using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class ReporteCompra
    {
        public string FechaRegistro { get; set; }
        public Usuario oUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string TotalCosto { get; set; }
        public string Nombres { get; set; }
        public string NombreComercial { get; set; }
        public string Concentracion { get; set; }
    }
}
