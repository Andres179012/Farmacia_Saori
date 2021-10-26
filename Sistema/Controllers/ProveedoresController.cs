using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;


namespace Sistema.Controllers
{
    public class ProveedoresController : Controller
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
            List<Proveedores> lista = CD_Proveedores.Instancia.ObtenerProveedores();
            return Json(new { data = lista });
        }
    }
}
