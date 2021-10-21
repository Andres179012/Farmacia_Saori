using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Detalle_Devolucion
    {
        public int Id_DetalleDevolucion { get; set; }
        public int Id_Devolucion { get; set; }
        public int Id_DetalleFarmaco { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }

    }
}
