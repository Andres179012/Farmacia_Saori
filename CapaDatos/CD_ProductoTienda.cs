using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ProductoTienda
    {
        public static CD_ProductoTienda _instancia = null;

        private CD_ProductoTienda()
        {

        }

        public static CD_ProductoTienda Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ProductoTienda();
                }
                return _instancia;
            }
        }

        public List<ProductoDetalle> ObtenerProductoTienda()
        {
            List<ProductoDetalle> rptListaProductoTienda = new List<ProductoDetalle>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerProductoTienda", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProductoTienda.Add(new ProductoDetalle()
                        {
                            IdProductoDetalle = Convert.ToInt32(dr["IdProductoDetalle"].ToString()),
                            oProducto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                                Codigo = dr["CodigoProducto"].ToString(),
                                NombreGenerico = dr["NombreGenerico"].ToString(),
                                Descripcion = dr["DescripcionProducto"].ToString(),
                            },
                            oDetalleFarmaco = new DetalleFarmaco()
                            {
                                IdDetalleFarmaco = Convert.ToInt32(dr["IdDetalleFarmaco"].ToString()),
                                NombreComercial = dr["NombreComercial"].ToString(),
                                Concentracion = dr["Concentracion"].ToString(),

                            },
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString(), new CultureInfo("es-PE")),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString(), new CultureInfo("es-PE")),
                            Stock = Convert.ToInt32(dr["Stock"].ToString()),
                            Iniciado = Convert.ToBoolean(dr["Iniciado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaProductoTienda;

                }
                catch (Exception )
                {
                    rptListaProductoTienda = null;
                    return rptListaProductoTienda;
                }
            }
        }

        public bool RegistrarProductoTienda(ProductoDetalle oProductoTienda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarProductoTienda", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProductoTienda.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", oProductoTienda.oDetalleFarmaco.IdDetalleFarmaco);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception )
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool ModificarProductoTienda(ProductoDetalle oProductoTienda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarProductoTienda", oConexion);
                    cmd.Parameters.AddWithValue("IdProductoDetalle", oProductoTienda.IdProductoDetalle);
                    cmd.Parameters.AddWithValue("IdProducto", oProductoTienda.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", oProductoTienda.oDetalleFarmaco.IdDetalleFarmaco);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception )
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool EliminarProductoTienda(int IdProductoTienda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarProductoTienda", oConexion);
                    cmd.Parameters.AddWithValue("IdProductoDetalle", IdProductoTienda);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool ControlarStock(int IdProducto, int IdDetalleFarmaco, int Cantidad, bool Restar)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ControlarStock", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", IdDetalleFarmaco);
                    cmd.Parameters.AddWithValue("Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("Restar", Restar);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}
