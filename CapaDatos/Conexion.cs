using System.Configuration;


namespace CapaDatos
{
    public class Conexion
    {
        public static string CN = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //string conString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");
    }
}
