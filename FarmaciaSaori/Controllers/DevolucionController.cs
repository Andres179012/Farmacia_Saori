using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class DevolucionController : Controller
    {
        private static Usuario SesionUsuario;
        // GET: Compra
        public ActionResult Crear()
        {
            SesionUsuario = (Usuario)Session["Usuario"];
            return View();
        }
        // GET: Devolucion
        // GET: FormaPago
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<DetalleCompra> lista = CD_Devolucion.Instancia.ObtenerDetalleCompra();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Devolucion objeto)
        {

               bool respuesta = CD_Devolucion.Instancia.RegistrarDevolucion(objeto);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}