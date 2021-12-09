using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class ViaAdministracionController : Controller
    {
       
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Via_Administracion> oListaCliente = CD_ViaAdministracion.Instancia.ObtenerViaAdministracion();
            return Json(new { data = oListaCliente }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Via_Administracion objeto)
        {
            bool respuesta = false;

            if (objeto.IdViaAdministracion == 0)
            {
                respuesta = CD_ViaAdministracion.Instancia.RegistrarViaAdministracion(objeto);
            }
            else
            {
                respuesta = CD_ViaAdministracion.Instancia.ModificarViaAdministracion(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_ViaAdministracion.Instancia.EliminarViaAdministracion(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}