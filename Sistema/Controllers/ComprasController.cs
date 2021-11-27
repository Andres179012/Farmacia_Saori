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

        public ActionResult Crear()
        {
            return View();
        }
        // GET: Producto
        public ActionResult Asignar()
        {
            return View();
        }
        public JsonResult Obtener()
        {
            List<Factura_Compra> lista = CD_FacturaCompra.Instancia.ObtenerFacturaCompra();
            return Json(new { data = lista });
        }
    }
}
