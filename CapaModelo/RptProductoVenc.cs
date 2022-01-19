using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class RptProductoVenc
    {
        public int IdProducto { get; set; }
        public string NombreGenerico { get; set; }
        public Producto oProducto { get; set; }

        public int IdDetalleFarmaco { get; set; }
        public string NombreComercial { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
