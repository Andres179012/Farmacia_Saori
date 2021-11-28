using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelo;

namespace Sistema.Controllers
{
    public class ClientesController : Controller
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
            List<Clientes> lista = CD_Clientes.Instancia.ObtenerClientes();
            return Json(new { data = lista });
        }

        public JsonResult Guardar(Clientes objeto)
        {
            bool respuesta = false;

            if (objeto.Id_Cliente == 0)
            {

                respuesta = CD_Clientes.Instancia.RegistrarCliente(objeto);
            }
            else
            {
                respuesta = CD_Clientes.Instancia.ModificarCliente(objeto);
            }
            return Json(new { resultado = respuesta });
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Clientes.Instancia.EliminarCliente(id);
            return Json(new { resultado = respuesta });
        }
    }
}
