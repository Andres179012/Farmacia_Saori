using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class DetalleFarmaco
    {
        public int IdDetalleFarmaco { get; set; }
        public int IdProducto { get; set; }
        public Producto oProducto { get; set; }
        public int IdFormaFarmaceutica { get; set; }
        public Forma_Farmaceutica oFormaFarmaceutica { get; set; }
        public int IdViaAdministracion { get; set; }
        public Via_Administracion oViaAdministracion { get; set; }
        public int IdLaboratorio { get; set; }
        public Laboratorio oLaboratorio { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor oProveedor { get; set; }
        public string NombreComercial { get; set; }
        public string Concentracion { get; set; }
        public string FechaVencimiento { get; set; }
        public string NumeroLote { get; set; }
        public Boolean PrescripcionMedica { get; set; }

    }
}
