using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class FormaFarmaceuticaController : Controller
    {
        // GET: Cliente
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Forma_Farmaceutica> oListaFormaFarmaceutica = CD_FormaFarmaceutica.Instancia.ObtenerFormaFarmaceutica();
            return Json(new { data = oListaFormaFarmaceutica }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Forma_Farmaceutica objeto)
        {
            bool respuesta = false;

            if (objeto.IdFormaFarmaceutica == 0)
            {
                respuesta = CD_FormaFarmaceutica.Instancia.RegistrarFormaFarmaceutica(objeto);
            }
            else
            {
                respuesta = CD_FormaFarmaceutica.Instancia.ModificarFormaFarmaceutica(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_FormaFarmaceutica.Instancia.EliminarFormaFarmaceutica(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}