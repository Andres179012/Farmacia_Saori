using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Devolucion
    {
        public int IdDevolucion { get; set; }
        public string Codigo { get; set; }
        public string NumeroDevolucion { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor oProveedor { get; set; }
        public string Concepto { get; set; }
        public bool Activo { get; set; }
        public string FechaDevolucion { get; set; }
        public DateTime VFechaDevolucion { get; set; }
    }
}
