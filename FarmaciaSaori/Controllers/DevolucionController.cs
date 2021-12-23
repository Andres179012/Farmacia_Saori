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
        public ActionResult Crear()
        {
            return View();
        }
        public JsonResult Obtener()
        {
            List<DetalleCompra> lista = CD_Devolucion.Instancia.ObtenerDevolucion();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

    }
}
