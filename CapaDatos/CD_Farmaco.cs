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
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"].ToString()),
                            Objcategoria = new Categorias() { Categoria = dr["Categoria"].ToString() },
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
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
                    cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
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
                    cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
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
