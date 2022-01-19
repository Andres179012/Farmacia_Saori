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
    public class CD_Reportes
    {
        public static CD_Reportes _instancia = null;

        private CD_Reportes()
        {

        }

        public static CD_Reportes Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Reportes();
                }
                return _instancia;
            }
        }

        public List<ReporteProducto> ReporteProductoTienda(DateTime FechaInicio, DateTime FechaFin)
        {
            List<ReporteProducto> lista = new List<ReporteProducto>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptProductoTienda", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteProducto()
                            {
                                FechaRegistro = dr["Fecha Registro"].ToString(),
                                NombreComercial = dr["Nombre Comercial"].ToString(),
                                Concentracion = dr["Concentracion"].ToString(),
                                NombreGenerico = dr["Nombre Producto"].ToString(),
                                Codigo = dr["Codigo"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Stock = dr["Stock"].ToString(),
                                PrecioCompra = dr["Precio Compra"].ToString(),
                                PrecioVenta = dr["Precio Venta"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception)
                {
                    lista = new List<ReporteProducto>();
                }
            }

            return lista;
        }

        public List<ReporteVenta> ReporteVenta(DateTime FechaInicio, DateTime FechaFin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptVenta", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaVenta = dr["Fecha Venta"].ToString(),
                                NumeroDocumento = dr["Numero Documento"].ToString(),
                                TipoDocumento = dr["Tipo Documento"].ToString(),
                                NombreComercial = dr["Nombre Comercial"].ToString(),
                                Concentracion = dr["Concentracion"].ToString(),
                                NombreEmpleado = dr["Nombre Empleado"].ToString(),
                                CantidadUnidadesVendidas = dr["Cantidad Unidades Vendidas"].ToString(),
                                CantidadProductos = dr["Cantidad Productos"].ToString(),
                                TotalCosto = Convert.ToDecimal(dr["Total Venta"].ToString(), new CultureInfo("es-PE")).ToString("N", formato)
                            });
                        }

                    }

                }
                catch (Exception)
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;

        }


        public List<ReporteCompra> ReporteCompra(DateTime FechaInicio, DateTime FechaFin)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ReporteCompra", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["Fecha Compra"].ToString(),
                                NombreComercial = dr["Nombre Comercial"].ToString(),
                                Concentracion = dr["Concentracion"].ToString(),
                                NombreEmpleado = dr["Nombre Empleado"].ToString(),
                                TotalCompra = Convert.ToDecimal(dr["Total Compra"].ToString(), new CultureInfo("es-PE")).ToString("N", formato)
                            });
                        }

                    }

                }
                catch (Exception)
                {
                    lista = new List<ReporteCompra>();
                }
            }

            return lista;

        }

        public List<ReporteDevolucionCompra> ReporteDevolucionCompra(DateTime FechaInicio, DateTime FechaFin)
        {
            List<ReporteDevolucionCompra> lista = new List<ReporteDevolucionCompra>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptDevolucionCompra", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteDevolucionCompra()
                            {
                                FechaDevolucion = dr["Fecha Devolucion"].ToString(),
                                NombreEmpleado = dr["Empleado"].ToString(),
                                Codigo = dr["Codigo"].ToString(),
                                NombreComercial = dr["Producto"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                RazonSocial = dr["Proveedor"].ToString(),
                                Concepto = dr["Concepto"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception)
                {
                    lista = new List<ReporteDevolucionCompra>();
                }
            }

            return lista;
        }

        public List<ReporteDevolucionVenta> ReporteDevolucionVenta(DateTime FechaInicio, DateTime FechaFin)
        {
            List<ReporteDevolucionVenta> lista = new List<ReporteDevolucionVenta>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptDevolucionVenta", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteDevolucionVenta()
                            {
                                FechaDevolucion = dr["Fecha Devolucion"].ToString(),
                                NombreEmpleado = dr["Empleado"].ToString(),
                                Codigo = dr["Codigo"].ToString(),
                                NombreComercial = dr["Producto"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                NombreCliente = dr["Cliente"].ToString(),
                                Concepto = dr["Concepto"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception)
                {
                    lista = new List<ReporteDevolucionVenta>();
                }
            }

            return lista;
        }

        public List<RptProductoVenc> ReporteProductoVencer()
        {
            List<RptProductoVenc> rptListaProductsVen = new List<RptProductoVenc>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptProductoProximosVencer", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProductsVen.Add(new RptProductoVenc()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                            NombreGenerico =  dr["NombreGenerico"].ToString(),
                            IdDetalleFarmaco = Convert.ToInt32(dr["IdDetalleFarmaco"].ToString()),
                            NombreComercial = dr["NombreComercial"].ToString(),
                            FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"].ToString())
                        });
                    }
                    dr.Close();

                     return rptListaProductsVen;

                }
                catch (Exception)
                {
                    rptListaProductsVen = null;
                    return rptListaProductsVen;
                }
            }
        }
    }
}
