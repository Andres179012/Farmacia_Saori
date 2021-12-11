using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class ReporteVenta
    {
        public string FechaVenta { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreComercial { get; set; }
        public string Concentracion { get; set; }
        public string NombreEmpleado { get; set; }
        public string CantidadUnidadesVendidas { get; set; }
        public string CantidadProductos { get; set; }
        public string TotalVenta { get; set; }
    }
}
