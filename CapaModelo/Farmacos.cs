using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelo
{
    public class Farmacos
    {
        public int Id_Farmaco { get; set; }
        public string Nombre_Generico { get; set; }
        public int Id_Categoria { get; set; }
        public bool Estado { get; set; }
        public Categorias Objcategoria { get; set; }
    }
}
