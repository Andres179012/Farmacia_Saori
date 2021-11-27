using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Farmaco
    {
        public static CD_Farmaco _instancia = null;

        private CD_Farmaco()
        {

        }

        public static CD_Farmaco Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Farmaco();
                }
                return _instancia;
            }
        }

        public List<Farmacos> ObtenerProducto()
        {
            List<Farmacos> rptListaFarmaco = new List<Farmacos>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_FarmacoObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFarmaco.Add(new Farmacos()
                        {
                            Id_Farmaco = Convert.ToInt32(dr["Id_Farmaco"].ToString()),
                            Nombre_Generico = dr["Nombre_Generico"].ToString(),
                            Nombre_Comercial = dr["Nombre_Comercial"].ToString(),
                            Id_Laboratorio = Convert.ToInt32(dr["Id_Laboratorio"].ToString()),
                            Objlaboratorio = new Laboratorios() { Nombre_Laboratorio = dr["Nombre_Laboratorio"].ToString() },
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"].ToString()),
                            Objproveedor = new Proveedores() { Proveedor = dr["Proveedor"].ToString() },
                            Concentracion = dr["Concentracion"].ToString(),
                            Fecha_Vencimiento = Convert.ToDateTime(dr["Fecha_Vencimiento"].ToString()),
                            Stock = Convert.ToInt32(dr["Stock"].ToString()),
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"].ToString()),
                            Objcategoria = new Categorias() { Categoria = dr["Categoria"].ToString() },
                            Id_FormaFarmaceutica = Convert.ToInt32(dr["Id_FormaFarmaceutica"].ToString()),
                            Objformafarmaceutica = new Forma_Farmaceuticas() { Forma_Faumaceutica = dr["Forma_Faumaceutica"].ToString() },
                            Id_ViaAdministracion = Convert.ToInt32(dr["Id_ViaAdministracion"].ToString()),
                            Objviadministacion = new ViaAdministracion() { Via_Administracion = dr["Via_Administracion"].ToString() },
                            Precio_Venta = Convert.ToInt32(dr["Precio_Venta"].ToString()),
                            Numero_Lote = Convert.ToInt32(dr["Numero_Lote"].ToString()),
                            Prescripcion_Medica = Convert.ToBoolean(dr["Prescripcion_Medica"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Stado = Convert.ToBoolean(dr["Stado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaFarmaco;

                }
                catch (Exception)
                {
                    rptListaFarmaco = null;
                    return rptListaFarmaco;
                }
            }
        }

        public bool RegistrarProducto(Farmacos oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FarmacoRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("NombreGenerico", oProducto.Nombre_Generico);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.Id_Categoria);
                    cmd.Parameters.AddWithValue("Estado", oProducto.Stado);
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

        public bool ModificarProducto(Farmacos oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FarmacoModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdFarmaco", oProducto.Id_Farmaco);
                    cmd.Parameters.AddWithValue("NombreGenerico", oProducto.Nombre_Generico);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.Id_Categoria);
                    cmd.Parameters.AddWithValue("Stado", oProducto.Stado);
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

        public bool EliminarProducto(int IdFarmaco)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FarmacoEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdFarmaco", IdFarmaco);
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
