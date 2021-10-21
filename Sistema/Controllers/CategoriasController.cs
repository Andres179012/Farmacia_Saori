using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;

namespace Sistema.Controllers
{
    public class CategoriasController : Controller
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
            List<Categorias> lista = CD_Categoria.Instancia.ObtenerCategoria();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Categorias objeto)
        {
            bool respuesta = false;

            if (objeto.Id_Categoria == 0)
            {

                respuesta = CD_Categoria.Instancia.RegistrarCategoria(objeto);
            }
            else
            {
                respuesta = CD_Categoria.Instancia.ModificarCategoria(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Categoria.Instancia.EliminarCategoria(id);
            return Json(new { resultado = respuesta });
        }
    }
}
