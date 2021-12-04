using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Utilidades;


namespace Sistema.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Usuario> oListaUsuario = CD_Usuario.Instancia.ObtenerUsuarios();
            //return Json(new { data = oListaUsuario }, JsonRequestBehavior.AllowGet);
            return Json(oListaUsuario, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult Guardar(Usuario objeto)
        {
            bool respuesta = false;

            if (objeto.IdUsuario == 0)
            {
                objeto.Clave = Encriptar.GetSHA256(objeto.Clave);

                respuesta = CD_Usuario.Instancia.RegistrarUsuario(objeto);
            }
            else
            {
                respuesta = CD_Usuario.Instancia.ModificarUsuario(objeto);
            }


            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Usuario.Instancia.EliminarUsuario(id);

            return Json(new { resultado = respuesta });
        }
    }
}
