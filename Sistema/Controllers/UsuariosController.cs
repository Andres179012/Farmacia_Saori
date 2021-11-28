using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;

namespace Sistema.Controllers
{
    public class UsuariosController : Controller
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
            List<Usuarios> lista = CD_Usuarios.Instancia.ObtenerUsuarios();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Usuarios objeto)
        {
            bool respuesta = false;

            if (objeto.Id_Usuario == 0)
            {

                respuesta = CD_Usuarios.Instancia.RegistrarUsuario(objeto);
            }
            else
            {
                respuesta = CD_Usuarios.Instancia.ModificarUsuario(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Usuarios.Instancia.EliminarUsuario(id);
            return Json(new { resultado = respuesta });
        }
    }
}
