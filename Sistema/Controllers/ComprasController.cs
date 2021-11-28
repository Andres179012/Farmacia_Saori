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

            bool respuesta = CD_FacturaCompra.Instancia.RegistrarCompra(xml);

            return Json(new { resultado = respuesta });
        }

        public JsonResult Obtener()
        {
            List<Factura_Compra> lista = CD_FacturaCompra.Instancia.ObtenerFacturaCompra();
            return Json(new { data = lista });
        }

        public ActionResult Documento(int idcompra = 0)
        {

            Factura_Compra oCompra = CD_FacturaCompra.Instancia.ObtenerDetalleCompra(idcompra);

            if (oCompra == null)
            {
                oCompra = new Factura_Compra();
            }


            return View(oCompra);
        }
    }
}
