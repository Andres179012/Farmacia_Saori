using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ObtenerTotales
    {
        public static CD_ObtenerTotales _instancia = null;

        private CD_ObtenerTotales()
        {

        }

        public static CD_ObtenerTotales Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ObtenerTotales();
                }
                return _instancia;
            }
        }

        public double VentasPorDia()
        {
            double total = 0.00;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_TotalVentasPorDia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        total = Convert.ToDouble(dr["TotalVentasPorDia"].ToString());
                    }
                    dr.Close();

                    return total;

                }
                catch (Exception)
                {
                    total = 0;
                    return total;
                }
            }
        }



        public double VentasPorMes()
        {
            double total = 0.00;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_TotalVentasPorMes", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        total = Convert.ToDouble(dr["TotalVentasPorMes"].ToString());
                    }
                    dr.Close();

                    return total;

                }
                catch (Exception)
                {
                    total = 0;
                    return total;
                }
            }
        }
    }
}
