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
    public class CompraController : Controller
    {
        private static Usuario SesionUsuario;
        // GET: Compra
        public ActionResult Crear()
        {
            SesionUsuario = (Usuario)Session["Usuario"];
            return View();
        }
        // GET: Compra
        public ActionResult Consultar()
        {
            return View();
        }

        public ActionResult Documento(int idcompra = 0)
        {

            Compra oCompra = CD_Compra.Instancia.ObtenerDetalleCompra(idcompra);

            if (oCompra == null)
            {
                oCompra = new Compra();
            }


            return View(oCompra);
        }

        public JsonResult ObtenerProductoPorTienda(int IdDetalleFarmaco)
        {

            List<ProductoDetalle> oListaProductoTienda = CD_ProductoTienda.Instancia.ObtenerProductoTienda();
            oListaProductoTienda = oListaProductoTienda.Where(x => x.oDetalleFarmaco.IdDetalleFarmaco == IdDetalleFarmaco && x.Stock > 0).ToList();


            return Json(new { data = oListaProductoTienda }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Obtener(string fechainicio, string fechafin)
        {
            List<Compra> lista = CD_Compra.Instancia.ObtenerListaCompra(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));

            if (lista == null)
                lista = new List<Compra>();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerUsuario()
        {
            Usuario rptUsuario = CD_Usuario.Instancia.ObtenerDetalleUsuario(SesionUsuario.IdUsuario);
            return Json(rptUsuario, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(string xml)
        {
            xml = xml.Replace("!idusuario¡", SesionUsuario.IdUsuario.ToString());

            bool respuesta  = CD_Compra.Instancia.RegistrarCompra(xml);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerLaboratorioProveedor()
        {
            List<LaboratorioProveedor> lista = CD_Compra.Instancia.ObtenerLaboratorioProveedor();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

    }
}