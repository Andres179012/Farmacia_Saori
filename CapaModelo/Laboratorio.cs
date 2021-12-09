using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Laboratorio
    {
        public int IdLaboratorio { get; set; }
        public string NombreLaboratorio { get; set; }
        public string RUC { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string PoliticaVencimiento { get; set; }
        public int CantidadMeses { get; set; }
        public Boolean Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
