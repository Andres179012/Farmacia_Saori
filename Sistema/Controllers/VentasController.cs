using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaModelo;
using CapaDatos;

namespace Sistema.Controllers
{
    public class VentasController : Controller
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

        public ActionResult Consultar()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Guardar(string xml)
        {

            bool respuesta = CD_FacturaVenta.Instancia.RegistraVenta(xml);

            return Json(new { resultado = respuesta });
        }
        public JsonResult Obtener()
        {
            List<Factura_Venta> lista = CD_FacturaVenta.Instancia.ObtenerFacturaVenta();
            return Json(new { data = lista });
        }
        public ActionResult Documento(int idventa = 0)
        {

            Factura_Venta oVenta = CD_FacturaVenta.Instancia.ObtenerDetalleVenta(idventa);

            if (oVenta == null)
            {
                oVenta = new Factura_Venta();
            }
            return View(oVenta);
        }
    }
}
