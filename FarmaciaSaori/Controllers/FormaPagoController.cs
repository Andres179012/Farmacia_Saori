using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos;
using CapaModelo;

namespace FarmaciaSaori.Controllers
{
    public class FormaPagoController : Controller
    {
        // GET: FormaPago
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Obtener()
        {
            List<Forma_Pago> lista = CD_FormaPago.Instancia.ObtenerFormaPago();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Forma_Pago objeto)
        {
            bool respuesta = false;

            if (objeto.IdFormaPago == 0)
            {

                respuesta = CD_FormaPago.Instancia.RegistrarFormaPago(objeto);
            }
            else
            {
                respuesta = CD_FormaPago.Instancia.ModificarFormaPago(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_FormaPago.Instancia.EliminarFormaPago(id);
            return Json(new { resultado = respuesta });
        }

    }
}