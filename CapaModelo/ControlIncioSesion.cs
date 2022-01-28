using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
   public class ControlIncioSesion
    {
        public int IdInicioSesion { get; set; } 

        public string Correo { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string FechaEntrada { get; set; }
    }
}
