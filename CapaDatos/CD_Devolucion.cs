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
        public bool RegistrarDevolucionV(DevolucionVenta oDevoluciom)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_GuardarDevolucionV", oConexion);
                    cmd.Parameters.AddWithValue("IdVenta", oDevoluciom.IdVenta);
                    cmd.Parameters.AddWithValue("IdCliente", oDevoluciom.IdCliente);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", oDevoluciom.IdDetalleFarmaco);
                    cmd.Parameters.AddWithValue("IdUsuario", oDevoluciom.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProducto", oDevoluciom.IdProducto);
                    cmd.Parameters.AddWithValue("Concepto", oDevoluciom.Concepto);
                    cmd.Parameters.AddWithValue("Cantidad", oDevoluciom.Cantidad);
                    cmd.Parameters.AddWithValue("Activo", oDevoluciom.Activo);
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

        public bool RegistrarDevolucion(Devolucion oDevoluciom)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_GuardarDevolucion", oConexion);
                    cmd.Parameters.AddWithValue("IdCompra", oDevoluciom.IdCompra);
                    cmd.Parameters.AddWithValue("IdProveedor", oDevoluciom.IdProveedor);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", oDevoluciom.IdDetalleFarmaco);
                    cmd.Parameters.AddWithValue("IdUsuario", oDevoluciom.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProducto", oDevoluciom.IdProducto);
                    cmd.Parameters.AddWithValue("Concepto", oDevoluciom.Concepto);
                    cmd.Parameters.AddWithValue("Cantidad", oDevoluciom.Cantidad);
                    cmd.Parameters.AddWithValue("Activo", oDevoluciom.Activo);
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

        public List<DetalleCompra> ObtenerDetalleCompra()
        {
            List<DetalleCompra> rptListaDetalleCompra = new List<DetalleCompra>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerListaDetalle", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaDetalleCompra.Add(new DetalleCompra()
                        {
                            IdDetalleCompra = Convert.ToInt32(dr["IdDetalleCompra"].ToString()),
                            NumeroCompra = dr["NumeroCompra"].ToString(),
                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                            oProducto = new Producto() { 
                            NombreGenerico = dr["NombreGenerico"].ToString(), 
                            },
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                            oProveedor = new Proveedor()
                            {
                                RazonSocial = dr["RazonSocial"].ToString(),
                            },
                            IdCompra = Convert.ToInt32(dr["IdCompra"].ToString()),
                            oLaboratorio = new Laboratorio()
                            {
                                NombreLaboratorio = dr["NombreLaboratorio"].ToString(),
                            },
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                            oUsuario = new Usuario()
                            {
                                Correo = dr["Correo"].ToString(),
                            },
                            IdDetalleFarmaco = Convert.ToInt32(dr["IdDetalleFarmaco"].ToString()),
                            oDetalleFarmaco = new DetalleFarmaco() { 
                            NombreComercial = dr["NombreComercial"].ToString(), 
                            Concentracion = dr["Concentracion"].ToString()
                            },
                            Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                            TotalCosto = Convert.ToDecimal(dr["TotalCosto"].ToString()),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()).ToString("dd/MM/yyyy"),
                            VFechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                        });
                    }
                    dr.Close();

                    return rptListaDetalleCompra;

                }
                catch (Exception)
                {
                    rptListaDetalleCompra = null;
                    return rptListaDetalleCompra;
                }
            }
        }

        public List<DetalleVenta> ObtenerDetalleVenta()
        {
            List<DetalleVenta> rptListaDetalleCompra = new List<DetalleVenta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerListaD", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaDetalleCompra.Add(new DetalleVenta()
                        {
                            IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"].ToString()),
                            NumeroVenta = dr["NumeroVenta"].ToString(),
                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                            oProducto = new Producto()
                            {
                                NombreGenerico = dr["NombreGenerico"].ToString(),
                            },
                            IdCliente = Convert.ToInt32(dr["IdCliente"].ToString()),
                            oCliente = new Cliente()
                            {
                                Nombre = dr["Nombre"].ToString(),
                            },
                            IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                            oUsuario = new Usuario()
                            {
                                Correo = dr["Correo"].ToString(),
                            },
                            IdDetalleFarmaco = Convert.ToInt32(dr["IdDetalleFarmaco"].ToString()),
                            oDetalleFarmaco = new DetalleFarmaco()
                            {
                                NombreComercial = dr["NombreComercial"].ToString(),
                                Concentracion = dr["Concentracion"].ToString()
                            },
                            Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                            PrecioUnidad = Convert.ToDecimal(dr["PrecioUnidad"].ToString()),
                            ImporteTotal = Convert.ToDecimal(dr["ImporteTotal"].ToString()),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()).ToString("dd/MM/yyyy"),
                            VFechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                        });
                    }
                    dr.Close();

                    return rptListaDetalleCompra;

                }
                catch (Exception)
                {
                    rptListaDetalleCompra = null;
                    return rptListaDetalleCompra;
                }
            }
        }

    }
}
