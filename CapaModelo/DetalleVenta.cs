using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public Venta oVenta { get; set; }
        public string NumeroVenta { get; set; }
        public int IdProducto { get; set; }
        public Producto oProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdCliente { get; set; }
        public Cliente oCliente { get; set; }
        public int IdUsuario { get; set; }
        public Usuario oUsuario { get; set; }
        public int Cantidad { get; set; }
        public int IdDetalleFarmaco { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public decimal PrecioUnidad { get; set; }
        public string TextoPrecioUnidad { get; set; }
        public decimal ImporteTotal { get; set; }
        public string TextoImporteTotal { get; set; }
        public string FechaRegistro { get; set; }
        public DateTime VFechaRegistro { get; set; }
    }
}
