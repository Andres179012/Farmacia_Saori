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
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor oProveedor { get; set; }
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
