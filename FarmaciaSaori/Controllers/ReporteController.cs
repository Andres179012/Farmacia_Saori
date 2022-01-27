using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Producto()
        {
            return View();
        }

        // GET: Reporte
        public ActionResult Ventas()
        {
            return View();
        }

        public ActionResult Compras()
        {
            return View();  
        }
        public ActionResult DevolucionC()
        {
            return View();
        }
        public ActionResult DevolucionRV()
        {
            return View();
        }
        public ActionResult ProductosVencer()
        {
            return View();
        }
        public JsonResult ObtenerProducto(string fechainicio, string fechafin)
        {

            List<ReporteProducto> lista = CD_Reportes.Instancia.ReporteProductoTienda(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerVenta(string fechainicio, string fechafin)
        {
            
            List<ReporteVenta> lista = CD_Reportes.Instancia.ReporteVenta(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerCompra(string fechainicio, string fechafin)
        {

            List<ReporteCompra> lista = CD_Reportes.Instancia.ReporteCompra(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerDevolucion(string fechainicio, string fechafin)
        {

            List<ReporteDevolucionCompra> lista = CD_Reportes.Instancia.ReporteDevolucionCompra(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerDevolucionRV(string fechainicio, string fechafin)
        {

            List<ReporteDevolucionVenta> lista = CD_Reportes.Instancia.ReporteDevolucionVenta(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerProductosVencer()
        {

            List<RptProductoVenc> lista = CD_Reportes.Instancia.ReporteProductoVencer();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerClientesHome()
        {
            List<rptClientesHome> lista = CD_Reportes.Instancia.ObClientesHome();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTopProducts()
        {
            List<TopProducts> lista = CD_Reportes.Instancia.ObTopProducts();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerLaboratoriosHome()
        {
            List<Laboratorio> lista = CD_Laboratorio.Instancia.ObtenerLaboratorio();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}