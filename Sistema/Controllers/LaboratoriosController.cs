using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;

namespace Sistema.Controllers
{
    public class LaboratoriosController : Controller
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
            List<Laboratorios> lista = CD_Laboratorios.Instancia.ObtenerLaboratorio();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Laboratorios objeto)
        {
            bool respuesta = false;

            if (objeto.Id_Laboratorio == 0)
            {

                respuesta = CD_Laboratorios.Instancia.RegistrarLaboratorio(objeto);
            }
            else
            {
                respuesta = CD_Laboratorios.Instancia.ModificarLaboratorio(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Laboratorios.Instancia.EliminarLaboratorio(id);
            return Json(new { resultado = respuesta });
        }


    }
}
