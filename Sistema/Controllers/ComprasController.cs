using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaModelo;
using CapaDatos;

namespace Sistema.Controllers
{
    public class ComprasController : Controller
    {

        public IActionResult Crear()
        {
            return View();
        }
        // GET: Producto
        public IActionResult Asignar()
        {
            return View();
        }



        public JsonResult Obtener2()
        {
            List<Factura_Compra> lista2 = CD_FacturaCompra.Instancia.ObtenerFacturaCompra();
            return Json(new { data = lista2 });
        }
        public JsonResult Obtener()
        {
            List<Detalle_Compra> lista = CD_FacturaCompra.Instancia.ObtenerDetalleCompra();
            return Json(new { data = lista });
        }
    }
}
