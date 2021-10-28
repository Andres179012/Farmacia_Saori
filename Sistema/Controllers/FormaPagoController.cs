using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;

namespace Sistema.Controllers
{
    public class FormaPagoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Obtener()
        {
            List<Forma_Pagos> lista = CD_FormaPago.Instancia.ObtenerFormaPago();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Forma_Pagos objeto)
        {
            bool respuesta = false;

            if (objeto.Id_FormaPago == 0)
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
