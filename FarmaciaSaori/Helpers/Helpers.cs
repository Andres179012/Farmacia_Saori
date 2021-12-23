using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaSaori.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString ActionLinkAllow(this HtmlHelper helper)
        {

            StringBuilder sb = new StringBuilder();

            if (HttpContext.Current.Session["Usuario"] != null)
            {

                Usuario oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];

                Usuario rptUsuario = CD_Usuario.Instancia.ObtenerDetalleUsuario(oUsuario.IdUsuario);


                foreach (Menu item in rptUsuario.oListaMenu)
                {

                    sb.AppendLine("<li>");
                    sb.AppendLine("<a href='javascript:;' class='has-arrow'><div class='parent-icon'><i class='" + item.Icono + "'></i></div><div class='menu-title'>" + item.Nombre + "</div></a>");
                    

                    sb.AppendLine("<ul>");
                    foreach (SubMenu subitem in item.oSubMenu)
                    {
                        if (subitem.Activo == true)
                            sb.AppendLine("<li><a class='dropdown-item' name='" + item.Nombre + "' href='/" + subitem.Controlador + "/" + subitem.Vista + "'><i class='" + subitem.Icono + "'></i> " + subitem.Nombre + "</a></li>");

                    }
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</li>");


                }


            }


            return new MvcHtmlString(sb.ToString());
        }

    }
}