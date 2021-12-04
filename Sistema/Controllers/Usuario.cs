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
    }
}
