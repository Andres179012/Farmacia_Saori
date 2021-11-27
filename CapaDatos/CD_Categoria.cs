using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;


namespace CapaDatos
{
    public class CD_Categoria
    {
        public static CD_Categoria _instancia = null;

        private CD_Categoria()
        {

        }

        public static CD_Categoria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Categoria();
                }
                return _instancia;
            }
        }

        public List<Categorias> ObtenerCategoria()
        {
            var rptListaCategoria = new List<Categorias>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_CategoriaObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categorias()
                        {
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"].ToString()),
                            Categoria = dr["Categoria"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaCategoria;

                }
                catch 
                {
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }

        public bool RegistrarCategoria(Categorias oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoriaRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("Categoria", oCategoria.Categoria);cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch 
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool ModificarCategoria(Categorias oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoriaModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.Id_Categoria);
                    cmd.Parameters.AddWithValue("Categoria", oCategoria.Categoria);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch 
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool EliminarCategoria(int IdCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoriaEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}
