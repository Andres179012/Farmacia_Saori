using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class VentaController : Controller
    {
        private static Usuario SesionUsuario;
        // GET: Venta
        public ActionResult Crear()
        {
            SesionUsuario = (Usuario)Session["Usuario"];
            return View();
        }

        // GET: Venta
        public ActionResult Consultar()
        {
            return View();
        }
        public ActionResult Documento(int IdVenta = 0)
        {

            Venta oVenta = CD_Venta.Instancia.ObtenerDetalleVenta(IdVenta);

            if (oVenta == null)
            {
                oVenta = new Venta();
            }


            return View(oVenta);
        }


        public JsonResult Obtener(string codigo, string fechainicio, string fechafin)
        {
            List<Venta> lista = CD_Venta.Instancia.ObtenerListaVenta(codigo, Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));


            if (lista == null)
                lista = new List<Venta>();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerUsuario()
        {
            Usuario rptUsuario = CD_Usuario.Instancia.ObtenerDetalleUsuario(SesionUsuario.IdUsuario);
            return Json(rptUsuario, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerProductoPorTienda(int IdDetalleFarmaco)
        {

            List<ProductoDetalle> oListaProductoTienda = CD_ProductoTienda.Instancia.ObtenerProductoTienda();
            oListaProductoTienda = oListaProductoTienda.Where(x => x.oDetalleFarmaco.IdDetalleFarmaco == IdDetalleFarmaco && x.Stock > 0).ToList();


            return Json(new { data = oListaProductoTienda }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ControlarStock(int idproducto, int idtienda, int cantidad, bool restar)
        {
            bool respuesta = CD_ProductoTienda.Instancia.ControlarStock(idproducto, idtienda, cantidad, restar);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(string xml)
        {
            xml = xml.Replace("!idusuario¡", SesionUsuario.IdUsuario.ToString());
            int Respuesta = 0;
            Respuesta = CD_Venta.Instancia.RegistrarVenta(xml);
            if (Respuesta != 0)
                return Json(new { estado = true, valor = Respuesta.ToString() }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { estado = false, valor = "" }, JsonRequestBehavior.AllowGet);
        }

    }
}