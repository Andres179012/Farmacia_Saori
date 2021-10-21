using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Equivalencias
    {
        public int Id_Equivalencia { get; set; }
        public int Id_UnidadMedidaBase { get; set; }
        public int Id_UnidadFinal { get; set; }
        public int Equivalencia { get; set; }
        public bool Estado { get; set; }
    }
}
