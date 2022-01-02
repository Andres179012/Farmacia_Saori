using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class DetalleDevolucion
    {
        public int IdDetalleDevolucion { get; set; }
        public int IdDevolucion { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public List<DetalleCompra> oListaDetalleCompra { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; }
    }
}
