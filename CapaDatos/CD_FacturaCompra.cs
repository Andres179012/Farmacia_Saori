using CapaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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

        public List<Factura_Compra> ObtenerFacturaCompra()
        {
            List<Factura_Compra> rptListaFacturaCompra = new List<Factura_Compra>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_FacturaCompraObtener", oConexion);
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
                            Objproveedores = new Proveedores() { Proveedor = dr["Proveedor"].ToString() },
                            Fecha_Compra = Convert.ToDateTime(dr["Fecha_Compra"].ToString()),
                            Sub_Total = Convert.ToDecimal(dr["Sub_Total"].ToString()),
                            Descuento = Convert.ToDecimal(dr["Descuento"].ToString()),
                            IVA = Convert.ToDecimal(dr["IVA"].ToString()),
                            Total = Convert.ToDecimal(dr["Total"].ToString()),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
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


        public List<Detalle_Compra> ObtenerDetalleCompra()
        {
            List<Detalle_Compra> rptListaDetalleCompra = new List<Detalle_Compra>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_FacturaCompraObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaDetalleCompra.Add(new Detalle_Compra()
                        {
                            Id_DetalleCompra = Convert.ToInt32(dr["Id_DetalleCompra"].ToString()),
                            Id_Farmaco = Convert.ToInt32(dr["Id_Farmaco"].ToString()),
                            Objfarmacos = new Farmacos() { Nombre_Generico = dr["Nombre_Generico"].ToString() },
                            Id_FormaFarmaceutica = Convert.ToInt32(dr["Id_FormaFarmaceutica"].ToString()),
                            Objformafarmaceutica = new Forma_Farmaceuticas() { Forma_Faumaceutica = dr["Forma_Faumaceutica"].ToString() },
                            Id_FormaPago = Convert.ToInt32(dr["Id_FormaPago"].ToString()),
                            Objformapago = new Forma_Pagos() { Forma_Pago = dr["Forma_Pago"].ToString() },
                            Cantidad_Compra = Convert.ToInt32(dr["Cantidad_Compra"].ToString()),
                            Precio_Compra = Convert.ToInt32(dr["Precio_Compra"].ToString()),
                            Lote = Convert.ToInt32(dr["Lote"].ToString()),
                            Unitario = Convert.ToInt32(dr["Unitario"].ToString()),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())

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

        //public bool RegistrarProducto(Farmacos oProducto)
        //{
        //    bool respuesta = true;
        //    using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("USP_FarmacoRegistrar", oConexion);
        //            cmd.Parameters.AddWithValue("NombreGenerico", oProducto.Nombre_Generico);
        //            cmd.Parameters.AddWithValue("IdCategoria", oProducto.Id_Categoria);
        //            cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
        //            cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oConexion.Open();

        //            cmd.ExecuteNonQuery();

        //            respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

        //        }
        //        catch (Exception)
        //        {
        //            respuesta = false;
        //        }
        //    }
        //    return respuesta;
        //}

        //public bool ModificarProducto(Farmacos oProducto)
        //{
        //    bool respuesta = true;
        //    using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("USP_FarmacoModificar", oConexion);
        //            cmd.Parameters.AddWithValue("IdFarmaco", oProducto.Id_Farmaco);
        //            cmd.Parameters.AddWithValue("NombreGenerico", oProducto.Nombre_Generico);
        //            cmd.Parameters.AddWithValue("IdCategoria", oProducto.Id_Categoria);
        //            cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
        //            cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oConexion.Open();

        //            cmd.ExecuteNonQuery();

        //            respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

        //        }
        //        catch (Exception)
        //        {
        //            respuesta = false;
        //        }

        //    }

        //    return respuesta;

        //}

        //public bool EliminarProducto(int IdFarmaco)
        //{
        //    bool respuesta = true;
        //    using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("USP_FarmacoEliminar", oConexion);
        //            cmd.Parameters.AddWithValue("IdFarmaco", IdFarmaco);
        //            cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oConexion.Open();

        //            cmd.ExecuteNonQuery();

        //            respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

        //        }
        //        catch (Exception)
        //        {
        //            respuesta = false;
        //        }

        //    }

        //    return respuesta;

        //}
    }
}
