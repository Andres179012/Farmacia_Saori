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

        public JsonResult Guardar(Proveedores objeto)
        {
            bool respuesta = false;

            if (objeto.Id_Proveedor == 0)
            {

                respuesta = CD_Proveedores.Instancia.RegistrarProveedores(objeto);
            }
            else
            {
                respuesta = CD_Proveedores.Instancia.ModificarProveedor(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Proveedores.Instancia.EliminarProveedor(id);
            return Json(new { resultado = respuesta });
        }
    }
}
