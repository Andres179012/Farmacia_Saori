using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class ControlSesion
    {
        public int IdInicioSesion { get; set; }
        public int IdUsuario { get; set; }
        public Usuario oUsuario { get; set; }
        public DateTime FechaEntrada { get; set; }
    }
}
