using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_FacturaVenta
    {
        public static CD_FacturaVenta _instancia = null;

        private CD_FacturaVenta()
        {

        }

        public static CD_FacturaVenta Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_FacturaVenta();
                }
                return _instancia;
            }
        }

        public bool RegistraVenta(string Detalle)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oConexion);
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

        public Factura_Venta ObtenerDetalleVenta(int IdVenta)
        {
            Factura_Venta rptDetalleVenta = new Factura_Venta();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerDetalleVenta", oConexion);
                cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("DETALLE_VENTA") != null)
                            {
                                rptDetalleVenta = (from dato in doc.Elements("DETALLE_VENTA")
                                                   select new Factura_Venta()
                                                   {
                                                       Fecha_Venta = dato.Element("Fecha_Venta").Value,
                                                       Sub_Total = Convert.ToDecimal(dato.Element("Sub_Total").Value, new CultureInfo("es-PE")),
                                                       Descuento = Convert.ToDecimal(dato.Element("Descuento").Value, new CultureInfo("es-PE")),
                                                       IVA = Convert.ToDecimal(dato.Element("IVA").Value, new CultureInfo("es-PE")),
                                                       Total = Convert.ToDecimal(dato.Element("Total").Value, new CultureInfo("es-PE")),
                                                   }).FirstOrDefault();
                                rptDetalleVenta.Objusuario = (from dato in doc.Element("DETALLE_VENTA").Elements("DETALLE_USUARIO")
                                                              select new Usuarios()
                                                              {
                                                                  Usuario = dato.Element("Usuario").Value
                                                              }).FirstOrDefault();
                                rptDetalleVenta.Objcliente = (from dato in doc.Element("DETALLE_VENTA").Elements("DETALLE_CLIENTE")
                                                              select new Clientes()
                                                              {
                                                                  Nombre_Cliente = dato.Element("Nombre_Cliente").Value,
                                                              }).FirstOrDefault();
                                rptDetalleVenta.oListaDetalleVenta = (from Farmacos in doc.Element("DETALLE_VENTA").Element("DETALLE_PRODUCTO").Elements("PRODUCTO")
                                                                      select new Detalle_Venta()
                                                                      {
                                                                          Cantidad_Venta = int.Parse(Farmacos.Element("Cantidad").Value),
                                                                          Precio_Venta = int.Parse(Farmacos.Element("Precio_Venta").Value),
                                                                          objfarmaco = new Farmacos() { Nombre_Generico = Farmacos.Element("Nombre_Generico").Value },
                                                                          objformapago = new Forma_Pagos() { Forma_Pago = Farmacos.Element("Forma_Pago").Value }

                                                                      }).ToList();
                            }
                            else
                            {
                                rptDetalleVenta = null;
                            }
                        }

                        dr.Close();

                    }

                    return rptDetalleVenta;
                }
                catch (Exception)
                {
                    rptDetalleVenta = null;
                    return rptDetalleVenta;
                }
            }
        }

        public List<Factura_Venta> ObtenerFacturaVenta()
        {
            List<Factura_Venta> rptListaFacturaVenta = new List<Factura_Venta>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerListaVenta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFacturaVenta.Add(new Factura_Venta()
                        {
                            Id_FacturaVenta = Convert.ToInt32(dr["Id_FacturaVenta"].ToString()),
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"].ToString()),
                            Objusuario = new Usuarios() { Usuario = dr["Usuario"].ToString() },
                            Id_Cliente = Convert.ToInt32(dr["Id_Cliente"].ToString()),
                            Objcliente = new Clientes() { Nombre_Cliente = dr["Nombre_Cliente"].ToString() },
                            Fecha_Venta = (dr["Fecha_Venta"].ToString()),
                            Sub_Total = Convert.ToDecimal(dr["Sub_Total"].ToString()),
                            Descuento = Convert.ToDecimal(dr["Descuento"].ToString()),
                            IVA = Convert.ToDecimal(dr["IVA"].ToString()),
                            Total = Convert.ToDecimal(dr["Total"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaFacturaVenta;

                }
                catch (Exception)
                {
                    rptListaFacturaVenta = null;
                    return rptListaFacturaVenta;
                }
            }
        }
    }
}
