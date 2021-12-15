﻿using CapaModelo;
using System;
using System.Collections.Generic;
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

    }
}