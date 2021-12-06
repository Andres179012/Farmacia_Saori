using System.Web;
using System.Web.Mvc;
using FarmaciaSaori.Filters;
namespace FarmaciaSaori
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificarSession());
        }
    }
}
