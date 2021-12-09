using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class LaboratorioController : Controller
    {
        // GET: Cliente
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Laboratorio> oListaLaboratorio = CD_Laboratorio.Instancia.ObtenerLaboratorio();
            return Json(new { data = oListaLaboratorio }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Laboratorio objeto)
        {
            bool respuesta = false;

            if (objeto.IdLaboratorio == 0)
            {
                respuesta = CD_Laboratorio.Instancia.RegistrarLaboratorio(objeto);
            }
            else
            {
                respuesta = CD_Laboratorio.Instancia.ModificarLaboratorio(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Laboratorio.Instancia.EliminarLaboratorio(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}