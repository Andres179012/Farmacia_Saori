using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Laboratorios
    {
        public int Id_Laboratorio { get; set; }
        public string Nombre_Laboratorio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Politica_Vencimiento { get; set; }
        public int Cantidad_Meses { get; set; }
        public bool Estado { get; set; }
    }
}
