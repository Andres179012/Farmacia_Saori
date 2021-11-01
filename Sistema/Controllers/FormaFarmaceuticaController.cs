using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;


namespace Sistema.Controllers
{
    public class FormaFarmaceuticaController : Controller
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
            List<Forma_Farmaceuticas> lista = CD_FormaFarmaceutica.Instancia.ObtenerFormaFarmaceutica();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Forma_Farmaceuticas objeto)
        {
            bool respuesta = false;

            if (objeto.Id_FormaFarmaceutica == 0)
            {

                respuesta = CD_FormaFarmaceutica.Instancia.RegistrarFormaFarmaceutica(objeto);
            }
            else
            {
                respuesta = CD_FormaFarmaceutica.Instancia.ModificarFormaFarmaceutica(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_FormaFarmaceutica.Instancia.EliminarFormaFarmaceutica(id);
            return Json(new { resultado = respuesta });
        }
    }
}
