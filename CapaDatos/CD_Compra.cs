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
    public class CD_Compra
    {
        public static CD_Compra _instancia = null;

        private CD_Compra()
        {

        }

        public static CD_Compra Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Compra();
                }
                return _instancia;
            }
        }

        public bool RegistrarCompra(string Detalle)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarFCompra", oConexion);
                    cmd.Parameters.Add("Detalle", SqlDbType.Xml).Value = Detalle;
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


        public Compra ObtenerDetalleCompra(int IdCompra)
        {
            Compra rptDetalleCompra = new Compra();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerDetalleCompra", oConexion);
                cmd.Parameters.AddWithValue("@IdCompra", IdCompra);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("DETALLE_COMPRA") != null)
                            {
                                rptDetalleCompra = (from dato in doc.Elements("DETALLE_COMPRA")
                                                    select new Compra()
                                                    {
                                                        Codigo = dato.Element("Codigo").Value,
                                                        TotalCosto = Convert.ToDecimal(dato.Element("TotalCosto").Value, new CultureInfo("es-PE")),
                                                        FechaRegistro = dato.Element("FechaRegistro").Value
                                                    }).FirstOrDefault();
                                rptDetalleCompra.oUsuario = (from dato in doc.Element("DETALLE_COMPRA").Elements("DETALLE_USUARIO")
                                                            select new Usuario()
                                                            {
                                                                Nombres = dato.Element("Nombres").Value,
                                                                Apellidos = dato.Element("Apellidos").Value,
                                                            }).FirstOrDefault();
                                rptDetalleCompra.oProveedor = (from dato in doc.Element("DETALLE_COMPRA").Elements("DETALLE_PROVEEDOR")
                                                               select new Proveedor()
                                                               {
                                                                   Ruc = dato.Element("RUC").Value,
                                                                   RazonSocial = dato.Element("RazonSocial").Value,
                                                               }).FirstOrDefault();
                                //rptDetalleCompra.oDetalleFarmaco = (from dato in doc.Element("DETALLE_COMPRA").Elements("DETALLE_FARMACO")
                                //                                    select new DetalleFarmaco()
                                //                                    {
                                //                                        NombreComercial = dato.Element("NombreComercial").Value,
                                //                                        Concentracion = dato.Element("Concentracion").Value,
                                //                                        NumeroLote = dato.Element("NumeroLote").Value,
                                //                                    }).FirstOrDefault();
                                rptDetalleCompra.oListaDetalleCompra = (from producto in doc.Element("DETALLE_COMPRA").Element("DETALLE_PRODUCTO").Elements("PRODUCTO")
                                                                        select new DetalleCompra()
                                                                        {
                                                                            Cantidad = int.Parse(producto.Element("Cantidad").Value),
                                                                            oProducto = new Producto() { NombreGenerico = producto.Element("NombreProducto").Value },
                                                                            oDetalleFarmaco=new DetalleFarmaco() { NombreComercial = producto.Element("NombreComercial").Value },
                                                                            PrecioCompra = Convert.ToDecimal(producto.Element("PrecioCompra").Value, new CultureInfo("es-PE")),
                                                                            TotalCosto = Convert.ToDecimal(producto.Element("TotalCosto").Value, new CultureInfo("es-PE"))
                                                                        }).ToList();
                            }
                            else
                            {
                                rptDetalleCompra = null;
                            }
                        }

                        dr.Close();

                    }

                    return rptDetalleCompra;
                }
                catch (Exception)
                {
                    rptDetalleCompra = null;
                    return rptDetalleCompra;
                }
            }
        }


        public List<LaboratorioProveedor> ObtenerLaboratorioProveedor()
        {
            List<LaboratorioProveedor> rptListaLaboratorioProveedor = new List<LaboratorioProveedor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerLaboratorioProveedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaLaboratorioProveedor.Add(new LaboratorioProveedor()
                        {
                            IdLaboratorioProveedor = Convert.ToInt32(dr["IdLaboratorioProveedor"].ToString()),
                            oLaboratorio = new Laboratorio()
                            {
                                IdLaboratorio = Convert.ToInt32(dr["IdLaboratorio"].ToString()),
                                NombreLaboratorio = dr["NombreLaboratorio"].ToString(),
                            },
                            oProveedor = new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Ruc = dr["Ruc"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            },
                        });
                    }
                    dr.Close();

                    return rptListaLaboratorioProveedor;

                }
                catch (Exception)
                {
                    rptListaLaboratorioProveedor = null;
                    return rptListaLaboratorioProveedor;
                }
            }
        }


        public double ObtenerTotalCompras()
        {
            double total = 0.00;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_TotalCompras", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        total = Convert.ToDouble(dr["TOTALCOMPRAS"].ToString());
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

        public double ObtenerTotalVentas()
        {
            double total = 0.00;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_TotalVentas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        total = Convert.ToDouble(dr["IMPORTETOTAL"].ToString());
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

        public List<Compra> ObtenerListaCompra(DateTime FechaInicio, DateTime FechaFin)
        {
            List<Compra> rptListaCompra = new List<Compra>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerListaCompra", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCompra.Add(new Compra()
                        {
                            IdCompra = Convert.ToInt32(dr["IdCompra"].ToString()),
                            NumeroCompra = dr["NumeroCompra"].ToString(),
                            oUsuario = new Usuario() { Nombres = dr["Nombres"].ToString() },
                            oProveedor = new Proveedor() { RazonSocial = dr["RazonSocial"].ToString() },
                            //oDetalleFarmaco = new DetalleFarmaco() { NombreComercial = dr["NombreComercial"].ToString() },
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()).ToString("dd/MM/yyyy"),
                            VFechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                            TotalCosto = Convert.ToDecimal(dr["TotalCosto"].ToString(), new CultureInfo("es-PE"))
                        });
                    }
                    dr.Close();

                    return rptListaCompra;

                }
                catch (Exception)
                {
                    rptListaCompra = null;
                    return rptListaCompra;
                }
            }
        }
    }


}
