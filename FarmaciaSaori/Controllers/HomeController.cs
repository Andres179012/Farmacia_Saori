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
    public class HomeController : Controller
    {
        private static Usuario SesionUsuario;
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
                SesionUsuario = (Usuario)Session["Usuario"];
            else {
                SesionUsuario = new Usuario();
            }
            try
            {
                ViewBag.NombreUsuario = SesionUsuario.Nombres + " " + SesionUsuario.Apellidos;
                ViewBag.RolUsuario = SesionUsuario.oRol.Descripcion;

            }
            catch {

            }

           
            return View();
        }

        public ActionResult PieChart()
        {
            return View();
        }


        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }

        public JsonResult ObtenerTotal()
        {
            int total = CapaDatos.CD_Producto.Instancia.ObtenerTotalProducto();
            return Json(new { data = total }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTotalC()
        {
            int totalcategorias = CapaDatos.CD_Categoria.Instancia.ObtenerTotalCategoria();
            return Json(new { data = totalcategorias }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTotalCompras()
        {
            double totalcompras = CapaDatos.CD_Compra.Instancia.ObtenerTotalCompras();
            return Json(new { data = totalcompras }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTotalVentas()
        {
            double totalventas = CapaDatos.CD_Compra.Instancia.ObtenerTotalVentas();
            return Json(new { data = totalventas }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerVentaPorDia()
        {
            double totalventasdia = CapaDatos.CD_ObtenerTotales.Instancia.VentasPorDia();
            return Json(new { data = totalventasdia }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerVentaPorMes()
        {
            double totalventasmes = CapaDatos.CD_ObtenerTotales.Instancia.VentasPorMes();
            return Json(new { data = totalventasmes }, JsonRequestBehavior.AllowGet);
        }

        protected string Dashborad1()
        {
            DataTable Datos = new DataTable();
            Datos.Columns.Add(new DataColumn("task", typeof(string)));
            Datos.Columns.Add(new DataColumn("Hours", typeof(string)));

            Datos.Rows.Add(new Object[] { "work", 11 });
            Datos.Rows.Add(new Object[] { "Eat", 2 });
            Datos.Rows.Add(new Object[] { "Commute", 2 });
            Datos.Rows.Add(new Object[] { "work", 2 });
            Datos.Rows.Add(new Object[] { "Sleep", 7 });

            string srtDatos;
            srtDatos = "[['task','Hours'],";

            foreach (DataRow dr in Datos.Rows)
            {
                srtDatos = srtDatos + "[";
                srtDatos = srtDatos + "'" + dr[0] + "'" + "," + dr[1];
                srtDatos = srtDatos + "],";
            }

            srtDatos = srtDatos + "]";

            return srtDatos;
        }
    }
}