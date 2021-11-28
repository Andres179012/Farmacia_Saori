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
    public class CD_FacturaCompra
    {
        public static CD_FacturaCompra _instancia = null;

        private CD_FacturaCompra()
        {

        }

        public static CD_FacturaCompra Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_FacturaCompra();
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
                    SqlCommand cmd = new SqlCommand("usp_RegistrarCompra", oConexion);
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

        public Factura_Compra ObtenerDetalleCompra(int IdCompra)
        {
            Factura_Compra rptDetalleCompra = new Factura_Compra();
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
                                                    select new Factura_Compra()
                                                    {
                                                        Fecha_Compra = dato.Element("Fecha_Compra").Value,
                                                        Sub_Total = Convert.ToDecimal(dato.Element("Sub_Total").Value, new CultureInfo("es-PE")),
                                                        Descuento = Convert.ToDecimal(dato.Element("Descuento").Value, new CultureInfo("es-PE")),
                                                        IVA = Convert.ToDecimal(dato.Element("IVA").Value, new CultureInfo("es-PE")),
                                                        Total = Convert.ToDecimal(dato.Element("TotalCosto").Value, new CultureInfo("es-PE")),
                                                    }).FirstOrDefault();
                                rptDetalleCompra.Objproveedor = (from dato in doc.Element("DETALLE_COMPRA").Elements("DETALLE_PROVEEDOR")
                                                               select new Proveedores()
                                                               {
                                                                   Proveedor = dato.Element("Proveedor").Value,
                                                                   Direccion = dato.Element("Direccion").Value,
                                                                   Telefono = dato.Element("Telefono").Value,
                                                               }).FirstOrDefault();
                                rptDetalleCompra.Objlaboratorio = (from dato in doc.Element("DETALLE_COMPRA").Elements("DETALLE_LABORATORIO")
                                                            select new Laboratorios()
                                                            {
                                                                Nombre_Laboratorio = dato.Element("Nombre_Laboratorio").Value,
                                                            }).FirstOrDefault();
                                rptDetalleCompra.oListaDetalleCompra = (from producto in doc.Element("DETALLE_COMPRA").Element("DETALLE_PRODUCTO").Elements("PRODUCTO")
                                                                        select new Detalle_Compra()
                                                                        {
                                                                            Cantidad_Compra = int.Parse(producto.Element("Cantidad").Value),
                                                                            Precio_Compra = int.Parse(producto.Element("Precio_Compra").Value),
                                                                            Lote = Convert.ToInt32(producto.Element("Lote").Value, new CultureInfo("es-PE")),
                                                                            Unitario = Convert.ToInt32(producto.Element("Unitario").Value, new CultureInfo("es-PE")),
                                                                            objfarmaco = new Farmacos() { Nombre_Generico = producto.Element("Nombre_Generico").Value },
                                                                            objformaf = new Forma_Farmaceuticas() { Forma_Farmaceutica = producto.Element("Forma_Faumaceutica").Value },
                                                                            objformap = new Forma_Pagos() { Forma_Pago = producto.Element("Forma_Pago").Value }

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

        public List<Factura_Compra> ObtenerFacturaCompra()
        {
            List<Factura_Compra> rptListaFacturaCompra = new List<Factura_Compra>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerListaCompra", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFacturaCompra.Add(new Factura_Compra()
                        {
                            Id_FacturaCompra = Convert.ToInt32(dr["Id_FacturaCompra"].ToString()),
                            Id_Laboratorio = Convert.ToInt32(dr["Id_Laboratorio"].ToString()),
                            Objlaboratorio = new Laboratorios() { Nombre_Laboratorio = dr["Nombre_Laboratorio"].ToString() },
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"].ToString()),
                            Objproveedor = new Proveedores() { Proveedor = dr["Proveedor"].ToString() },
                            Fecha_Compra = (dr["Fecha_Compra"].ToString()),
                            Sub_Total = Convert.ToDecimal(dr["Sub_Total"].ToString()),
                            Descuento = Convert.ToDecimal(dr["Descuento"].ToString()),
                            IVA = Convert.ToDecimal(dr["IVA"].ToString()),
                            Total = Convert.ToDecimal(dr["Total"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaFacturaCompra;

                }
                catch (Exception)
                {
                    rptListaFacturaCompra = null;
                    return rptListaFacturaCompra;
                }
            }
        }
    }
}
