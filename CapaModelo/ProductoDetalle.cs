using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class ProductoDetalle
    {
        public int IdProductoDetalle { get; set; }
        public Producto oProducto { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Iniciado { get; set; }
    }
}
