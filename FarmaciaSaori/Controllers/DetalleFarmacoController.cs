using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class DetalleFarmacoController : Controller
    {
        // GET: Cliente
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<DetalleFarmaco> oListaDetalleFarmaco = CD_DetalleFarmaco.Instancia.ObtenerDetalleFarmaco();
            return Json(new { data = oListaDetalleFarmaco }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(DetalleFarmaco objeto)
        {
            bool respuesta = false;

            if (objeto.IdDetalleFarmaco == 0)
            {
                respuesta = CD_DetalleFarmaco.Instancia.RegistrarDetalleFarmaco(objeto);
            }
            else
            {
                respuesta = CD_DetalleFarmaco.Instancia.ModificarDetalleFarmaco(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_DetalleFarmaco.Instancia.EliminarDetalleFarmaco(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}