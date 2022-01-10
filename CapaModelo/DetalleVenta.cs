using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class DetalleVenta
    {
        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public int IdDetalleFarmaco { get; set; }
        public DetalleFarmaco oDetalleFarmaco { get; set; }
        public decimal PrecioUnidad { get; set; }
        public string TextoPrecioUnidad { get; set; }
        public decimal ImporteTotal { get; set; }
        public string TextoImporteTotal { get; set; }
    }
}
