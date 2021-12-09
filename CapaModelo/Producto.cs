using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public int ValorCodigo { get; set; }
        public string NombreGenerico { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public Categorias oCategoria { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
