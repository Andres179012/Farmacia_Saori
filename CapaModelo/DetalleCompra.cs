using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public Compra oCompra { get; set; }
        public string NumeroCompra { get; set; }
        public Forma_Farmaceutica oFormaFarmaceutica { get; set; }
        public int IdProducto { get; set; }
        public Producto oProducto { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor oProveedor { get; set; }
        public int IdUsuario { get; set; }
        public Usuario oUsuario { get; set; }
        public int IdLaboratorio { get; set; }
        public Laboratorio oLaboratorio { get; set; }
        public int IdDetalleFarmaco { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public string TextoPrecioUnitarioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string TextoPrecioUnitarioVenta { get; set; }
        public decimal TotalCosto { get; set; }
        public string TextoTotalCosto { get; set; }
        public bool Activo { get; set; }
        public string FechaRegistro { get; set; }
        public DateTime VFechaRegistro { get; set; }
    }
}
