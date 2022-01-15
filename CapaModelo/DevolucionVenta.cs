using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class DevolucionVenta
    {
        public int IdDevolucionVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public Cliente oCliente { get; set; }
        public int IdDetalleFarmaco { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public int IdUsuario { get; set; }
        public Usuario oUsuario { get; set; }
        public int IdProducto { get; set; }
        public Producto oProducto { get; set; }
        public string Concepto { get; set; }
        public int Cantidad { get; set; }
        public Boolean Activo { get; set; }
        public string FechaDevolucion { get; set; }
        public DateTime VFechaDevolucion { get; set; }
    }
}
