using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_Devolucion
    {
        public static CD_Devolucion _instancia = null;

        private CD_Devolucion()
        {

        }

        public static CD_Devolucion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Devolucion();
                }
                return _instancia;
            }
        }
    

        public List<DetalleCompra> ObtenerDevolucion()
        {
            List<DetalleCompra> rptListaDevolucion = new List<DetalleCompra>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerDevolucionCompra", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaDevolucion.Add(new DetalleCompra()
                        {
                            IdDetalleCompra = Convert.ToInt32(dr["IdDetalleCompra"].ToString()),
                            Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                            TotalCosto = Convert.ToDecimal(dr["TotalCosto"].ToString()),
                            FechaRegistro = Convert.ToDateTime( dr["FechaRegistro"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaDevolucion;

                }
                catch (Exception)
                {
                    rptListaDevolucion = null;
                    return rptListaDevolucion;
                }
            }
        }
    }
}

