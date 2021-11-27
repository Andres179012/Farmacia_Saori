using CapaModelo;
using System;
using System.Collections.Generic;
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
