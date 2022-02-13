using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class LaboratorioProveedor
    {
        public int IdLaboratorioProveedor { get; set; }
        public int IdLaboratorio { get; set; }
        public Laboratorio oLaboratorio { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor oProveedor { get; set; }
        public string Ruc  { get; set; }
        public string Telefono  { get; set; }
        public string Direccion  { get; set; }
    }
}
